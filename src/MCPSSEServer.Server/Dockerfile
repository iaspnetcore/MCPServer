# 请参阅 https://aka.ms/customizecontainer 
# https://www.cnblogs.com/alives/p/17669161.html
# https://wirefuture.com/post/dockerizing-net-applications-step-by-step-tutorial

# 此阶段用于在快速模式(默认为调试配置)下从 VS 运行时
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# 此阶段用于生成服务项目
# 指定基础镜像
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MCPSSEServer.Server.csproj", "."]
RUN dotnet restore "./MCPSSEServer.Server.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./MCPSSEServer.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build

# 此阶段用于发布要复制到最终阶段的服务项目
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MCPSSEServer.Server.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# 此阶段在生产中使用，或在常规模式下从 VS 运行时使用(在不使用调试配置时为默认值)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MCPSSEServer.Server.dll"]

# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy remaining files and build the application
COPY . ./
RUN dotnet publish -c Release -o out

# Use the runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./

# Expose the port and define the entry point
EXPOSE 8080
CMD ["dotnet", "MCPSSEServer.Server.dll"]