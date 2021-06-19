FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src

COPY ["Services/Catalog/Application/Catalog.Application.API/Catalog.Application.API.csproj", "Services/Catalog/Application/Catalog.Application.API/"]
COPY ["Services/Catalog/Infra/Data/Catalog.Infra.Data/Catalog.Infra.Data.csproj", "Services/Catalog/Infra/Data/Catalog.Infra.Data/"]
COPY ["Services/Catalog/Domain/Catalog.Domain/Catalog.Domain.csproj", "Services/Catalog/Domain/Catalog.Domain/"]

RUN dotnet restore "Services/Catalog/Application/Catalog.Application.API/Catalog.Application.API.csproj"

COPY . .

WORKDIR "/src/Services/Catalog/Application/Catalog.Application.API"

RUN dotnet build "Catalog.Application.API.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "Catalog.Application.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Catalog.Application.API.dll"]
