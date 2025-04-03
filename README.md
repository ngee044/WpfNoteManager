# WpfNoteManager

WpfNoteManager는 **WPF(Windows Presentation Foundation)**를 사용하여 구현한 간단한 CRUD 기능과 메모장 기능을 포함한 데스크톱 애플리케이션 예제입니다.  
MVVM 패턴, 데이터 바인딩, 파일 입출력, ObservableCollection, ICommand 등을 학습하고 활용하기에 적합한 프로젝트입니다.

## 데모
// TODO
// image;


## 기능

1. **할 일(Todo) CRUD 기능**  
   - 새로운 할 일 등록  
   - 할 일 목록 조회  
   - 할 일 수정 / 완료 표시  
   - 할 일 삭제

2. **메모장 기능**  
   - 메모 작성 (여러 줄 텍스트 입력 가능)  
   - 메모 저장 (파일로 저장)  
   - 메모 불러오기 (저장된 파일 로드)

3. **MVVM 패턴 및 데이터 바인딩**  
   - View와 ViewModel 분리  
   - `ObservableCollection`으로 아이템 목록 관리  
   - `RelayCommand` 등을 활용한 Command 바인딩

4. **UI 요소**  
   - Grid, StackPanel 등 WPF 레이아웃  
   - DataTemplate을 통한 항목 표시 커스터마이징  
   - 기본 WPF 스타일, 리소스 활용

## 프로젝트 구조

```plaintext
WpfNoteManager
 ┣ Docs                  // 문서, 이미지 스크린샷 등
 ┣ Models
 │   ┣ TodoItem.cs       // 할 일 모델
 │   ┗ ...
 ┣ ViewModels
 │   ┣ MainViewModel.cs  // 메인 뷰모델 (Todo 관리, 메모 로직)
 │   ┗ ...
 ┣ Views
 │   ┣ MainWindow.xaml   // 메인 화면
 │   ┗ ...
 ┣ Converters            // (선택) BoolToTextDecorationConverter 등
 ┣ Services              // (선택) 파일 저장/로드 서비스, DB 연결 등
 ┣ App.xaml
 ┗ App.xaml.cs
```

## 설치 및 실행
리포지토리 클론

```plaintext
git clone https://github.com/YourUsername/WpfNoteManager.git
cd WpfNoteManager
```
### Visual Studio(또는 Rider 등)에서 솔루션 열기
- WpfNoteManager.sln 파일을 실행 후 로드

### 빌드 및 실행
- Visual Studio 상단 메뉴에서 빌드 > 솔루션 빌드
- 빌드가 성공하면 디버그 > 디버깅 시작 또는 Ctrl + F5 로 실행

## 사용 방법
### 1) Todo 목록
- 상단 입력란에 새로운 할 일(Todo)의 제목을 입력한 뒤 추가 버튼 클릭
- 목록에서 특정 Todo 선택 후 상태(IsDone) 체크 또는 수정 가능
- 삭제 버튼을 통해 목록에서 제거 가능

### 2) 메모장
- 메인 화면에서 메모 입력 가능(예: TextBox, RichTextBox 등)
- 저장 버튼 클릭 시 텍스트 파일(*.txt 등)로 내보내기
- 불러오기 버튼 클릭 시 기존에 저장된 텍스트 파일 로드

## 기술 스택 및 라이브러리
- .NET 6 (또는 .NET 5 / .NET 7 등)
- C# / WPF
- MVVM 패턴
- ObservableCollection / INotifyPropertyChanged
- ICommand / RelayCommand

## 확장 아이디어
- DB 연동: SQLite 등 간단한 DB 연결 후 CRUD 기능 확장
- 검색 & 필터: 할 일 검색, 완료/미완료 분류 필터
- UI 개선: Material Design in XAML, MahApps.Metro 등을 사용해 디자인 개선
- 애니메이션: 항목 추가/삭제 시 애니메이션 적용
- 단축키 지원: 추가, 저장, 불러오기 등 자주 사용하는 기능에 단축키 할당
