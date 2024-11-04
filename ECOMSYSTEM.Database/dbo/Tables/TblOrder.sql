CREATE TABLE [dbo].[TblOrder]
(
	[OrderId] BIGINT NOT NULL PRIMARY KEY Identity, 
    [UserId] BIGINT NOT NULL, 
    [ItemId] BIGINT NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Address] NVARCHAR(100) NULL, 
    [Email] NVARCHAR(50) NULL, 
    [Mobile] NVARCHAR(50) NULL, 
    [OderValue] FLOAT NULL, 
    [IsActive] BIT NULL, 
    [OrderStatus] NVARCHAR(50) NULL, 
    [CreatedDate] DATETIME NULL, 
    [ModifiedDate] DATETIME NULL,
    [IsOrderAccept] BIT NULL, 
    [SupplierId] BIGINT NULL, 
    FOREIGN KEY (ItemId) REFERENCES TblItemCart(ItemId),
    FOREIGN KEY (UserId) REFERENCES TblUserRegistration(UserId)
)
