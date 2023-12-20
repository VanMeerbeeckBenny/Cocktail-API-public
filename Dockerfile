#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
COPY "server.pfx" /app/
run chmod 700 /app/server.pfx

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY Pri.Cocktails.sln ./
COPY ["Pri.Cocktails.Core/Pri.Cocktails.Core.csproj", "Pri.Cocktails.Core/"]
COPY ["Pri.Cocktails.Infrastructure/Pri.Cocktails.Infrastructure.csproj", "Pri.Cocktails.Infrastructure/"]
COPY ["Pri.Cocktails.Api/Pri.Cocktails.Api.csproj", "Pri.Cocktails.Api/"]


RUN dotnet restore "Pri.Cocktails.Core/Pri.Cocktails.Core.csproj"
RUN dotnet restore "Pri.Cocktails.Infrastructure/Pri.Cocktails.Infrastructure.csproj"
RUN dotnet restore "Pri.Cocktails.Api/Pri.Cocktails.Api.csproj"

COPY . .
WORKDIR /src/Pri.Cocktails.Core
RUN dotnet build "Pri.Cocktails.Core.csproj" -c Release -o /app/build

WORKDIR /src/Pri.Cocktails.Infrastructure
RUN dotnet build "Pri.Cocktails.Infrastructure.csproj" -c Release -o /app/build

WORKDIR /src/Pri.Cocktails.Api
RUN dotnet build "Pri.Cocktails.Api.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pri.Cocktails.Api.dll"]