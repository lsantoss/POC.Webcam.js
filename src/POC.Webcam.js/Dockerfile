FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/POC.Webcam.js/POC.Webcam.js.csproj", "src/POC.Webcam.js/"]
RUN dotnet restore "./src/POC.Webcam.js/POC.Webcam.js.csproj"
COPY . .
WORKDIR "/src/src/POC.Webcam.js"
RUN dotnet build "./POC.Webcam.js.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./POC.Webcam.js.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Webcam.js.dll"]