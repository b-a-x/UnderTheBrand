#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1803 AS build
WORKDIR /src
COPY ["Presentation.Server/Presentation.Server.csproj", "Presentation.Server/"]
COPY ["Infrastructure.Dal/Infrastructure.Dal.csproj", "Infrastructure.Dal/"]
COPY ["Domain.Interfaces/Domain.Interfaces.csproj", "Domain.Interfaces/"]
COPY ["Domain.Model/Domain.Model.csproj", "Domain.Model/"]
COPY ["Domain.Core/Domain.Core.csproj", "Domain.Core/"]
COPY ["Infrastructure.Core/Infrastructure.Core.csproj", "Infrastructure.Core/"]
RUN dotnet restore "Presentation.Server/Presentation.Server.csproj"
COPY . .
WORKDIR "/src/Presentation.Server"
RUN dotnet build "Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.Server.dll"]