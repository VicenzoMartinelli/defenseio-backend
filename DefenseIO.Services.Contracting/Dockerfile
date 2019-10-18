FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DefenseIO.Services.Contracting/DefenseIO.Services.Contracting.csproj", "DefenseIO.Services.Contracting/"]
RUN dotnet restore "DefenseIO.Services.Contracting/DefenseIO.Services.Contracting.csproj"
COPY . .
WORKDIR "/src/DefenseIO.Services.Contracting"
RUN dotnet build "DefenseIO.Services.Contracting.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DefenseIO.Services.Contracting.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefenseIO.Services.Contracting.dll"]