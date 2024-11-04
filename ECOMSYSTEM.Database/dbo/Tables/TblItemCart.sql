CREATE TABLE [dbo].[TblItemCart]
(
	[ItemId] BIGINT NOT NULL PRIMARY KEY Identity, 
    [ProductId] BIGINT NOT NULL, 
    [UserId] BIGINT NOT NULL, 
    [ItemPrice] FLOAT NULL, 
    [ItemQTY] INT NULL, 
    [IsActive] BIT NULL, 
    [IsInCart] BIT NULL, 
    [CreatedDate] DATETIME NULL,
    [ItemName] NVARCHAR(50) NULL, 
    [ItemDescription] NVARCHAR(300) NULL, 
    FOREIGN KEY (ProductId) REFERENCES TblProducts(ProductId),
    FOREIGN KEY (UserId) REFERENCES TblUserRegistration(UserId)
)
