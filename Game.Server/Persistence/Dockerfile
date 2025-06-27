# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 프로젝트 파일 복사 및 복원
COPY ["Persistence/Persistence.csproj", "Persistence/"]
RUN dotnet restore "Persistence/Persistence.csproj"

# 나머지 소스 복사 및 퍼블리시
COPY . .
WORKDIR "/src/Persistence"
RUN dotnet publish -c Release -o /app/publish

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0-slim AS runtime

# AWS CLI v2 설치 (최신 AWS API 호출용) :contentReference[oaicite:0]{index=0}
RUN apt-get update && apt-get install -y --no-install-recommends \
        curl unzip \
    && curl "https://awscli.amazonaws.com/awscli-exe-linux-x86_64.zip" -o "awscliv2.zip" \
    && unzip awscliv2.zip && ./aws/install \
    && rm -rf awscliv2.zip aws \
    && apt-get purge -y --auto-remove curl unzip \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
# 빌드된 앱 복사
COPY --from=build /app/publish .

# ASP.NET Core 설정 & AWS 기본 리전 지정
ENV ASPNETCORE_URLS=http://+:80 \
    DOTNET_RUNNING_IN_CONTAINER=true \
    AWS_DEFAULT_REGION=ap-northeast-2

# 컨테이너 포트 노출
EXPOSE 80

# 애플리케이션 실행
ENTRYPOINT ["dotnet", "Persistence.dll"]