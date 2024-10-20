FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
EXPOSE 80
EXPOSE 403

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /src
COPY ["Api/Api.csproj","Api/"]
COPY ["Application/Application.csproj","Application/"]
COPY ["Domain/Domain.csproj","Domain/"]
COPY ["Infrastructure/Infrastructure.csproj","Infrastructure/"]

RUN dotnet restore "Api/Api.csproj"

COPY . .

WORKDIR "/src/Api"

RUN dotnet build "Api.csproj" -c Release -o /app/build

FROM build as publish

RUN dotnet publish "Api.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet","Api.dll" ]

