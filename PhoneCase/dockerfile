# Use the official .NET image as a parent image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /app

COPY phonecase.csproj ./
RUN dotnet restore
COPY . ./

#publish application
RUN dotnet publish -c Release -o out

# official >NET runtime image for the runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app
COPY --from=build /app/out .

#done after build, is in bin folder
ENTRYPOINT ["dotnet", "PhoneCase.dll"]