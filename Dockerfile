FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Conscea-Api/Conscea-Api.csproj", "Conscea-Api/"]
RUN dotnet restore "Conscea-Api/Conscea-Api.csproj"
COPY . .
WORKDIR "/src/Conscea-Api"
RUN dotnet build "Conscea-Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Conscea-Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Conscea-Api.dll"]
