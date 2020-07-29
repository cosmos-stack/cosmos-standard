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
dotnet pack src/Cosmos.Abstractions/Cosmos.Abstractions._build.csproj                         -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos/Cosmos._build.csproj                                                   -c Release -o nuget_packages --no-restore

::cosmos-extensions
dotnet pack src/Cosmos.Extensions.Asyncs/Cosmos.Extensions.Asyncs._build.csproj               -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.DateTime/Cosmos.Extensions.DateTime._build.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Conversions/Cosmos.Extensions.Conversions._build.csproj     -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Collections/Cosmos.Extensions.Collections._build.csproj     -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Disposables/Cosmos.Extensions.Disposables._build.csproj     -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Optionals/Cosmos.Extensions.Optionals._build.csproj         -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Reflection/Cosmos.Extensions.Reflection._build.csproj       -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Preconditions/Cosmos.Extensions.Preconditions._build.csproj -c Release -o nuget_packages --no-restore

::cosmos-standard
dotnet pack src/Cosmos.Standard/Cosmos.Standard._build.csproj                                 -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Release" --skip-duplicate
	echo.
)

::get back to build folder
cd build