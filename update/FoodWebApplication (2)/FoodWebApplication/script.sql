USE [master]
GO
/****** Object:  Database [DBFoodVNQ]    Script Date: 11/18/2023 12:03:22 PM ******/
CREATE DATABASE [DBFoodVNQ]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBFoodVNQ', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBFoodVNQ.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DBFoodVNQ_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBFoodVNQ_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBFoodVNQ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBFoodVNQ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [DBFoodVNQ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBFoodVNQ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBFoodVNQ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DBFoodVNQ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBFoodVNQ] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [DBFoodVNQ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DBFoodVNQ] SET  MULTI_USER 
GO
ALTER DATABASE [DBFoodVNQ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBFoodVNQ] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBFoodVNQ] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBFoodVNQ] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DBFoodVNQ] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DBFoodVNQ] SET QUERY_STORE = OFF
GO
USE [DBFoodVNQ]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Type] [int] NOT NULL,
	[ImageURL] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Gender] [int] NOT NULL,
	[Avartar] [nvarchar](max) NULL,
	[DateOfBirth] [datetime2](7) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[RestaurantId] [bigint] NOT NULL,
	[ImageURL] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modifier]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modifier](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [float] NOT NULL,
	[FoodId] [bigint] NOT NULL,
	[ImageURL] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Modifier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModifierFood]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModifierFood](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ModifierId] [nvarchar](max) NULL,
	[FoodId] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_ModifierFood] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Qty] [int] NOT NULL,
	[CustomerName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Status] [int] NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [nvarchar](max) NULL,
	[Qty] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[OrderId] [nvarchar](max) NULL,
	[ImageURL] [nvarchar](max) NULL,
	[ProductName] [nvarchar](max) NULL,
	[ProductCode] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OutOfSale]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OutOfSale](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[Qty] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_OutOfSale] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[React]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[React](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[ProductId] [bigint] NOT NULL,
	[IsLike] [bit] NOT NULL,
	[IsShare] [bit] NOT NULL,
	[IsComment] [bit] NOT NULL,
	[Comment] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_React] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CategoryId] [bigint] NOT NULL,
	[ImageURL] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/18/2023 12:03:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](max) NULL,
	[FullName] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[BirthDay] [datetime2](7) NOT NULL,
	[Role] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[UpdatedBy] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[IsDelete] [bit] NOT NULL,
	[IsSupper] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231116022728_InitDB', N'5.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117034035_updateColumn', N'5.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117082405_UpdateColumnRestaurantID', N'5.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231117083839_addTableReact', N'5.0.1')
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [Type], [ImageURL], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'Cơm bình dân', 0, N'/Uploads/Images/f0df096c-cf88-40d3-9225-532246ede481.jpg', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
INSERT [dbo].[Category] ([Id], [Name], [Type], [ImageURL], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (2, N'Buffer', 0, N'/Uploads/Images/3cf013f7-4643-4c28-9597-0ebbc649a071.jpg', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [UserName], [Password], [FirstName], [LastName], [Address], [Email], [Phone], [Gender], [Avartar], [DateOfBirth], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'1113333', N'123', N't1', N'1', N'1', N't', N'111', 0, N'/Uploads/Images/default-image.jpg', CAST(N'2023-11-07T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([Id], [Code], [Name], [Price], [RestaurantId], [ImageURL], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'Com01', N'Cơm cháy rang', 30000, 1, N'/Uploads/Images/e4a88d96-6f2e-472b-aebe-0b4c93d5d902.jpg', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[Modifier] ON 

INSERT [dbo].[Modifier] ([Id], [Code], [Name], [Price], [FoodId], [ImageURL], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'MCom01', N'Tỏi', 5000, 1, N'/Uploads/Images/3dc20bd2-63fa-44f1-a0a0-8169a165a8b1.png', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Modifier] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [Price], [Qty], [CustomerName], [Phone], [Address], [Email], [Status], [Code], [Description], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, CAST(20000.00 AS Decimal(18, 2)), 2, N'guts - tu', N'0989410324', N'HCM', N'tunx@devblock.net', 1, NULL, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Restaurant] ON 

INSERT [dbo].[Restaurant] ([Id], [Name], [CategoryId], [ImageURL], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete]) VALUES (1, N'Nhà Hàng Cơm Hà Nội', 1, N'/Uploads/Images/cd798f68-a02f-4919-a7df-20169999b881.jpg', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Restaurant] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [UserName], [FullName], [Phone], [Email], [Password], [Address], [BirthDay], [Role], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsSupper]) VALUES (-1, N'admin', N'Admin', N'0987654321', N'admin@gmail.com', N'123', NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, CAST(N'2023-11-17T15:38:38.8849837' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 1, 0, 1)
INSERT [dbo].[User] ([Id], [UserName], [FullName], [Phone], [Email], [Password], [Address], [BirthDay], [Role], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsSupper]) VALUES (1, NULL, N'guts tu', N'0989410324', N'tunx@devblock.net', N'123', N'HCM', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, 0)
INSERT [dbo].[User] ([Id], [UserName], [FullName], [Phone], [Email], [Password], [Address], [BirthDay], [Role], [CreatedAt], [UpdatedAt], [CreatedBy], [UpdatedBy], [IsActive], [IsDelete], [IsSupper]) VALUES (3, N'tunx@devblock.net', N'1111211211', N'121', N'121', N'123', N'111', CAST(N'2021-01-01T00:00:00.0000000' AS DateTime2), 1, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Food] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [RestaurantId]
GO
ALTER TABLE [dbo].[Modifier] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [FoodId]
GO
ALTER TABLE [dbo].[Restaurant] ADD  DEFAULT (CONVERT([bigint],(0))) FOR [CategoryId]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsSupper]
GO
USE [master]
GO
ALTER DATABASE [DBFoodVNQ] SET  READ_WRITE 
GO
