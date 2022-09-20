#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Daycoval.Solid.Pedido.API/Daycoval.Solid.Pedido.API.csproj", "src/Daycoval.Solid.Pedido.API/"]
RUN dotnet restore "src/Daycoval.Solid.Pedido.API/Daycoval.Solid.Pedido.API.csproj"
COPY . .
WORKDIR "/src/Daycoval.Solid.Pedido.API"
RUN dotnet build "Daycoval.Solid.Pedido.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Daycoval.Solid.Pedido.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Daycoval.Solid.Pedido.API.dll"]