@echo off

echo =======================================================================
echo CosmosStack.Standard
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
dotnet pack src/CosmosStack.Abstractions -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack              -c Release -o nuget_packages --no-restore

::cosmos-extensions
dotnet pack src/CosmosStack.Extensions.Asyncs      -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.DateTime    -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Conversions -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Collections -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Disposables -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Optionals   -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Reflection  -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Enums       -c Release -o nuget_packages --no-restore
dotnet pack src/CosmosStack.Extensions.Guard       -c Release -o nuget_packages --no-restore

::cosmos-standard
dotnet pack src/CosmosStack.Standard -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -s "Beta"  --skip-duplicate
	echo.
)

::get back to build folder
cd scripts