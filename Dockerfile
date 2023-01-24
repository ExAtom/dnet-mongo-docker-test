FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY . .
WORKDIR /
RUN dotnet build ./src/Test.csproj -o build -c Release
CMD ["dotnet", "build/Test.dll"]
