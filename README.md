# Unity VR Defense Portfolio

## 프로젝트 소개

<div align="center">
<img src="https://github.com/user-attachments/assets/ce3b302a-edc5-4962-ab44-16e6afa7a7c9" width="45%">
<img src="https://github.com/user-attachments/assets/3ecd801b-7383-4683-9f93-bf9c689450cc" width="45%">
<p>소개 이미지</p>
</div>

---
+ "__던진다는 간단한 행위만으로 재미를 느끼게 만들자__"는 목표를 가지고 개발한 가상현실 디펜스 게임입니다

+ 대학교 캡스톤디자인에서 진행한 팀 프로젝트 작품입니다

+ 유로에셋 사용으로 인해 이 Repository에는 본인의 소스코드만 등록하고 설명할 점을 밝힙니다
<br></br>

## 개발 환경

__1. 장르__
   + VR Defense
     
__2. 플랫폼__
   + Unity 3D / 2022.3.6f1 LTS
     
__3. 개발언어__
   + C#
     
__4. 프로젝트 목표__
   + 던진다는 간단한 행위만으로 재미를 느낄 수 있게 만들자
     
__5. 개발 기간__
   + 2024/03/17 ~ 2024/06/12 (약 3개월)
<br></br>

## 사용 기술

기술 | 설명
-------- | -------
Singleton | 싱글톤 패턴을 통한 여러개의 매니저 관리 
XR Interaction Toolkit API | VR 기기를 다루기 위한 Unity 패키지 API 활용
Object Pooling | 많은 수의 몬스터 GameObject 관리하기 위한 최적화 기법
몬스터 Animation | Animator 및 Animation Event 를 이용한 몬스터 공격 판정
추상화 | override, abstract class를 이용한 코드 중복 제거

## 담당 기능

+ VR 컨트롤러
     + 기본적인 컨트롤러 기능 (이동, 오브젝트 상호작용 등)
     + 컨트롤러 속도 측정 후 무기 융합 시스템에 적용 

+ 게임 규칙
     + 메인메뉴에서 선택한 무기정보를 스테이지씬으로 전달
     + 무기를 던진 후 기존 자리에 리스폰
     + 적이 플레이어 본진까지 이동 후 공격
     + 가중치에 따라 몬스터 종류별로 스폰

+ 무기
   + 효과가 다른 무기 10종 제작
   + 무기 융합 시스템

+ 몬스터
     + 각 스테이지 별 3마리씩 총 6종류 몬스터 제작
     + 각 몬스터 애니메이터 구성
<br></br>

## 플레이 영상

<div align="center">
   <img src="https://github.com/user-attachments/assets/d9de7504-e633-41e6-9ebf-1766b9b6bfbc" width="40%">
   <img src="https://github.com/user-attachments/assets/785a2309-895b-433c-9695-74665d3839a3" width="40%">
   <img src="https://github.com/user-attachments/assets/d4a94376-478b-481d-a00b-0c2c4cbe1693" width="40%">
   <p> [인 게임 플레이 사진 GIF] </p>
</div>
<br></br>

## 팀원 구성

## 게임 빌드
