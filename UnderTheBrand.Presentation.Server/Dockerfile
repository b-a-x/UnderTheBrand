FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["UnderTheBrand.Presentation.Server/UnderTheBrand.Presentation.Server.csproj", "UnderTheBrand.Presentation.Server/"]
RUN dotnet restore "UnderTheBrand.Presentation.Server/UnderTheBrand.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/UnderTheBrand.Presentation.Server"
RUN dotnet build "UnderTheBrand.Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnderTheBrand.Presentation.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnderTheBrand.Presentation.Server.dll"]