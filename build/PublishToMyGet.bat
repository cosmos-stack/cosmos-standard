@echo off

::go to parent folder
cd ..

::create nuget_packages
if not exist nuget_packages (
    md nuget_packages
    echo Created nuget_packages folder.
)

::clear nuget_packages
for /R "nuget_packages" %%s in (*symbols.nupkg) do (
    del %%s
)
echo Cleaned up all nuget packages.
echo.

::get nuget key
set /p key=input key:

::start to package all projects

::cosmos-core
dotnet pack src/Cosmos.Abstractions -c Release -o nuget_packages
dotnet pack src/Cosmos -c Release -o nuget_packages

::cosmos-extensions
dotnet pack src/Cosmos.Extensions.Asyncs -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.DateTime -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.Conversions -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.Collections -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.Disposables -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.Optionals -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.Preconditions -c Release -o nuget_packages
dotnet pack src/Cosmos.Extensions.Reflection -c Release -o nuget_packages

::cosmos-standard
dotnet pack src/Cosmos.Standard -c Release -o nuget_packages

echo.
echo.

::set target nuget server url
set source=https://www.myget.org/F/alexinea/api/v2/package

::push nuget packages to server
for /R "nuget_packages" %%s in (*.nupkg) do ( 	
    dotnet nuget push "%%s" -k %key% -s %source%
	echo.
)

::get back to build folder
cd build

pause