FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["DefenseIO.Services.Chat/DefenseIO.Services.Chat.csproj", "DefenseIO.Services.Chat/"]
RUN dotnet restore "DefenseIO.Services.Chat/DefenseIO.Services.Chat.csproj"
COPY . .
WORKDIR "/src/DefenseIO.Services.Chat"
RUN dotnet build "DefenseIO.Services.Chat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DefenseIO.Services.Chat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefenseIO.Services.Chat.dll"]