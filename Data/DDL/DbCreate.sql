-- 17/10/2023:
--------------
-- ASSIGNMENTS
--------------
-- Assignment 1: get github code - create DevOps project, attach github - send DevOps link to LVET - add LVET to team
-- Assignment 2: configure VIC access / test VIC access; develop using own local SQLServer instance (see ActiveCS)
-- Assignment 3: configure VS Server Explorer - easy to maintain data; study how you can generate json to start from if an input file does not exist
-- Assignment 4: create triggers for your domain and assign PK names in a separate file for each team next to DbTriggers.sql; upgrade to bigint
-- Assignment 5: check if data can be uploaded - are all required fields and tables available?
-- Assignment 6: implement "soft delete"
-- Assignment 7: install EF Tools
-- Assignment 8: implement "logging" (Seq/SeriLog)
-- Assignment 9: test raw sql


/* 
docker pull datalust/seq
docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest

1. Triggers
2. Logging en doc logging opkuisen
*/

-----------
-- CREATION
-----------

-- Courses (Merel)

if not exists (select * from sysobjects where name='AcademicYear' and xtype='U')
CREATE TABLE AcademicYear (
	AcademicYearId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Description NVARCHAR(MAX) NOT NULL,
	StartDate DATETIME2(7) NOT NULL,
	StopDate DATETIME2(7) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT INT NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Trajectory' and xtype='U')
CREATE TABLE Trajectory (
    TrajectoryId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(512) NOT NULL,
	Description NVARCHAR(MAX) NULL,

   	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='CourseType' and xtype='U')
CREATE TABLE CourseType (
    CourseTypeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(512),

   	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Course' and xtype='U')
CREATE TABLE Course (
	CourseId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	LetterId INT NOT NULL,
	Name NVARCHAR(125) NOT NULL,
	CourseTypeId INT NOT NULL,
	Points INT NOT NULL,
	Weight NVARCHAR(125) NOT NULL,
	HoursTotal INT NOT NULL,
	HoursContact INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Course_CourseType FOREIGN KEY (CourseTypeId) REFERENCES CourseType(CourseTypeId)
)
GO

if not exists (select * from sysobjects where name='CourseTrajectory' and xtype='U')
CREATE TABLE CourseTrajectory (
	CourseTrajectoryId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	CourseId INT NOT NULL,
	TrajectoryId INT NOT NULL,
	StudyPoints INT NOT NULL DEFAULT 0,
	StudySheetUrl NVARCHAR(MAX) NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_CourseTrajectory_Course FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
    CONSTRAINT FK_CourseTrajectory_Trajectory FOREIGN KEY (TrajectoryId) REFERENCES Trajectory(TrajectoryId)
)
GO

if not exists (select * from sysobjects where name='TopicCategory' and xtype='U')
CREATE TABLE TopicCategory (
    TopicCategoryId INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	Description NVARCHAR(512) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Topic' and xtype='U')
CREATE TABLE Topic (
    TopicId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    TopicCategoryId INT NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,
	Priority INT NOT NULL,

   	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0

	CONSTRAINT FK_Topic_TopicCategory FOREIGN KEY (TopicCategoryId) REFERENCES TopicCategory(TopicCategoryId)	
)
GO

-- Opleidingsspecifiek or domeinspecifiek
if not exists (select * from sysobjects where name='LearningOutcomeType' and xtype='U')
CREATE TABLE LearningOutcomeType (
    LearningOutcomeTypeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	Name NVARCHAR(125) NOT NULL UNIQUE,
	Description NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='LearningOutcome' and xtype='U')
CREATE TABLE LearningOutcome (
    LearningOutcomeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	Name NVARCHAR(125) NOT NULL UNIQUE,
	Description NVARCHAR(MAX) NOT NULL,
	LearningOutcomeTypeId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_LearningOutcome_LearningOutcomeType FOREIGN KEY (LearningOutcomeTypeId) REFERENCES LearningOutcomeType(LearningOutcomeTypeId)	
)
GO

if not exists (select * from sysobjects where name='ControlLevel' and xtype='U')
CREATE TABLE ControlLevel (
    ControlLevelId INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	Name NVARCHAR(125) NOT NULL UNIQUE,
	Abbreviation NVARCHAR(1) NOT NULL UNIQUE,
	Description NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='LearningTarget' and xtype='U')
CREATE TABLE LearningTarget (
    LearningTargetId INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	Name NVARCHAR(125) NOT NULL UNIQUE,
	Description NVARCHAR(MAX) NOT NULL,
	LearningOutcomeId INT NOT NULL,
	ControlLevelId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0

	CONSTRAINT FK_LearningTarget_LearningOutcome FOREIGN KEY (LearningOutcomeId) REFERENCES LearningOutcome(LearningOutcomeId),
	CONSTRAINT FK_LearningTarget_ControlLevel FOREIGN KEY (ControlLevelId) REFERENCES ControlLevel(ControlLevelId)
)
GO

-- TODO: topics for courses are quoted for students every semester ... Are the topics planned, were they covered (treated, applied, evaluated) for a specific student, ...

-- Notes (Mohammad, Glenn)

if not exists (select * from sysobjects where name='InfoType' and xtype='U')
CREATE TABLE InfoType (
	InfoTypeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(MAX) NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Concept' and xtype='U')
CREATE TABLE Concept (
	ConceptId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	TableName [nvarchar](MAX) NULL,
    Description [nvarchar](MAX) NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Info' and xtype='U')
CREATE TABLE Info (
	[InfoId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ConceptId] [int] NOT NULL,
	[RefKeyId] [int] NOT NULL,
	[InfoTypeId] [int] NOT NULL,
	[Data] [nvarchar](MAX) NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Info_Concept FOREIGN KEY (ConceptId) REFERENCES Concept(ConceptId),
	CONSTRAINT FK_Info_InfoTypeId FOREIGN KEY (InfoTypeId) REFERENCES InfoType(InfoTypeId)
)
GO

----------
-- Address
----------

if not exists (select * from sysobjects where name='Country' and xtype='U')
CREATE TABLE Country
(
	CountryId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(250) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Address' and xtype='U')
CREATE TABLE Address
(
	AddressId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Street NVARCHAR(50) NOT NULL,
	StreetNumber INT NOT NULL,
	Bus INT,
	PostalCode INT NOT NULL,
	City NVARCHAR(50) NOT NULL,
	CountryId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Address_Country FOREIGN KEY (CountryId) REFERENCES Country(CountryId)
)
GO

----------------------------------------
-- Persons, students, Teachers, IOEM, ...
----------------------------------------

if not exists (select * from sysobjects where name='Person' and xtype='U')
CREATE TABLE Person (
	PersonID int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	FirstName nvarchar(255) NOT NULL, 
	LastName nvarchar(255) NOT NULL, 
	SortName nvarchar(255) NOT NULL, 
	Phone nvarchar(255) NULL, 
	Mobile nvarchar(255) NULL,
	Email nvarchar(255) NULL,
	AddressId INT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Person_Address FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
)
GO

if not exists (select * from sysobjects where name='RegistrationState' and xtype='U')
CREATE TABLE RegistrationState (
	RegistrationStateId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Description NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='IOEM' and xtype='U')
Create TABLE IOEM (
	IOEMId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	ShortName NVARCHAR(125) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	Title NVARCHAR(125), 
	Detail NVARCHAR(512), 
	Remark NVARCHAR(MAX),

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Student' and xtype='U')
CREATE TABLE Student (
	StudentId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	OfficialCode BIGINT NOT NULL, 
	RegistrationStateId INT NOT NULL, 
	Mobile nvarchar(255) NULL,
	Email nvarchar(255) NULL,
	PersonId int NOT NULL, 

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Student_Person FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
	CONSTRAINT FK_Student_RegistrationState FOREIGN KEY (RegistrationStateId) REFERENCES RegistrationState(RegistrationStateId)
)
GO

if not exists (select * from sysobjects where name='StudentIOEM' and xtype='U')
CREATE TABLE StudentIOEM (
	StudentIOEMId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	AcademicYearId INT NOT NULL,
	-- Period??
	StudentId INT NOT NULL,
	IOEMId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,	

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_StudentIOEM_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_StudentIOEM_Student FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
	CONSTRAINT FK_StudentIOEM_IOEM FOREIGN KEY (IOEMId) REFERENCES IOEM(IOEMId)
)

if not exists (select * from sysobjects where name='TeacherType' and xtype='U')
CREATE TABLE TeacherType (
   TeacherTypeId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
   Description NVARCHAR(MAX) NOT NULL DEFAULT 'Temporary',

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)

if not exists (select * from sysobjects where name='Teacher' and xtype='U')
CREATE TABLE Teacher (
	TeacherId int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Abbreviation NVARCHAR(10) NOT NULL DEFAULT '?',
	Mobile nvarchar(255) NULL,
	Email nvarchar(255) NULL,
	AssignmentPercentage INT NOT NULL DEFAULT 0,
	TeacherTypeId INT NOT NULL DEFAULT 1,
	RegistrationStateId INT NOT NULL DEFAULT 1, 
	PersonId int NOT NULL, 

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Teacher_Person FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
	CONSTRAINT FK_Teacher_TeacherType FOREIGN KEY (TeacherTypeId) REFERENCES TeacherType(TeacherTypeId),	
	CONSTRAINT FK_Teacher_RegistrationState FOREIGN KEY (RegistrationStateId) REFERENCES RegistrationState(RegistrationStateId)
)
GO

if not exists (select * from sysobjects where name='StudentGroup' and xtype='U')
CREATE TABLE StudentGroup (
	StudentGroupId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Name NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
);

if not exists (select * from sysobjects where name='TeacherGroup' and xtype='U')
CREATE TABLE TeacherGroup (
	TeacherGroupId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Name NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
);

if not exists (select * from sysobjects where name='Student_StudentGroup' and xtype='U')
CREATE TABLE Student_StudentGroup (
	Student_StudentGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	StudentGroupId INT NOT NULL, 
	StudentId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,	

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Student_StudentGroup_StudentGroup FOREIGN KEY (StudentGroupId) REFERENCES StudentGroup(StudentGroupId),
	CONSTRAINT FK_Student_StudentGroup_Student FOREIGN KEY (StudentId) REFERENCES Student(StudentId)
);

if not exists (select * from sysobjects where name='Teacher_TeacherGroup' and xtype='U')
CREATE TABLE Teacher_TeacherGroup (
	Teacher_TeacherGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	TeacherGroupId INT NOT NULL, 
	TeacherId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,	

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Teacher_TeacherGroup_TeacherGroup FOREIGN KEY (TeacherGroupId) REFERENCES TeacherGroup(TeacherGroupId),
	CONSTRAINT FK_Teacher_TeacherGroup_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId)
);

-------------
-- Internship
-------------

if not exists (select * from sysobjects where name='Internship' and xtype='U')
CREATE TABLE Education (
	EducationId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(250) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Company' and xtype='U')
CREATE TABLE Company (
	CompanyId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(250) NOT NULL,
	URL NVARCHAR(MAX) DEFAULT 'https://',
	Phone NVARCHAR(12) DEFAULT '+' UNIQUE,
	Mobile NVARCHAR(12) DEFAULT '+' UNIQUE,	
	Email NVARCHAR(250) NULL UNIQUE,
	VAT NVARCHAR(13),
	EmployeeCount INT NOT NULL,
	Description NVARCHAR(MAX) NULL,
	AddressId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Company_Address FOREIGN KEY (AddressId) REFERENCES Address(AddressId)
)
GO

if not exists (select * from sysobjects where name='Contact' and xtype='U')
CREATE TABLE Contact (
	ContactId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	PersonId INT NOT NULL,
	CompanyId INT NOT NULL,
	Verified DATETIME2 NOT NULL,
	FunctionRole NVARCHAR(512) NOT NULL,
	Department NVARCHAR(512) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Contact_Person FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
	CONSTRAINT FK_Contact_Company FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId),
)

if not exists (select * from sysobjects where name='Internship' and xtype='U')
CREATE TABLE Internship (
	InternshipId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	EducationId INT NOT NULL,
	CompanyId INT NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
    AddressId INT NOT NULL,
	PositionCount INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Internship_Education FOREIGN KEY (EducationId) REFERENCES Education(EducationId),
	CONSTRAINT FK_Internship_Company FOREIGN KEY (CompanyId) REFERENCES Company(CompanyId)
)
GO

if not exists (select * from sysobjects where name='Internship_Contact' and xtype='U')
CREATE TABLE Internship_Contact (
	InternshipId INT NOT NULL,
	ContactId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Internship_Contact_Internship FOREIGN KEY (InternshipId) REFERENCES Internship(InternshipId),
	CONSTRAINT FK_Internship_Contact_Contact FOREIGN KEY (ContactId) REFERENCES Contact(ContactId)
)
GO

------------
-- Buildings
------------

if not exists (select * from sysobjects where name='Campus' and xtype='U')
CREATE TABLE Campus (
	[CampusId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [nvarchar](125) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Location' and xtype='U')
CREATE TABLE Location (
	[LocationId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [nvarchar](125) NOT NULL,
	CampusId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Location_Campus FOREIGN KEY (CampusId) REFERENCES Campus(CampusId)
)
GO

if not exists (select * from sysobjects where name='Building' and xtype='U')
CREATE TABLE Building (
	[BuildingId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	LocationId INT NOT NULL,
	[Name] [nvarchar](125) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Building_Location FOREIGN KEY (LocationId) REFERENCES Location(LocationId)
)
GO

if not exists (select * from sysobjects where name='RoomType' and xtype='U')
CREATE TABLE RoomType (
	[RoomTypeId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [nvarchar](125) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='RoomKind' and xtype='U')
CREATE TABLE RoomKind (
	[RoomKindId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] [nvarchar](125) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,
	
	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='Room' and xtype='U')
CREATE TABLE Room (
	[RoomId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[BuildingId] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoomTypeId] INT NULL,
	[RoomKindId] INT NULL,
	[Capacity] [int] NOT NULL DEFAULT 0,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Room_Building FOREIGN KEY (BuildingId) REFERENCES Building(BuildingId),	
	CONSTRAINT FK_Room_RoomType FOREIGN KEY (RoomTypeId) REFERENCES RoomType(RoomTypeId),	
	CONSTRAINT FK_Room_RoomKind FOREIGN KEY (RoomKindId) REFERENCES RoomKind(RoomKindId)
)
GO

-------------
-- Scheduling
-------------

if not exists (select * from sysobjects where name='CoordinationRole' and xtype='U')
-- Coordination roles
CREATE TABLE CoordinationRole (
    CoordinationRoleId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(125) NOT NULL,
    AssignmentPercentage INT NOT NULL DEFAULT 0,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='TeacherPreference' and xtype='U')
CREATE TABLE TeacherPreference (
    TeacherPreferenceId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Preference INT NOT NULL DEFAULT 1,
    Description NVARCHAR(MAX),

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,
	
	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='TeacherCoordinationRoleInterest' and xtype='U')
CREATE TABLE TeacherCoordinationRoleInterest
(
	TeacherCoordinationRoleInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	TeacherId INT NOT NULL,
	TeacherPreferenceId INT NOT NULL,
	CoordinationRoleId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_TeacherCoordinationRoleInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_TeacherCoordinationRoleInterest_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
	CONSTRAINT FK_TeacherCoordinationRoleInterest_TeacherPreference FOREIGN KEY (TeacherPreferenceId) REFERENCES TeacherPreference(TeacherPreferenceId),
	CONSTRAINT FK_TeacherCoordinationRoleInterest_CoordinationRoleId FOREIGN KEY (CoordinationRoleId) REFERENCES CoordinationRole(CoordinationRoleId)
)
GO

if not exists (select * from sysobjects where name='TeacherCourseInterest' and xtype='U')
CREATE TABLE TeacherCourseInterest
(
	TeacherCourseInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	TeacherId INT NOT NULL,
	TeacherPreferenceId INT NOT NULL,
	CourseId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_TeacherCourseInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_TeacherCourseInterest_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
	CONSTRAINT FK_TeacherCourseInterest_TeacherPreference FOREIGN KEY (TeacherPreferenceId) REFERENCES TeacherPreference(TeacherPreferenceId),
	CONSTRAINT FK_TeacherCourseInterest_Course FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
)
GO

if not exists (select * from sysobjects where name='TeacherInterest' and xtype='U')
CREATE TABLE TeacherInterest
(
	TeacherInterestId INT NOT NULL PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	TeacherId INT NOT NULL,
	Description NVARCHAR(MAX),

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_TeacherInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_TeacherInterest_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId)
)
GO

if not exists (select * from sysobjects where name='TeacherLocationInterest' and xtype='U')
CREATE TABLE TeacherLocationInterest
(
	TeacherLocationInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	TeacherId INT NOT NULL,
	TeacherPreferenceId INT NOT NULL,
	LocationId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_TeacherLocationInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_TeacherLocationInterest_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
	CONSTRAINT FK_TeacherLocationInterest_TeacherPreference FOREIGN KEY (TeacherPreferenceId) REFERENCES TeacherPreference(TeacherPreferenceId),
	CONSTRAINT FK_TeacherLocationInterest_Course FOREIGN KEY (LocationId) REFERENCES Location(LocationId)
)
GO

if not exists (select * from sysobjects where name='Period' and xtype='U')
CREATE TABLE Period (
	
	PeriodId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,
	-- Inhoud is nu Semester 1 en Semester 2, maar staat open voor aanpassingen naar trimesters ed

	IsDeleted BIT NOT NULL DEFAULT 0
);

if not exists (select * from sysobjects where name='SchedulingTimeslot' and xtype='U')
create TABLE SchedulingTimeslot (

	SchedulingTimeslotId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	
	-- Teacher_ID int not null,
	-- Jaardeel_ID int not null,
	-- Tijdslot int not null,

	Name NVARCHAR(10) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL, 
	StartTime DateTime2(7) NOT NULL,
	StopTime DateTime2(7) NOT NULL,
	
	-- FOREIGN KEY Teacher_ID REFERENCES Teacher(TeacherId), --groep steije
	-- FOREIGN KEY Jaardeel_ID REFERENCES Jaardeel(Jaardeel_ID)
	
	-- tijdslotjes worden in de code omgezet naar het juiste uur
	-- volgens volgende logica:
	-- 6 werkdagen met elk 8 tijdslots = 48 tijdslots (zonder avond les)
	-- Bv Teacher is beschikbaar voor slot 37:
	-- 37 % 8 = 4
	-- 37 - (8 x 4) = 5
	-- Dus tijdslotje 37 is de 4de dag, 5de slotje, dus op donderdag het 5de lesuur
	
	-- enkel tijdslotjes die door de Teacher als ok zijn aangeduid worden bijgehouden in de db omdat er toch maar twee opties zijn

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='TeacherAssignmentPercentageInterest' and xtype='U')
CREATE TABLE TeacherAssignmentPercentageInterest (

	TeacherAssignmentPercentageInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

	AcademicYearId INT NOT NULL,
	TeacherId int not null,
	PeriodId int not null,
	Percentage int not null,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
	
	CONSTRAINT FK_TeacherAssignmentPercentageInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_TeacherAssignmentPercentageInterest_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
	CONSTRAINT FK_TeacherAssignmentPercentageInterest_Period FOREIGN KEY (PeriodId) REFERENCES Period(PeriodId),
	CONSTRAINT CHK_TeacherAssignmentPercentageInterest_Percentage CHECK (Percentage >= 0 AND Percentage<= 100)
);

if not exists (select * from sysobjects where name='CourseGroup' and xtype='U')
CREATE TABLE CourseGroup(
	CourseGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='CourseGroup_TeacherGroup' and xtype='U')
CREATE TABLE CourseGroup_TeacherGroup (
    CourseGroup_TeacherGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CourseGroupId INT NOT NULL,
    TeacherGroupId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_CourseGroup_TeacherGroup_TeacherGroupId FOREIGN KEY (TeacherGroupId) REFERENCES TeacherGroup(TeacherGroupId),
	CONSTRAINT FK_CourseGroup_TeacherGroup_CourseGroupId FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId)
)
GO

if not exists (select * from sysobjects where name='CourseGroup_StudentGroup' and xtype='U')
CREATE TABLE CourseGroup_StudentGroup (
    CourseGroup_StudentGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CourseGroupId INT NOT NULL,
    StudentGroupId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_CourseGroup_StudentGroup_StudentGroupId FOREIGN KEY (StudentGroupId) REFERENCES StudentGroup(StudentGroupId),
	CONSTRAINT FK_CourseGroup_StudentGroup_CourseGroupId FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId)
)
GO

if not exists (select * from sysobjects where name='CourseGroup_Student' and xtype='U')
CREATE TABLE CourseGroup_Student (
    CourseGroup_StudentId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CourseGroupId INT NOT NULL,
    StudentId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_CourseGroup_Student_StudentId FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
	CONSTRAINT FK_CourseGroup_Student_CourseGroupId FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId)
)
GO

if not exists (select * from sysobjects where name='CourseGroup_Teacher' and xtype='U')
CREATE TABLE CourseGroup_Teacher (
    CourseGroup_TeacherId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CourseGroupId INT NOT NULL,
    TeacherId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_CourseGroup_Teacher_TeacherId FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),
	CONSTRAINT FK_CourseGroup_Teacher_CourseGroupId FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId)
)
GO

if not exists (select * from sysobjects where name='Schedule' and xtype='U')
create TABLE Schedule (
	ScheduleId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2(7) NOT NULL,
	StopDate DATETIME2(7) NOT NULL, 
	SchedulingTimeslotId INT NOT NULL,
	CourseId INT NOT NULL,
	CourseGroupId INT NOT NULL,
	RoomId INT NOT NULL,
	TeacherId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,
	
	CONSTRAINT FK_Scheduling_Timeslot FOREIGN KEY (SchedulingTimeslotId) REFERENCES SchedulingTimeslot(SchedulingTimeslotId),
	CONSTRAINT FK_Scheduling_Course FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
	CONSTRAINT FK_Scheduling_CourseGroup FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId),
	CONSTRAINT FK_Scheduling_Room FOREIGN KEY (RoomId) REFERENCES Room(RoomId),
	CONSTRAINT FK_Scheduling_Teacher FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId),

	CONSTRAINT CHK_DatumStartBeforeEnd CHECK (StartDate < StopDate)
)
GO

-------
-- Lari - Tests, Rubrics
-------

CREATE TABLE Test (
    TestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	OfficialCode INT NOT NULL,
    CourseId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

CREATE TABLE Score (
    ScoreId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    TotalPercentage DECIMAL(5, 2),
    Total DECIMAL(4, 2),
	TestId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Score_Test FOREIGN KEY (TestId) REFERENCES Test(TestId)
)
GO

CREATE TABLE RubricColumn
(
    RubricColumnId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX),
    Description VARCHAR(MAX),

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

CREATE TABLE RubricRowHeader
(
    RubricRowHeaderId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX),
    Description VARCHAR(MAX),
	RubricRowHeaderParentId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_RubricRowHeader_RubricRowHeader FOREIGN KEY (RubricRowHeaderParentId) REFERENCES RubricRowHeader(RubricRowHeaderId)
)
GO

CREATE TABLE RubricRow
(
    RubricRowId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX),
    Description VARCHAR(MAX),
	MaxScore INT NOT NULL DEFAULT 20,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

CREATE TABLE Rubric (
    RubricId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX),
    Description VARCHAR(MAX),
	MaxScore INT NOT NULL DEFAULT 20,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

CREATE TABLE Rubric_RubricRow
(
    RubricRubricRowId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RubricId INT NOT NULL,
    RubricRowId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Rubric_RubricRow_Rubric FOREIGN KEY (RubricId) REFERENCES Rubric(RubricId),
    CONSTRAINT FK_Rubric_RubricRow_RubricRow FOREIGN KEY (RubricRowId) REFERENCES RubricRow(RubricRowId)
)
GO

CREATE TABLE Rubric_RubricRowHeader
(
    RubricRubricRowHeaderId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RubricId INT NOT NULL,
    RubricRowHeaderId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Rubric_RubricRowHeader_Rubric FOREIGN KEY (RubricId) REFERENCES Rubric(RubricId),
    CONSTRAINT FK_Rubric_RubricRowHeader_RubricRowHeader FOREIGN KEY (RubricRowHeaderId) REFERENCES RubricRowHeader(RubricRowHeaderId)
)
GO

CREATE TABLE Rubric_RubricColumn
(
    RubricRubricColumnId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    RubricId INT NOT NULL,
    RubricColumnId INT NOT NULL,
	RubricHeaderId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_Rubric_RubricColumn_Rubric FOREIGN KEY (RubricId) REFERENCES Rubric(RubricId),
    CONSTRAINT FK_Rubric_RubricColumn_RubricColumn FOREIGN KEY (RubricColumnId) REFERENCES RubricColumn(RubricColumnId),
	CONSTRAINT FK_Rubric_RubricColumn_RubricRowHeader FOREIGN KEY (RubricHeaderId) REFERENCES RubricRowHeader(RubricRowHeaderId)
)
GO

CREATE TABLE RubricInstance (
    RubricInstanceId INT IDENTITY(1,1) PRIMARY KEY,
    AuthorPersonId INT NOT NULL,
	RubricId INT NOT NULL,
	ScorePersonId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_RubricInstance_Rubric FOREIGN KEY (RubricId) REFERENCES Rubric(RubricId),
    CONSTRAINT FK_RubricInstance_AuthorPersonId FOREIGN KEY (AuthorPersonId) REFERENCES Person(PersonId),
    CONSTRAINT FK_RubricInstance_ScorePersonId FOREIGN KEY (ScorePersonId) REFERENCES Person(PersonId)
)
GO

CREATE TABLE RubricInstanceScore (
    RubricInstanceScoreId INT IDENTITY(1,1) PRIMARY KEY,
	RubricInstanceId INT NOT NULL,
	RubricRubricRowId INT NOT NULL,
	RubricRubricColumnId INT NOT NULL,
	Score DECIMAL(8,2) NOT NULL,
	
	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_RubricInstanceScore_RubricInstance FOREIGN KEY (RubricInstanceId) REFERENCES RubricInstance(RubricInstanceId),
    CONSTRAINT FK_RubricInstanceScore_RubricRow FOREIGN KEY (RubricRubricRowId) REFERENCES Rubric_RubricRow(RubricRubricRowId),
    CONSTRAINT FK_RubricInstanceScore_RubricColumn FOREIGN KEY (RubricRubricColumnId) REFERENCES Rubric_RubricColumn(RubricRubricColumnId)
)
GO

CREATE TABLE PresenceState (
    PresenceStateId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(255) NOT NULL,
    Description NVARCHAR(255) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

CREATE TABLE Presence (
    PresenceId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    OfficialCode INT NOT NULL,
	QRCode NVARCHAR(512) NOT NULL,
    PresenceStateId INT NOT NULL,
	PersonId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Presence_Person FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
	CONSTRAINT FK_Presence_PresenceState FOREIGN KEY (PresenceStateId) REFERENCES PresenceState(PresenceStateId)
)
GO

----------------------------
-- Academic calendar: Jeroen
----------------------------


