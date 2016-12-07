USE [master]
GO
/****** Object:  Database [SUCRMS]    Script Date: 26 Nov 2016 12:09:24 AM ******/
CREATE DATABASE [SUCRMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SUCRMS', FILENAME = N'E:\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SUCRMS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SUCRMS_log', FILENAME = N'E:\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\SUCRMS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SUCRMS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SUCRMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SUCRMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SUCRMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SUCRMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SUCRMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SUCRMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SUCRMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SUCRMS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SUCRMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SUCRMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SUCRMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SUCRMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SUCRMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SUCRMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SUCRMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SUCRMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SUCRMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SUCRMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SUCRMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SUCRMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SUCRMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SUCRMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SUCRMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SUCRMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SUCRMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SUCRMS] SET  MULTI_USER 
GO
ALTER DATABASE [SUCRMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SUCRMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SUCRMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SUCRMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SUCRMS]
GO
/****** Object:  Table [dbo].[AllocateClassrooms]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AllocateClassrooms](
	[AcrId] [int] IDENTITY(1,1) NOT NULL,
	[CourseId] [int] NOT NULL,
	[RoomId] [int] NOT NULL,
	[DayId] [int] NOT NULL,
	[TimeFrom] [time](7) NULL,
	[TimeTo] [time](7) NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_AllocateClassrooms] PRIMARY KEY CLUSTERED 
(
	[AcrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Course]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NULL,
	[CourseName] [varchar](50) NULL,
	[CourseCredit] [numeric](18, 2) NULL,
	[CourseDescription] [text] NULL,
	[DepartmentId] [int] NULL,
	[SemesterId] [int] NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssigntoTeacher]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssigntoTeacher](
	[CatId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_CourseAssigntoTeacher] PRIMARY KEY CLUSTERED 
(
	[CatId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Day]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Day](
	[DayId] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](50) NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[DayId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Department]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DepartmentId] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentCode] [varchar](50) NULL,
	[DepartmentName] [varchar](50) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](50) NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EnrollCourse]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnrollCourse](
	[EcId] [int] IDENTITY(1,1) NOT NULL,
	[StudenId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[Date] [date] NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_EnrollCourse] PRIMARY KEY CLUSTERED 
(
	[EcId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Grade]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grade](
	[GradeId] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](50) NULL,
 CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED 
(
	[GradeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Result]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[GradeId] [int] NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Room]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [nchar](10) NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Semester]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterId] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](50) NULL,
 CONSTRAINT [PK_Semister] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NULL,
	[StudentEmail] [varchar](50) NULL,
	[StudentContactNo] [numeric](18, 0) NULL,
	[Date] [date] NULL,
	[StudentAddress] [text] NULL,
	[RegistrationId] [varchar](50) NULL,
	[DepartmentId] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 26 Nov 2016 12:09:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[TeacherAddress] [text] NULL,
	[TeacherContactNo] [numeric](18, 0) NULL,
	[DesignationId] [int] NULL,
	[DepartmentId] [int] NULL,
	[CreditTobeTaken] [numeric](18, 2) NULL,
	[TeacherEmail] [varchar](50) NULL,
	[RemainingCredit] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[AllocateClassrooms] ON 

INSERT [dbo].[AllocateClassrooms] ([AcrId], [CourseId], [RoomId], [DayId], [TimeFrom], [TimeTo], [Status]) VALUES (1, 2, 1, 1, CAST(0x0700A8E76F4B0000 AS Time), CAST(0x070010ACD1530000 AS Time), 1)
INSERT [dbo].[AllocateClassrooms] ([AcrId], [CourseId], [RoomId], [DayId], [TimeFrom], [TimeTo], [Status]) VALUES (2, 6, 1, 1, CAST(0x07007870335C0000 AS Time), CAST(0x0700E03495640000 AS Time), 1)
INSERT [dbo].[AllocateClassrooms] ([AcrId], [CourseId], [RoomId], [DayId], [TimeFrom], [TimeTo], [Status]) VALUES (4, 2, 2, 2, CAST(0x0700E03495640000 AS Time), CAST(0x070048F9F66C0000 AS Time), 1)
SET IDENTITY_INSERT [dbo].[AllocateClassrooms] OFF
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentId], [SemesterId]) VALUES (2, N'CSE101', N'Basic C', CAST(3.00 AS Numeric(18, 2)), N'testing', 1, 1)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentId], [SemesterId]) VALUES (5, N'EEE101', N'DC Circuit', CAST(3.00 AS Numeric(18, 2)), N'testing', 2, 1)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentId], [SemesterId]) VALUES (6, N'CSE201', N'Discreet Math ', CAST(3.00 AS Numeric(18, 2)), N'test', 1, 3)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentId], [SemesterId]) VALUES (7, N'CSE202', N'Basic Java', CAST(4.00 AS Numeric(18, 2)), N'Java all', 1, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentId], [SemesterId]) VALUES (8, N'ETE101', N'Microwave and Radar', CAST(3.00 AS Numeric(18, 2)), N'ETE', 1002, 1)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [CourseCredit], [CourseDescription], [DepartmentId], [SemesterId]) VALUES (9, N'ETE102', N'Digital Signal and System', CAST(3.00 AS Numeric(18, 2)), N'ETE', 1002, 2)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[CourseAssigntoTeacher] ON 

INSERT [dbo].[CourseAssigntoTeacher] ([CatId], [TeacherId], [CourseId], [Status]) VALUES (2, 1, 2, 1)
INSERT [dbo].[CourseAssigntoTeacher] ([CatId], [TeacherId], [CourseId], [Status]) VALUES (3, 1, 6, 1)
SET IDENTITY_INSERT [dbo].[CourseAssigntoTeacher] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([DayId], [Day]) VALUES (1, N'Sat')
INSERT [dbo].[Day] ([DayId], [Day]) VALUES (2, N'Sun')
INSERT [dbo].[Day] ([DayId], [Day]) VALUES (3, N'Mon')
INSERT [dbo].[Day] ([DayId], [Day]) VALUES (4, N'Tue')
INSERT [dbo].[Day] ([DayId], [Day]) VALUES (5, N'Wed')
INSERT [dbo].[Day] ([DayId], [Day]) VALUES (6, N'Thu')
INSERT [dbo].[Day] ([DayId], [Day]) VALUES (7, N'Fri')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Department] ON 

INSERT [dbo].[Department] ([DepartmentId], [DepartmentCode], [DepartmentName]) VALUES (1, N'CSE', N'Computer Science and Engineering')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentCode], [DepartmentName]) VALUES (2, N'EEE', N'Electrical & Electronics Engineering')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentCode], [DepartmentName]) VALUES (3, N'CE', N'Civil Engineering')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentCode], [DepartmentName]) VALUES (4, N'ME', N'Mechanical Engineering')
INSERT [dbo].[Department] ([DepartmentId], [DepartmentCode], [DepartmentName]) VALUES (1002, N'ETE', N'Electronics & Telecommunication Engineering')
SET IDENTITY_INSERT [dbo].[Department] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (1, N'Lecturer')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (2, N'Serior Lecturer')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (3, N'Professor')
INSERT [dbo].[Designation] ([DesignationId], [DesignationName]) VALUES (4, N'Head of Department')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[EnrollCourse] ON 

INSERT [dbo].[EnrollCourse] ([EcId], [StudenId], [CourseId], [Date], [Status]) VALUES (1, 1, 2, CAST(0x243C0B00 AS Date), 1)
INSERT [dbo].[EnrollCourse] ([EcId], [StudenId], [CourseId], [Date], [Status]) VALUES (2, 2, 2, CAST(0x243C0B00 AS Date), 1)
INSERT [dbo].[EnrollCourse] ([EcId], [StudenId], [CourseId], [Date], [Status]) VALUES (3, 3, 5, CAST(0x243C0B00 AS Date), 1)
INSERT [dbo].[EnrollCourse] ([EcId], [StudenId], [CourseId], [Date], [Status]) VALUES (4, 1, 6, CAST(0x233C0B00 AS Date), 1)
SET IDENTITY_INSERT [dbo].[EnrollCourse] OFF
SET IDENTITY_INSERT [dbo].[Grade] ON 

INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (1, N'A+')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (2, N'A')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (3, N'A-')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (4, N'B+')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (5, N'B')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (6, N'B-')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (7, N'C+')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (8, N'C')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (9, N'C-')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (10, N'D+')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (11, N'D')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (12, N'D-')
INSERT [dbo].[Grade] ([GradeId], [Grade]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[Grade] OFF
SET IDENTITY_INSERT [dbo].[Result] ON 

INSERT [dbo].[Result] ([ResultId], [StudentId], [CourseId], [GradeId]) VALUES (1, 1, 2, 1)
INSERT [dbo].[Result] ([ResultId], [StudentId], [CourseId], [GradeId]) VALUES (2, 2, 2, 2)
SET IDENTITY_INSERT [dbo].[Result] OFF
SET IDENTITY_INSERT [dbo].[Room] ON 

INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (1, N'R-101     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (2, N'R-102     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (3, N'R-103     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (4, N'R-201     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (5, N'R-202     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (6, N'R-203     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (7, N'R-301     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (8, N'R-302     ')
INSERT [dbo].[Room] ([RoomId], [RoomNo]) VALUES (9, N'R-303     ')
SET IDENTITY_INSERT [dbo].[Room] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (1, N'1.1')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (2, N'1.2')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (3, N'2.1')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (4, N'2.2')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (5, N'3.1')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (6, N'3.2')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (7, N'4.1')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (8, N'4.2')
SET IDENTITY_INSERT [dbo].[Semester] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (1, N'Prakash', N'prakash@gmail.com', CAST(1671340328 AS Numeric(18, 0)), CAST(0x193C0B00 AS Date), N'dhaka', N'CSE-2016-001', 1)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (2, N'Dolar', N'dolar@google.com', CAST(987654321 AS Numeric(18, 0)), CAST(0x233C0B00 AS Date), N'Bogra', N'CSE-2016-002', 1)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (3, N'Nayem', N'nayem@google.com', CAST(912345678 AS Numeric(18, 0)), CAST(0x223C0B00 AS Date), N'Komilla', N'EEE-2016-001', 2)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (4, N'Parash', N'parash@gmail.com', CAST(9876345671 AS Numeric(18, 0)), CAST(0x243C0B00 AS Date), N'Dhaka', N'EEE-2016-002', 2)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (5, N'Rubel', N'rubel@gmail.com', CAST(98765412536 AS Numeric(18, 0)), CAST(0x253C0B00 AS Date), N'Tangail', N'CE-2016-001', 3)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (6, N'Tushar', N'tushar@gmail.com', CAST(987554333 AS Numeric(18, 0)), CAST(0x253C0B00 AS Date), N'Dhaka', N'CE-2016-002', 3)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (7, N'Robin', N'robin@gmail.com', CAST(987554333 AS Numeric(18, 0)), CAST(0x253C0B00 AS Date), N'Faridpur', N'CSE-2016-003', 1)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (8, N'Sojib', N'sojib@gmail.com', CAST(987331113 AS Numeric(18, 0)), CAST(0x253C0B00 AS Date), N'Dhaka', N'EEE-2016-003', 2)
INSERT [dbo].[Student] ([StudentId], [StudentName], [StudentEmail], [StudentContactNo], [Date], [StudentAddress], [RegistrationId], [DepartmentId]) VALUES (9, N'Saikat', N'saikat@gmail.com', CAST(6541627839 AS Numeric(18, 0)), CAST(0x253C0B00 AS Date), N'Dhaka', N'ME-2016-001', 4)
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherAddress], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditTobeTaken], [TeacherEmail], [RemainingCredit]) VALUES (1, N'Tanvir Ahmed', N'Dhaka', CAST(1671234567 AS Numeric(18, 0)), 2, 1, CAST(12.00 AS Numeric(18, 2)), N'tanvir@gmail.com', CAST(2.00 AS Numeric(18, 2)))
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherAddress], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditTobeTaken], [TeacherEmail], [RemainingCredit]) VALUES (2, N'Atikur Rahman', N'Dhaka', CAST(981246123 AS Numeric(18, 0)), 3, 2, CAST(12.00 AS Numeric(18, 2)), N'atik@gmail.com', CAST(12.00 AS Numeric(18, 2)))
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherAddress], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditTobeTaken], [TeacherEmail], [RemainingCredit]) VALUES (3, N'Zia Haque', N'Dhaka', CAST(7654123123 AS Numeric(18, 0)), 2, 4, CAST(12.00 AS Numeric(18, 2)), N'zia@gmail.com', CAST(12.00 AS Numeric(18, 2)))
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherAddress], [TeacherContactNo], [DesignationId], [DepartmentId], [CreditTobeTaken], [TeacherEmail], [RemainingCredit]) VALUES (4, N'Tareq Aziz', N'Dhaka', CAST(987124124 AS Numeric(18, 0)), 3, 4, CAST(12.00 AS Numeric(18, 2)), N'tareq@gmail.com', CAST(12.00 AS Numeric(18, 2)))
SET IDENTITY_INSERT [dbo].[Teacher] OFF
ALTER TABLE [dbo].[AllocateClassrooms]  WITH CHECK ADD  CONSTRAINT [FK_AllocateClassrooms_Day] FOREIGN KEY([DayId])
REFERENCES [dbo].[Day] ([DayId])
GO
ALTER TABLE [dbo].[AllocateClassrooms] CHECK CONSTRAINT [FK_AllocateClassrooms_Day]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semister] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([SemesterId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semister]
GO
ALTER TABLE [dbo].[CourseAssigntoTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssigntoTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[CourseAssigntoTeacher] CHECK CONSTRAINT [FK_CourseAssigntoTeacher_Course]
GO
ALTER TABLE [dbo].[EnrollCourse]  WITH CHECK ADD  CONSTRAINT [FK_EnrollCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[EnrollCourse] CHECK CONSTRAINT [FK_EnrollCourse_Course]
GO
ALTER TABLE [dbo].[Result]  WITH CHECK ADD  CONSTRAINT [FK_Result_Grade] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentId])
GO
ALTER TABLE [dbo].[Result] CHECK CONSTRAINT [FK_Result_Grade]
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_Department]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Department] ([DepartmentId])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Department]
GO
USE [master]
GO
ALTER DATABASE [SUCRMS] SET  READ_WRITE 
GO
