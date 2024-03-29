USE [master]
GO
/****** Object:  Database [11_DangThuyTrang_CinemaManagement]    Script Date: 1/27/2024 5:04:11 PM ******/
CREATE DATABASE [11_DangThuyTrang_CinemaManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MovieManagementSystem.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MovieManagementSystem_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [11_DangThuyTrang_CinemaManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET  MULTI_USER 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'11_DangThuyTrang_CinemaManagement', N'ON'
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [11_DangThuyTrang_CinemaManagement]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[id] [int] NOT NULL,
	[username] [nvarchar](150) NULL,
	[password] [nvarchar](150) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cast]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cast](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Cast] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feature]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feature](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
	[url] [nvarchar](150) NULL,
 CONSTRAINT [PK_Feature] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Genre] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movie]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movie](
	[id] [int] NOT NULL,
	[title] [nvarchar](150) NULL,
	[description] [nvarchar](300) NULL,
	[director] [nvarchar](150) NULL,
	[length] [int] NULL,
	[language] [nvarchar](150) NULL,
	[purchase_time] [datetime] NULL,
	[rating] [int] NULL,
	[image] [nvarchar](max) NULL,
	[genre_id] [int] NULL,
 CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieCast]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieCast](
	[movie_id] [int] NULL,
	[cast_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentMethod]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentMethod](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
 CONSTRAINT [PK_PaymentMethod] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleFeature]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleFeature](
	[role_id] [int] NULL,
	[feature_id] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seat]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seat](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
	[type] [nvarchar](150) NULL,
	[status] [bit] NULL,
	[showroom_id] [int] NULL,
 CONSTRAINT [PK_Seat] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShowRoom]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowRoom](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
	[number_seat] [int] NULL,
	[type] [nvarchar](150) NULL,
	[status] [bit] NULL,
	[image] [nvarchar](max) NULL,
 CONSTRAINT [PK_ShowRoom] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShowTime]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShowTime](
	[id] [int] NOT NULL,
	[start_time] [datetime] NULL,
	[end_time] [datetime] NULL,
	[showroom_id] [int] NOT NULL,
	[movie_id] [int] NOT NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_ShowTime] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Theater]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Theater](
	[id] [int] NOT NULL,
	[name] [nvarchar](150) NULL,
	[hotline] [nvarchar](150) NULL,
	[address] [nvarchar](150) NULL,
	[showroom_id] [int] NULL,
 CONSTRAINT [PK_Theater] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ticket]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ticket](
	[id] [int] NOT NULL,
	[total_price] [float] NULL,
	[customer_id] [int] NULL,
	[created_time] [datetime] NULL,
	[quantity] [int] NULL,
	[showtime_id] [int] NULL,
	[payment_method_id] [int] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/27/2024 5:04:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] NOT NULL,
	[phone] [nvarchar](150) NULL,
	[email] [nvarchar](150) NULL,
	[address] [nvarchar](150) NULL,
	[status] [bit] NULL,
	[role_id] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Movie]  WITH CHECK ADD  CONSTRAINT [FK_Movie_Genre] FOREIGN KEY([genre_id])
REFERENCES [dbo].[Genre] ([id])
GO
ALTER TABLE [dbo].[Movie] CHECK CONSTRAINT [FK_Movie_Genre]
GO
ALTER TABLE [dbo].[MovieCast]  WITH CHECK ADD  CONSTRAINT [FK_MovieCast_Cast] FOREIGN KEY([cast_id])
REFERENCES [dbo].[Cast] ([id])
GO
ALTER TABLE [dbo].[MovieCast] CHECK CONSTRAINT [FK_MovieCast_Cast]
GO
ALTER TABLE [dbo].[MovieCast]  WITH CHECK ADD  CONSTRAINT [FK_MovieCast_Movie] FOREIGN KEY([movie_id])
REFERENCES [dbo].[Movie] ([id])
GO
ALTER TABLE [dbo].[MovieCast] CHECK CONSTRAINT [FK_MovieCast_Movie]
GO
ALTER TABLE [dbo].[Role]  WITH CHECK ADD  CONSTRAINT [FK_Role_User] FOREIGN KEY([id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Role] CHECK CONSTRAINT [FK_Role_User]
GO
ALTER TABLE [dbo].[RoleFeature]  WITH CHECK ADD  CONSTRAINT [FK_RoleFeature_Feature] FOREIGN KEY([feature_id])
REFERENCES [dbo].[Feature] ([id])
GO
ALTER TABLE [dbo].[RoleFeature] CHECK CONSTRAINT [FK_RoleFeature_Feature]
GO
ALTER TABLE [dbo].[RoleFeature]  WITH CHECK ADD  CONSTRAINT [FK_RoleFeature_Role] FOREIGN KEY([role_id])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[RoleFeature] CHECK CONSTRAINT [FK_RoleFeature_Role]
GO
ALTER TABLE [dbo].[Seat]  WITH CHECK ADD  CONSTRAINT [FK_Seat_ShowRoom] FOREIGN KEY([showroom_id])
REFERENCES [dbo].[ShowRoom] ([id])
GO
ALTER TABLE [dbo].[Seat] CHECK CONSTRAINT [FK_Seat_ShowRoom]
GO
ALTER TABLE [dbo].[ShowTime]  WITH CHECK ADD  CONSTRAINT [FK_ShowTime_Movie] FOREIGN KEY([movie_id])
REFERENCES [dbo].[Movie] ([id])
GO
ALTER TABLE [dbo].[ShowTime] CHECK CONSTRAINT [FK_ShowTime_Movie]
GO
ALTER TABLE [dbo].[ShowTime]  WITH CHECK ADD  CONSTRAINT [FK_ShowTime_ShowRoom] FOREIGN KEY([showroom_id])
REFERENCES [dbo].[ShowRoom] ([id])
GO
ALTER TABLE [dbo].[ShowTime] CHECK CONSTRAINT [FK_ShowTime_ShowRoom]
GO
ALTER TABLE [dbo].[Theater]  WITH CHECK ADD  CONSTRAINT [FK_Theater_ShowRoom] FOREIGN KEY([showroom_id])
REFERENCES [dbo].[ShowRoom] ([id])
GO
ALTER TABLE [dbo].[Theater] CHECK CONSTRAINT [FK_Theater_ShowRoom]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_PaymentMethod] FOREIGN KEY([payment_method_id])
REFERENCES [dbo].[PaymentMethod] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_PaymentMethod]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_Seat] FOREIGN KEY([id])
REFERENCES [dbo].[Seat] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_Seat]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_ShowTime] FOREIGN KEY([showtime_id])
REFERENCES [dbo].[ShowTime] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_ShowTime]
GO
ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_User] FOREIGN KEY([customer_id])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Account] FOREIGN KEY([id])
REFERENCES [dbo].[Account] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Account]
GO
USE [master]
GO
ALTER DATABASE [11_DangThuyTrang_CinemaManagement] SET  READ_WRITE 
GO
