# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project file(s) to the container and restore dependencies
COPY ./backend/*.csproj ./
RUN dotnet restore

# Copy the remaining project files to the container
COPY ./backend/. ./

# Publish the application to a folder
RUN dotnet publish -c Release -o /app/publish

# Use the official .NET runtime image as a base for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

# Set the working directory inside the container
WORKDIR /app

# Copy the published app from the build stage to the final stage
COPY --from=build /app/publish .

# Set the entry point to run the API
ENTRYPOINT ["dotnet", "Backend.dll"]

# Expose port 80 to be accessible outside the container
EXPOSE 80