USE [master]
GO
/****** Object:  Database [Books]    Script Date: 10/28/2022 11:59:18 AM ******/
CREATE DATABASE [Books]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Books', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Books.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Books_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Books_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Books] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Books].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Books] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Books] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Books] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Books] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Books] SET ARITHABORT OFF 
GO
ALTER DATABASE [Books] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Books] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Books] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Books] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Books] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Books] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Books] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Books] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Books] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Books] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Books] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Books] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Books] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Books] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Books] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Books] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Books] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Books] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Books] SET  MULTI_USER 
GO
ALTER DATABASE [Books] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Books] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Books] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Books] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Books] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Books] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Books] SET QUERY_STORE = OFF
GO
USE [Books]
GO
/****** Object:  Table [dbo].[Author_tb]    Script Date: 10/28/2022 11:59:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author_tb](
	[Author_id] [int] NOT NULL,
	[Author_Name] [varchar](50) NOT NULL,
	[Experience_in_years] [int] NOT NULL,
	[Book_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book_tb]    Script Date: 10/28/2022 11:59:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book_tb](
	[Book_id] [int] NOT NULL,
	[Book_Referenceno] [nchar](10) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[No_of_Pages] [int] NOT NULL,
	[No_of_volume] [nchar](10) NOT NULL,
	[publish_date] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[Book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category_tb]    Script Date: 10/28/2022 11:59:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category_tb](
	[Category_id] [int] NOT NULL,
	[Category_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/28/2022 11:59:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Role_Id] [int] NOT NULL,
	[Role_Name] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Role_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[subcategory_tb]    Script Date: 10/28/2022 11:59:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subcategory_tb](
	[Sub_Cat_id] [int] NOT NULL,
	[Sub_Cat_Name] [varchar](50) NOT NULL,
	[Category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Sub_Cat_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/28/2022 11:59:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[User_Id] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Mobile] [nchar](10) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Gender] [varchar](6) NOT NULL,
	[DOB] [date] NOT NULL,
	[Hobbies] [varchar](100) NOT NULL,
	[Profile_pic] [varchar](200) NOT NULL,
	[Role_Id] [int] NULL,
	[password] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Author_tb] ([Author_id], [Author_Name], [Experience_in_years], [Book_id]) VALUES (2, N'Dennis', 20, 2)
GO
INSERT [dbo].[Book_tb] ([Book_id], [Book_Referenceno], [Title], [No_of_Pages], [No_of_volume], [publish_date]) VALUES (1, N'10        ', N'NoteBook', 40, N'3         ', NULL)
INSERT [dbo].[Book_tb] ([Book_id], [Book_Referenceno], [Title], [No_of_Pages], [No_of_volume], [publish_date]) VALUES (2, N'20        ', N'RD Sharma', 80, N'4         ', NULL)
INSERT [dbo].[Book_tb] ([Book_id], [Book_Referenceno], [Title], [No_of_Pages], [No_of_volume], [publish_date]) VALUES (3, N'10        ', N'Book', 40, N'3         ', NULL)
INSERT [dbo].[Book_tb] ([Book_id], [Book_Referenceno], [Title], [No_of_Pages], [No_of_volume], [publish_date]) VALUES (6, N'8         ', N'software', 100, N'2         ', CAST(N'2010-07-07' AS Date))
INSERT [dbo].[Book_tb] ([Book_id], [Book_Referenceno], [Title], [No_of_Pages], [No_of_volume], [publish_date]) VALUES (7, N'12        ', N'dotnet core', 99, N'12        ', CAST(N'1999-10-12' AS Date))
GO
INSERT [dbo].[Category_tb] ([Category_id], [Category_Name]) VALUES (1, N'Notes')
INSERT [dbo].[Category_tb] ([Category_id], [Category_Name]) VALUES (2, N'programming')
GO
INSERT [dbo].[Roles] ([Role_Id], [Role_Name]) VALUES (1, N'admin')
INSERT [dbo].[Roles] ([Role_Id], [Role_Name]) VALUES (2, N'user')
INSERT [dbo].[Roles] ([Role_Id], [Role_Name]) VALUES (3, N'role')
GO
INSERT [dbo].[Users] ([User_Id], [UserName], [Mobile], [Email], [Gender], [DOB], [Hobbies], [Profile_pic], [Role_Id], [password]) VALUES (8, N'mahima', N'8426861410', N'mahima06mahi@gmail.com', N'female', CAST(N'2000-06-07' AS Date), N'sketching', N'Screenshot (32).png', 2, N'ma@1234')
INSERT [dbo].[Users] ([User_Id], [UserName], [Mobile], [Email], [Gender], [DOB], [Hobbies], [Profile_pic], [Role_Id], [password]) VALUES (23, N'asp', N'9878677687', N'a@gmail.com', N'male', CAST(N'1992-01-03' AS Date), N'sketching', N'Screenshot (37).png', 1, N'a@123')
INSERT [dbo].[Users] ([User_Id], [UserName], [Mobile], [Email], [Gender], [DOB], [Hobbies], [Profile_pic], [Role_Id], [password]) VALUES (456, N'userrrrrr', N'6758493929', N'user@mail.com', N'male', CAST(N'1994-02-04' AS Date), N'cricket', N'Profilepic', 3, N'user@23445')
GO
ALTER TABLE [dbo].[Author_tb]  WITH CHECK ADD FOREIGN KEY([Book_id])
REFERENCES [dbo].[Book_tb] ([Book_id])
GO
ALTER TABLE [dbo].[subcategory_tb]  WITH CHECK ADD FOREIGN KEY([Category_id])
REFERENCES [dbo].[Category_tb] ([Category_id])
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD FOREIGN KEY([Role_Id])
REFERENCES [dbo].[Roles] ([Role_Id])
GO
USE [master]
GO
ALTER DATABASE [Books] SET  READ_WRITE 
GO
