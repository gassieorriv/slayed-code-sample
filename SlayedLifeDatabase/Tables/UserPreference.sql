CREATE TABLE [dbo].[UserPreference]
(
	[Id] INT NOT NULL IDENTITY(1,1) INDEX PK_UserPreference_Id PRIMARY KEY,
	[userId] INT NOT NULL CONSTRAINT [FK_UserPreference_UserId] REFERENCES [User]([Id]),
	[preferenceId] INT CONSTRAINT [FK_UserPreference_preferenceId] REFERENCES [Preference]([Id]),
	[active] BIT NOT NULL
)

GO
CREATE NONCLUSTERED INDEX IX_UserPreference_UserId ON UserPreference ([userId])
GO

CREATE NONCLUSTERED INDEX IX_UserPreference_preferenceId ON UserPreference ([preferenceId])
GO

ALTER TABLE [dbo].UserPreference
ADD CONSTRAINT uq_UserPreference UNIQUE(userId, preferenceId);
GO