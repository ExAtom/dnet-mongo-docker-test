FROM --platform=linux/arm64v8 mcr.microsoft.com/dotnet/sdk:6.0.405-focal-arm64v8
COPY . .
WORKDIR /
RUN dotnet build ./src/Test.csproj -o build -c Release
CMD ["dotnet", "build/Test.dll"]
