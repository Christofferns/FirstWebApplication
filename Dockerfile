# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Kopier kun csproj først (bedre cache ved restore)
COPY FirstWebApplication.csproj ./
RUN dotnet restore FirstWebApplication.csproj

# Kopier resten og bygg
COPY . .
RUN dotnet publish FirstWebApplication.csproj -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "FirstWebApplication.dll"]
