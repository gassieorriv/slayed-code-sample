CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY INDEX pk_Product_Id IDENTITY(1, 1),
	[UserId] INT NOT NULL CONSTRAINT [FK_Proudct_UserId] REFERENCES [User]([Id]),
	[Name] VARCHAR(200) NOT NULL,
	[Description] VARCHAR(2000) NULL, 
    [Sku] VARCHAR(50) NOT NULL, 
    [Images] VARCHAR(2000) NULL, 
    [Price] DECIMAL(18,2) NOT NULL, 
    [TaxId] INT NOT NULL CONSTRAINT [FK_StateTax_Id] REFERENCES [StateTax]([Id]), 
    [Shipping] DECIMAL(18, 2) NOT NULL,
    [ShippingType] VARCHAR(20) NULL,
    [DiscountType] VARCHAR(20) NULL,
    [Active] BIT NOT NULL,    
    [Deleted] BIT NOT NULL,
    [Discount] DECIMAL(18, 2) NULL,
    [Category] VARCHAR(50) NULL,
    [CreatedDate] DATETIME NOT NULL,
    [ModifiedDate] DATETIME NULL,
    
)
GO

CREATE NONCLUSTERED INDEX IX_Product_UserId ON [Product] ([UserId])
GO

CREATE NONCLUSTERED INDEX IX_StateTax_Id ON [StateTax] ([Id])
GO

