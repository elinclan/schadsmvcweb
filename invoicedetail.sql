USE [Test_Invoice]
GO

/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 25/02/2023 21:54:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InvoiceDetail](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[InvoiceId] [int] NULL,
	[Qty] [int] NULL,
	[Price] [decimal](18, 0) NULL,
	[TotalItbis] [decimal](18, 0) NULL,
	[SubTotal] [decimal](18, 0) NULL,
	[Total] [decimal](18, 0) NULL
) ON [PRIMARY]
GO

