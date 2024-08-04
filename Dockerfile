# Use the official .NET SDK image for the build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore dependencies
COPY PhoneCase/PhoneCase.csproj ./PhoneCase/
RUN dotnet restore PhoneCase/PhoneCase.csproj

# Copy the rest of the application code
COPY PhoneCase/ ./PhoneCase/
WORKDIR /app/PhoneCase

# Publish the application
RUN dotnet publish -c Release -o /app/out

# Use the official .NET runtime image for the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "PhoneCase.dll"]
