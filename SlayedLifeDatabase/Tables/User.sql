CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX PK_User_Id, 
    [userName] NVARCHAR(100) NOT NULL UNIQUE,
    [firstName] VARCHAR(50) NOT NULL, 
    [lastName] VARCHAR(50) NOT NULL, 
    [email] VARCHAR(100) NOT NULL UNIQUE, 
    [phone] VARCHAR(20) NULL, 
    [photo] VARCHAR(MAX) NULL,
    [createdDate] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [createdBy] VARCHAR(50) NOT NULL, 
    [modifiedDate] DATETIME2 NULL DEFAULT GETDATE(), 
    [modifiedBy] VARCHAR(50) NULL, 
    [dob] DATETIME2 NULL 
)
