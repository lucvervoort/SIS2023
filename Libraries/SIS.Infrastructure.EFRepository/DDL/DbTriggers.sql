
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

-- TODO: triggers for other classes
