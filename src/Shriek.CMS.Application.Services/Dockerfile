FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY src/Shriek.CMS.Application.Services/Shriek.CMS.Application.Services.csproj src/Shriek.CMS.Application.Services/
RUN dotnet restore src/Shriek.CMS.Application.Services/Shriek.CMS.Application.Services.csproj
COPY . .
WORKDIR /src/src/Shriek.CMS.Application.Services
RUN dotnet build Shriek.CMS.Application.Services.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Shriek.CMS.Application.Services.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shriek.CMS.Application.Services.dll"]
