#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MassTransit Quick Start/Habr Simple Fanout/Habr Simple Fanout Web Api Producer/Habr Simple Fanout Web Api Producer.csproj", "MassTransit Quick Start/Habr Simple Fanout/Habr Simple Fanout Web Api Producer/"]
RUN dotnet restore "./MassTransit Quick Start/Habr Simple Fanout/Habr Simple Fanout Web Api Producer/Habr Simple Fanout Web Api Producer.csproj"
COPY . .
WORKDIR "/src/MassTransit Quick Start/Habr Simple Fanout/Habr Simple Fanout Web Api Producer"
RUN dotnet build "./Habr Simple Fanout Web Api Producer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Habr Simple Fanout Web Api Producer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Habr Simple Fanout Web Api Producer.dll"]