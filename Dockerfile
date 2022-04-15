FROM mcr.microsoft.com/dotnet/sdk:5.0.407-alpine3.14-amd64
WORKDIR /app
COPY publish/ .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
RUN addgroup -S dotnet
RUN adduser -S -D -h /app dotnet dotnet
RUN chown -R dotnet:dotnet /app
USER dotnet
ENTRYPOINT ["./BankOfGringotts.Api"]
