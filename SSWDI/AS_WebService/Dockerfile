#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AS_WebService/AS_WebService.csproj", "AS_WebService/"]
RUN dotnet restore "AS_WebService/AS_WebService.csproj"
COPY . .
WORKDIR "/src/AS_WebService"
RUN dotnet build "AS_WebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AS_WebService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AS_WebService.dll"]