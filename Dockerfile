FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY . .
RUN dotnet restore RestaurantsList.Api/RestaurantsList.Api.csproj
COPY . .
WORKDIR /src
RUN dotnet build RestaurantsList.Api/RestaurantsList.Api.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish RestaurantsList.Api/RestaurantsList.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RestaurantsList.Api.dll"]