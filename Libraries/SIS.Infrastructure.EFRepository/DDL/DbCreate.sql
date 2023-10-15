﻿-- github code
-- finish 2 teams DDL
-- In classroom: create database on VIC; use VIC in first code version
-- Assignment 1: configure VS Server Explorer
-- Assignment 2: create triggers for your domain and assign PK names; upgrade to bigint
-- Assignment 3: check if data can be uploaded - are all required fields and tables available?
-- Assignment 4: implement "soft delete"

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

	IsDeleted BIT NOT NULL DEFAULT 0

    CONSTRAINT FK_Course_CourseType FOREIGN KEY (CourseTypeId) REFERENCES CourseType(CourseTypeId)
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

   	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0

	CONSTRAINT FK_Topic_TopicCategory FOREIGN KEY (TopicCategoryId) REFERENCES TopicCategory(TopicCategoryId)	
)

if not exists (select * from sysobjects where name='LearningOutcome' and xtype='U')
CREATE TABLE LearningOutcome (
    LearningOutcomeId INT NOT NULL PRIMARY KEY IDENTITY(1,1),	
	Description NVARCHAR(MAX) NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

-- LOTS OF WORK ...

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
-- Persons, students, lectors, IOEM, ...
----------------------------------------

if not exists (select * from sysobjects where name='Person' and xtype='U')
CREATE TABLE Person (
	PersonID int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	FirstName nvarchar(255) NOT NULL, 
	LastName nvarchar(255) NOT NULL, 
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

if not exists (select * from sysobjects where name='LectorType' and xtype='U')
CREATE TABLE LectorType (
   LectorTypeId INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
   Description NVARCHAR(MAX) NOT NULL DEFAULT 'Temporary',

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)

if not exists (select * from sysobjects where name='Lector' and xtype='U')
CREATE TABLE Lector (
	LectorId int IDENTITY(1,1) NOT NULL PRIMARY KEY, 
	Abbreviation NVARCHAR(10) NOT NULL DEFAULT '?',
	Mobile nvarchar(255) NULL,
	Email nvarchar(255) NULL,
	AssignmentPercentage INT NOT NULL DEFAULT 0,
	LectorTypeId INT NOT NULL DEFAULT 1,
	RegistrationStateId INT NOT NULL DEFAULT 1, 
	PersonId int NOT NULL, 

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Lector_Person FOREIGN KEY (PersonId) REFERENCES Person(PersonId),
	CONSTRAINT FK_Lector_LectorType FOREIGN KEY (LectorTypeId) REFERENCES LectorType(LectorTypeId),	
	CONSTRAINT FK_Lector_RegistrationState FOREIGN KEY (RegistrationStateId) REFERENCES RegistrationState(RegistrationStateId)
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

if not exists (select * from sysobjects where name='LectorGroup' and xtype='U')
CREATE TABLE LectorGroup (
	LectorGroupId INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
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

if not exists (select * from sysobjects where name='Lector_LectorGroup' and xtype='U')
CREATE TABLE Lector_LectorGroup (
	Lector_LectorGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	LectorGroupId INT NOT NULL, 
	LectorId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,	

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_Lector_LectorGroup_LectorGroup FOREIGN KEY (LectorGroupId) REFERENCES LectorGroup(LectorGroupId),
	CONSTRAINT FK_Lector_LectorGroup_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId)
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

if not exists (select * from sysobjects where name='LectorPreference' and xtype='U')
CREATE TABLE LectorPreference (
    LectorPreferenceId INT NOT NULL PRIMARY KEY,
    Preference INT NOT NULL DEFAULT 1,
    Description NVARCHAR(MAX),

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,
	
	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='LectorCoordinationRoleInterest' and xtype='U')
CREATE TABLE LectorCoordinationRoleInterest
(
	LectorCoordinationRoleInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	LectorId INT NOT NULL,
	LectorPreferenceId INT NOT NULL,
	CoordinationRoleId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_LectorCoordinationRoleInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_LectorCoordinationRoleInterest_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId),
	CONSTRAINT FK_LectorCoordinationRoleInterest_LectorPreference FOREIGN KEY (LectorPreferenceId) REFERENCES LectorPreference(LectorPreferenceId),
	CONSTRAINT FK_LectorCoordinationRoleInterest_CoordinationRoleId FOREIGN KEY (CoordinationRoleId) REFERENCES CoordinationRole(CoordinationRoleId)
)
GO

if not exists (select * from sysobjects where name='LectorCourseInterest' and xtype='U')
CREATE TABLE LectorCourseInterest
(
	LectorCourseInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	LectorId INT NOT NULL,
	LectorPreferenceId INT NOT NULL,
	CourseId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_LectorCourseInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_LectorCourseInterest_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId),
	CONSTRAINT FK_LectorCourseInterest_LectorPreference FOREIGN KEY (LectorPreferenceId) REFERENCES LectorPreference(LectorPreferenceId),
	CONSTRAINT FK_LectorCourseInterest_Course FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
)
GO

if not exists (select * from sysobjects where name='LectorInterest' and xtype='U')
CREATE TABLE LectorInterest
(
	LectorInterestId INT NOT NULL PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	LectorId INT NOT NULL,
	Description NVARCHAR(MAX),

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_LectorInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_LectorInterest_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId)
)
GO

if not exists (select * from sysobjects where name='LectorLocationInterest' and xtype='U')
CREATE TABLE LectorLocationInterest
(
	LectorLocationInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	AcademicYearId INT NOT NULL,
	LectorId INT NOT NULL,
	LectorPreferenceId INT NOT NULL,
	LocationId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_LectorLocationInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_LectorLocationInterest_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId),
	CONSTRAINT FK_LectorLocationInterest_LectorPreference FOREIGN KEY (LectorPreferenceId) REFERENCES LectorPreference(LectorPreferenceId),
	CONSTRAINT FK_LectorLocationInterest_Course FOREIGN KEY (LocationId) REFERENCES Location(LocationId)
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
	
	-- Lector_ID int not null,
	-- Jaardeel_ID int not null,
	-- Tijdslot int not null,

	Name NVARCHAR(10) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL, 
	StartTime DateTime2(7) NOT NULL,
	StopTime DateTime2(7) NOT NULL,
	
	-- FOREIGN KEY Lector_ID REFERENCES Lector(LectorId), --groep steije
	-- FOREIGN KEY Jaardeel_ID REFERENCES Jaardeel(Jaardeel_ID)
	
	-- tijdslotjes worden in de code omgezet naar het juiste uur
	-- volgens volgende logica:
	-- 6 werkdagen met elk 8 tijdslots = 48 tijdslots (zonder avond les)
	-- Bv lector is beschikbaar voor slot 37:
	-- 37 % 8 = 4
	-- 37 - (8 x 4) = 5
	-- Dus tijdslotje 37 is de 4de dag, 5de slotje, dus op donderdag het 5de lesuur
	
	-- enkel tijdslotjes die door de lector als ok zijn aangeduid worden bijgehouden in de db omdat er toch maar twee opties zijn

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
)
GO

if not exists (select * from sysobjects where name='LectorAssignmentPercentageInterest' and xtype='U')
CREATE TABLE LectorAssignmentPercentageInterest (

	LectorAssignmentPercentageInterestId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,

	AcademicYearId INT NOT NULL,
	LectorId int not null,
	PeriodId int not null,
	Percentage int not null,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0
	
	CONSTRAINT FK_LectorAssignmentPercentageInterest_AcademicYear FOREIGN KEY (AcademicYearId) REFERENCES AcademicYear(AcademicYearId),
	CONSTRAINT FK_LectorAssignmentPercentageInterest_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId),
	CONSTRAINT FK_LectorAssignmentPercentageInterest_Period FOREIGN KEY (PeriodId) REFERENCES Period(PeriodId),
	CONSTRAINT CHK_LectorAssignmentPercentageInterest_Percentage CHECK (Percentage >= 0 AND Percentage<= 100)
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

if not exists (select * from sysobjects where name='CourseGroup_LectorGroup' and xtype='U')
CREATE TABLE CourseGroup_LectorGroup (
    CourseGroup_LectorGroupId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CourseGroupId INT NOT NULL,
    LectorGroupId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_CourseGroup_LectorGroup_LectorGroupId FOREIGN KEY (LectorGroupId) REFERENCES LectorGroup(LectorGroupId),
	CONSTRAINT FK_CourseGroup_LectorGroup_CourseGroupId FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId)
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

if not exists (select * from sysobjects where name='CourseGroup_Lector' and xtype='U')
CREATE TABLE CourseGroup_Lector (
    CourseGroup_LectorId INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CourseGroupId INT NOT NULL,
    LectorId INT NOT NULL,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,

	CONSTRAINT FK_CourseGroup_Lector_LectorId FOREIGN KEY (LectorId) REFERENCES Lector(LectorId),
	CONSTRAINT FK_CourseGroup_Lector_CourseGroupId FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId)
)
GO

if not exists (select * from sysobjects where name='Schedule' and xtype='U')
create TABLE Schedule (
	ScheduleId int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	StartDate DATETIME2(7) not NULL,
	StopDate DATETIME2(7) not null, 
	SchedulingTimeslotId INT NOT NULL,
	CourseId int not null,
	CourseGroupId int not null,
	RoomId int not null,
	LectorId int not null,

	AUTO_TIME_CREATION DateTime2(7) NOT NULL DEFAULT GETDATE(),
	AUTO_TIME_UPDATE DateTime2(7) NOT NULL DEFAULT GETDATE(),	
	AUTO_UPDATE_COUNT int NOT NULL DEFAULT 0,

	IsDeleted BIT NOT NULL DEFAULT 0,
	
	CONSTRAINT FK_Scheduling_Timeslot FOREIGN KEY (SchedulingTimeslotId) REFERENCES SchedulingTimeslot(SchedulingTimeslotId),
	CONSTRAINT FK_Scheduling_Course FOREIGN KEY (CourseId) REFERENCES Course(CourseId),
	CONSTRAINT FK_Scheduling_CourseGroup FOREIGN KEY (CourseGroupId) REFERENCES CourseGroup(CourseGroupId),
	CONSTRAINT FK_Scheduling_Room FOREIGN KEY (RoomId) REFERENCES Room(RoomId),
	CONSTRAINT FK_Scheduling_Lector FOREIGN KEY (LectorId) REFERENCES Lector(LectorId),

	CONSTRAINT CHK_DatumStartBeforeEnd CHECK (StartDate < StopDate)
)
GO

-- Academic calendar: Jeroen

-- LOTS OF WORK...

-- Evaluations, Rubrics - Lari
-- 14/10/2023 niet ontvangen?

-- LOTS OF WORK...

IF EXISTS (select * from sysobjects where name like '%TG_AcademicYear_Update%')
DROP TRIGGER TG_AcademicYear_Update
GO
Create trigger TG_AcademicYear_Update
on AcademicYear after insert, update
as
begin
if update(AcademicYearId) or update(Description) or update(StartDate) or update(StopDate) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN AcademicYear a
        ON a.AcademicYearId = d.AcademicYearId
END 
end
GO


