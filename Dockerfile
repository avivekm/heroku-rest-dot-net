#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/API/bilerplate.Api/bilerplate.Api.csproj", "src/API/bilerplate.Api/"]
COPY ["src/Core/bilerplate.Application/bilerplate.Application.csproj", "src/Core/bilerplate.Application/"]
COPY ["src/Core/bilerplate.Domain/bilerplate.Domain.csproj", "src/Core/bilerplate.Domain/"]
COPY ["src/Infrastructure/bilerplate.Identity/bilerplate.Identity.csproj", "src/Infrastructure/bilerplate.Identity/"]
COPY ["src/Infrastructure/bilerplate.Persistence/bilerplate.Persistence.csproj", "src/Infrastructure/bilerplate.Persistence/"]
COPY ["src/Infrastructure/bilerplate.Infrastructure/bilerplate.Infrastructure.csproj", "src/Infrastructure/bilerplate.Infrastructure/"]
RUN dotnet restore "src/API/bilerplate.Api/bilerplate.Api.csproj"
COPY . .
WORKDIR "/src/src/API/bilerplate.Api"
RUN dotnet build "bilerplate.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bilerplate.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bilerplate.Api.dll"]