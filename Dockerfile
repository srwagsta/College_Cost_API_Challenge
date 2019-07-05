FROM mcr.microsoft.com/dotnet/core/runtime:2.2 AS base
WORKDIR /app
EXPOSE 80
 
FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /src
COPY ["AdvicentChallenge.csproj", ""]
RUN dotnet restore "AdvicentChallenge.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "AdvicentChallenge.csproj" -c Release -o /app
 
FROM build AS publish
RUN dotnet publish "AdvicentChallenge.csproj" -c Release -o /app
 
FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AdvicentChallenge.dll"]