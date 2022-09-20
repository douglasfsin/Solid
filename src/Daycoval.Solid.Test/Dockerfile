#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Daycoval.Solid.Test/Daycoval.Solid.Test.csproj", "src/Daycoval.Solid.Test/"]
RUN dotnet restore "src/Daycoval.Solid.Test/Daycoval.Solid.Test.csproj"
COPY . .
WORKDIR "/src/Daycoval.Solid.Test"
RUN dotnet build 
RUN dotnet test
