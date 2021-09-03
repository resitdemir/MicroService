FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY DiscountAPI/*.csproj DiscountAPI/
RUN dotnet restore DiscountAPI/*.csproj
COPY . .
RUN dotnet publish DiscountAPI/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","DiscountAPI.dll" ]
