FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DefenseIO.Services.Report/DefenseIO.Services.Report.csproj", "DefenseIO.Services.Report/"]
RUN dotnet restore "DefenseIO.Services.Report/DefenseIO.Services.Report.csproj"
COPY . .
WORKDIR "/src/DefenseIO.Services.Report"
RUN dotnet build "DefenseIO.Services.Report.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DefenseIO.Services.Report.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefenseIO.Services.Report.dll"]