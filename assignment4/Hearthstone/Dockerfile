FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# Copy everything and build app
COPY . ./
#Restore
RUN dotnet restore "./Hearthstone.csproj"
#Publish
RUN dotnet publish "Hearthstone.csproj" -c Release -o /app
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /source
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Hearthstone.dll"]