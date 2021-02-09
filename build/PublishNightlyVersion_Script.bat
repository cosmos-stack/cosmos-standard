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
dotnet pack src/Cosmos.Abstractions/Cosmos.Abstractions.csproj                               -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos/Cosmos.csproj                                                         -c Release -o nuget_packages --no-restore

::cosmos-extensions
dotnet pack src/Cosmos.Extensions.Asyncs/Cosmos.Extensions.Asyncs.csproj                     -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.DateTime/Cosmos.Extensions.DateTime.csproj                 -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Conversions/Cosmos.Extensions.Conversions.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Collections/Cosmos.Extensions.Collections.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Disposables/Cosmos.Extensions.Disposables.csproj           -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Optionals/Cosmos.Extensions.Optionals.csproj               -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Reflection/Cosmos.Extensions.Reflection.csproj             -c Release -o nuget_packages --no-restore
dotnet pack src/Cosmos.Extensions.Validation.Basic/Cosmos.Extensions.Validation.Basic.csproj -c Release -o nuget_packages --no-restore

::cosmos-standard
dotnet pack src/Cosmos.Standard/Cosmos.Standard.csproj                                       -c Release -o nuget_packages --no-restore

for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del "%%s"
)

echo.
echo.

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do (
    dotnet nuget push "%%s" -s "Nightly" --skip-duplicate
	echo.
)

::get back to build folder
cd build