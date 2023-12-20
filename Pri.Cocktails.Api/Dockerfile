#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY Pri.Cocktails.sln ./
COPY ["Pri.Cocktails.Api/Pri.Cocktails.Api.csproj", "Pri.Cocktails.Api/"]
COPY ["Pri.Cocktails.Infrastructure/Pri.Cocktails.Infrastructure.csproj", "Pri.Cocktails.Infrastructure/"]
COPY ["Pri.Cocktails.Core/Pri.Cocktails.Core.csproj", "Pri.Cocktails.Core/"]
RUN dotnet restore
COPY . .
WORKDIR "/src/Pri.Cocktails.Api"
RUN dotnet build "Pri.Cocktails.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pri.Cocktails.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Pri.Cocktails.Api.dll"]