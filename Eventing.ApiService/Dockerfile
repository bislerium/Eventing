FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Eventing.ApiService/Eventing.ApiService.csproj", "Eventing.ApiService/"]
COPY ["Eventing.Data/Eventing.Data.csproj", "Eventing.Data/"]
COPY ["Eventing.ServiceDefaults/Eventing.ServiceDefaults.csproj", "Eventing.ServiceDefaults/"]
RUN dotnet restore "Eventing.ApiService/Eventing.ApiService.csproj"
COPY . .
WORKDIR "/src/Eventing.ApiService"
RUN dotnet build "./Eventing.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Eventing.ApiService.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Eventing.ApiService.dll"]
