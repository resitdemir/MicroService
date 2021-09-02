FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/*.csproj Shared/
COPY IdentityServer/AuthServerIds4/*.csproj IdentityServer/AuthServerIds4/
RUN dotnet restore IdentityServer/AuthServerIds4/*.csproj
COPY . .
RUN dotnet publish IdentityServer/AuthServerIds4/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","AuthServerIds4.dll" ]
