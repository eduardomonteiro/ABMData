FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ABMData/ABMData.csproj", "ABMData/"]
RUN dotnet restore "ABMData/ABMData.csproj"
COPY . .
WORKDIR "/src/ABMData"
RUN dotnet build "ABMData.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ABMData.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ABMData.dll"]