USE [master]
GO
/****** Object:  Database [Timetable]    Script Date: 05/15/2012 05:47:25 ******/
CREATE DATABASE [Timetable] ON  PRIMARY 
( NAME = N'Timetable', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Timetable.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Timetable_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\Timetable_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Timetable] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Timetable].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Timetable] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Timetable] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Timetable] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Timetable] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Timetable] SET ARITHABORT OFF
GO
ALTER DATABASE [Timetable] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Timetable] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Timetable] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Timetable] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Timetable] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Timetable] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Timetable] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Timetable] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Timetable] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Timetable] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Timetable] SET  DISABLE_BROKER
GO
ALTER DATABASE [Timetable] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Timetable] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Timetable] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Timetable] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Timetable] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Timetable] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Timetable] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Timetable] SET  READ_WRITE
GO
ALTER DATABASE [Timetable] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Timetable] SET  MULTI_USER
GO
ALTER DATABASE [Timetable] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Timetable] SET DB_CHAINING OFF
GO
USE [Timetable]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 05/15/2012 05:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Group] ON
INSERT [dbo].[Group] ([id], [name]) VALUES (1, N'PM                  ')
INSERT [dbo].[Group] ([id], [name]) VALUES (2, N'EK                  ')
INSERT [dbo].[Group] ([id], [name]) VALUES (3, N'MI                  ')
INSERT [dbo].[Group] ([id], [name]) VALUES (4, N'II                  ')
SET IDENTITY_INSERT [dbo].[Group] OFF
/****** Object:  Table [dbo].[Teacher]    Script Date: 05/15/2012 05:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NOT NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON
INSERT [dbo].[Teacher] ([id], [name]) VALUES (1, N'Козинский А. А.                                                                                     ')
INSERT [dbo].[Teacher] ([id], [name]) VALUES (2, N'Шило Т. И.                                                                                          ')
INSERT [dbo].[Teacher] ([id], [name]) VALUES (3, N'Матысик О. В.                                                                                       ')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
/****** Object:  Table [dbo].[Subject]    Script Date: 05/15/2012 05:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Subject] ON
INSERT [dbo].[Subject] ([id], [name]) VALUES (1, N'Programmirovanie                                  ')
INSERT [dbo].[Subject] ([id], [name]) VALUES (2, N'Mat. an.                                          ')
INSERT [dbo].[Subject] ([id], [name]) VALUES (3, N'DU                                                ')
INSERT [dbo].[Subject] ([id], [name]) VALUES (4, N'VMA                                               ')
SET IDENTITY_INSERT [dbo].[Subject] OFF
/****** Object:  Table [dbo].[Subj_Teach]    Script Date: 05/15/2012 05:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subj_Teach](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_subject] [int] NOT NULL,
	[id_teacher] [int] NOT NULL,
 CONSTRAINT [PK_Subj_Teach_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Subj_Teach] ON
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (1, 1, 1)
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (2, 2, 2)
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (3, 3, 3)
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (4, 4, 3)
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (5, 1, 1)
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (6, 1, 1)
INSERT [dbo].[Subj_Teach] ([id], [id_subject], [id_teacher]) VALUES (8, 3, 2)
SET IDENTITY_INSERT [dbo].[Subj_Teach] OFF
/****** Object:  Table [dbo].[Student]    Script Date: 05/15/2012 05:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](100) NOT NULL,
	[id_group] [int] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (1, N'Труцик Э. Л.                                                                                        ', 1)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (2, N'Колдушко А. Ю.                                                                                      ', 1)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (3, N'Гиль Д. И.                                                                                          ', 1)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (4, N'Якута О. В.                                                                                         ', 2)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (5, N'Бовш Е. Н.                                                                                          ', 2)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (6, N'Микитич А. И.                                                                                       ', 3)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (7, N'Пернач А. Н.                                                                                        ', 3)
INSERT [dbo].[Student] ([id], [name], [id_group]) VALUES (8, N'Вася П. П.                                                                                          ', 2)
SET IDENTITY_INSERT [dbo].[Student] OFF
/****** Object:  Table [dbo].[TimeTable]    Script Date: 05/15/2012 05:47:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[id_subj_teach] [int] NOT NULL,
	[id_group] [int] NOT NULL,
 CONSTRAINT [PK_TimeTable] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TimeTable] ON
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (3, CAST(0x0000A037008C1360 AS DateTime), 1, 2)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (5, CAST(0x0000A03700A4CB80 AS DateTime), 2, 1)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (6, CAST(0x0000A03700C042C0 AS DateTime), 3, 1)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (7, CAST(0x0000A03700D8FAE0 AS DateTime), 4, 3)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (8, CAST(0x0000A037008C1360 AS DateTime), 1, 1)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (9, CAST(0x0000A03700A4CB80 AS DateTime), 2, 2)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (10, CAST(0x0000A03700C042C0 AS DateTime), 3, 2)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (11, CAST(0x0000A03700D8FAE0 AS DateTime), 4, 2)
INSERT [dbo].[TimeTable] ([id], [DateTime], [id_subj_teach], [id_group]) VALUES (13, CAST(0x00009E0B00000000 AS DateTime), 6, 1)
SET IDENTITY_INSERT [dbo].[TimeTable] OFF
/****** Object:  ForeignKey [FK_Subj_Teach_Subject]    Script Date: 05/15/2012 05:47:27 ******/
ALTER TABLE [dbo].[Subj_Teach]  WITH CHECK ADD  CONSTRAINT [FK_Subj_Teach_Subject] FOREIGN KEY([id_subject])
REFERENCES [dbo].[Subject] ([id])
GO
ALTER TABLE [dbo].[Subj_Teach] CHECK CONSTRAINT [FK_Subj_Teach_Subject]
GO
/****** Object:  ForeignKey [FK_Subj_Teach_Teacher]    Script Date: 05/15/2012 05:47:27 ******/
ALTER TABLE [dbo].[Subj_Teach]  WITH CHECK ADD  CONSTRAINT [FK_Subj_Teach_Teacher] FOREIGN KEY([id_teacher])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Subj_Teach] CHECK CONSTRAINT [FK_Subj_Teach_Teacher]
GO
/****** Object:  ForeignKey [FK_Student_Group]    Script Date: 05/15/2012 05:47:27 ******/
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Group] FOREIGN KEY([id_group])
REFERENCES [dbo].[Group] ([id])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Group]
GO
/****** Object:  ForeignKey [FK_TimeTable_Group]    Script Date: 05/15/2012 05:47:27 ******/
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Group] FOREIGN KEY([id_group])
REFERENCES [dbo].[Group] ([id])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Group]
GO
/****** Object:  ForeignKey [FK_TimeTable_Subj_Teach1]    Script Date: 05/15/2012 05:47:27 ******/
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [FK_TimeTable_Subj_Teach1] FOREIGN KEY([id_subj_teach])
REFERENCES [dbo].[Subj_Teach] ([id])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [FK_TimeTable_Subj_Teach1]
GO
