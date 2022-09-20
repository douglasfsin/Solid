#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Daycoval.Solid.Test/Daycoval.Solid.Test.csproj", "src/Daycoval.Solid.Test/"]
RUN dotnet restore "src/Daycoval.Solid.Test/Daycoval.Solid.Test.csproj"
COPY . .
WORKDIR "/src/Daycoval.Solid.Test"
RUN dotnet build "Daycoval.Solid.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Daycoval.Solid.Test.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Daycoval.Solid.Test.dll"]