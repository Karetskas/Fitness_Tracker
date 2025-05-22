# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Fitness_tracker.Api/Fitness_tracker.Api.csproj", "Fitness_tracker.Api/"]
COPY ["Fitness_tracker.Application/Fitness_tracker.Application.csproj", "Fitness_tracker.Application/"]
COPY ["Fitness_tracker.Domain/Fitness_tracker.Domain.csproj", "Fitness_tracker.Domain/"]
COPY ["Fitness_tracker.Infrastructure/Fitness_tracker.Infrastructure.csproj", "Fitness_tracker.Infrastructure/"]
RUN dotnet restore "./Fitness_tracker.Api/Fitness_tracker.Api.csproj"
COPY . .
WORKDIR "/src/Fitness_tracker.Api"
RUN dotnet build "./Fitness_tracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Fitness_tracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./Fitness_tracker.Api/certs/ /app/certs/
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certs/aspnetsert.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=FirstFranklin
ENTRYPOINT ["dotnet", "Fitness_tracker.Api.dll"]