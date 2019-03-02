@echo off
if not exist nuget_pub (
    md nuget_pub
)

for /R "nuget_pub" %%s in (*) do (
    del %%s
)

dotnet pack src/Cosmos.Serialization.Xml -c Release -o ../../nuget_pub
dotnet pack src/Cosmos.Serialization.Jil -c Release -o ../../nuget_pub
dotnet pack src/Cosmos.Serialization.Lit -c Release -o ../../nuget_pub
dotnet pack src/Cosmos.Serialization.Json -c Release -o ../../nuget_pub
dotnet pack src/Cosmos.Serialization.Swifter -c Release -o ../../nuget_pub
dotnet pack src/Cosmos.Serialization.Protobuf -c Release -o ../../nuget_pub
dotnet pack src/Cosmos.Serialization.MessagePack -c Release -o ../../nuget_pub

for /R "nuget_pub" %%s in (*symbols.nupkg) do (
    del %%s
)

echo.
echo.

set /p key=input key:
set source=https://api.nuget.org/v3/index.json

for /R "nuget_pub" %%s in (*.nupkg) do ( 
    call nuget push %%s %key% -Source %source%	
	echo.
)

pause