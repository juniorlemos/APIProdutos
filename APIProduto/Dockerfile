#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["APIProduto/APIProduto.csproj", "APIProduto/"]
COPY ["Modelo.Infra/Modelo.Infra.csproj", "Modelo.Infra/"]
COPY ["Modelo.Domain/Modelo.Domain.csproj", "Modelo.Domain/"]
COPY ["Modelo.Application/Modelo.Application.csproj", "Modelo.Application/"]
COPY ["Modelo.Service/Modelo.Service.csproj", "Modelo.Service/"]
RUN dotnet restore "APIProduto/APIProduto.csproj"
COPY . .
WORKDIR "/src/APIProduto"
RUN dotnet build "APIProduto.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "APIProduto.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "APIProduto.dll"]