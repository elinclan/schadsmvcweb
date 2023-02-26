USE [Test_Invoice]
GO

/****** Object:  Table [dbo].[Invoice]    Script Date: 25/02/2023 21:53:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Invoice](
	[Id] [int] NOT NULL,
	[CustomerId] [int] NULL,
	[TotalItbis] [decimal](18, 0) NULL,
	[SubTotal] [decimal](18, 0) NULL,
	[Total] [decimal](18, 0) NULL
) ON [PRIMARY]
GO

