#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HorasExtrasApi/HorasExtras.Api/HorasExtras.Api.csproj", "HorasExtrasApi/HorasExtras.Api/"]
COPY ["HorasExtrasApi/HorasExtras.Application/HorasExtras.Application.csproj", "HorasExtrasApi/HorasExtras.Application/"]
COPY ["HorasExtrasApi/HorasExtras.Domain/HorasExtras.Domain.csproj", "HorasExtrasApi/HorasExtras.Domain/"]
COPY ["HorasExtrasApi/HorasExtras.Infrastructure/HorasExtras.Infrastructure.csproj", "HorasExtrasApi/HorasExtras.Infrastructure/"]
RUN dotnet restore "HorasExtrasApi/HorasExtras.Api/HorasExtras.Api.csproj"
COPY . .
WORKDIR "/src/HorasExtrasApi/HorasExtras.Api"
RUN dotnet build "HorasExtras.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HorasExtras.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HorasExtras.Api.dll"]