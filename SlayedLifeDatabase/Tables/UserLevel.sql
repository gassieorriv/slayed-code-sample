CREATE TABLE [dbo].[UserLevel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX PK_UserLevel_Id,
	[userId] INT NOT NULL CONSTRAINT [FK_UserLevel_UserId] REFERENCES [User]([Id]),
	
)
