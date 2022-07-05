@echo off

echo =======================================================================
echo Cosmos.Standard (Without Build)
echo =======================================================================

::go to parent folder
cd ..

::create nuget_packages
if not exist nuget_packages (
    md nuget_packages
    echo Created nuget_packages folder.
)

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do (
::    dotnet nuget push "%%s" -s "Nightly" --skip-duplicate --no-symbols
    dotnet nuget push "%%s" -s "Nightly" --skip-duplicate
    echo.
)

::get back to build folder
cd scripts