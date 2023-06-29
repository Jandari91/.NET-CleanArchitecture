## 키워드
#### 1. EF Core

* 스키마 및 데이터 자동 생성(Migration)
* 아키텍처 관점으로 사용하던 DB가 Postgres였다가 Oracle이였다가 MSSql이였다가 자유자재로 DI 가능


#### 2. 통합 테스트

* 통합 테스트는 프로세스(테스트 내부)와 외부가 같이 테스트 되는 테스트.
* UserServiceInPostgresTests.cs를 실행 시키면 자동으로 Postgres Docker 이미지를 다운받아 실행함.
* 실행된 Postgres와 연동 되어 User 5개를 리턴 시켜 줌
