#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["UnderTheBrand.Presentation.Server/Presentation.Server.csproj", "UnderTheBrand.Presentation.Server/"]
COPY ["UnderTheBrand.Infrastructure.ViewModel/Infrastructure.ViewModel.csproj", "UnderTheBrand.Infrastructure.ViewModel/"]
COPY ["UnderTheBrand.Domain.ValueObject/Domain.ValueObject.csproj", "UnderTheBrand.Domain.ValueObject/"]
COPY ["UnderTheBrand.Domain.Core/Domain.Core.csproj", "UnderTheBrand.Domain.Core/"]
COPY ["UnderTheBrand.Infrastructure.DAL/Infrastructure.Dal.csproj", "UnderTheBrand.Infrastructure.DAL/"]
COPY ["UnderTheBrand.Domain.Interfaces/Domain.Interfaces.csproj", "UnderTheBrand.Domain.Interfaces/"]
COPY ["UnderTheBrand.Domain.Entity/Domain.Entity.csproj", "UnderTheBrand.Domain.Entity/"]
RUN dotnet restore "UnderTheBrand.Presentation.Server/Presentation.Server.csproj"
COPY . .
WORKDIR "/src/UnderTheBrand.Presentation.Server"
RUN dotnet build "Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.Server.dll"]