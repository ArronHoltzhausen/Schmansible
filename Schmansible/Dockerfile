#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1.20-bullseye-slim-arm64v8, 3.1-bullseye-slim-arm64v8 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1.20-bullseye-slim-arm64v8, 3.1-bullseye-slim-arm64v8 AS build
WORKDIR /src
COPY ["Schmansible/Schmansible.csproj", "Schmansible/"]
RUN dotnet restore "Schmansible/Schmansible.csproj"
COPY . .
WORKDIR "/src/Schmansible"
RUN dotnet build "Schmansible.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Schmansible.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Schmansible.dll"]