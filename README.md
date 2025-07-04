## AWS EC2 Instance 에 호스팅 되어 있어 별도의 실행 과정 없이 클라이언트에서 바로 사용 가능합니다
<br/>


메인 게임에서 플레이 모드를 즐기기 위해 **매번 컴퓨터에 연결해서 데이터를 옮겨야 하는** 불편함이 존재

  
➡️ 데이터베이스를 관리하는 서버 제작  [🔗 메인 게임 깃허브 링크](https://github.com/BIT-Unity12th-XRProjects/Gwangpibara)

# 💁🏻‍♀️ 프로젝트 구현


AR 클라이언트 개발 팀을 위해 백엔드 데이터베이스 서버를 직접 설계·구축

이를 편리하게 호출할 수 있는 C# 함수 라이브러리와 사용 가이드를 제공

![image (14)](https://github.com/user-attachments/assets/f6868dc3-56f0-46c7-8438-3513ebcffe7d)

| 분류 | 사용 기술 |
| --- | --- |
| **언어 (Language)** | C#  |
| **웹 프레임워크 (Web Framework)** | ASP.NET Core( EF Core ) |
| **데이터베이스 (Database)** | MySQL (Amazon RDS 기반) |
| **컨테이너화 (Containerization)** | Docker |
| **클라우드 인프라 (Cloud Infrastructure)** | AWS EC2, AWS RDS |

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
EC2 에서만 접근 가능하도록 보안 그룹 제어

### 🔹사용 가이드 문서화 하여 팀원들에게 전달


서버 구축 및 팀원 배포까지 진행하여 AR 클라이언트 개발의 안정성과 효율성을 개선

[함수 사용방법](https://www.notion.so/21c9103cc1eb80f6879cd8510533aa68?pvs=21)

