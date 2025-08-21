FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# STAGE 1: Restore and build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["matthewshan.MinecraftUtils.Api/matthewshan.MinecraftUtils.Api.csproj", "matthewshan.MinecraftUtils.Api/"]
RUN dotnet restore "matthewshan.MinecraftUtils.Api/matthewshan.MinecraftUtils.Api.csproj"
COPY . .

WORKDIR "/src/matthewshan.MinecraftUtils.Api"
RUN dotnet build "./matthewshan.MinecraftUtils.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# STAGE 2: Create the publish output
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./matthewshan.MinecraftUtils.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# STAGE 3: Create the final runner image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "matthewshan.MinecraftUtils.Api.dll"]