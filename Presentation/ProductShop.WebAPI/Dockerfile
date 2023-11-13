#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj", "Presentation/ProductShop.WebAPI/"]
COPY ["Application/ProductShop.Application/ProductShop.Application.csproj", "Application/ProductShop.Application/"]
COPY ["Domain/ProductShop.Domain/ProductShop.Domain.csproj", "Domain/ProductShop.Domain/"]
COPY ["Infrastructrure/ProductShop.Persistance.Abstractions/ProductShop.Persistence.Abstractions.csproj", "Infrastructrure/ProductShop.Persistance.Abstractions/"]
COPY ["Infrastructrure/ProductShop.Persistance/ProductShop.Persistence.csproj", "Infrastructrure/ProductShop.Persistance/"]
RUN dotnet restore "Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/ProductShop.WebAPI"
RUN dotnet build "ProductShop.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductShop.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductShop.WebAPI.dll"]