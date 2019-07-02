USE master;  
GO
IF DB_ID ( N'InterviewDb' ) IS  NULL
CREATE DATABASE InterviewDb;  
GO
CREATE TABLE InterviewDb.dbo.Staging( 
   Name NVARCHAR (200),
   Value INT
)      
GO
CREATE TABLE InterviewDb.dbo.Dimension( 
   Id INT IDENTITY(1,1),
   Name NVARCHAR (200),
   Value INT,
   IsDeleted bit,
   CONSTRAINT [PK_Dimension] PRIMARY KEY CLUSTERED 
   (
       Id ASC
   ),
    CONSTRAINT [UQ_Dimension] UNIQUE NONCLUSTERED
   (
       Name
   )
   --CONSTRAINT UC_Dimension UNIQUE (Id,Value)
)  
GO