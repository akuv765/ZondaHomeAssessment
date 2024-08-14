Use ZondaHome
GO

IF NOT EXISTS(SELECT * FROM sys.tables WHERE name = 'Employee' AND type = 'U')
BEGIN
CREATE TABLE dbo.Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Department NVARCHAR(50),
    Basic DECIMAL(18, 2),
    HRA AS (Basic * 0.15) PERSISTED,
    DA AS (Basic * 0.10) PERSISTED,
    TA DECIMAL(18, 2) DEFAULT 800
);
END