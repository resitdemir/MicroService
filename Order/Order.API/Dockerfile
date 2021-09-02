FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY Order/Order.Application/*.csproj Order/Order.Application/
COPY Order/Order.Domain/*.csproj Order/Order.Domain/
COPY Order/Order.Domain.Core/*.csproj Order/Order.Domain.Core/
COPY Order/Order.Infrastructure/*.csproj Order/Order.Infrastructure/
COPY Order/Order.API/*.csproj Order/Order.API/
RUN dotnet restore Order/Order.API/*.csproj
COPY . .
RUN dotnet publish Order/Order.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Order.API.dll" ]
