CREATE TABLE [dbo].[ProductSize]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1) INDEX [Pk_ProductSize_Id],
	[ProductId] INT NOT NULL CONSTRAINT [FK_ProudctSize_ProductId] REFERENCES [Product]([Id]),
	[Size] VARCHAR(30) NOT NULL,
	[Quantity] INT NOT NULL,
	[Active] BIT NULL
)
GO

CREATE NONCLUSTERED INDEX IX_ProductSize_ProductId ON [Product] (Id)
GO

ALTER TABLE [dbo].[ProductSize]
ADD CONSTRAINT uq_ProductSize UNIQUE(ProductId, Size);
GO
