# .NetCore-RestApi-UnitOfWork-Repository-Swagger-Example
Using Generic Repository Pattern and Repository Pattern With Unit Of Work Pattern and Dapper with using Swagger In.Net Core Rest Api

Hi Everyone,

This is Example of Using .Net Core RestApi with Dapper(also Dapper Contrip) and Generic Repository Pattern(also special Repository) with Unit Of Work Pattern
include Swagger integration too

I create and test restapi using this(market) database, create script on below.
```sql
USE [market]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 9.07.2019 14:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NULL,
	[Properties] [ntext] NULL,
	[CreationTime] [datetime] NULL,
	[IsRowActive] [bit] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 9.07.2019 14:27:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [ntext] NULL,
	[Properties] [ntext] NULL,
	[Price] [float] NULL,
	[Seller] [ntext] NULL,
	[Brand] [ntext] NULL,
	[CategoryId] [int] NULL,
	[CreationTime] [datetime] NULL,
	[IsRowActive] [bit] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```
