USE [master]
GO
/****** Object:  Database [EF.Wines]    Script Date: 3/31/2025 4:19:31 AM ******/
CREATE DATABASE [EF.Wines]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EF.Wines', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EF.Wines.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EF.Wines_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EF.Wines_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EF.Wines] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EF.Wines].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EF.Wines] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EF.Wines] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EF.Wines] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EF.Wines] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EF.Wines] SET ARITHABORT OFF 
GO
ALTER DATABASE [EF.Wines] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EF.Wines] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EF.Wines] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EF.Wines] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EF.Wines] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EF.Wines] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EF.Wines] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EF.Wines] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EF.Wines] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EF.Wines] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EF.Wines] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EF.Wines] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EF.Wines] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EF.Wines] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EF.Wines] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EF.Wines] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EF.Wines] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EF.Wines] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EF.Wines] SET  MULTI_USER 
GO
ALTER DATABASE [EF.Wines] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EF.Wines] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EF.Wines] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EF.Wines] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EF.Wines] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EF.Wines] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EF.Wines] SET QUERY_STORE = OFF
GO
USE [EF.Wines]
GO
/****** Object:  Table [dbo].[Wines]    Script Date: 3/31/2025 4:19:32 AM ******/
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
/****** Object:  Table [dbo].[WineType]    Script Date: 3/31/2025 4:19:32 AM ******/
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
SET IDENTITY_INSERT [dbo].[WineType] OFF
GO
USE [master]
GO
ALTER DATABASE [EF.Wines] SET  READ_WRITE 
GO
