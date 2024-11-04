CREATE TABLE [dbo].[TblProducts]
(
	[ProductId] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] VARCHAR(100) NULL, 
    [ProductCategoryId] INT NULL, 
    [ProductSubCategoryId] INT NULL, 
    [Description] NVARCHAR(350) NULL, 
    [Price] FLOAT NULL, 
    [ImageName] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME NULL, 
    [IsActive] BIT NULL
)
