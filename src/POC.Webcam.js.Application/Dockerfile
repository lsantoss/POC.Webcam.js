FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/POC.Webcam.js.Application/POC.Webcam.js.Application.csproj", "src/POC.Webcam.js.Application/"]
COPY ["src/POC.Webcam.js.Domain/POC.Webcam.js.Domain.csproj", "src/POC.Webcam.js.Domain/"]
COPY ["src/POC.Webcam.js.Infra.Crosscutting/POC.Webcam.js.Infra.Crosscutting.csproj", "src/POC.Webcam.js.Infra.Crosscutting/"]
COPY ["src/POC.Webcam.js.Infra/POC.Webcam.js.Infra.csproj", "src/POC.Webcam.js.Infra/"]
COPY ["src/POC.Webcam.js.Infra.Data/POC.Webcam.js.Infra.Data.csproj", "src/POC.Webcam.js.Infra.Data/"]
RUN dotnet restore "src/POC.Webcam.js.Application/POC.Webcam.js.Application.csproj"
COPY . .
WORKDIR "/src/src/POC.Webcam.js.Application"
RUN dotnet build "POC.Webcam.js.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "POC.Webcam.js.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "POC.Webcam.js.Application.dll"]