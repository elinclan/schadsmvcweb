USE [Test_Invoice]
GO

/****** Object:  Table [dbo].[CustomerTypes]    Script Date: 25/02/2023 21:53:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerTypes](
	[Id] [int] NOT NULL,
	[Description] [nvarchar](70) NULL
) ON [PRIMARY]
GO

