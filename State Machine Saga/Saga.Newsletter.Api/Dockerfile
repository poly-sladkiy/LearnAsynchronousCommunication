FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["State Machine Saga/Saga.Newsletter.Api/Saga.Newsletter.Api/Saga.Newsletter.Api.csproj", "State Machine Saga/Saga.Newsletter.Api/Saga.Newsletter.Api/"]
RUN dotnet restore "State Machine Saga/Saga.Newsletter.Api/Saga.Newsletter.Api/Saga.Newsletter.Api.csproj"
COPY . .
WORKDIR "/src/State Machine Saga/Saga.Newsletter.Api/Saga.Newsletter.Api"
RUN dotnet build "Saga.Newsletter.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Saga.Newsletter.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Saga.Newsletter.Api.dll"]
