#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GeoLocAPI/GeoLocAPI.csproj", "GeoLocAPI/"]
RUN dotnet restore "GeoLocAPI/GeoLocAPI.csproj"
COPY . .
WORKDIR "/src/GeoLocAPI"
RUN dotnet build "GeoLocAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeoLocAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeoLocAPI.dll"]