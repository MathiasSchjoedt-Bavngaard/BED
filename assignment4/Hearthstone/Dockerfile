# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Hearthstone/*.csproj ./Hearhtstone/
RUN dotnet restore

# copy everything else and build app
COPY Hearthstone/. ./Hearthstone/
COPY Cards.json /Hearthstone/Cards.json
WORKDIR /source/Hearthstone
RUN dotnet publish -c release -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Hearthstone.dll"]