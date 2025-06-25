
## 데이터베이스 서버 사용 방법

### Docker 로 API 서버의 이미지와 컨테이너 생성 및 실행

[5000 : 8000] 으로 포트포워딩 하기

⚠️ 유니티에서 서버 접속하려면 컨테이너 실행 중이어야 함

### API 서버 실행시키기

비쥬얼스튜디오에서 실행 시키기

### 클라이언트에서 IP 주소 지정하기

유니티 *MarkersApiClient.cs*의 _baseUrl 을 서버 실행시킨 컴퓨터의 ip주소 + 포트 번호(5000)로 변경

Ex) `“http://192.168.0.28:5000”`

### MySQL Workbench 에서 AWS RDS의 데이터 베이스 확인하기

- 홈에서 AWS RDS 와 Connection 만들기
    
    > 아이디 : root
    비번 : gwangpibara!!
    > 

## 주의 사항

같은 LAN에서 사용 가능

서버 실행 시켜야 AWS RDS 접근 가능

AWS RDS 의 설정에 서버 실행시키는 컴퓨터의 IP 주소 등록되어 있어야 접근 가능

서버의 방화벽 5000포트(http, https는 5001) 열어두기

## 클라이언트에서 사용하기

[🔗 사용 방법](https://www.notion.so/21c9103cc1eb80f6879cd8510533aa68?pvs=21)

![image (14)](https://github.com/user-attachments/assets/f6868dc3-56f0-46c7-8438-3513ebcffe7d)
