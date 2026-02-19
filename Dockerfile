# ========= BUILD =========
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia só o csproj primeiro (melhor cache)
COPY PedidosEDA.csproj ./
RUN dotnet restore "./PedidosEDA.csproj"

# Copia o resto
COPY . ./
RUN dotnet publish "./PedidosEDA.csproj" -c Release -o /app/publish /p:UseAppHost=false

# ========= RUNTIME =========
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Porta padrão do container
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

COPY --from=build /app/publish ./

# Se sua app for Blazor Server / ASP.NET, o dll vai ser esse:
ENTRYPOINT ["dotnet", "PedidosEDA.dll"]
