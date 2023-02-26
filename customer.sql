USE [Test_Invoice]
GO

/****** Object:  Table [dbo].[Customer]    Script Date: 25/02/2023 21:53:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customer](
	[Id] [int] NOT NULL,
	[CustName] [nvarchar](70) NULL,
	[Adress] [nvarchar](120) NULL,
	[Status] [bit] NULL,
	[CustomerTypeId] [int] NULL
) ON [PRIMARY]
GO

