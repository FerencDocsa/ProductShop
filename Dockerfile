#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

## Use the official .NET Core SDK image as a build stage
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /app
#
## Copy only the necessary files to restore dependencies
#COPY ./ProductShop.sln .
#COPY Presentation/ProductShop.WebAPI/*.csproj ./
#COPY Domain/ProductShop.Domain/*.csproj ./
#COPY Infrastructrure/ProductShop.Persistance/*.csproj ./
#COPY Infrastructrure/ProductShop.Persistance.Abstractions/*.csproj ./
#COPY Application/ProductShop.Application/*.csproj ./
## Restore dependencies
#RUN dotnet restore ./ProductShop.sln
#
## Copy the full project and build
#COPY . .
#RUN dotnet publish -c Release -o out
#
## Use the official .NET Core ASP.NET Runtime image as the runtime environment
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
#WORKDIR /app
#COPY --from=build /app/out ./
#
## Set the entry point for the application
#ENTRYPOINT ["dotnet", "ProductShop.WebAPI.dll"]
#
## Use the official .NET Core SDK image as a build stage
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /app
#
## Copy the project files and restore dependencies
#COPY Presentation/ProductShop.WebAPI/*.csproj ./
#COPY Domain/ProductShop.Domain/*.csproj ./
#COPY Infrastructrure/ProductShop.Persistance/*.csproj ./
#COPY Infrastructrure/ProductShop.Persistance.Abstractions/*.csproj ./
#COPY Application/ProductShop.Application/*.csproj ./
#
## Build the application
#RUN dotnet restore  ./Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj
#RUN dotnet publish -c Release -o out
#
## Use the official .NET Core Runtime image as the runtime environment
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
#WORKDIR /app
#COPY --from=build /app/out ./
#
## Set the entry point for the application
#ENTRYPOINT ["dotnet", "ProductShop.WebAPI.dll"]

# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
EXPOSE 80
EXPOSE 443

# Copy only the project files and restore dependencies
COPY Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj ./Presentation/ProductShop.WebAPI/
COPY Domain/ProductShop.Domain/ProductShop.Domain.csproj ./Domain/ProductShop.Domain/
COPY Infrastructrure/ProductShop.Persistance/ProductShop.Persistence.csproj ./Infrastructrure/ProductShop.Persistance/
COPY Infrastructrure/ProductShop.Persistance.Abstractions/ProductShop.Persistence.Abstractions.csproj ./Infrastructrure/ProductShop.Persistance.Abstractions/
COPY Application/ProductShop.Application/ProductShop.Application.csproj ./Application/ProductShop.Application/
RUN dotnet restore ./Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj

# Copy the entire solution and build
COPY . .
RUN dotnet publish -c Release -o /app ./Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ProductShop.WebAPI.dll"]


#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj", "ProductShop/Presentation/ProductShop.WebAPI/"]
#COPY ["Infrastructrure/ProductShop.Persistance/ProductShop.Persistence.csproj", "ProductShop/Infrastructure/ProductShop.Persistance/"]
#COPY ["Infrastructrure/ProductShop.Persistance.Abstractions/ProductShop.Persistence.Abstractions.csproj", "ProductShop/Infrastructure/ProductShop.Persistance.Abstractions/"]
#COPY ["Domain/ProductShop.Domain/ProductShop.Domain.csproj", "ProductShop/Domain/ProductShop.Domain/"]
#COPY ["Application/ProductShop.Application/ProductShop.Application.csproj", "ProductShop/Application/ProductShop.Application/"]
#
#RUN dotnet restore "ProductShop/Presentation/ProductShop.WebAPI/ProductShop.WebAPI.csproj"
#COPY . .
#WORKDIR "ProductShop/Presentation/ProductShop.WebAPI/"
#RUN dotnet build "ProductShop.WebAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "ProductShop.WebAPI" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ProductShop.WebAPI.dll"]