FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY out/ .
ENTRYPOINT ["dotnet", "Account.dll"]
