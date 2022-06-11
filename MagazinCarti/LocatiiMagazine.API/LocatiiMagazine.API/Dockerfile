FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["/LocatiiMagazine.API.csproj", "LocatiiMagazine.API/"]

RUN dotnet restore "LocatiiMagazine.API/LocatiiMagazine.API.csproj"

WORKDIR "/src/LocatiiMagazine.API"
COPY . .
WORKDIR "/src/LocatiiMagazine.API"
RUN dotnet build "LocatiiMagazine.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocatiiMagazine.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocatiiMagazine.API.dll"]