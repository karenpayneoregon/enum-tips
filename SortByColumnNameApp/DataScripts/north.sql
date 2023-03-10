USE [master]
GO
/****** Object:  Database [NorthWind2022Short]    Script Date: 1/21/2023 2:53:50 AM ******/
CREATE DATABASE [NorthWind2022Short]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NorthWind2022Short', FILENAME = N'C:\Users\paynek\NorthWind2022Short.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NorthWind2022Short_log', FILENAME = N'C:\Users\paynek\NorthWind2022Short_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [NorthWind2022Short] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NorthWind2022Short].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NorthWind2022Short] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET ARITHABORT OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NorthWind2022Short] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NorthWind2022Short] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NorthWind2022Short] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NorthWind2022Short] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NorthWind2022Short] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [NorthWind2022Short] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NorthWind2022Short] SET  MULTI_USER 
GO
ALTER DATABASE [NorthWind2022Short] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NorthWind2022Short] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NorthWind2022Short] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NorthWind2022Short] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NorthWind2022Short] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NorthWind2022Short] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [NorthWind2022Short] SET QUERY_STORE = OFF
GO
USE [NorthWind2022Short]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 1/21/2023 2:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[ContactId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[ContactTypeIdentifier] [int] NULL,
 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 1/21/2023 2:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactType](
	[ContactTypeIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[ContactTitle] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED 
(
	[ContactTypeIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 1/21/2023 2:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 1/21/2023 2:53:50 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerIdentifier] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](40) NOT NULL,
	[ContactId] [int] NULL,
	[CountryIdentifier] [int] NULL,
	[ContactTypeIdentifier] [int] NULL,
 CONSTRAINT [PK_Customers_1] PRIMARY KEY CLUSTERED 
(
	[CustomerIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (1, N'Maria', N'Anders', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (2, N'Ana', N'Trujillo', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (3, N'Antonio', N'Moreno', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (4, N'Thomas', N'Hardy', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (5, N'Christina', N'Berglund', 6)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (6, N'Hanna', N'Moos', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (7, N'FrÃ©dÃ©rique', N'Citeaux', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (8, N'MartÃ­n', N'Sommer', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (9, N'Laurence', N'Lebihan', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (10, N'Victoria', N'Ashworth', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (11, N'Patricio', N'Simpson', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (12, N'Francisco', N'Chang', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (13, N'Yang', N'Wang', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (14, N'Elizabeth', N'Brown', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (15, N'Sven', N'Ottlieb', 6)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (16, N'Janine', N'Labrune', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (17, N'Ann', N'Devon', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (18, N'Roland', N'Mendel', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (19, N'Die', N'Roel', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (20, N'Martine', N'RancÃ©', 2)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (21, N'Maria', N'Larsson', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (22, N'Peter', N'Franken', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (23, N'Carine', N'Schmitt', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (24, N'Paolo', N'Accorti', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (25, N'Lino', N'Rodriguez', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (26, N'Eduardo', N'Saavedra', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (27, N'JosÃ©', N'Pedro Freyre', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (28, N'Philip', N'Cramer', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (29, N'Daniel', N'Tonini', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (30, N'Annette', N'Roulet', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (31, N'Renate', N'Messner', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (32, N'Giovanni', N'Rovelli', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (33, N'Catherine', N'Dewey', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (34, N'Alexander', N'Feuer', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (35, N'Simon', N'Crowther', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (36, N'Yvonne', N'Moncada', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (37, N'Henriette', N'Pfalzheim', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (38, N'Marie', N'Bertrand', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (39, N'Guillermo', N'FernÃ¡ndez', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (40, N'Georg', N'Pipps', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (41, N'Isabel', N'de Castro', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (42, N'Horst', N'Kloss', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (43, N'Sergio', N'GutiÃ©rrez', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (44, N'Maurizio', N'Moroni', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (45, N'Michael', N'Holz', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (46, N'Alejandra', N'Camino', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (47, N'Jonas', N'Bergulfsen', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (48, N'Hari', N'Kumar', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (49, N'Jytte', N'Petersen', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (50, N'Dominique', N'Perrier', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (51, N'Pascale', N'Cartrain', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (52, N'Karin', N'Josephs', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (53, N'Miguel', N'Angel Paolino', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (54, N'Palle', N'Ibsen', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (55, N'Mary', N'Saveley', 9)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (56, N'Paul', N'Henriot', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (57, N'Rita', N'MÃ¼ller', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (58, N'Pirkko', N'Koskitalo', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (59, N'Matti', N'Karttunen', 8)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (60, N'Zbyszek', N'Piestrzeniewicz', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (61, N'Rene', N'Phillips', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (62, N'Elizabeth', N'Lincoln', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (63, N'Yoshi', N'Tannamuri', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (64, N'Jaime', N'Yorres', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (65, N'Patricia', N'McKenna', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (66, N'Manuel', N'Pereira', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (67, N'Jose', N'Pavarotti', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (68, N'Helen', N'Bennett', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (69, N'Carlos', N'nzÃ¡lez', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (70, N'Liu', N'Wong', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (71, N'Paula', N'Wilson', 3)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (72, N'Felipe', N'Izquierdo', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (73, N'Howard', N'Snyder', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (74, N'Yoshi', N'Latimer', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (75, N'Fran', N'Wilson', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (76, N'Liz', N'Nixon', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (77, N'Jean', N'FresniÃ¨re', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (78, N'Mario', N'Pontes', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (79, N'Bernardo', N'Batista', 1)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (80, N'Janete', N'Limeira', 2)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (81, N'Pedro', N'Afonso', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (82, N'Aria', N'Cruz', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (83, N'AndrÃ©', N'Fonseca', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (84, N'LÃºcia', N'Carvalho', 4)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (85, N'Anabela', N'Domingues', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (86, N'Paula', N'Parente', 11)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (87, N'Carlos', N'HernÃ¡ndez', 12)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (88, N'John', N'Steel', 5)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (89, N'Helvetius', N'Nagy', 10)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (90, N'Karl', N'Jablonski', 7)
INSERT [dbo].[Contacts] ([ContactId], [FirstName], [LastName], [ContactTypeIdentifier]) VALUES (91, N'Art', N'Braunschweiger', 11)
SET IDENTITY_INSERT [dbo].[Contacts] OFF
GO
SET IDENTITY_INSERT [dbo].[ContactType] ON 

INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (1, N'Accounting Manager')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (2, N'Assistant Sales Agent')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (3, N'Assistant Sales Representative')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (4, N'Marketing Assistant')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (5, N'Marketing Manager')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (6, N'Order Administrator')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (7, N'Owner')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (8, N'Owner/Marketing Assistant')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (9, N'Sales Agent')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (10, N'Sales Associate')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (11, N'Sales Manager')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (12, N'Sales Representative')
INSERT [dbo].[ContactType] ([ContactTypeIdentifier], [ContactTitle]) VALUES (13, N'Vice President, Sales
')
SET IDENTITY_INSERT [dbo].[ContactType] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (1, N'Argentina')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (2, N'Austria')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (3, N'Belgium')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (4, N'Brazil')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (5, N'Canada')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (6, N'Denmark')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (7, N'Finland')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (8, N'France')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (9, N'Germany')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (10, N'Ireland')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (11, N'Italy')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (12, N'Mexico')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (13, N'Norway')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (14, N'Poland')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (15, N'Portugal')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (16, N'Spain')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (17, N'Sweden')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (18, N'Switzerland')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (19, N'UK')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (20, N'USA')
INSERT [dbo].[Countries] ([CountryIdentifier], [Name]) VALUES (21, N'Venezuela')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (1, N'Alfreds Futterkiste', 1, 9, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (2, N'Ana Trujillo Emparedados y helados', 2, 12, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (3, N'Antonio Moreno Taquer', 3, 12, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (4, N'Around the Horn', 4, 19, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (5, N'Berglunds snabbk', 5, 17, 6)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (6, N'Blauer See Delikatessen', 6, 8, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (7, N'Blondesddsl pet fils', 7, 9, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (8, N'Blido Comidas preparadas', 8, 16, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (9, N'Bon app', 9, 1, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (10, N'Bs Beverages', 10, 12, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (11, N'Cactus Comidas para llevar', 11, 19, 9)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (12, N'Centro comercial Moctezuma', 12, 1, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (13, N'Chop-suey Chinese', 13, 12, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (14, N'Consolidated Holdings', 14, 19, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (15, N'Drachenblut Delikatessen', 15, 9, 6)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (16, N'Du monde entier', 16, 8, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (17, N'Eastern Connection', 17, 19, 9)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (18, N'Ernst Handel', 18, 2, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (19, N'FISSA Fabrica Inter. Salchichas S.A.', 19, 16, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (20, N'Folies urmandes', 20, 8, 2)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (21, N'Folkoch HB', 21, 17, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (22, N'Frankenversand', 22, 9, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (23, N'France restauration', 23, 8, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (24, N'Franchi S.p.A.', 24, 11, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (25, N'Furia Bacalhau e Frutos do Mar', 25, 15, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (26, N'Galernomo', 26, 16, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (27, N'dos Cocina', 27, 16, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (28, N'Kniglich Essen', 28, 9, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (29, N'La corne', 29, 8, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (30, N'La maison', 30, 8, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (31, N'Lehmanns Marktstand', 31, 9, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (32, N'Magazzini Alimentari Riuniti', 32, 11, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (33, N'Maison Dewey', 33, 3, 9)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (34, N'Morgenstern Gesundkost', 34, 9, 4)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (35, N'North/South', 35, 19, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (36, N'OcLtda.', 36, 1, 9)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (37, N'Ottilies', 37, 9, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (38, N'Paris Inc', 38, 8, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (39, N'Pericles Comidas', 39, 12, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (40, N'Piccolo und mehr', 40, 2, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (41, N'Princesa Isabel Vinhos', 41, 15, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (42, N'QUICK Stop', 42, 9, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (43, N'Rancho grande', 43, 1, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (44, N'Reggiani Caseifici', 44, 11, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (45, N'Richter Supermarkt', 45, 18, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (46, N'Romero y tomillo', 46, 16, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (47, N'Santurmet', 47, 13, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (48, N'Seven Seas Imports', 48, 19, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (49, N'Simons bistro', 49, 6, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (50, N'Spdu monde', 50, 8, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (51, N'Suprlices', 51, 3, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (52, N'Toms Spezialitten', 52, 9, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (53, N'Tortuga Restaurante', 53, 12, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (54, N'Vaffeljernet', 54, 6, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (55, N'Victuailles en stock', 55, 8, 9)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (56, N'Vins et alcools Chevalier', 56, 8, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (57, N'Die Wandernde Kuh', 57, 9, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (58, N'Wartian Herkku', 58, 7, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (59, N'Wilman Kala', 59, 20, 8)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (60, N'Wolski  Zajazd', 60, 14, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (61, N'Old World Delicatessen', 61, 20, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (62, N'Bottom-Dollar Markets', 62, 5, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (63, N'Laughing Bacchus Wine Cellars', 63, 5, 4)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (64, N'Lets Stop N Shop', 64, 20, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (65, N'Hungry Owl All-Night Grocers', 65, 20, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (66, N'GROSELLA-Restaurante', 66, 21, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (67, N'Save-a-lot Markets', 67, 20, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (68, N'Island Trading', 68, 19, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (69, N'LILA-Supermercado', 69, 21, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (70, N'The Cracker Box', 70, 20, 4)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (71, N'Rattlesnake Canyon Grocery', 71, 20, 3)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (72, N'LINO-Delicateses', 72, 21, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (73, N'Great Lakes Food Market', 73, 20, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (74, N'Hungry Coyote Import Store', 74, 20, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (75, N'Lonesome Pine Restaurant', 75, 20, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (76, N'The Big Cheese', 76, 20, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (77, N'Paillarde', 77, 5, 4)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (78, N'Hanari Carnes', 78, 4, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (79, N'Que Del', 79, 4, 1)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (80, N'Ricardo Adocicados', 80, 4, 2)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (81, N'Comrcio Mineiro', 81, 4, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (82, N'Familia Arquibaldo', 82, 4, 4)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (83, N'urmet Lanchonetes', 83, 4, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (84, N'Queen Cozinha', 84, 4, 4)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (85, N'Hipermercados', 85, 4, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (86, N'Wellington Importadora', 86, 4, 11)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (87, N'HILARION-Abastos', 87, 21, 12)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (88, N'Lazy K Kountry Store', 88, 20, 5)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (89, N'Trail Head urmet Provisioners', 89, 20, 10)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (90, N'White Clover Markets', 90, 20, 7)
INSERT [dbo].[Customers] ([CustomerIdentifier], [CompanyName], [ContactId], [CountryIdentifier], [ContactTypeIdentifier]) VALUES (91, N'Split Rail Beer Ale', 91, 20, 11)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
/****** Object:  Index [IX_Contacts_ContactTypeIdentifier]    Script Date: 1/21/2023 2:53:50 AM ******/
CREATE NONCLUSTERED INDEX [IX_Contacts_ContactTypeIdentifier] ON [dbo].[Contacts]
(
	[ContactTypeIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [CompanyName]    Script Date: 1/21/2023 2:53:50 AM ******/
CREATE NONCLUSTERED INDEX [CompanyName] ON [dbo].[Customers]
(
	[CompanyName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customers_ContactId]    Script Date: 1/21/2023 2:53:50 AM ******/
CREATE NONCLUSTERED INDEX [IX_Customers_ContactId] ON [dbo].[Customers]
(
	[ContactId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customers_ContactTypeIdentifier]    Script Date: 1/21/2023 2:53:50 AM ******/
CREATE NONCLUSTERED INDEX [IX_Customers_ContactTypeIdentifier] ON [dbo].[Customers]
(
	[ContactTypeIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Customers_CountryIdentifier]    Script Date: 1/21/2023 2:53:50 AM ******/
CREATE NONCLUSTERED INDEX [IX_Customers_CountryIdentifier] ON [dbo].[Customers]
(
	[CountryIdentifier] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_ContactType] FOREIGN KEY([ContactTypeIdentifier])
REFERENCES [dbo].[ContactType] ([ContactTypeIdentifier])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_ContactType]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([ContactId])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Contacts]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_ContactType] FOREIGN KEY([ContactTypeIdentifier])
REFERENCES [dbo].[ContactType] ([ContactTypeIdentifier])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_ContactType]
GO
ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Countries] FOREIGN KEY([CountryIdentifier])
REFERENCES [dbo].[Countries] ([CountryIdentifier])
GO
ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Countries]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Company' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Customers', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
USE [master]
GO
ALTER DATABASE [NorthWind2022Short] SET  READ_WRITE 
GO
