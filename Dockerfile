# Build stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env-7.0
WORKDIR /app
COPY *.csproj /app
RUN dotnet restore *.csproj
COPY . .
RUN dotnet build -c Release   # Build in Release mode
RUN ASPNETCORE_ENVIRONMENT=Production dotnet publish -c Release -o /app/out  # Set environment to Production during publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app
COPY --from=build-env-7.0 /app/out .
# Set the desired port (5000 in this case) 
# ENV ASPNETCORE_URLS=http://+:5000
# Expose the port your application is listening on
EXPOSE 80
ENTRYPOINT ["dotnet", "OptechXPortalAdmin.dll"]
