FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GameTests/GameTests.csproj", "GameTests/"]
RUN dotnet restore "GameTests/GameTests.csproj"
COPY . .
WORKDIR "/src/GameTests"
RUN dotnet build "GameTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameTests.dll"]
