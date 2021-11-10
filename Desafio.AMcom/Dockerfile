#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Desafio.AMcom/Desafio.AMcom.csproj", "Desafio.AMcom/"]
COPY ["Desafio.AMcom.Infraestrutura/Desafio.AMcom.Infraestrutura.csproj", "Desafio.AMcom.Infraestrutura/"]
COPY ["Desafio.AMcom.Dominio/Desafio.AMcom.Dominio.csproj", "Desafio.AMcom.Dominio/"]
RUN dotnet restore "Desafio.AMcom/Desafio.AMcom.csproj"
COPY . .
WORKDIR "/src/Desafio.AMcom"
RUN dotnet build "Desafio.AMcom.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Desafio.AMcom.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.AMcom.dll"]