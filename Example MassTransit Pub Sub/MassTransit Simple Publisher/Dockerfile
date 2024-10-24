FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Example MassTransit Pub Sub/MassTransit Simple Publisher/MassTransit Simple Publisher.csproj", "Example MassTransit Pub Sub/MassTransit Simple Publisher/"]
RUN dotnet restore "Example MassTransit Pub Sub/MassTransit Simple Publisher/MassTransit Simple Publisher.csproj"
COPY . .
WORKDIR "/src/Example MassTransit Pub Sub/MassTransit Simple Publisher"
RUN dotnet build "MassTransit Simple Publisher.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MassTransit Simple Publisher.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MassTransit Simple Publisher.dll"]
