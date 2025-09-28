
USE DBPatientHub
GO

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetPatientsCreatedAfter')
    DROP PROCEDURE GetPatientsCreatedAfter
GO


CREATE PROCEDURE GetPatientsCreatedAfter
    @DateCreated DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT 
        PatientId,
        DocumentType,
        DocumentNumber,
        FirstName,
        LastName,
        BirthDate,
        PhoneNumber,
        Email,
        CreatedAt
    FROM Patients 
    WHERE CreatedAt > @DateCreated
    ORDER BY CreatedAt DESC;
END
GO


GRANT EXECUTE ON GetPatientsCreatedAfter TO PUBLIC;
GO
