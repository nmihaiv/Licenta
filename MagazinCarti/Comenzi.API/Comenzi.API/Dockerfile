FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://*:80;
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["/Comenzi.API.csproj", "Comenzi.API/"]

RUN dotnet restore "Comenzi.API/Comenzi.API.csproj"
WORKDIR "/src/Comenzi.API"
COPY . .
WORKDIR "/src/Comenzi.API"
RUN dotnet build "Comenzi.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Comenzi.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Comenzi.API.dll"]