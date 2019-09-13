FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ApiReadXml/ApiReadXml.csproj", "ApiReadXml/"]
RUN dotnet restore "ApiReadXml/ApiReadXml.csproj"
COPY . .
WORKDIR "/src/ApiReadXml"
RUN dotnet build "ApiReadXml.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiReadXml.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiReadXml.dll"]