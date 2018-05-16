FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY src/Shriek.CMS.UI.Web/Shriek.CMS.UI.Web.csproj src/Shriek.CMS.UI.Web/
RUN dotnet restore src/Shriek.CMS.UI.Web/Shriek.CMS.UI.Web.csproj
COPY . .
WORKDIR /src/src/Shriek.CMS.UI.Web
RUN dotnet build Shriek.CMS.UI.Web.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Shriek.CMS.UI.Web.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shriek.CMS.UI.Web.dll"]
