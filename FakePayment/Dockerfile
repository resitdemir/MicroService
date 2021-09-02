FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY FakePayment/*.csproj FakePayment/
RUN dotnet restore FakePayment/*.csproj
COPY . .
RUN dotnet publish FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FakePayment.dll" ]
