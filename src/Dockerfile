FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY AuthenticationService.sln ./
COPY ["./AuthenticationService.Core/*.csproj", "AuthenticationService.Core/"]
COPY ["./AuthenticationService.DAL/*.csproj", "AuthenticationService.DAL/"]
COPY ["./AuthenticationService.BL/*.csproj", "AuthenticationService.BL/"]
COPY ["./AuthenticationService.API/*.csproj", "AuthenticationService.API/"]

RUN dotnet restore "./AuthenticationService.API/AuthenticationService.API.csproj"
COPY . .

WORKDIR /src/AuthenticationService.API

RUN dotnet build "AuthenticationService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuthenticationService.API.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationService.API.dll"]