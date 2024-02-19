CREATE TABLE [dbo].[Preference]
(
	[Id] INT NOT NULL INDEX PK_Preference_Id PRIMARY KEY,
	[name] VARCHAR(100) NOT NULL,
	[levelId] INT NULL CONSTRAINT [FK_Preference_levelId] REFERENCES [Preference]([Id]),
)
