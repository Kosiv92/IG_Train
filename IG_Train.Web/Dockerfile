#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IG_Train.Web/IG_Train.Web.csproj", "IG_Train.Web/"]
COPY ["IG_Train.Contracts/IG_Train.Contracts.csproj", "IG_Train.Contracts/"]
COPY ["IG_Train.Domain/IG_Train.Domain.csproj", "IG_Train.Domain/"]
COPY ["IG_Train.Infrastructure/IG_Train.Infrastructure.csproj", "IG_Train.Infrastructure/"]
RUN dotnet restore "./IG_Train.Web/IG_Train.Web.csproj"
COPY . .
WORKDIR "/src/IG_Train.Web"
RUN dotnet build "./IG_Train.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./IG_Train.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IG_Train.Web.dll"]