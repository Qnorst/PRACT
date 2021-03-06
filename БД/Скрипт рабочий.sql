USE [master]
GO
/****** Object:  Database [Cafe]    Script Date: 21.04.2022 19:29:05 ******/
CREATE DATABASE [Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cafe', FILENAME = N'C:\Users\gr611_deval\Cafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cafe_log', FILENAME = N'C:\Users\gr611_deval\Cafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cafe] SET  MULTI_USER 
GO
ALTER DATABASE [Cafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cafe] SET QUERY_STORE = OFF
GO
USE [Cafe]
GO
/****** Object:  Table [dbo].[Dish]    Script Date: 21.04.2022 19:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](20) NULL,
	[Price] [money] NULL,
	[Time] [decimal](4, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dish_Order]    Script Date: 21.04.2022 19:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dish_Order](
	[Dish_Id] [int] NOT NULL,
	[Order_Id] [int] NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Dish_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 21.04.2022 19:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CookerStatus] [bit] NULL,
	[WaiterStatus] [bit] NULL,
	[Flunky_Id] [int] NOT NULL,
	[Waiter_Id] [int] NOT NULL,
 CONSTRAINT [PK__Orders__3214EC0756EC5D5E] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 21.04.2022 19:29:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[SecondName] [nvarchar](20) NULL,
	[Login] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[Role] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Dish] ON 

INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (1, N'Суп из брокколи', 380.0000, CAST(30.00 AS Decimal(4, 2)))
INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (2, N'Борщ постный', 380.0000, CAST(30.00 AS Decimal(4, 2)))
INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (3, N'Салат с артишоками', 590.0000, CAST(25.00 AS Decimal(4, 2)))
INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (4, N'Рулет «Весенний»', 350.0000, CAST(30.00 AS Decimal(4, 2)))
INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (5, N'Рататуй овощной', 430.0000, CAST(35.00 AS Decimal(4, 2)))
INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (6, N'Молочный Коктейль', 410.0000, CAST(10.00 AS Decimal(4, 2)))
INSERT [dbo].[Dish] ([Id], [Title], [Price], [Time]) VALUES (7, N'Кофе', 140.0000, CAST(15.00 AS Decimal(4, 2)))
SET IDENTITY_INSERT [dbo].[Dish] OFF
GO
SET IDENTITY_INSERT [dbo].[Dish_Order] ON 

INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (1, 1, 1)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (1, 1, 2)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (4, 1, 3)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (5, 1, 4)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (1, 2, 1004)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (3, 2, 1005)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (5, 2, 1006)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (7, 2, 1007)
INSERT [dbo].[Dish_Order] ([Dish_Id], [Order_Id], [Id]) VALUES (7, 2, 1008)
SET IDENTITY_INSERT [dbo].[Dish_Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [CookerStatus], [WaiterStatus], [Flunky_Id], [Waiter_Id]) VALUES (1, 0, 0, 1, 2)
INSERT [dbo].[Orders] ([Id], [CookerStatus], [WaiterStatus], [Flunky_Id], [Waiter_Id]) VALUES (2, 1, 1, 1, 2)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Login], [Password], [Role]) VALUES (1, N'Тест', N'Поваров', N'Тестович', N'QWE', N'asd', 0)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [SecondName], [Login], [Password], [Role]) VALUES (2, N'Тест', N'Официантов', N'Тестович', N'ASD', N'qwe', 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Dish_Order]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Order_Dish] FOREIGN KEY([Dish_Id])
REFERENCES [dbo].[Dish] ([Id])
GO
ALTER TABLE [dbo].[Dish_Order] CHECK CONSTRAINT [FK_Dish_Order_Dish]
GO
ALTER TABLE [dbo].[Dish_Order]  WITH CHECK ADD  CONSTRAINT [FK_Dish_Order_Orders] FOREIGN KEY([Order_Id])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[Dish_Order] CHECK CONSTRAINT [FK_Dish_Order_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users] FOREIGN KEY([Flunky_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Users1] FOREIGN KEY([Waiter_Id])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Users1]
GO
USE [master]
GO
ALTER DATABASE [Cafe] SET  READ_WRITE 
GO
