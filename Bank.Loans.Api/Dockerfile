#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 4002

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Bank.Loans.Api/Bank.Loans.Api.csproj", "Bank.Loans.Api/"]
COPY ["Bank.Loans.Infrastructure.Bootstrap/Bank.Loans.Infrastructure.Bootstrap.csproj", "Bank.Loans.Infrastructure.Bootstrap/"]
COPY ["Bank.Loans.Infrastructure/Bank.Loans.Infrastructure.csproj", "Bank.Loans.Infrastructure/"]
COPY ["Bank.Loans.Domain/Bank.Loans.Domain.csproj", "Bank.Loans.Domain/"]
COPY ["Bank.Loans.Application/Bank.Loans.Application.csproj", "Bank.Loans.Application/"]
RUN dotnet restore "Bank.Loans.Api/Bank.Loans.Api.csproj"
COPY . .
WORKDIR "/src/Bank.Loans.Api"
RUN dotnet build "Bank.Loans.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.Loans.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.Loans.Api.dll"]
