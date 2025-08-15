FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Eventing.Data.Migrator/Eventing.Data.Migrator.csproj", "Eventing.Data.Migrator/"]
RUN dotnet restore "Eventing.Data.Migrator/Eventing.Data.Migrator.csproj"
COPY . .
WORKDIR "/src/Eventing.Data.Migrator"
RUN dotnet build "./Eventing.Data.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Eventing.Data.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eventing.Data.Migrator.dll"]
