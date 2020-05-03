FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1809 AS build-env
WORKDIR /src

COPY *.sln .
COPY ["BookingTelegramBot.Tests/BookingTelegramBot.Tests.csproj", "BookingTelegramBot.Tests/"]
COPY ["BookingTelegramBot/BookingTelegramBot.csproj", "BookingTelegramBot/"]
COPY ["BookingTelegramBot.BLL/BookingTelegramBot.BLL.csproj", "BookingTelegramBot.BLL/"]
COPY ["BookingTelegramBot.DAL/BookingTelegramBot.DAL.csproj", "BookingTelegramBot.DAL/"]

RUN dotnet restore

COPY . .
WORKDIR "/src/BookingTelegramBot"
RUN dotnet build "BookingTelegramBot.csproj" -c Release -o /app/build

RUN dotnet publish "BookingTelegramBot.csproj" -c Release -o /app/out

FROM base as final
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BookingTelegramBot.dll"]