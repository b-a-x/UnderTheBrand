#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1803 AS build
WORKDIR /src
COPY "Presentation.Server.csproj" "Presentation.Server.csproj"
#COPY "Infrastructure.Dal/Infrastructure.Dal.csproj" "Presentation.Server/Infrastructure.Dal.csproj"
#COPY "Domain.Interfaces/Domain.Interfaces.csproj" "Domain.Interfaces/Domain.Interfaces.csproj"
#COPY "Domain.Model/Domain.Model.csproj" "Domain.Model/Domain.Model.csproj"
#COPY "Domain.Core/Domain.Core.csproj" "Domain.Core/Domain.Core.csproj"
#COPY "Infrastructure.Core/Infrastructure.Core.csproj" "Infrastructure.Core/Infrastructure.Core.csproj"
RUN dotnet restore "Presentation.Server.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Presentation.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Presentation.Server.dll"]