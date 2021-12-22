FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Pipeline.Agent/Pipeline.Agent.csproj", "src/Pipeline.Agent/"]
RUN dotnet restore "src/Pipeline.Agent/Pipeline.Agent.csproj"
COPY . .
WORKDIR "/src/src/Pipeline.Agent"
RUN dotnet build "Pipeline.Agent.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Pipeline.Agent.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

USER 65535:65535
ENTRYPOINT ["dotnet", "Pipeline.Agent.dll"]