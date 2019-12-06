FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["LocationHunter.WebApi/LocationHunter.WebApi.csproj", "LocationHunter.WebApi/"]
RUN dotnet restore "LocationHunter.WebApi/LocationHunter.WebApi.csproj"
COPY . .
WORKDIR "/src/LocationHunter.WebApi"
RUN dotnet build "LocationHunter.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocationHunter.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocationHunter.WebApi.dll"]