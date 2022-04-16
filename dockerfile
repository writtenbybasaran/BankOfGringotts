# First stage
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY BankOfGringotts/*.csproj ./BankOfGringotts/
RUN dotnet restore

# Copy everything else and build website
COPY BankOfGringotts/. ./BankOfGringotts/
WORKDIR /app/BankOfGringotts
RUN dotnet publish -c release -o /DockerOutput/Website --no-restore

# Final stage
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /DockerOutput/Website
COPY --from=build /DockerOutput/Website ./
ENTRYPOINT ["dotnet", "BankOfGringotts.Api.dll"]