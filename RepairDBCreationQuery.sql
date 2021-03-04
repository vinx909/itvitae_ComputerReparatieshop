/**/
/*
USE [master]
DROP DATABASE [RepairDB]
CREATE DATABASE [RepairDB]
USE [RepairDB]
GO
**/

/** Object:  Table [dbo].[Customers]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Auth] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Employees]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[PayPerHour] [decimal](16, 2) NOT NULL,
	CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Images]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] VARCHAR(255) NOT NULL,
	[OrderId] [int] NOT NULL,
	CONSTRAINT [PK_ImageList] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/** Object:  Table [dbo].[Orders]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[Description] [varchar](1000) NULL,
	[StartDate] [datetime2](7) NOT NULL,
	[EndDate] [datetime2](7) NULL,
	[HoursWorked] DECIMAL(16, 2) NOT NULL, 
	[ToDo] [bit] NOT NULL,
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Parts]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](16, 2) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[OrderParts]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderParts](
	[OrderId] [int] NOT NULL,
	[PartId] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	CONSTRAINT [PK_Table_5212766990031B67] PRIMARY KEY CLUSTERED (
		[OrderID],[PartId] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
/** Object:  Table [dbo].[Status]    Script Date: 1/29/2021 3:01:54 PM **/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StatusDescription] [varchar](50) NOT NULL,
	[StatusColour] [varchar](7) Not Null,
	CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED (
		[Id] ASC
	) WITH (
		PAD_INDEX = OFF,
		STATISTICS_NORECOMPUTE = OFF,
		IGNORE_DUP_KEY = OFF,
		ALLOW_ROW_LOCKS = ON,
		ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Employee]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Order_Status] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Status] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Order_Status]
GO
ALTER TABLE [dbo].[OrderParts]  WITH CHECK ADD  CONSTRAINT [FK_PartsList_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderParts] CHECK CONSTRAINT [FK_PartsList_Order]
GO
ALTER TABLE [dbo].[OrderParts]  WITH CHECK ADD  CONSTRAINT [FK_PartsList_Part] FOREIGN KEY([PartId])
REFERENCES [dbo].[Parts] ([Id])
GO
ALTER TABLE [dbo].[OrderParts] CHECK CONSTRAINT [FK_PartsList_Part]
GO