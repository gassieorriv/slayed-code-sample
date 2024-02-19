CREATE TABLE [dbo].[SupportNote]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1)  INDEX PK_SuportNote_id,
	[userId] INT NOT NULL CONSTRAINT [FK_SupportNote_UserId] REFERENCES [User]([Id]),
	[note] NVARCHAR(400) NOT NULL,
	[resolved] BIT NOT NULL,
	CreatedDate DATETIME NOT NULL,
	UpdatedDate DATETIME NULL,
	UpdatedBy VARCHAR(100) NULL
)

GO
CREATE NONCLUSTERED INDEX IX_SupportNote_UserId ON SupportNote ([userId])
GO
