CREATE TABLE [dbo].[TblQuotation] (
    [QuotationId] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ItemId] [bigint] NOT NULL,
    [SupplierId] [bigint] NULL,
    [QuotationAmount] [float] NULL,
    [CreatedDate] [datetime] NULL,
    [UserId] [bigint] NULL,
    FOREIGN KEY (UserId) REFERENCES TblUserRegistration(UserId),
    FOREIGN KEY (SupplierId) REFERENCES TblUserRegistration (UserId),
    FOREIGN KEY (ItemId) REFERENCES TblItemCart (ItemId)
);
