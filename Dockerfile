FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
 
FROM microsoft/dotnet:2.2-sdk AS build
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
ENTRYPOINT ["dotnet", "/app/AdvicentChallenge.dll"]