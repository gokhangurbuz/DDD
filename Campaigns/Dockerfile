FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . /app
RUN dotnet restore

#Unit Test
RUN dotnet test "./Campaigns.Tests/Campaigns.Tests.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime

WORKDIR /app
COPY --from=build-env /app .

ENTRYPOINT ["dotnet", "Campaigns.App.dll"]