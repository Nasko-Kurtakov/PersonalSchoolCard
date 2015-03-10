USE [master]
GO
/****** Object:  Database [PersonalSchoolCard]    Script Date: 1.3.2015 г. 2:05:31 ******/
CREATE DATABASE [PersonalSchoolCard] ON  PRIMARY 
( NAME = N'PersonalSchoolCard', FILENAME = N'D:\Programi\SQL Server 2014\MSSQL12.FIRSTINSTANCE14\MSSQL\DATA\PersonalSchoolCard.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'PersonalSchoolCard_log', FILENAME = N'D:\Programi\SQL Server 2014\MSSQL12.FIRSTINSTANCE14\MSSQL\DATA\PersonalSchoolCard_log.ldf' , SIZE = 3136KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PersonalSchoolCard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PersonalSchoolCard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET ARITHABORT OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PersonalSchoolCard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PersonalSchoolCard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PersonalSchoolCard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PersonalSchoolCard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PersonalSchoolCard] SET RECOVERY FULL 
GO
ALTER DATABASE [PersonalSchoolCard] SET  MULTI_USER 
GO
ALTER DATABASE [PersonalSchoolCard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PersonalSchoolCard] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'PersonalSchoolCard', N'ON'
GO
USE [PersonalSchoolCard]
GO
/****** Object:  Table [dbo].[Absences]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Absences](
	[StudentID] [bigint] NOT NULL,
	[ClassID] [int] NOT NULL,
	[TermID] [tinyint] NOT NULL,
	[TypeAbsenceID] [tinyint] NOT NULL,
	[AbsencesNumber] [nvarchar](6) NULL,
 CONSTRAINT [PK_Absences_1] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ClassID] ASC,
	[TermID] ASC,
	[TypeAbsenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Diploms]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Diploms](
	[StudentID] [bigint] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[SubjectTypeID] [tinyint] NOT NULL,
	[Mark] [real] NOT NULL,
	[HoursStudied] [int] NULL,
 CONSTRAINT [PK_Diploms] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[SubjectID] ASC,
	[SubjectTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoursStudiedSubject]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoursStudiedSubject](
	[ClassID] [int] NOT NULL,
	[ProfileID] [int] NULL,
	[SubjectID] [int] NOT NULL,
	[SubjectTypeID] [tinyint] NOT NULL,
	[HoursStudied] [int] NOT NULL,
 CONSTRAINT [PK_HoursStudiedSubject] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC,
	[SubjectID] ASC,
	[SubjectTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Marks]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marks](
	[StudentID] [bigint] NOT NULL,
	[SubjectID] [int] NOT NULL,
	[SubjectTypeID] [tinyint] NOT NULL,
	[TermID] [tinyint] NOT NULL,
	[ClassID] [int] NOT NULL,
	[Grade] [tinyint] NULL,
 CONSTRAINT [PK_Marks] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[SubjectID] ASC,
	[SubjectTypeID] ASC,
	[TermID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Pictures]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pictures](
	[StudentID] [bigint] NOT NULL,
	[PicturePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Principals]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Principals](
	[PrincipalID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[SecondName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Principals] PRIMARY KEY CLUSTERED 
(
	[PrincipalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ProfileID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfilesSubjects]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfilesSubjects](
	[ProfilesID] [int] NOT NULL,
	[SubjectID] [int] NOT NULL,
 CONSTRAINT [PK_ProfilesSubjects_1] PRIMARY KEY CLUSTERED 
(
	[ProfilesID] ASC,
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolClasses]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolClasses](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](5) NULL,
	[SchoolYearID] [int] NULL,
	[ProfileID] [int] NULL,
	[TeacherID] [int] NOT NULL,
 CONSTRAINT [PK_Classes] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Schools]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Schools](
	[SchoolID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolName] [nvarchar](100) NOT NULL,
	[SettlementID] [int] NULL,
 CONSTRAINT [PK_Schools] PRIMARY KEY CLUSTERED 
(
	[SchoolID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SchoolYears]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SchoolYears](
	[SchoolYearID] [int] IDENTITY(1,1) NOT NULL,
	[SchoolYearName] [nchar](10) NULL,
 CONSTRAINT [PK_SchoolYear] PRIMARY KEY CLUSTERED 
(
	[SchoolYearID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Settlements]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Settlements](
	[SettlementID] [int] IDENTITY(1,1) NOT NULL,
	[SettlementName] [nvarchar](50) NULL,
	[ManicipalityID] [int] NULL,
	[AreaID] [int] NULL,
	[District] [nvarchar](50) NULL,
 CONSTRAINT [PK_Settlements] PRIMARY KEY CLUSTERED 
(
	[SettlementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[SecondName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PersonalNumber] [nchar](10) NULL,
	[PersonalCardNumber] [nchar](10) NULL,
	[DateOfBirth] [date] NULL,
	[SettlementID] [int] NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[EnrollmentYear] [int] NULL,
	[ProfileID] [int] NULL,
	[MarkFromDiplom] [real] NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StudentsSchoolYear]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsSchoolYear](
	[StudentID] [bigint] NOT NULL,
	[SchoolYearID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
 CONSTRAINT [PK_StudentsSchoolYear] PRIMARY KEY CLUSTERED 
(
	[SchoolYearID] ASC,
	[StudentID] ASC,
	[ClassID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Subjects]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subjects](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SubjectTypes]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubjectTypes](
	[SubjectTypeID] [tinyint] IDENTITY(1,1) NOT NULL,
	[SubjectTypeName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_SubjectTypes] PRIMARY KEY CLUSTERED 
(
	[SubjectTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teachers]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teachers](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[UserName] [nvarchar](15) NULL,
	[Password] [nvarchar](15) NULL,
 CONSTRAINT [PK_Teachers] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Terms]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Terms](
	[TermID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TermName] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Terms] PRIMARY KEY CLUSTERED 
(
	[TermID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TypeAbsences]    Script Date: 1.3.2015 г. 2:05:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeAbsences](
	[TypeAbsenceID] [tinyint] IDENTITY(1,1) NOT NULL,
	[TypeAbsenceName] [nvarchar](15) NULL,
 CONSTRAINT [PK_TypeAbsences] PRIMARY KEY CLUSTERED 
(
	[TypeAbsenceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (1, 27, 1, 1, N'2')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (1, 27, 1, 2, N'1 1/3')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (2, 27, 1, 1, N'40')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (2, 27, 1, 2, N'5 2/3')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (5, 16, 1, 1, N'2')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (5, 16, 1, 2, N'3 2/3')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (10032, 22, 1, 1, N'33')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (10035, 22, 1, 1, N'33')
INSERT [dbo].[Absences] ([StudentID], [ClassID], [TermID], [TypeAbsenceID], [AbsencesNumber]) VALUES (10035, 22, 1, 2, N'3 1/3')
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 1, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 1, 3, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 1, 4, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 2, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 2, 2, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 3, 1, 5.5, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 6, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 6, 2, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 6, 4, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 7, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 7, 2, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 8, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 9, 1, 5, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 10, 1, 5.5, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 11, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 12, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 13, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 14, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 15, 1, 5.67, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 16, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 17, 1, 5.67, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 18, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 19, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10032, 20, 1, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10035, 1, 5, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10035, 2, 5, 5, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10057, 1, 5, 6, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10057, 2, 5, 5, NULL)
INSERT [dbo].[Diploms] ([StudentID], [SubjectID], [SubjectTypeID], [Mark], [HoursStudied]) VALUES (10057, 10, 5, 4, NULL)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 1, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 2, 1, 108)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 3, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 6, 1, 108)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 7, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 8, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 11, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 18, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 19, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (1, 1, 20, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 1, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 2, 1, 108)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 3, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 6, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 7, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 8, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 11, 1, 72)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 18, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 19, 1, 36)
INSERT [dbo].[HoursStudiedSubject] ([ClassID], [ProfileID], [SubjectID], [SubjectTypeID], [HoursStudied]) VALUES (2, 2, 20, 1, 72)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 1, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 1, 1, 2, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 1, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 2, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 2, 1, 2, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 2, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 3, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 3, 1, 2, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 3, 1, 3, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 6, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 6, 1, 2, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 6, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 7, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 7, 1, 2, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 7, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 8, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 8, 1, 2, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 8, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 11, 1, 1, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 11, 1, 2, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 11, 1, 3, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 18, 1, 1, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 18, 1, 2, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 18, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 19, 1, 1, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 19, 1, 2, 2, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 19, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 20, 1, 1, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 20, 1, 2, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (1, 20, 1, 3, 2, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 1, 1, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 3, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 1, 4, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 2, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 2, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 2, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 2, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 3, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 3, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 3, 1, 3, 18, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 3, 1, 3, 22, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 4, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 4, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 4, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 6, 4, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 7, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 7, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 7, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 7, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 8, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 8, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 9, 1, 3, 1, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 9, 1, 3, 10, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 9, 1, 3, 18, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 9, 1, 3, 22, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 10, 1, 3, 1, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 10, 1, 3, 10, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 10, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 10, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 11, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 12, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 13, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 14, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 15, 1, 3, 1, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 15, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 15, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 16, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 16, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 16, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 16, 1, 3, 22, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 17, 1, 3, 1, 5)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 17, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 17, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 18, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 19, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 20, 1, 3, 1, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 20, 1, 3, 10, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 20, 1, 3, 18, 6)
INSERT [dbo].[Marks] ([StudentID], [SubjectID], [SubjectTypeID], [TermID], [ClassID], [Grade]) VALUES (10032, 20, 1, 3, 22, 6)
INSERT [dbo].[Pictures] ([StudentID], [PicturePath]) VALUES (10032, N'C:\Users\Todor\Desktop\Anton.jpg')
SET IDENTITY_INSERT [dbo].[Principals] ON 

INSERT [dbo].[Principals] ([PrincipalID], [FirstName], [SecondName], [LastName]) VALUES (1, N'Ангел', N'Димитров', N'Велков')
INSERT [dbo].[Principals] ([PrincipalID], [FirstName], [SecondName], [LastName]) VALUES (3, N'Иван', N'Иван', N'Иван')
INSERT [dbo].[Principals] ([PrincipalID], [FirstName], [SecondName], [LastName]) VALUES (4, N'Гошо', N'Гошо', N'Гошо')
SET IDENTITY_INSERT [dbo].[Principals] OFF
SET IDENTITY_INSERT [dbo].[Profiles] ON 

INSERT [dbo].[Profiles] ([ProfileID], [ProfileName]) VALUES (1, N'Математика, Информатика, Английски език')
INSERT [dbo].[Profiles] ([ProfileID], [ProfileName]) VALUES (2, N'Информатика, Математика, Английски език')
INSERT [dbo].[Profiles] ([ProfileID], [ProfileName]) VALUES (3, N'Информационни технологии, Математика, Английски')
INSERT [dbo].[Profiles] ([ProfileID], [ProfileName]) VALUES (4, N'География, Информационни технологии, Английски език')
INSERT [dbo].[Profiles] ([ProfileID], [ProfileName]) VALUES (5, N'Информатика, Информационни технологии, Математика')
INSERT [dbo].[Profiles] ([ProfileID], [ProfileName]) VALUES (1005, N'Биология, Физика, Химия')
SET IDENTITY_INSERT [dbo].[Profiles] OFF
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (1, 2)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (1, 6)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (1, 7)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (2, 2)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (2, 6)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (2, 7)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (3, 2)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (3, 6)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (3, 8)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (4, 3)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (4, 8)
INSERT [dbo].[ProfilesSubjects] ([ProfilesID], [SubjectID]) VALUES (4, 10)
SET IDENTITY_INSERT [dbo].[SchoolClasses] ON 

INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (1, N'9 а', 1, 1, 1)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (2, N'9 б ', 1, 2, 2)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (3, N'10 а', 1, 1, 3)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (4, N'10 б', 1, 2, 4)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (5, N'11а', 1, 1, 5)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (6, N'11 б', 1, 2, 8)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (7, N'12 а', 1, 1, 9)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (8, N'12 б', 1, 2, 10)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (9, N'9 а', 2, 1, 12)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (10, N'10 а', 2, 1, 1)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (11, N'10 б', 2, 2, 2)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (12, N'11 а', 2, 1, 3)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (13, N'11 б', 2, 2, 4)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (14, N'12 а', 2, 1, 5)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (15, N'12 б', 2, 2, 11)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (16, N'9 а', 3, 1, 13)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (17, N'10 а', 3, 1, 12)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (18, N'11 а', 3, 1, 1)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (19, N'11 б', 3, 2, 2)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (20, N'12 а', 3, 1, 3)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (21, N'12 б', 3, 2, 4)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (22, N'12 а', 4, 1, 1)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (23, N'9 б', 4, 2, 15)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (24, N'10 а', 4, 1, 13)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (25, N'11 а', 4, 1, 12)
INSERT [dbo].[SchoolClasses] ([ClassID], [ClassName], [SchoolYearID], [ProfileID], [TeacherID]) VALUES (27, N'12 б', 4, 2, 2)
SET IDENTITY_INSERT [dbo].[SchoolClasses] OFF
SET IDENTITY_INSERT [dbo].[Schools] ON 

INSERT [dbo].[Schools] ([SchoolID], [SchoolName], [SettlementID]) VALUES (1, N'МГ "Константин Величков"', 4)
SET IDENTITY_INSERT [dbo].[Schools] OFF
SET IDENTITY_INSERT [dbo].[SchoolYears] ON 

INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (1, N'2011/2012 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (2, N'2012/2013 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (3, N'2013/2014 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (4, N'2014/2015 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (5, N'2015/2016 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (6, N'2016/2017 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (8, N'2010/2011 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (9, N'2008/2009 ')
INSERT [dbo].[SchoolYears] ([SchoolYearID], [SchoolYearName]) VALUES (10, N'2007/2008 ')
SET IDENTITY_INSERT [dbo].[SchoolYears] OFF
SET IDENTITY_INSERT [dbo].[Settlements] ON 

INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (1, N'София', 1, 1, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (2, N'Пещера', 2, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (3, N'Брацигово', 3, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (4, N'Пазарджик', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (5, N'Бургас', 5, 5, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (6, N'с. Главиница', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (7, N'с. Мокрище', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (8, N'с. Ивайло', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (12, N'Ветрен дол', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (13, N'Ивайло', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (14, N'Ивайло', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (17, N'Драгор', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (40, N'Варна', 40, 40, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (41, N'Гюргево', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (42, N'Варна', 42, 42, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (43, N'Главиница', 4, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (46, N'Велинград', 46, 4, NULL)
INSERT [dbo].[Settlements] ([SettlementID], [SettlementName], [ManicipalityID], [AreaID], [District]) VALUES (47, N'Стрелча', 46, 4, NULL)
SET IDENTITY_INSERT [dbo].[Settlements] OFF
SET IDENTITY_INSERT [dbo].[Students] ON 

INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (1, N'Атанас', N'Тодорив', N'Куртаков', N'9701113507', N'3512457896', CAST(N'1997-01-11' AS Date), 4, N'Маестро Атанасов ', N'0899627347', 2010, 2, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (2, N'Александър', N'Бориславов', N'Горанов', N'9608223821', N'1346798524', CAST(N'1996-01-21' AS Date), 1, N'8 Март', N'0897458124', 2010, 2, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (3, N'Иван', N'Иванов', N'Георгиев', N'9812315847', N'1873694248', CAST(N'1998-12-31' AS Date), 3, N'Пловдивска', N'0897514752', 2010, 2, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (5, N'Иван', N'Георгиев', N'Димитров', NULL, NULL, CAST(N'2002-01-20' AS Date), 4, NULL, NULL, 2013, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10032, N'Антон', N'Иванов', N'Дамянов', N'9701113507', N'895623147 ', CAST(N'1997-01-11' AS Date), 4, N'Маестро Атанасов 7', N'0898561820', 2010, 1, 5.68)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10033, N'Атанас', N'Георгиев', N'Петров', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10034, N'Васил', N'Стоянов', N'Георгиев', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10035, N'Весела', N'Петрова', N'Михайлова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10036, N'Веселин', N'Стоилов', N'Петров', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10037, N'Галя', N'Иванова', N'Владимирва', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10038, N'Георги', N'Петров', N'Георгиев', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10039, N'Гергана', N'Георгиева', N'Владимирва', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10040, N'Гинка', N'Стоянова', N'Михайлова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10041, N'Десислава', N'Станимирова', N'Петрова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10042, N'Дима', N'Петрова', N'Владимирва', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10043, N'Димитър', N'Илиев', N'Дамянов', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10044, N'Дончо', N'Димитров', N'Димитров', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10045, N'Елена', N'Иванова', N'Михайлова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10046, N'Ива', N'Михайлова', N'Владимирва', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10047, N'Ивайло', N'Стоянов', N'Стоянов', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10048, N'Иван', N'Димитров', N'Стоянов', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10049, N'Калоян', N'Дамянов', N'Георгиев', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10050, N'Катя', N'Владимирва', N'Владимирва', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10051, N'Лиляна', N'Стоянова', N'Михайлова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10052, N'Мария', N'Стойчева', N'Стоилов', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10053, N'Марияна', N'Владимирва', N'Иванова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10054, N'Рада', N'Георгиева', N'Иванова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10055, N'Стефан', N'Стефанов', N'Георгиев', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10056, N'Стоян', N'Петров', N'Георгиев', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
INSERT [dbo].[Students] ([StudentID], [FirstName], [SecondName], [LastName], [PersonalNumber], [PersonalCardNumber], [DateOfBirth], [SettlementID], [Address], [Phone], [EnrollmentYear], [ProfileID], [MarkFromDiplom]) VALUES (10057, N'Цветелина', N'Иванова', N'Михайлова', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Students] OFF
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (1, 1, 2)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10032, 1, 1)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (1, 2, 11)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10032, 2, 10)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (1, 3, 19)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (5, 3, 16)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10032, 3, 18)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (1, 4, 27)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (2, 4, 27)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (3, 4, 27)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10032, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10033, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10034, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10035, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10036, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10037, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10038, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10039, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10040, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10041, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10042, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10043, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10044, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10045, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10046, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10047, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10048, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10049, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10050, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10051, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10052, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10053, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10054, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10055, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10056, 4, 22)
INSERT [dbo].[StudentsSchoolYear] ([StudentID], [SchoolYearID], [ClassID]) VALUES (10057, 4, 22)
SET IDENTITY_INSERT [dbo].[Subjects] ON 

INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (1, N'Български език и литература')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (2, N'Английски език')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (3, N'Немски език')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (4, N'Руски език')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (5, N'Френски език')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (6, N'Математика')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (7, N'Информатика')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (8, N'Информационни технологии')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (9, N'История и цивилизация')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (10, N'География и икономика')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (11, N'Психология и логика')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (12, N'Етика и право')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (13, N'Философия')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (14, N'Свят и личност')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (15, N'Биология и здравно образование')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (16, N'Физика и астрономия')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (17, N'Химия и опазване на околната среда')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (18, N'Музика')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (19, N'Изобразително изкуство')
INSERT [dbo].[Subjects] ([SubjectID], [SubjectName]) VALUES (20, N'Физическо възпитание и спорт')
SET IDENTITY_INSERT [dbo].[Subjects] OFF
SET IDENTITY_INSERT [dbo].[SubjectTypes] ON 

INSERT [dbo].[SubjectTypes] ([SubjectTypeID], [SubjectTypeName]) VALUES (1, N'ЗП')
INSERT [dbo].[SubjectTypes] ([SubjectTypeID], [SubjectTypeName]) VALUES (2, N'ЗПП')
INSERT [dbo].[SubjectTypes] ([SubjectTypeID], [SubjectTypeName]) VALUES (3, N'ЗИП')
INSERT [dbo].[SubjectTypes] ([SubjectTypeID], [SubjectTypeName]) VALUES (4, N'СИП')
INSERT [dbo].[SubjectTypes] ([SubjectTypeID], [SubjectTypeName]) VALUES (5, N'ДЗИ')
SET IDENTITY_INSERT [dbo].[SubjectTypes] OFF
SET IDENTITY_INSERT [dbo].[Teachers] ON 

INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (1, N'Стояна', N'Пенова', N'penova', N'123')
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (2, N'Даниела', N'Нестерова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (3, N'Стойна', N'Попова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (4, N'Людмила', N'Стоянова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (5, N'Сашка', N'Топалова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (8, N'Цветанка', N'Плачкова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (9, N'Георги', N'Стойчев', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (10, N'Георги ', N'Кокозов', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (11, N'Цанко', N'Бангьозов', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (12, N'Мария', N'Янчева', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (13, N'Елена', N'Чолакова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (14, N'Христина', N'Стефанова', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (15, N'Ана', N'Рабаджийска', NULL, NULL)
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (16, N'Иванка', N'Иванова', N'ivanka', N'1234')
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (17, N'Петя', N'Петрова', N'иванка', N'1234')
INSERT [dbo].[Teachers] ([TeacherID], [FirstName], [LastName], [UserName], [Password]) VALUES (18, N'иван', N'иван', N'ivan', N'1234')
SET IDENTITY_INSERT [dbo].[Teachers] OFF
SET IDENTITY_INSERT [dbo].[Terms] ON 

INSERT [dbo].[Terms] ([TermID], [TermName]) VALUES (1, N'Първи срок')
INSERT [dbo].[Terms] ([TermID], [TermName]) VALUES (2, N'Втори срок')
INSERT [dbo].[Terms] ([TermID], [TermName]) VALUES (3, N'Година')
SET IDENTITY_INSERT [dbo].[Terms] OFF
SET IDENTITY_INSERT [dbo].[TypeAbsences] ON 

INSERT [dbo].[TypeAbsences] ([TypeAbsenceID], [TypeAbsenceName]) VALUES (1, N'Извинени')
INSERT [dbo].[TypeAbsences] ([TypeAbsenceID], [TypeAbsenceName]) VALUES (2, N'Неизвинени')
SET IDENTITY_INSERT [dbo].[TypeAbsences] OFF
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Classes1] FOREIGN KEY([ClassID])
REFERENCES [dbo].[SchoolClasses] ([ClassID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Classes1]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Students]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_Terms] FOREIGN KEY([TermID])
REFERENCES [dbo].[Terms] ([TermID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_Terms]
GO
ALTER TABLE [dbo].[Absences]  WITH CHECK ADD  CONSTRAINT [FK_Absences_TypeAbsences] FOREIGN KEY([TypeAbsenceID])
REFERENCES [dbo].[TypeAbsences] ([TypeAbsenceID])
GO
ALTER TABLE [dbo].[Absences] CHECK CONSTRAINT [FK_Absences_TypeAbsences]
GO
ALTER TABLE [dbo].[Diploms]  WITH CHECK ADD  CONSTRAINT [FK_Diploms_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Diploms] CHECK CONSTRAINT [FK_Diploms_Students]
GO
ALTER TABLE [dbo].[Diploms]  WITH CHECK ADD  CONSTRAINT [FK_Diploms_Subjects] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subjects] ([SubjectID])
GO
ALTER TABLE [dbo].[Diploms] CHECK CONSTRAINT [FK_Diploms_Subjects]
GO
ALTER TABLE [dbo].[Diploms]  WITH CHECK ADD  CONSTRAINT [FK_Diploms_SubjectTypes] FOREIGN KEY([SubjectTypeID])
REFERENCES [dbo].[SubjectTypes] ([SubjectTypeID])
GO
ALTER TABLE [dbo].[Diploms] CHECK CONSTRAINT [FK_Diploms_SubjectTypes]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[SchoolClasses] ([ClassID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Classes]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Students]
GO
ALTER TABLE [dbo].[Marks]  WITH CHECK ADD  CONSTRAINT [FK_Marks_Terms] FOREIGN KEY([TermID])
REFERENCES [dbo].[Terms] ([TermID])
GO
ALTER TABLE [dbo].[Marks] CHECK CONSTRAINT [FK_Marks_Terms]
GO
ALTER TABLE [dbo].[Pictures]  WITH CHECK ADD  CONSTRAINT [FK_Pictures_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[Pictures] CHECK CONSTRAINT [FK_Pictures_Students]
GO
ALTER TABLE [dbo].[ProfilesSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ProfilesSubjects_Profiles] FOREIGN KEY([ProfilesID])
REFERENCES [dbo].[Profiles] ([ProfileID])
GO
ALTER TABLE [dbo].[ProfilesSubjects] CHECK CONSTRAINT [FK_ProfilesSubjects_Profiles]
GO
ALTER TABLE [dbo].[ProfilesSubjects]  WITH CHECK ADD  CONSTRAINT [FK_ProfilesSubjects_Subjects] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subjects] ([SubjectID])
GO
ALTER TABLE [dbo].[ProfilesSubjects] CHECK CONSTRAINT [FK_ProfilesSubjects_Subjects]
GO
ALTER TABLE [dbo].[SchoolClasses]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Profiles] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profiles] ([ProfileID])
GO
ALTER TABLE [dbo].[SchoolClasses] CHECK CONSTRAINT [FK_Classes_Profiles]
GO
ALTER TABLE [dbo].[SchoolClasses]  WITH CHECK ADD  CONSTRAINT [FK_Classes_SchoolYears] FOREIGN KEY([SchoolYearID])
REFERENCES [dbo].[SchoolYears] ([SchoolYearID])
GO
ALTER TABLE [dbo].[SchoolClasses] CHECK CONSTRAINT [FK_Classes_SchoolYears]
GO
ALTER TABLE [dbo].[SchoolClasses]  WITH CHECK ADD  CONSTRAINT [FK_Classes_Teachers] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teachers] ([TeacherID])
GO
ALTER TABLE [dbo].[SchoolClasses] CHECK CONSTRAINT [FK_Classes_Teachers]
GO
ALTER TABLE [dbo].[Schools]  WITH CHECK ADD  CONSTRAINT [FK_Schools_Settlements] FOREIGN KEY([SettlementID])
REFERENCES [dbo].[Settlements] ([SettlementID])
GO
ALTER TABLE [dbo].[Schools] CHECK CONSTRAINT [FK_Schools_Settlements]
GO
ALTER TABLE [dbo].[Settlements]  WITH CHECK ADD  CONSTRAINT [FK_SetlementID_To_ManicipalityID] FOREIGN KEY([ManicipalityID])
REFERENCES [dbo].[Settlements] ([SettlementID])
GO
ALTER TABLE [dbo].[Settlements] CHECK CONSTRAINT [FK_SetlementID_To_ManicipalityID]
GO
ALTER TABLE [dbo].[Settlements]  WITH CHECK ADD  CONSTRAINT [FK_SettlementId_To_AreaID] FOREIGN KEY([AreaID])
REFERENCES [dbo].[Settlements] ([SettlementID])
GO
ALTER TABLE [dbo].[Settlements] CHECK CONSTRAINT [FK_SettlementId_To_AreaID]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Profiles] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profiles] ([ProfileID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Profiles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Settlements] FOREIGN KEY([SettlementID])
REFERENCES [dbo].[Settlements] ([SettlementID])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Settlements]
GO
ALTER TABLE [dbo].[StudentsSchoolYear]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSchoolYear_Classes] FOREIGN KEY([ClassID])
REFERENCES [dbo].[SchoolClasses] ([ClassID])
GO
ALTER TABLE [dbo].[StudentsSchoolYear] CHECK CONSTRAINT [FK_StudentsSchoolYear_Classes]
GO
ALTER TABLE [dbo].[StudentsSchoolYear]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSchoolYear_SchoolYears] FOREIGN KEY([SchoolYearID])
REFERENCES [dbo].[SchoolYears] ([SchoolYearID])
GO
ALTER TABLE [dbo].[StudentsSchoolYear] CHECK CONSTRAINT [FK_StudentsSchoolYear_SchoolYears]
GO
ALTER TABLE [dbo].[StudentsSchoolYear]  WITH CHECK ADD  CONSTRAINT [FK_StudentsSchoolYear_Students] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Students] ([StudentID])
GO
ALTER TABLE [dbo].[StudentsSchoolYear] CHECK CONSTRAINT [FK_StudentsSchoolYear_Students]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'профилиращ предмет по съответния профил' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProfilesSubjects', @level2type=N'COLUMN',@level2name=N'SubjectID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ЕГН' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Students', @level2type=N'COLUMN',@level2name=N'PersonalNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'лична карта' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Students', @level2type=N'COLUMN',@level2name=N'PersonalCardNumber'
GO
USE [master]
GO
ALTER DATABASE [PersonalSchoolCard] SET  READ_WRITE 
GO
