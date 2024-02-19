CREATE TABLE [dbo].[UserSchedule]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX PK_UserSchedule_Id,
	[UserId] INT NOT NULL CONSTRAINT [FK_UserSchedule_UserId] REFERENCES [User]([Id]),
	[DayOfWeekId] INT NULL CONSTRAINT [FK_UserSchedule_DayOfWeek] REFERENCES [DayOfWeek]([Id]),
	[SpecificDate] DATETIME NULL,
	[StartHour] INT NOT NULL,
	[StartMinute] INT NOT NULL,
	[ClosedHour] INT NOT NULL,
	[ClosedMinute] INT NOT NULL,
	[Deleted] BIT NOT NULL,
	[Closed] BIT NOT NULL,
	CreatedDate DATETIME NOT NULL
)

GO
CREATE NONCLUSTERED INDEX IX_UserSchedule_UserId ON UserSchedule([userId])
GO

CREATE NONCLUSTERED INDEX IX_UserSchedule_DayOfWeek ON [DayOfWeek] ([id])
GO


ALTER TABLE [dbo].[UserSchedule]
ADD CONSTRAINT uq_UserSchedule UNIQUE(UserId, dayOfWeekId, SpecificDate);
GO