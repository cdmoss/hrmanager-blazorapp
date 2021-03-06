#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["HRManager.Blazor/HRManager.Blazor.csproj", "HRManager.Blazor/"]
COPY ["HRManager.Common/HRManager.Common.csproj", "HRManager.Common/"]
RUN dotnet restore "HRManager.Blazor/HRManager.Blazor.csproj"
RUN dotnet restore "HRManager.Common/HRManager.Common.csproj"
COPY . .
WORKDIR "/src/HRManager.Api"
RUN dotnet build "HRManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HRManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HRManager.Api.dll"]