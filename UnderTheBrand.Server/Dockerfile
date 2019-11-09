FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UnderTheBrand.Server/UnderTheBrand.Server.csproj", "UnderTheBrand.Server/"]
RUN dotnet restore "UnderTheBrand.Server/UnderTheBrand.Server.csproj"
COPY . .
WORKDIR "/src/UnderTheBrand.Server"
RUN dotnet build "UnderTheBrand.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnderTheBrand.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnderTheBrand.Server.dll"]