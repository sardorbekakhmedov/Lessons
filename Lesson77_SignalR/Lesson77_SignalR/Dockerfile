#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Lesson77_SignalR/Lesson77_SignalR.csproj", "Lesson77_SignalR/"]
RUN dotnet restore "Lesson77_SignalR/Lesson77_SignalR.csproj"
COPY . .
WORKDIR "/src/Lesson77_SignalR"
RUN dotnet build "Lesson77_SignalR.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lesson77_SignalR.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lesson77_SignalR.dll"]