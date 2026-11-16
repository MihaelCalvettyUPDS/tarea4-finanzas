
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY finanzas.csproj .
RUN dotnet restore "finanzas.csproj"
COPY . .
RUN dotnet build "finanzas.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "finanzas.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "finanzas.dll"]