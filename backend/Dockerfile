# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Publish the application in Release mode to the /app/publish directory
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Setup the runtime container
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Expose the port your app will run on (make sure this matches your app’s port)
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "backend.dll"]