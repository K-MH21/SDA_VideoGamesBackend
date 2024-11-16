# Use the ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5125
ENV ASPNETCORE_URLS=http://0.0.0.0:5125

# Set the configuration argument for build
ARG configuration=Release

# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ["Backend.csproj", "./"]
RUN dotnet restore "Backend.csproj"
COPY wwwroot /app/wwwroot

# Copy the rest of the application code
COPY . .

# Build the application using -p flag for properties
RUN dotnet build "Backend.csproj" -p:Configuration=${configuration} -p:OutputPath=/app/build

# Publish the application
FROM build AS publish
RUN echo "Configuration: ${configuration}" && \
    dotnet publish "Backend.csproj" -p:Configuration=${configuration} -p:OutputPath=/app/publish /p:UseAppHost=false

# Final stage: use the base image and copy the published output
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point for the application
ENTRYPOINT ["dotnet", "Backend.dll"]









#docker build -t my-backend-app .






