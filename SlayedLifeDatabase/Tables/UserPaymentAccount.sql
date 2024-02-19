CREATE TABLE [dbo].[UserPaymentAccount]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX pk_UserPaymentAccount_id,
	[userId] INT NOT NULL CONSTRAINT [FK_UserPaymentAccount_UserId] REFERENCES [User]([Id]) UNIQUE,
	[accountId] VARCHAR(100) NOT NULL UNIQUE,
	[chargesEnabled] BIT NULL, 
    [created] DATETIME2 NOT NULL, 
    [modified] DATETIME2 NULL,
)
GO

CREATE NONCLUSTERED INDEX IX_UserPaymentAccount_UserId ON UserPaymentAccount ([userId])
GO
