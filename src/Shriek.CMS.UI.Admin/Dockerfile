FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src

RUN apt-get -qq update && apt-get -qqy --no-install-recommends install wget gnupg \
    git \
    unzip

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

COPY src/Shriek.CMS.UI.Admin/Shriek.CMS.UI.Admin.csproj src/Shriek.CMS.UI.Admin/
RUN dotnet restore src/Shriek.CMS.UI.Admin/Shriek.CMS.UI.Admin.csproj
COPY . .
WORKDIR /src/src/Shriek.CMS.UI.Admin
RUN dotnet build Shriek.CMS.UI.Admin.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Shriek.CMS.UI.Admin.csproj -c Release -o /app

FROM base AS final
WORKDIR /app

RUN apt-get -qq update && apt-get -qqy --no-install-recommends install wget gnupg \
    git \
    unzip

RUN curl -sL https://deb.nodesource.com/setup_6.x |  bash -
RUN apt-get install -y nodejs

COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Shriek.CMS.UI.Admin.dll"]
