# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /source
COPY /. ./

RUN dotnet restore

RUN dotnet build -c release

RUN dotnet publish -c release -o /src/output

FROM mcr.microsoft.com/dotnet/aspnet:5.0

WORKDIR /src/output
COPY --from=build /src/output ./
ENTRYPOINT ["dotnet", "BankOfGringotts.Api.dll"]