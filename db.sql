Create database MiniFap5
create table Role (
	RoleID int identity(1, 1) primary key not null,
	RoleName varchar(100) not null
)
create table Class(
	ClassId int identity(1, 1) primary key not null,
	ClassName varchar(50) not null,
)
create table [User] (
	UserId int identity(1, 1) primary key not null,
	Email varchar(255) not null,
	[Password] varchar(255) not null,
	FullName nvarchar(255) not null,
	RoleID int references Role(RoleID),
	StudentID varchar(20),
	ClassId int references Class(ClassId)
)
create table Subject(
	SubjectId varchar(20) primary key not null,
	SubjectName nvarchar(20) not null
)


create table Course(
	CourseId int identity(1, 1) primary key not null,
	CourseName varchar(255) not null,
	LecturerId int references [User](UserId),
	SubjectId varchar(20) references Subject(SubjectId),
)
create table UserCourse(
	CourseId int references Course(CourseId),
	UserId int references [User](UserId),
	PRIMARY KEY (CourseId, UserId)
)
create table Schedule(
	ScheduleId int identity(1, 1) primary key not null,
	Slot int not null,
	[Date] date not null,
	Room varchar(25) not null,
	CourseId int references Course(CourseId)
)