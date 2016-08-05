USE [NHibernatePerformance]
GO

/****** Object:  Table [dbo].[NH_HiLo]    Script Date: 19/07/2015 09:17:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[NH_HiLo](
	[NextHi] [int] NOT NULL,
	[TableKey] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [NHibernatePerformance]
GO

/****** Object:  Table [dbo].[Product]    Script Date: 19/07/2015 09:18:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[Category] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [NHibernatePerformance]
GO

/****** Object:  Table [dbo].[ProductWithHiLo]    Script Date: 19/07/2015 09:18:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductWithHiLo](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[Category] [varchar](20) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

USE [NHibernatePerformance]
GO

/****** Object:  Table [dbo].[ProductWithGuid]    Script Date: 19/07/2015 09:18:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ProductWithGuid](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[Price] [decimal](8, 2) NOT NULL,
	[Category] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ProductWithGuid] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


USE [NHibernatePerformance]
GO

INSERT INTO [dbo].[NH_HiLo]
           ([NextHi]
           ,[TableKey])
     VALUES
           (1
           ,'ProductWithHiLo')
GO
