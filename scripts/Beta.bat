@echo off

echo =======================================================================
echo Cosmos.Standard
echo =======================================================================

::go to parent folder
cd ..

::create nuget_packages
if not exist nuget_packages (
    md nuget_packages
    echo Created nuget_packages folder.
)

::clear nuget_packages
for /R "nuget_packages" %%s in (*) do (
    del "%%s"
)
echo Cleaned up all nuget packages.
echo.

::start to package all projects

::cosmos-core
dotnet pack src/Cosmos.Abstractions -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Core         -c Release -o nuget_packages --no-restore

::cosmos-extensions
dotnet pack src/Cosmos.Extensions.Asyncs      -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.DateTime    -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Conversions -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Collections -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Disposables -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Optionals   -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Reflection  -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Enums       -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Guard       -c Release -o nuget_packages --no-restore

::cosmos-standard
dotnet pack src/Cosmos.Standard -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Beta"  --skip-duplicate --no-symbols
	echo.
)

::get back to build folder
cd scripts