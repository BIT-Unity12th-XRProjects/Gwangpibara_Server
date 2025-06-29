
AWS EC2 Instance 에 호스팅 되어 있어 별도의 실행 과정 없이 클라이언트에서 바로 사용 가능합니다

## ⚙️ 기술 스택

- **C#**, **ASP.NET Core**
- **Entity Framework Core (EF Core)**
- **MySQL** + **AWS RDS**
- **AWS EC2** (서버 호스팅)
- **Docker** (서버 환경 구성)

### 🔹API Server

- ASP.NET Core + EF Core로 
CRUD API 서버 구현
- API Server 에서 RDS MySQL 에 연결

### 🔹Client (Unity)

- UnityWebRequest 를 통한 RESTful API 통신
- Newtonsoft 라이브러리를 활용하여 
Json 파싱

### 🔹AWS EC2 & RDS 기반 인프라 구축

**Instance**

OS : Ubuntu <br/>
역할 : API 서버 호스팅 <br/>
Docker 기반 컨테이너 배포 <br/>

**RDS**

MySQL <br/>
EC2 에서만 접근 가능하도록 보안 그룹 제어 <br/>

## 클라이언트에서 사용하기

[🔗 사용 방법](https://www.notion.so/21c9103cc1eb80f6879cd8510533aa68?pvs=21)

![image (14)](https://github.com/user-attachments/assets/f6868dc3-56f0-46c7-8438-3513ebcffe7d)
