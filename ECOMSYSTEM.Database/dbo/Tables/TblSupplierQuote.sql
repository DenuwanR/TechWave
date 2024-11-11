CREATE TABLE [dbo].[TblSupplierQuote] (
    [SupplierQuoteId] [bigint] IDENTITY(1,1) NOT NULL PRIMARY KEY,  -- Unique identifier for the supplier's quote submission
    [QuotationId] BIGINT NOT NULL,          -- References the Quotation
    [SupplierId] [bigint] NULL,  -- Supplier submitting the quotation
    [QuotationAmount] [float] NULL,  -- The amount quoted by the supplier
    [QuotationStatus] varchar(50) NULL,  -- The status of the quotation (e.g., Pending, Accepted, Rejected)
    [CreatedDate] [datetime] NULL,  -- Timestamp when the quotation was created

    -- Foreign Key Constraints
    FOREIGN KEY (QuotationId) REFERENCES TblQuotation(QuotationId),
);
