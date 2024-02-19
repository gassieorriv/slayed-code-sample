CREATE TABLE [dbo].[Service]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX PK_Servic_Id,
	[UserId] INT NOT NULL CONSTRAINT [FK_Service_UserId] REFERENCES [User]([Id]),
	[Name] VARCHAR(200) NOT NULL,
	[Description] VARCHAR(2000) NULL, 
    [Images] VARCHAR(2000) NULL, 
    [Price] DECIMAL(18,2) NOT NULL, 
    [TaxId] INT NOT NULL CONSTRAINT [FK_Service_StateTax_Id] REFERENCES [StateTax]([Id]), 
    [Active] BIT NOT NULL, 
    [Deleted] BIT NOT NULL,
    [Discount] INT NULL,
    [Duration] INT NULL,
    [CreatedDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL
)
GO

CREATE NONCLUSTERED INDEX IX_Service_UserId ON [Service] ([UserId])
GO

CREATE NONCLUSTERED INDEX IX_Service_StateTax_Id ON [StateTax] ([Id])
GO
