-- TODO: check if all tables have triggers and if all triggers work

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

-- Internship

IF EXISTS (select * from sysobjects where name like '%TG_Company_Update%')
DROP TRIGGER TG_Company_Update
GO
Create trigger TG_Company_Update
on Company after insert, update
as
begin
if update(CompanyId) or update(Name) or update(URL) or update(Phone) or update(Mobile) or update(Email) or update(VAT) or update(EmployeeCount) or update(Description) or update(AddressId) or exists (select * from deleted)
BEGIN
    UPDATE c
        set c.AUTO_UPDATE_COUNT = c.AUTO_UPDATE_COUNT + 1, c.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Company c
        ON c.CompanyId = d.CompanyId
END
end
GO

-----------------------------------------------------------------------------

IF EXISTS (select * from sysobjects where name like '%TG_Education_Update%')
DROP TRIGGER TG_Education_Update
GO

Create trigger TG_Education_Update
on Education after insert, update
as
begin
if update(EducationId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE e
        set e.AUTO_UPDATE_COUNT = e.AUTO_UPDATE_COUNT + 1, e.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Education e
        ON e.EducationId = d.EducationId
END
end
GO

-----------------------------------------------------------------------------------

IF EXISTS (select * from sysobjects where name like '%TG_Internship_Update%')
DROP TRIGGER TG_Internship_Update
GO

Create trigger TG_Internship_Update
on Internship after insert, update
as
begin
if update(InternshipId) or update(EducationId) or update(CompanyId) or update(Description) or update(AddressId) or update(PositionCount) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE i
        set i.AUTO_UPDATE_COUNT = i.AUTO_UPDATE_COUNT + 1, i.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Internship i
        ON i.InternshipId = d.InternshipId
END
end
GO

---------------------------------------------------------------------------

IF EXISTS (select * from sysobjects where name like '%TG_Internship_Contact_Update%')
DROP TRIGGER TG_Internship_Contact_Update
GO

Create trigger TG_Internship_Contact_Update
on Internship_Contact after insert, update
as
begin
if update(InternshipId) or update(ContactId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE i
        set i.AUTO_UPDATE_COUNT = i.AUTO_UPDATE_COUNT + 1, i.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Internship_Contact i
        ON i.InternshipId = d.InternshipId
END
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Contact_Update%')
DROP TRIGGER TG_Contact_Update
GO

Create trigger TG_Contact_Update
on Contact after insert, update
as
begin
if update(ContactId) or update(PersonId) or update(CompanyId) or update(Verified) or update(FunctionRole) or update(Department) or exists (select * from deleted)
BEGIN
   UPDATE c
       set c.AUTO_UPDATE_COUNT = c.AUTO_UPDATE_COUNT + 1, c.AUTO_TIME_UPDATE = GETDATE()
   FROM deleted d
       INNER JOIN Contact c
       ON c.ContactId = d.ContactId
END
end
GO

-- Buildings

IF EXISTS (select * from sysobjects where name like '%TG_Campus_Update%')
DROP TRIGGER TG_Campus_Update
GO
Create trigger TG_Campus_Update
on Campus after insert, update
as
begin
if update(CampusId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
	UPDATE a
		set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
	FROM deleted d
		INNER JOIN Campus a
		ON a.CampusId = d.CampusId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Location_Update%')
DROP TRIGGER TG_Location_Update
GO
Create trigger TG_Location_Update
on Location after insert, update
as
begin
if update(LocationId) or update(Name) or update(CampusId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
	UPDATE a
		set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
	FROM deleted d
		INNER JOIN Location a
		ON a.LocationId = d.LocationId
END 
end

IF exists (select * from sysobjects where name like '%TG_RoomType_Update%')
DROP TRIGGER TG_RoomType_Update
GO
Create trigger TG_RoomType_Update
on RoomType after insert, update
as
begin
if update(RoomTypeId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
	UPDATE a
		set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
	FROM deleted d
		INNER JOIN RoomType a
		ON a.RoomTypeId = d.RoomTypeId
END 
end
GO


IF exists (select * from sysobjects where name like '%TG_RoomKind_Update%')
DROP TRIGGER TG_RoomKind_Update
GO
CREATE TRIGGER TG_RoomKind_Update
on RoomKind after insert, update
as
begin
if update(RoomKindId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
	UPDATE a
		set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
	FROM deleted d 
		INNER JOIN RoomKind a
		ON a.RoomKindId = d.RoomKindId
END 
end
GO

IF exists (select * from sysobjects where name like '%TG_Room_Update%')
DROP TRIGGER TG_Room_Update
GO
CREATE TRIGGER TG_Room_Update
on Room after insert, update
as
begin
if update(RoomId) or update(BuildingId) or update(Name) or update(RoomTypeId) or update(RoomKindId) or update(Capacity) or update(IsDeleted) or exists (select * from deleted)
BEGIN
	UPDATE a
		set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
	FROM deleted d 
		INNER JOIN Room a
		ON a.RoomId = d.RoomId
END 
end

IF EXISTS (select * from sysobjects where name like '%TG_Building_Update%')
DROP TRIGGER TG_Building_Update
GO
Create trigger TG_Building_Update
on Building after insert, update
as
begin
if update(BuildingId) or update(Name) or update(LocationId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
	UPDATE a
		set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
	FROM deleted d
		INNER JOIN Building a
		ON a.BuildingId = d.BuildingId
END 
end
GO

-- DenderValley

IF EXISTS (select * from sysobjects where name like '%TG_RegistrationState%')
DROP TRIGGER TG_RegistrationState_Update
GO
Create trigger TG_RegistrationState_Update
on RegistrationState after insert, update
as
begin
if update(RegistrationStateId) or update(Description) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN RegistrationState a
        ON a.RegistrationStateId = d.RegistrationStateId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_IOEM%')
DROP TRIGGER TG_IOEM_Update
GO
Create trigger TG_IOEM_Update
on IOEM after insert, update
as
begin
if update(IOEMId) or update(Description) or update(ShortName) or update(Title) or update(Detail) or update(Remark) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN IOEM a
        ON a.IOEMId = d.IOEMId
END 
end
GO


IF EXISTS (select * from sysobjects where name like '%TG_Student%')
DROP TRIGGER TG_Student_Update
GO
Create trigger TG_Student_Update
on Student after insert, update
as
begin
if update(StudentId) or update(OfficialCode) or update(RegistrationStateId) or update(Mobile) or update(Email) or update(PersonId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Student a
        ON a.StudentId = d.StudentId
END 
end
GO

-- naming was wrong:
IF EXISTS (select * from sysobjects where name like '%TG_Student_IOEM%')
DROP TRIGGER TG_StudentIOEM_Update
GO
Create trigger TG_StudentIOEM_Update
on StudentIOEM after insert, update
as
begin
if update(StudentIOEMId) or update(AcademicYearId) or update(StudentId) or update(IOEMId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN StudentIOEM a
        ON a.StudentIOEMId = d.StudentIOEMId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_TeacherType%')
DROP TRIGGER TG_TeacherType_Update
GO
Create trigger TG_TeacherType_Update
on TeacherType after insert, update
as
begin
if update(TeacherTypeId) or update(Description) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN TeacherType a
        ON a.TeacherTypeId = d.TeacherTypeId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_StudentGroup%')
DROP TRIGGER TG_StudentGroup_Update
GO
Create trigger TG_StudentGroup_Update
on StudentGroup after insert, update
as
begin
if update(StudentGroupId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN StudentGroup a
        ON a.StudentGroupId = d.StudentGroupId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_TeacherGroup%')
DROP TRIGGER TG_TeacherGroup_Update
GO
Create trigger TG_TeacherGroup_Update
on TeacherGroup after insert, update
as
begin
if update(TeacherGroupId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN TeacherGroup a
        ON a.TeacherGroupId = d.TeacherGroupId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Student_StudentGroup%')
DROP TRIGGER TG_Student_StudentGroup_Update
GO
Create trigger TG_Student_StudentGroup_Update
on Student_StudentGroup after insert, update
as
begin
if update(Student_StudentGroupId) or update(StudentGroupId) or update(StudentId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Student_StudentGroup a
        ON a.Student_StudentGroupId = d.Student_StudentGroupId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Teacher_TeacherGroup%')
DROP TRIGGER TG_Teacher_TeacherGroup_Update
GO
Create trigger TG_Teacher_TeacherGroup_Update
on Teacher_TeacherGroup after insert, update
as
begin
if update(Teacher_TeacherGroupId) or update(TeacherGroupId) or update(TeacherId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Teacher_TeacherGroup a
        ON a.Teacher_TeacherGroupId = d.Teacher_TeacherGroupId
END 
end
GO


IF EXISTS (select * from sysobjects where name like '%TG_Teacher_Update%')
DROP TRIGGER TG_Teacher_Update
GO
Create trigger TG_Teacher_Update
on Teacher after insert, update
as
begin
if update(TeacherId) or update(Abbreviation) or update(Mobile) or update(Email) or update(AssignmentPercentage) or update(TeacherTypeId) or update(RegistrationStateId) or update(PersonId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Teacher a
        ON a.TeacherId = d.TeacherId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Person%')
DROP TRIGGER TG_Person_Update
GO
Create trigger TG_Person_Update
on Person after insert, update
as
begin
if update(PersonID) or update(FirstName) or update(LastName) or update(SortName) or update(Phone) or update(Mobile) or update(Email) or update(AddressId) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE a
        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Person a
        ON a.PersonID = d.PersonID
END 
end
GO

-- BertEnErnie

-- Triggers nodig voor:
-----------------------

-- Onze tabellen zijn te vinden in DbCreate.sql vanaf lijn 660

-- Nathalie:
------------
-- 1 CoordinationRole V
-- 2 TeacherPreference V
-- 3 TeacherCoordinationRoleInterest V
-- 4 TeacherCourseInterest V
-- 5 TeacherInterest V
-- 6 TeacherLocationInterest V
-- 7 Period V
-- 8 SchedulingTimeslot V

-- Ilya:
--------
-- 9 TeacherAssignmentPercentageInterest
-- 10 CourseGroup
-- 11 CourseGroup_TeacherGroup
-- 12 CourseGroup_StudentGroup
-- 13 CourseGroup_Student
-- 14 CourseGroup_Teacher
-- 15 Schedule

--Template:

--IF EXISTS (select * from sysobjects where name like '%TG_AcademicYear_Update%')
--DROP TRIGGER TG_AcademicYear_Update
--GO
--Create trigger TG_AcademicYear_Update
--on AcademicYear after insert, update
--as
--begin
--if update(AcademicYearId) or update(Description) or update(StartDate) or update(StopDate) or update(IsDeleted) or exists (select * from deleted)
--BEGIN
--    UPDATE a
--        set a.AUTO_UPDATE_COUNT = a.AUTO_UPDATE_COUNT + 1, a.AUTO_TIME_UPDATE = GETDATE()
--    FROM deleted d
--        INNER JOIN AcademicYear a
--        ON a.AcademicYearId = d.AcademicYearId
--END
--end
--GO


-- CoordinationRole
IF EXISTS (select *
from sysobjects
where name like '%TG_CoordinationRole_Update%')
DROP TRIGGER TG_CoordinationRole_Update
GO
Create trigger TG_CoordinationRole_Update
on CoordinationRole after insert, update
as
begin
    if update(CoordinationRoleId) or update(Name) or update(AssignmentPercentage) or exists (select *
        from deleted)
BEGIN
        UPDATE c
        set c.AUTO_UPDATE_COUNT = c.AUTO_UPDATE_COUNT + 1, c.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN CoordinationRole c
            ON c.CoordinationRoleId = d.CoordinationRoleId
    END
end
GO

-- TeacherPreference
IF EXISTS (select *
from sysobjects
where name like '%TG_TeacherPreference_Update%')
DROP TRIGGER TG_TeacherPreference_Update
GO
Create trigger TG_TeacherPreference_Update
on TeacherPreference after insert, update
as
begin
    if update(TeacherPreferenceId) or update(Preference) or update(Description) or exists (select *
        from deleted)
BEGIN
        UPDATE tp
        set tp.AUTO_UPDATE_COUNT = tp.AUTO_UPDATE_COUNT + 1, tp.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN TeacherPreference tp
            ON tp.TeacherPreferenceId = d.TeacherPreferenceId
    END
end
GO

-- TeacherCoordinationRoleInterest
IF EXISTS (select *
from sysobjects
where name like '%TG_TeacherCoordinationRoleInterest_Update%')
DROP TRIGGER TG_TeacherCoordinationRoleInterest_Update
GO
Create trigger TG_TeacherCoordinationRoleInterest_Update
on TeacherCoordinationRoleInterest after insert, update
as
begin
    if update(TeacherCoordinationRoleInterestId) or exists (select *
        from deleted)
BEGIN
        UPDATE tc
        set tc.AUTO_UPDATE_COUNT = tc.AUTO_UPDATE_COUNT + 1, tc.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN TeacherCoordinationRoleInterest tc
            ON tc.TeacherCoordinationRoleInterestId = d.TeacherCoordinationRoleInterestId
    END
end
GO
-- TeacherCourseInterest
IF EXISTS (select *
from sysobjects
where name like '%TG_TeacherCourseInterest_Update%')
DROP TRIGGER TG_TeacherCourseInterest_Update
GO
Create trigger TG_TeacherCourseInterest_Update
on TeacherCourseInterest after insert, update
as
begin
    if update(TeacherCourseInterestId) or update(AcademicYearId) or update(TeacherId) or update(TeacherPreferenceId) or update(CourseId) or exists (select *
        from deleted)
BEGIN
        UPDATE tci
        set tci.AUTO_UPDATE_COUNT = tci.AUTO_UPDATE_COUNT + 1, tci.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN TeacherCourseInterest tci
            ON tci.TeacherCourseInterestId = d.TeacherCourseInterestId
    END
end
GO

-- TeacherInterest
IF EXISTS (select *
from sysobjects
where name like '%TG_TeacherInterest_Update%')
DROP TRIGGER TG_TeacherInterest_Update
GO
Create trigger TG_TeacherInterest_Update
on TeacherInterest after insert, update
as
begin
    if update(TeacherInterestId) or update(AcademicYearId) or update(TeacherId) or update(Description) or exists (select *
        from deleted)
BEGIN
        UPDATE ti
        set ti.AUTO_UPDATE_COUNT = ti.AUTO_UPDATE_COUNT + 1, ti.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN TeacherInterest ti
            ON ti.TeacherInterestId = d.TeacherInterestId
    END
end
GO

-- TeacherLocationInterest
IF EXISTS (select *
from sysobjects
where name like '%TG_TeacherLocationInterest_Update%')
DROP TRIGGER TG_TeacherLocationInterest_Update
GO
Create trigger TG_TeacherLocationInterest_Update
on TeacherLocationInterest after insert, update
as
begin
    if update(TeacherLocationInterestId) or update(AcademicYearId) or update(TeacherId) or update(TeacherPreferenceId) or update(LocationId) or exists (select *
        from deleted)
BEGIN
        UPDATE tli
        set tli.AUTO_UPDATE_COUNT = tli.AUTO_UPDATE_COUNT + 1, tli.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN TeacherLocationInterest tli
            ON tli.TeacherLocationInterestid = d.TeacherLocationInterestid
    END
end
GO

-- Period
IF EXISTS (select *
from sysobjects
where name like '%TG_Period_Update%')
DROP TRIGGER TG_Period_Update
GO
Create trigger TG_Period_Update
on Period after insert, update
as
begin
    if update(PeriodId) or update(Name) or exists (select *
        from deleted)
BEGIN
        UPDATE p
        set p.AUTO_UPDATE_COUNT = p.AUTO_UPDATE_COUNT + 1, p.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN Period p
            ON p.PeriodId = d.PeriodId
    END
end
GO

-- SchedulingTimeslot
IF EXISTS (select *
from sysobjects
where name like '%TG_SchedulingTimeslot_Update%')
DROP TRIGGER TG_SchedulingTimeslot_Update
GO
Create trigger TG_SchedulingTimeslot_Update
on SchedulingTimeslot after insert, update
as
begin
    if update(SchedulingTimeslotId) or update(Name) or update(Description) or update(StartTime) or update(StopTime) or exists (select *
        from deleted)
BEGIN
        UPDATE st
        set st.AUTO_UPDATE_COUNT = st.AUTO_UPDATE_COUNT + 1, st.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN SchedulingTimeslot st
            ON st.SchedulingTimeslotId = d.SchedulingTimeslotId
    END
end
GO

-- 9
IF EXISTS (select *
from sysobjects
where name like '%TG_TeacherAssignmentPercentageInterest_Update%')
DROP TRIGGER TG_TeacherAssignmentPercentageInterest_Update
GO
Create trigger TG_TeacherAssignmentPercentageInterest_Update
on TeacherAssignmentPercentageInterest after insert, update
as
begin
    if update(TeacherAssignmentPercentageInterestId) or update(AcademicYearId) or update(TeacherId) or update(PeriodId) or update(Percentage) or exists (select *
        from deleted)
BEGIN
        UPDATE tapi
        set tapi.AUTO_UPDATE_COUNT = tapi.AUTO_UPDATE_COUNT + 1, tapi.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN TeacherAssignmentPercentageInterest tapi
            ON tapi.TeacherAssignmentPercentageInterestId = d.TeacherAssignmentPercentageInterestId
    END
end
GO

-- 10
IF EXISTS (select *
from sysobjects
where name like '%TG_CourseGroup_Update%')
DROP TRIGGER TG_CourseGroup_Update
GO
Create trigger TG_CourseGroup_Update
on CourseGroup after insert, update
as
begin
    if update(CourseGroupId) or update(Name) or exists (select *
        from deleted)
BEGIN
        UPDATE cg
        set cg.AUTO_UPDATE_COUNT = cg.AUTO_UPDATE_COUNT + 1, cg.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN CourseGroup cg
            ON cg.CourseGroupId = d.CourseGroupId
    END
end
GO

-- 11
IF EXISTS (select *
from sysobjects
where name like '%TG_CourseGroup_TeacherGroup_Update%')
DROP TRIGGER TG_CourseGroup_TeacherGroup_Update
GO
Create trigger TG_CourseGroup_TeacherGroup_Update
on CourseGroup_TeacherGroup after insert, update
as
begin
    if update(CourseGroup_TeacherGroupId) or update(CourseGroupId) or update(TeacherGroupId) or exists (select *
        from deleted)
BEGIN
        UPDATE cgtg
        set cgtg.AUTO_UPDATE_COUNT = cgtg.AUTO_UPDATE_COUNT + 1, cgtg.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN CourseGroup_TeacherGroup cgtg
            ON cgtg.CourseGroup_TeacherGroupId = d.CourseGroup_TeacherGroupId
    END
end
GO

-- 12
IF EXISTS (select *
from sysobjects
where name like '%TG_CourseGroup_StudentGroup_Update%')
DROP TRIGGER TG_CourseGroup_StudentGroup_Update
GO
Create trigger TG_CourseGroup_StudentGroup_Update
on CourseGroup_StudentGroup after insert, update
as
begin
    if update(CourseGroup_StudentGroupId) or update(CourseGroupId) or update(StudentGroupId) or exists (select *
        from deleted)
BEGIN
        UPDATE csgs
        set csgs.AUTO_UPDATE_COUNT = csgs.AUTO_UPDATE_COUNT + 1, csgs.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN CourseGroup_StudentGroup csgs
            ON csgs.CourseGroup_StudentGroupId = d.CourseGroup_StudentGroupId
    END
end
GO

-- 13
IF EXISTS (select *
from sysobjects
where name like '%TG_CourseGroup_Student_Update%')
DROP TRIGGER TG_CourseGroup_Student_Update
GO
Create trigger TG_CourseGroup_Student_Update
on CourseGroup_Student after insert, update
as
begin
    if update(CourseGroup_StudentId) or update(CourseGroupId) or update(StudentId) or exists (select *
        from deleted)
BEGIN
        UPDATE cgs
        set cgs.AUTO_UPDATE_COUNT = cgs.AUTO_UPDATE_COUNT + 1, cgs.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN CourseGroup_Student cgs
            ON cgs.CourseGroup_StudentId = d.CourseGroup_StudentId
    END
end
GO

-- 14
IF EXISTS (select *
from sysobjects
where name like '%TG_CourseGroup_Teacher_Update%')
DROP TRIGGER TG_CourseGroup_Teacher_Update
GO
Create trigger TG_CourseGroup_Teacher_Update
on CourseGroup_Teacher after insert, update
as
begin
    if update(CourseGroup_TeacherId) or update(CourseGroupId) or update(TeacherId) or exists (select *
        from deleted)
BEGIN
        UPDATE cgt
        set cgt.AUTO_UPDATE_COUNT = cgt.AUTO_UPDATE_COUNT + 1, cgt.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN CourseGroup_Teacher cgt
            ON cgt.CourseGroup_TeacherId = d.CourseGroup_TeacherId
    END
end
GO

-- 15
IF EXISTS (select *
from sysobjects
where name like '%TG_Schedule_Update%')
DROP TRIGGER TG_Schedule_Update
GO
Create trigger TG_Schedule_Update
on Schedule after insert, update
as
begin
    if update(ScheduleId) or update(StartDate) or update(SchedulingTimeslotId) or update(CourseId) or update(CourseGroupId) or update(RoomId) or update(TeacherId) or update(StopDate) or exists (select *
        from deleted)
BEGIN
        UPDATE s
        set s.AUTO_UPDATE_COUNT = s.AUTO_UPDATE_COUNT + 1, s.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
            INNER JOIN Schedule s
            ON s.ScheduleId = d.ScheduleId
    END
end
GO

-- Jorn

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

IF EXISTS (select * from sysobjects where name like '%TG_Trajectory_Update%')
DROP TRIGGER TG_Trajectory_Update
GO
Create trigger TG_Trajectory_Update
on Trajectory after insert, update
as
begin
if update(TrajectoryId) or update(Name) or update(Description) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE t
        set t.AUTO_UPDATE_COUNT = t.AUTO_UPDATE_COUNT + 1, t.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Trajectory t
        ON t.TrajectoryId = d.TrajectoryId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_CourseType_Update%')
DROP TRIGGER TG_CourseType_Update
GO
Create trigger TG_CourseType_Update
on CourseType after insert, update
as
begin
if update(CourseTypeId) or update(Name) or update(IsDeleted) or exists (select * from deleted)
BEGIN
    UPDATE ct
        set ct.AUTO_UPDATE_COUNT = ct.AUTO_UPDATE_COUNT + 1, ct.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN CourseType ct
        ON ct.CourseTypeId = d.CourseTypeId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Course_Update%')
DROP TRIGGER TG_Course_Update
GO
Create trigger TG_Course_Update
on Course after insert, update
as
begin
if update(CourseId) or update(LetterId) or update(Name) or update(CourseTypeId) or update(Points) or update (Weight) or update(HoursTotal) or update (HoursContact) or exists (select * from deleted)
BEGIN
    UPDATE c
        set c.AUTO_UPDATE_COUNT = c.AUTO_UPDATE_COUNT + 1, c.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Course c
        ON c.CourseId = d.CourseId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_CourseTrajectory_Update%')
DROP TRIGGER TG_CourseTrajectory_Update
GO
Create trigger TG_CourseTrajectory_Update
on CourseTrajectory after insert, update
as
begin
if update(CourseTrajectoryId) or update(CourseId) or update(TrajectoryId) or update(StudyPoints) or update(StudySheetUrl) or exists (select * from deleted)
BEGIN
    UPDATE ctr
        set ctr.AUTO_UPDATE_COUNT = ctr.AUTO_UPDATE_COUNT + 1, ctr.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN CourseTrajectory ctr
        ON ctr.CourseTrajectoryId = d.CourseTrajectoryId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_TopicCategory_Update%')
DROP TRIGGER TG_TopicCategory_Update
GO
Create trigger TG_TopicCategory_Update
on TopicCategory after insert, update
as
begin
if update(TopicCategoryId) or update(Description) or exists (select * from deleted)
BEGIN
    UPDATE tc
        set tc.AUTO_UPDATE_COUNT = tc.AUTO_UPDATE_COUNT + 1, tc.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN TopicCategory tc
        ON tc.TopicCategoryId = d.TopicCategoryId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_Topic_Update%')
DROP TRIGGER TG_Topic_Update
GO
Create trigger TG_Topic_Update
on Topic after insert, update
as
begin
if update(TopicId) or update(TopicCategoryid) or update(Description) or update(Priority) or exists (select * from deleted)
BEGIN
    UPDATE tp
        set tp.AUTO_UPDATE_COUNT = tp.AUTO_UPDATE_COUNT + 1, tp.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN Topic tp
        ON tp.TopicId = d.TopicId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_LearningOutcomeType_Update%')
DROP TRIGGER TG_LearningOutcomeType_Update
GO
Create trigger TG_LearningOutcomeType_Update
on LearningOutcomeType after insert, update
as
begin
if update(LearningOutcomeTypeId) or update(Name) or update(Description) or exists (select * from deleted)
BEGIN
    UPDATE lot
        set lot.AUTO_UPDATE_COUNT = lot.AUTO_UPDATE_COUNT + 1, lot.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN LearningOutcomeType lot
        ON lot.LearningOutcomeTypeId = d.LearningOutcomeTypeId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_LearningOutcome_Update%')
DROP TRIGGER TG_LearningOutcome_Update
GO
Create trigger TG_LearningOutcome_Update
on LearningOutcome after insert, update
as
begin
if update(LearningOutcomeId) or update(Name) or update(Description) or update(LearningOutcomeTypeId) or exists (select * from deleted)
BEGIN
    UPDATE lo
        set lo.AUTO_UPDATE_COUNT = lo.AUTO_UPDATE_COUNT + 1, lo.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN LearningOutcome lo
        ON lo.LearningOutcomeId = d.LearningOutcomeId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_ControlLevel_Update%')
DROP TRIGGER TG_ControlLevel_Update
GO
Create trigger TG_ControlLevel_Update
on ControlLevel after insert, update
as
begin
if update(ControlLevelId) or update(Name) or update(Abbreviation) or update(Description)
BEGIN
    UPDATE cl
        set cl.AUTO_UPDATE_COUNT = cl.AUTO_UPDATE_COUNT + 1, cl.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN ControlLevel cl
        ON cl.ControlLevelId = d.ControlLevelId
END 
end
GO

IF EXISTS (select * from sysobjects where name like '%TG_LearningTarget_Update%')
DROP TRIGGER TG_LearningTarget_Update
GO
Create trigger TG_LearningTarget_Update
on LearningTarget after insert, update
as
begin
if update(LearningTargetId) or update(Name) or update(Description) or update(LearningOutcomeId) or update(ControlLevelId) or exists (select * from deleted)
BEGIN
    UPDATE lt
        set lt.AUTO_UPDATE_COUNT = lt.AUTO_UPDATE_COUNT + 1, lt.AUTO_TIME_UPDATE = GETDATE()
    FROM deleted d
        INNER JOIN LearningTarget lt
        ON lt.LearningTargetId = d.LearningTargetId
END 
end
GO

-- Glen en M

-- InfoType table:

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'TG_InfoType_Update' AND xtype = 'TR')
    DROP TRIGGER TG_InfoType_Update
GO

CREATE TRIGGER TG_InfoType_Update
ON InfoType AFTER INSERT, UPDATE
AS
BEGIN
    IF UPDATE(Name) OR UPDATE(AUTO_TIME_CREATION) OR UPDATE(AUTO_TIME_UPDATE) OR UPDATE(AUTO_UPDATE_COUNT) OR UPDATE(IsDeleted) OR EXISTS (SELECT * FROM deleted)
    BEGIN
        UPDATE i
        SET i.AUTO_UPDATE_COUNT = i.AUTO_UPDATE_COUNT + 1, i.AUTO_TIME_UPDATE = GETDATE()
        FROM deleted d
        INNER JOIN InfoType i
        ON i.InfoTypeId = d.InfoTypeId
    END 
END
GO

------------------------------------------------------


-- Concept Table:

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'TG_Concept_Update' AND xtype = 'TR')
    DROP TRIGGER TG_Concept_Update
GO

CREATE TRIGGER TG_Concept_Update
ON Concept AFTER INSERT, UPDATE
AS
BEGIN
    IF UPDATE(TableName) OR UPDATE(Description) OR UPDATE(AUTO_TIME_CREATION) OR UPDATE(AUTO_TIME_UPDATE) OR UPDATE(AUTO_UPDATE_COUNT) OR UPDATE(IsDeleted) OR EXISTS (SELECT * FROM deleted)
    BEGIN
        UPDATE c
        SET c.AUTO_UPDATE_COUNT = c.AUTO_UPDATE_COUNT + 1, c.AUTO_TIME_UPDATE = GETDATE()
        FROM deleted d
        INNER JOIN Concept c
        ON c.ConceptId = d.ConceptId
    END 
END
GO

--------------------------------------------------------

-- Info Table:

IF EXISTS (SELECT * FROM sysobjects WHERE name = 'TG_Info_Update' AND xtype = 'TR')
    DROP TRIGGER TG_Info_Update
GO

CREATE TRIGGER TG_Info_Update
ON Info AFTER INSERT, UPDATE
AS
BEGIN
    IF UPDATE(ConceptId) OR UPDATE(RefKeyId) OR UPDATE(InfoTypeId) OR UPDATE(Data) OR UPDATE(AUTO_TIME_CREATION) OR UPDATE(AUTO_TIME_UPDATE) OR UPDATE(AUTO_UPDATE_COUNT) OR UPDATE(IsDeleted) OR EXISTS (SELECT * FROM deleted)
    BEGIN
        UPDATE i
        SET i.AUTO_UPDATE_COUNT = i.AUTO_UPDATE_COUNT + 1, i.AUTO_TIME_UPDATE = GETDATE()
        FROM deleted d
        INNER JOIN Info i
        ON i.InfoId = d.InfoId
    END 
END
GO
