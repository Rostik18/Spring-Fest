#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SF.WebAPI/SF.WebAPI.csproj", "SF.WebAPI/"]
COPY ["SF.IoC/SF.IoC.csproj", "SF.IoC/"]
COPY ["SF.Services/SF.Services.csproj", "SF.Services/"]
COPY ["SF.Services.Interfaces/SF.Services.Interfaces.csproj", "SF.Services.Interfaces/"]
COPY ["SF.Services.Models/SF.Services.Models.csproj", "SF.Services.Models/"]
COPY ["SF.Infrastructure/SF.Infrastructure.csproj", "SF.Infrastructure/"]
COPY ["SF.Domain/SF.Domain.csproj", "SF.Domain/"]
COPY ["SF.Mappers/SF.Mappers.csproj", "SF.Mappers/"]
COPY ["SF.WebAPI.Models/SF.WebAPI.Models.csproj", "SF.WebAPI.Models/"]
RUN dotnet restore "SF.WebAPI/SF.WebAPI.csproj"
COPY . .
WORKDIR "/src/SF.WebAPI"
RUN dotnet build "SF.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SF.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SF.WebAPI.dll"]