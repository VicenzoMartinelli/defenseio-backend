FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DefenseIO.Services.Geographic/DefenseIO.Services.Geographic.csproj", "DefenseIO.Services.Geographic/"]
RUN dotnet restore "DefenseIO.Services.Geographic/DefenseIO.Services.Geographic.csproj"
COPY . .
WORKDIR "/src/DefenseIO.Services.Geographic"
RUN dotnet build "DefenseIO.Services.Geographic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DefenseIO.Services.Geographic.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefenseIO.Services.Geographic.dll"]
