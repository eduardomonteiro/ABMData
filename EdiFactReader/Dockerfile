FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EdiFactReader/EdiFactReader.csproj", "EdiFactReader/"]
RUN dotnet restore "EdiFactReader/EdiFactReader.csproj"
COPY . .
WORKDIR "/src/EdiFactReader"
RUN dotnet build "EdiFactReader.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EdiFactReader.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EdiFactReader.dll"]