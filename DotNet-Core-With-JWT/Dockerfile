FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["jwtnetcore31.csproj", "./"]
RUN dotnet restore "./jwtnetcore31.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "jwtnetcore31.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "jwtnetcore31.csproj" -c Release -o /app/publish

CMD ASPNETCORE_URLS=http://*:$PORT dotnet /app/publish/jwtnetcore31.dll

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "jwtnetcore31.dll"]
