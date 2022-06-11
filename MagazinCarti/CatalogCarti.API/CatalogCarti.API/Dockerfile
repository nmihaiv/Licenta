FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/CatalogCarti.API.csproj", "CatalogCarti.API/"]

RUN dotnet restore "CatalogCarti.API/CatalogCarti.API.csproj"
WORKDIR "/src/CatalogCarti.API"
COPY . .
WORKDIR "/src/CatalogCarti.API"
RUN dotnet build "CatalogCarti.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CatalogCarti.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CatalogCarti.API.dll"]