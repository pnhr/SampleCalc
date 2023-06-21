FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PS.Calc.Api/PS.Calc.Api.csproj", "PS.Calc.Api/"]
RUN dotnet restore "PS.Calc.Api/PS.Calc.Api.csproj"
COPY . .
WORKDIR "/src/PS.Calc.Api"
RUN dotnet build "PS.Calc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PS.Calc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PS.Calc.Api.dll"]
