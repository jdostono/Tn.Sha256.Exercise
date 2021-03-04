#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
#WORKDIR /app
#EXPOSE 8088

#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /src

#COPY ["Tn.Sha256Exercise.Api.csproj", "Tn.Sha256Exercise.Api/"]
#RUN dotnet restore "Tn.Sha256Exercise.Api/Tn.Sha256Exercise.Api.csproj"

#COPY . .
#WORKDIR "/src/Tn.Sha256Exercise.Api"
#RUN dotnet build "Tn.Sha256Exercise.Api.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Tn.Sha256Exercise.Api.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Tn.Sha256Exercise.Api.dll"]

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-buster-slim
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "tn.sha256.exercise.dll"]