FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy all project files
COPY ["src/Api/Api.csproj", "src/Api/"]
COPY ["src/Application/Application.csproj", "src/Application/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infra/Infra.csproj", "src/Infra/"]

# Restore packages
RUN dotnet restore "src/Api/Api.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish "src/Api/Api.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose port
EXPOSE 8080

# Entry point
ENTRYPOINT ["dotnet", "Api.dll"]
