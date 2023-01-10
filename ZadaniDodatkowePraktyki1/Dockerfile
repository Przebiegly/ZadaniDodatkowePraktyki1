FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ZadaniDodatkowePraktyki1/ZadaniDodatkowePraktyki1.csproj", "ZadaniDodatkowePraktyki1/"]
RUN dotnet restore "ZadaniDodatkowePraktyki1/ZadaniDodatkowePraktyki1.csproj"
COPY . .
WORKDIR "/src/ZadaniDodatkowePraktyki1"
RUN dotnet build "ZadaniDodatkowePraktyki1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ZadaniDodatkowePraktyki1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ZadaniDodatkowePraktyki1.dll"]
