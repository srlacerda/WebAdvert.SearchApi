FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
#EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

#COPY ["WebAdvert.SearchApi/WebAdvert.SearchApi.csproj", "WebAdvert.SearchApi/"]
#RUN dotnet restore "WebAdvert.SearchApi/WebAdvert.SearchApi.csproj"
#COPY . .
#WORKDIR "/src/WebAdvert.SearchApi"
#RUN dotnet build "WebAdvert.SearchApi.csproj" -c Release -o /app
COPY *.csproj ./
RUN dotnet restore

#FROM build AS publish
#RUN dotnet publish "WebAdvert.SearchApi.csproj" -c Release -o /app
COPY . ./
FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAdvert.SearchApi.dll"]