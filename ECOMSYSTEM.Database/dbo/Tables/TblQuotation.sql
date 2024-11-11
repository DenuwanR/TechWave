CREATE TABLE [dbo].[TblQuotation] (
    [QuotationId] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [ItemId] [bigint] NOT NULL,
    [CreatedDate] [datetime] NULL,
    [UserId] [bigint] NULL,
    FOREIGN KEY (ItemId) REFERENCES TblItemCart (ItemId),
);
