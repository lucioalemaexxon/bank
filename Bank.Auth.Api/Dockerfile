#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 4001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Bank.Auth.Api/Bank.Auth.Api.csproj", "Bank.Auth.Api/"]
COPY ["Bank.Auth.Infrastructure.Bootstrap/Bank.Auth.Infrastructure.Bootstrap.csproj", "Bank.Auth.Infrastructure.Bootstrap/"]
COPY ["Bank.Auth.Application/Bank.Auth.Application.csproj", "Bank.Auth.Application/"]
COPY ["Bank.Auth.Domain/Bank.Auth.Domain.csproj", "Bank.Auth.Domain/"]
COPY ["Bank.Auth.Infrastructure/Bank.Auth.Infrastructure.csproj", "Bank.Auth.Infrastructure/"]
RUN dotnet restore "Bank.Auth.Api/Bank.Auth.Api.csproj"
COPY . .
WORKDIR "/src/Bank.Auth.Api"
RUN dotnet build "Bank.Auth.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.Auth.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.Auth.Api.dll"]
