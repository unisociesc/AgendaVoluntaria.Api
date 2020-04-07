#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-alpine AS base
RUN apk add tzdata curl && cp /usr/share/zoneinfo/America/Bahia /etc/localtime && echo "America/Bahia" >  /etc/timezone
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build
WORKDIR /src
COPY ["src/AgendaVoluntaria.Scheduler/AgendaVoluntaria.Scheduler.csproj", "src/AgendaVoluntaria.Scheduler/"]
RUN dotnet restore "src/AgendaVoluntaria.Scheduler/AgendaVoluntaria.Scheduler.csproj"
COPY . .
WORKDIR "/src/src/AgendaVoluntaria.Scheduler"
RUN dotnet build "AgendaVoluntaria.Scheduler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AgendaVoluntaria.Scheduler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AgendaVoluntaria.Scheduler.dll"]