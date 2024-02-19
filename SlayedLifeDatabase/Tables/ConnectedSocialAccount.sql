CREATE TABLE [dbo].[ConnectedSocialAccount]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX PK_ConnectedSocialAccount,
	[userId] INT NOT NULL CONSTRAINT [FK_PK_ConnectedSocialAccount_UserId] REFERENCES [User]([Id]),
	[accountId] VARCHAR(300) NOT NULL,
	[socialAccountId] INT CONSTRAINT [FK_PK_SocialAccount_Id] REFERENCES [SocialAccount]([Id]),
	[token] NVARCHAR(MAX) NULL,
	[refreshToken] NVARCHAR(2000) NULL,
	[secret] NVARCHAR(200) NULL,
	[expires] FLOAT NULL,
	[following] INT NULL,
	[followers] INT NULL,
	[picture] VARCHAR(1500) NULL,
	[name] VARCHAR(100) NULL,
	[active] BIT NOT NULL,
	[createdDate] DATETIME NOT NULL,
	[modifiedDate] DATETIME NULL
)

GO
CREATE NONCLUSTERED INDEX IX_ConnectedSocialAccount_UserId ON ConnectedSocialAccount ([userId])
GO

CREATE NONCLUSTERED INDEX IX_ConnectedSocialAccount_socialAccountId ON socialAccount ([id])
GO


ALTER TABLE [dbo].[ConnectedSocialAccount]
ADD CONSTRAINT uq_ConnectedSocialAccount UNIQUE(userId, accountId, socialAccountId);
GO