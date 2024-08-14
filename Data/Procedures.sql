Use ZondaHome
GO
IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AddEmpDetails]') AND type in (N'P', N'PC'))
BEGIN
	EXEC('CREATE PROCEDURE dbo.AddEmpDetails AS SELECT ''stub version, to be replaced''')
END
GO
ALTER PROCEDURE [dbo].[AddEmpDetails]
(
   @FirstName nvarchar(50),
   @LastName nvarchar(50),
   @Department nvarchar(50),
   @Basic DECIMAL(18, 2)
)
AS
BEGIN
   INSERT INTO dbo.Employee(FirstName,LastName,Department,Basic)
   VALUES(@FirstName, @LastName, @Department,@Basic)
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetEmpDetails]') AND type in (N'P', N'PC'))
BEGIN
	EXEC('CREATE PROCEDURE dbo.GetEmpDetails AS SELECT ''stub version, to be replaced''')
END
GO
ALTER PROCEDURE [dbo].[GetEmpDetails]
AS
BEGIN
    SELECT Id,FirstName,LastName,Department,Basic,HRA,DA,TA FROM dbo.Employee
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateEmpDetails]') AND type in (N'P', N'PC'))
BEGIN
	EXEC('CREATE PROCEDURE dbo.UpdateEmpDetails AS SELECT ''stub version, to be replaced''')
END
GO

ALTER PROCEDURE [dbo].[UpdateEmpDetails]
(
   @Id int,
   @FirstName nvarchar(50),
   @LastName nvarchar(50),
   @Department nvarchar(50),
   @Basic DECIMAL(18, 2)
)
AS
BEGIN
   UPDATE dbo.Employee
   SET FirstName = @FirstName,
		LastName = @LastName,
		Department = @Department,
		Basic = @Basic
   WHERE Id = @Id
END

GO

IF NOT EXISTS(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteEmpById]') AND type in (N'P', N'PC'))
BEGIN
	EXEC('CREATE PROCEDURE dbo.DeleteEmpById AS SELECT ''stub version, to be replaced''')
END
GO

CREATE OR ALTER PROCEDURE [dbo].[DeleteEmpById]
(
   @Id int
)
AS
BEGIN
   DELETE FROM dbo.Employee WHERE Id = @Id
END

GO
