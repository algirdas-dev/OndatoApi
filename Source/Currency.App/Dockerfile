FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Ondato.Api/Ondato.Api.csproj", "Ondato.Api/"]
RUN dotnet restore "Ondato.Api/Ondato.Api.csproj"
COPY . .
WORKDIR "/src/Ondato.Api"
RUN dotnet build "Ondato.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ondato.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ondato.Api.dll"]
