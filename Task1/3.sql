CREATE PROCEDURE [dbo].[TestLoadDimension]
-- Add the parameters for the stored procedure here
AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

    -- Insert statements for procedure here
IF OBJECT_ID('actual') IS NOT NULL DROP TABLE actual;
    IF OBJECT_ID('expected') IS NOT NULL DROP TABLE expected;

    EXEC tSQLt.FakeTable 'Staging';
    EXEC tSQLt.FakeTable 'Dimension';
Create TABLE Expected -- Create expected table
(
  Id INT IDENTITY(1,1),
  Name NVARCHAR (200),
  Value INT,
  IsDeleted bit 
)

Create TABLE Actual -- Create actual table
(
  Id INT IDENTITY(1,1),
  Name NVARCHAR (200),
  Value INT,
  IsDeleted bit 
)
INSERT into Dimension (Name,Value,IsDeleted) values ('test3',20,0);
    INSERT INTO Dimension (Name,Value,IsDeleted) values ('test2',5,0)

INSERT into Expected (Name,Value,IsDeleted) values ('test3',20,1);
INSERT into Expected (Name,Value,IsDeleted) values ('test2',10,0);
INSERT into Expected (Name,Value,IsDeleted) values ('test',1,0);


INSERT into Staging (Name,Value) values ('test2',10);
INSERT into Staging (Name,Value) values ('test',1);
exec LoadDimension;
INSERT INTO Actual (Name,Value,IsDeleted) select Name,Value,IsDeleted from Dimension	
EXEC tSQLt.AssertEqualsTable 'Expected', 'Actual';

END