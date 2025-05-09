
/****** Object:  Database [EF.Wines]    Script Date: 3/26/2025 10:46:37 AM ******/

/****** Create the database EF.WINES first  ******/
USE [EF.Wines]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wines](
	[WineId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[WineType] [int] NOT NULL,
 CONSTRAINT [PK_Wines] PRIMARY KEY CLUSTERED 
(
	[WineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WineType]    Script Date: 3/26/2025 10:46:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WineType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TypeName] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_WineType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Wines] ON 

INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (1, N'Veuve Clicquot Rose', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (2, N'Whispering Angel Rose', 3)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (3, N'Pinot Grigi', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (4, N'White Zinfandel', 3)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (5, N'Cabernet Sauvignon', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (6, N'Chardonnay Reserve', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (7, N'Merlot Classic', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (8, N'Sauvignon Blanc', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (9, N'Syrah Premium', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (10, N'Blush Zinfandel', 3)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (11, N'Riesling Dry', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (12, N'Grenache Rosé', 3)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (13, N'Malbec Reserve', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (14, N'Pinot Noir', 1)

SET IDENTITY_INSERT [dbo].[Wines] OFF
GO
SET IDENTITY_INSERT [dbo].[WineType] ON 

INSERT [dbo].[WineType] ([Id], [TypeName], [Description]) VALUES (1, N'Red', N'Classic red')
INSERT [dbo].[WineType] ([Id], [TypeName], [Description]) VALUES (2, N'White', N'Dinner white')
INSERT [dbo].[WineType] ([Id], [TypeName], [Description]) VALUES (3, N'Rose', N'Imported rose')
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (5, N'Cabernet Sauvignon', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (6, N'Chardonnay Reserve', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (7, N'Merlot Classic', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (8, N'Sauvignon Blanc', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (9, N'Syrah Premium', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (10, N'Blush Zinfandel', 3)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (11, N'Riesling Dry', 2)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (12, N'Grenache Rosé', 3)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (13, N'Malbec Reserve', 1)
INSERT [dbo].[Wines] ([WineId], [Name], [WineType]) VALUES (14, N'Pinot Noir', 1)
SET IDENTITY_INSERT [dbo].[WineType] OFF
GO
USE [master]
GO
ALTER DATABASE [EF.Wines] SET  READ_WRITE 
GO
