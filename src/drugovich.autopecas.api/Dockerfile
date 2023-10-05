FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/drugovich.autopecas.api/drugovich.autopecas.api.csproj", "src/drugovich.autopecas.api/"]
COPY ["src/drugovich.autopecas.core/drugovich.autopecas.core.csproj", "src/drugovich.autopecas.core/"]
COPY ["src/drugovich.autopecas.infrastructure/drugovich.autopecas.infrastructure.csproj", "src/drugovich.autopecas.infrastructure/"]
COPY ["src/drugovich.autopecas.application/drugovich.autopecas.application.csproj", "src/drugovich.autopecas.application/"]
RUN dotnet restore "src/drugovich.autopecas.api/drugovich.autopecas.api.csproj"
COPY . .
WORKDIR "/src/src/drugovich.autopecas.api"
RUN dotnet build "drugovich.autopecas.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "drugovich.autopecas.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "drugovich.autopecas.api.dll"]
