#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 4000
#EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Bank.ApiGateway/Bank.ApiGateway.csproj", "Bank.ApiGateway/"]
RUN dotnet restore "Bank.ApiGateway/Bank.ApiGateway.csproj"
COPY . .
WORKDIR "/src/Bank.ApiGateway"
RUN dotnet build "Bank.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bank.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.ApiGateway.dll"]
