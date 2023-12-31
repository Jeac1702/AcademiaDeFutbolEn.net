USE [master]
GO
/****** Object:  Database [AcademiaFutbol]    Script Date: 25/03/2023 11:51:06 a. m. ******/
CREATE DATABASE [AcademiaFutbol]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'AcademiaFutbol', FILENAME = N'E:\SQL SERVER EX\MSSQL15.SQLEXPRESS\MSSQL\DATA\AcademiaFutbol.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'AcademiaFutbol_log', FILENAME = N'E:\SQL SERVER EX\MSSQL15.SQLEXPRESS\MSSQL\DATA\AcademiaFutbol_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [AcademiaFutbol] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AcademiaFutbol].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AcademiaFutbol] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET ARITHABORT OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [AcademiaFutbol] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [AcademiaFutbol] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET  DISABLE_BROKER 
GO
ALTER DATABASE [AcademiaFutbol] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [AcademiaFutbol] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [AcademiaFutbol] SET  MULTI_USER 
GO
ALTER DATABASE [AcademiaFutbol] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [AcademiaFutbol] SET DB_CHAINING OFF 
GO
ALTER DATABASE [AcademiaFutbol] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [AcademiaFutbol] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [AcademiaFutbol] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [AcademiaFutbol] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [AcademiaFutbol] SET QUERY_STORE = OFF
GO
USE [AcademiaFutbol]
GO
/****** Object:  Table [dbo].[Alineaciones]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alineaciones](
	[LineupId] [int] IDENTITY(1,1) NOT NULL,
	[Match] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Titular] [bit] NOT NULL,
 CONSTRAINT [PK_Alineaciones] PRIMARY KEY CLUSTERED 
(
	[LineupId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Alumnos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Alumnos](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Parent] [int] NOT NULL,
	[BirthDate] [date] NOT NULL,
	[BirthPlace] [varchar](200) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[CURP] [varchar](20) NOT NULL,
	[NSS] [varchar](20) NOT NULL,
	[BloodType] [varchar](5) NOT NULL,
	[Diseases] [varchar](500) NULL,
	[Address] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Alumnos] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Asistencias]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencias](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[Team] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[AttendanceType] [varchar](50) NOT NULL,
	[Coach] [int] NOT NULL,
	[Attendance] [bit] NOT NULL,
 CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsistenciasPartidos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsistenciasPartidos](
	[AssitId] [int] IDENTITY(1,1) NOT NULL,
	[Match] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[AssitTo] [int] NOT NULL,
	[Minute] [int] NOT NULL,
 CONSTRAINT [PK_AsistenciasPartidos] PRIMARY KEY CLUSTERED 
(
	[AssitId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambiosPartidos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambiosPartidos](
	[ChangesId] [int] IDENTITY(1,1) NOT NULL,
	[Match] [int] NOT NULL,
	[TeamEntry] [int] NOT NULL,
	[EntryPlayer] [int] NOT NULL,
	[TeamOut] [int] NOT NULL,
	[OutPlayer] [int] NOT NULL,
	[Minute] [int] NOT NULL,
 CONSTRAINT [PK_CambiosPartidos] PRIMARY KEY CLUSTERED 
(
	[ChangesId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[Category] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compras]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compras](
	[PurchaseId] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseBy] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Product] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
	[Paid] [decimal](18, 2) NOT NULL,
	[Provider] [int] NOT NULL,
 CONSTRAINT [PK_Compras] PRIMARY KEY CLUSTERED 
(
	[PurchaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Students] [int] NOT NULL,
	[Coach] [int] NOT NULL,
	[Category] [int] NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EquiposEstudiantes]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EquiposEstudiantes](
	[TeamStudentId] [int] IDENTITY(1,1) NOT NULL,
	[Team] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Position] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EquiposEstudiantes] PRIMARY KEY CLUSTERED 
(
	[TeamStudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstatusPago]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstatusPago](
	[StatusId] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[Status] [bit] NOT NULL,
	[Parent] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[LastDate] [date] NOT NULL,
 CONSTRAINT [PK_EstatusPago] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FaltasPartidos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FaltasPartidos](
	[FoulId] [int] IDENTITY(1,1) NOT NULL,
	[Match] [int] NOT NULL,
	[TeamOffender] [int] NOT NULL,
	[OffenderPlayer] [int] NOT NULL,
	[TeamOffended] [int] NOT NULL,
	[OffendedPlayer] [int] NOT NULL,
	[FoulType] [varchar](50) NOT NULL,
	[Card] [bit] NOT NULL,
	[Minute] [int] NOT NULL,
 CONSTRAINT [PK_FaltasPartidos] PRIMARY KEY CLUSTERED 
(
	[FoulId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GolesPartidos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GolesPartidos](
	[GoalMatchId] [int] IDENTITY(1,1) NOT NULL,
	[Match] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[GoalType] [varchar](50) NOT NULL,
	[Minute] [int] NOT NULL,
 CONSTRAINT [PK_GolesPartidos] PRIMARY KEY CLUSTERED 
(
	[GoalMatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HistorialPagos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialPagos](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Student] [int] NOT NULL,
	[PaymentDate] [date] NOT NULL,
	[Fee] [decimal](18, 2) NOT NULL,
	[Paid] [decimal](18, 2) NOT NULL,
	[Change] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_HistorialPagos] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Stock] [int] NOT NULL,
	[Provider] [int] NOT NULL,
	[UnitPrice] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ligas]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ligas](
	[LeagueId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Category] [int] NOT NULL,
	[Period] [varchar](100) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
 CONSTRAINT [PK_Ligas] PRIMARY KEY CLUSTERED 
(
	[LeagueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LigasEquipos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LigasEquipos](
	[LeagueTeamId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Team] [int] NOT NULL,
 CONSTRAINT [PK_LigasEquipos] PRIMARY KEY CLUSTERED 
(
	[LeagueTeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Padres]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Padres](
	[ParentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Phone] [varchar](25) NOT NULL,
	[BirthDate] [date] NOT NULL,
 CONSTRAINT [PK_Padres] PRIMARY KEY CLUSTERED 
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partidos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partidos](
	[MatchId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Journey] [int] NOT NULL,
	[LocalTeam] [int] NOT NULL,
	[VisitorTeam] [int] NOT NULL,
	[LocalGoals] [int] NOT NULL,
	[VisitorGoals] [int] NOT NULL,
	[DateStart] [datetime] NOT NULL,
	[DateEnd] [datetime] NOT NULL,
	[ExtraTime1] [int] NOT NULL,
	[ExtraTime2] [int] NOT NULL,
	[Fouls] [int] NOT NULL,
	[YellowCards] [int] NOT NULL,
	[RedCards] [int] NOT NULL,
 CONSTRAINT [PK_Partidos] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profesores]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profesores](
	[CoachId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[CURP] [varchar](20) NOT NULL,
	[BirthDate] [date] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[RFC] [varchar](20) NOT NULL,
	[NSS] [varchar](20) NOT NULL,
	[BirthPlace] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Profesores] PRIMARY KEY CLUSTERED 
(
	[CoachId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[ProviderId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[Phone] [varchar](20) NOT NULL,
	[Email] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[ProviderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaAsistencias]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaAsistencias](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Assists] [int] NOT NULL,
 CONSTRAINT [PK_TablaAsistencias] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaGeneral]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaGeneral](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Position] [int] NOT NULL,
	[GoalsFor] [int] NOT NULL,
	[GoalsAgainst] [int] NOT NULL,
	[Wins] [int] NOT NULL,
	[Losses] [int] NOT NULL,
	[Draws] [int] NOT NULL,
	[GamesPlayed] [int] NOT NULL,
 CONSTRAINT [PK_TablaGeneral] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaGoleo]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaGoleo](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Goals] [int] NOT NULL,
 CONSTRAINT [PK_TablaGoleo] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaTarjetasAmarillas]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaTarjetasAmarillas](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[YellowCards] [int] NOT NULL,
 CONSTRAINT [PK_TablaTarjetasAmarillas] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TablaTarjetasRojas]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TablaTarjetasRojas](
	[TableId] [int] IDENTITY(1,1) NOT NULL,
	[League] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[RedCards] [int] NOT NULL,
 CONSTRAINT [PK_TablaTarjetasRojas] PRIMARY KEY CLUSTERED 
(
	[TableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarjetasPartidos]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarjetasPartidos](
	[CardId] [int] IDENTITY(1,1) NOT NULL,
	[Match] [int] NOT NULL,
	[Team] [int] NOT NULL,
	[Student] [int] NOT NULL,
	[CartType] [bit] NOT NULL,
	[FoulId] [int] NOT NULL,
	[Minute] [int] NOT NULL,
 CONSTRAINT [PK_TarjetasPartidos] PRIMARY KEY CLUSTERED 
(
	[CardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 25/03/2023 11:51:07 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[CreatedDate] [date] NOT NULL,
	[Role] [int] NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Alineaciones]  WITH CHECK ADD  CONSTRAINT [FK_Alineaciones_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[Alineaciones] CHECK CONSTRAINT [FK_Alineaciones_Alumnos]
GO
ALTER TABLE [dbo].[Alineaciones]  WITH CHECK ADD  CONSTRAINT [FK_Alineaciones_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[Alineaciones] CHECK CONSTRAINT [FK_Alineaciones_Equipos]
GO
ALTER TABLE [dbo].[Alineaciones]  WITH CHECK ADD  CONSTRAINT [FK_Alineaciones_Partidos] FOREIGN KEY([Match])
REFERENCES [dbo].[Partidos] ([MatchId])
GO
ALTER TABLE [dbo].[Alineaciones] CHECK CONSTRAINT [FK_Alineaciones_Partidos]
GO
ALTER TABLE [dbo].[Alumnos]  WITH CHECK ADD  CONSTRAINT [FK_Alumnos_Padres] FOREIGN KEY([Parent])
REFERENCES [dbo].[Padres] ([ParentId])
GO
ALTER TABLE [dbo].[Alumnos] CHECK CONSTRAINT [FK_Alumnos_Padres]
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Alumnos]
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Equipos]
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Profesores] FOREIGN KEY([Coach])
REFERENCES [dbo].[Profesores] ([CoachId])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Profesores]
GO
ALTER TABLE [dbo].[AsistenciasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciasPartidos_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[AsistenciasPartidos] CHECK CONSTRAINT [FK_AsistenciasPartidos_Alumnos]
GO
ALTER TABLE [dbo].[AsistenciasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciasPartidos_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[AsistenciasPartidos] CHECK CONSTRAINT [FK_AsistenciasPartidos_Equipos]
GO
ALTER TABLE [dbo].[AsistenciasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciasPartidos_GolesPartidos] FOREIGN KEY([AssitTo])
REFERENCES [dbo].[GolesPartidos] ([GoalMatchId])
GO
ALTER TABLE [dbo].[AsistenciasPartidos] CHECK CONSTRAINT [FK_AsistenciasPartidos_GolesPartidos]
GO
ALTER TABLE [dbo].[AsistenciasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_AsistenciasPartidos_Partidos] FOREIGN KEY([Match])
REFERENCES [dbo].[Partidos] ([MatchId])
GO
ALTER TABLE [dbo].[AsistenciasPartidos] CHECK CONSTRAINT [FK_AsistenciasPartidos_Partidos]
GO
ALTER TABLE [dbo].[CambiosPartidos]  WITH CHECK ADD  CONSTRAINT [FK_CambiosPartidos_Alumnos] FOREIGN KEY([EntryPlayer])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[CambiosPartidos] CHECK CONSTRAINT [FK_CambiosPartidos_Alumnos]
GO
ALTER TABLE [dbo].[CambiosPartidos]  WITH CHECK ADD  CONSTRAINT [FK_CambiosPartidos_Alumnos1] FOREIGN KEY([OutPlayer])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[CambiosPartidos] CHECK CONSTRAINT [FK_CambiosPartidos_Alumnos1]
GO
ALTER TABLE [dbo].[CambiosPartidos]  WITH CHECK ADD  CONSTRAINT [FK_CambiosPartidos_Equipos] FOREIGN KEY([TeamEntry])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[CambiosPartidos] CHECK CONSTRAINT [FK_CambiosPartidos_Equipos]
GO
ALTER TABLE [dbo].[CambiosPartidos]  WITH CHECK ADD  CONSTRAINT [FK_CambiosPartidos_Equipos1] FOREIGN KEY([TeamOut])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[CambiosPartidos] CHECK CONSTRAINT [FK_CambiosPartidos_Equipos1]
GO
ALTER TABLE [dbo].[CambiosPartidos]  WITH CHECK ADD  CONSTRAINT [FK_CambiosPartidos_Partidos] FOREIGN KEY([Match])
REFERENCES [dbo].[Partidos] ([MatchId])
GO
ALTER TABLE [dbo].[CambiosPartidos] CHECK CONSTRAINT [FK_CambiosPartidos_Partidos]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Inventario] FOREIGN KEY([Product])
REFERENCES [dbo].[Inventario] ([ProductId])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Inventario]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Proveedores] FOREIGN KEY([Provider])
REFERENCES [dbo].[Proveedores] ([ProviderId])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Proveedores]
GO
ALTER TABLE [dbo].[Compras]  WITH CHECK ADD  CONSTRAINT [FK_Compras_Usuarios] FOREIGN KEY([PurchaseBy])
REFERENCES [dbo].[Usuarios] ([UserId])
GO
ALTER TABLE [dbo].[Compras] CHECK CONSTRAINT [FK_Compras_Usuarios]
GO
ALTER TABLE [dbo].[Equipos]  WITH CHECK ADD  CONSTRAINT [FK_Equipos_Categorias] FOREIGN KEY([Category])
REFERENCES [dbo].[Categorias] ([CategoryId])
GO
ALTER TABLE [dbo].[Equipos] CHECK CONSTRAINT [FK_Equipos_Categorias]
GO
ALTER TABLE [dbo].[Equipos]  WITH CHECK ADD  CONSTRAINT [FK_Equipos_Profesores] FOREIGN KEY([Coach])
REFERENCES [dbo].[Profesores] ([CoachId])
GO
ALTER TABLE [dbo].[Equipos] CHECK CONSTRAINT [FK_Equipos_Profesores]
GO
ALTER TABLE [dbo].[EquiposEstudiantes]  WITH CHECK ADD  CONSTRAINT [FK_EquiposEstudiantes_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[EquiposEstudiantes] CHECK CONSTRAINT [FK_EquiposEstudiantes_Alumnos]
GO
ALTER TABLE [dbo].[EquiposEstudiantes]  WITH CHECK ADD  CONSTRAINT [FK_EquiposEstudiantes_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[EquiposEstudiantes] CHECK CONSTRAINT [FK_EquiposEstudiantes_Equipos]
GO
ALTER TABLE [dbo].[EstatusPago]  WITH CHECK ADD  CONSTRAINT [FK_EstatusPago_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[EstatusPago] CHECK CONSTRAINT [FK_EstatusPago_Alumnos]
GO
ALTER TABLE [dbo].[EstatusPago]  WITH CHECK ADD  CONSTRAINT [FK_EstatusPago_Padres] FOREIGN KEY([Parent])
REFERENCES [dbo].[Padres] ([ParentId])
GO
ALTER TABLE [dbo].[EstatusPago] CHECK CONSTRAINT [FK_EstatusPago_Padres]
GO
ALTER TABLE [dbo].[FaltasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_FaltasPartidos_Alumnos] FOREIGN KEY([OffendedPlayer])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[FaltasPartidos] CHECK CONSTRAINT [FK_FaltasPartidos_Alumnos]
GO
ALTER TABLE [dbo].[FaltasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_FaltasPartidos_Alumnos1] FOREIGN KEY([OffenderPlayer])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[FaltasPartidos] CHECK CONSTRAINT [FK_FaltasPartidos_Alumnos1]
GO
ALTER TABLE [dbo].[FaltasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_FaltasPartidos_Equipos] FOREIGN KEY([TeamOffender])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[FaltasPartidos] CHECK CONSTRAINT [FK_FaltasPartidos_Equipos]
GO
ALTER TABLE [dbo].[FaltasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_FaltasPartidos_Equipos1] FOREIGN KEY([TeamOffended])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[FaltasPartidos] CHECK CONSTRAINT [FK_FaltasPartidos_Equipos1]
GO
ALTER TABLE [dbo].[FaltasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_FaltasPartidos_Partidos] FOREIGN KEY([Match])
REFERENCES [dbo].[Partidos] ([MatchId])
GO
ALTER TABLE [dbo].[FaltasPartidos] CHECK CONSTRAINT [FK_FaltasPartidos_Partidos]
GO
ALTER TABLE [dbo].[GolesPartidos]  WITH CHECK ADD  CONSTRAINT [FK_GolesPartidos_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[GolesPartidos] CHECK CONSTRAINT [FK_GolesPartidos_Alumnos]
GO
ALTER TABLE [dbo].[GolesPartidos]  WITH CHECK ADD  CONSTRAINT [FK_GolesPartidos_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[GolesPartidos] CHECK CONSTRAINT [FK_GolesPartidos_Equipos]
GO
ALTER TABLE [dbo].[GolesPartidos]  WITH CHECK ADD  CONSTRAINT [FK_GolesPartidos_Partidos] FOREIGN KEY([Match])
REFERENCES [dbo].[Partidos] ([MatchId])
GO
ALTER TABLE [dbo].[GolesPartidos] CHECK CONSTRAINT [FK_GolesPartidos_Partidos]
GO
ALTER TABLE [dbo].[HistorialPagos]  WITH CHECK ADD  CONSTRAINT [FK_HistorialPagos_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[HistorialPagos] CHECK CONSTRAINT [FK_HistorialPagos_Alumnos]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Proveedores] FOREIGN KEY([Provider])
REFERENCES [dbo].[Proveedores] ([ProviderId])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Proveedores]
GO
ALTER TABLE [dbo].[Ligas]  WITH CHECK ADD  CONSTRAINT [FK_Ligas_Categorias] FOREIGN KEY([Category])
REFERENCES [dbo].[Categorias] ([CategoryId])
GO
ALTER TABLE [dbo].[Ligas] CHECK CONSTRAINT [FK_Ligas_Categorias]
GO
ALTER TABLE [dbo].[LigasEquipos]  WITH CHECK ADD  CONSTRAINT [FK_LigasEquipos_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[LigasEquipos] CHECK CONSTRAINT [FK_LigasEquipos_Equipos]
GO
ALTER TABLE [dbo].[LigasEquipos]  WITH CHECK ADD  CONSTRAINT [FK_LigasEquipos_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[LigasEquipos] CHECK CONSTRAINT [FK_LigasEquipos_Ligas]
GO
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Equipos] FOREIGN KEY([VisitorTeam])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Equipos]
GO
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Equipos1] FOREIGN KEY([LocalTeam])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Equipos1]
GO
ALTER TABLE [dbo].[Partidos]  WITH CHECK ADD  CONSTRAINT [FK_Partidos_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[Partidos] CHECK CONSTRAINT [FK_Partidos_Ligas]
GO
ALTER TABLE [dbo].[TablaAsistencias]  WITH CHECK ADD  CONSTRAINT [FK_TablaAsistencias_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[TablaAsistencias] CHECK CONSTRAINT [FK_TablaAsistencias_Alumnos]
GO
ALTER TABLE [dbo].[TablaAsistencias]  WITH CHECK ADD  CONSTRAINT [FK_TablaAsistencias_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[TablaAsistencias] CHECK CONSTRAINT [FK_TablaAsistencias_Equipos]
GO
ALTER TABLE [dbo].[TablaAsistencias]  WITH CHECK ADD  CONSTRAINT [FK_TablaAsistencias_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[TablaAsistencias] CHECK CONSTRAINT [FK_TablaAsistencias_Ligas]
GO
ALTER TABLE [dbo].[TablaGeneral]  WITH CHECK ADD  CONSTRAINT [FK_TablaGeneral_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[TablaGeneral] CHECK CONSTRAINT [FK_TablaGeneral_Equipos]
GO
ALTER TABLE [dbo].[TablaGeneral]  WITH CHECK ADD  CONSTRAINT [FK_TablaGeneral_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[TablaGeneral] CHECK CONSTRAINT [FK_TablaGeneral_Ligas]
GO
ALTER TABLE [dbo].[TablaGoleo]  WITH CHECK ADD  CONSTRAINT [FK_TablaGoleo_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[TablaGoleo] CHECK CONSTRAINT [FK_TablaGoleo_Alumnos]
GO
ALTER TABLE [dbo].[TablaGoleo]  WITH CHECK ADD  CONSTRAINT [FK_TablaGoleo_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[TablaGoleo] CHECK CONSTRAINT [FK_TablaGoleo_Equipos]
GO
ALTER TABLE [dbo].[TablaGoleo]  WITH CHECK ADD  CONSTRAINT [FK_TablaGoleo_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[TablaGoleo] CHECK CONSTRAINT [FK_TablaGoleo_Ligas]
GO
ALTER TABLE [dbo].[TablaTarjetasAmarillas]  WITH CHECK ADD  CONSTRAINT [FK_TablaTarjetasAmarillas_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[TablaTarjetasAmarillas] CHECK CONSTRAINT [FK_TablaTarjetasAmarillas_Alumnos]
GO
ALTER TABLE [dbo].[TablaTarjetasAmarillas]  WITH CHECK ADD  CONSTRAINT [FK_TablaTarjetasAmarillas_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[TablaTarjetasAmarillas] CHECK CONSTRAINT [FK_TablaTarjetasAmarillas_Equipos]
GO
ALTER TABLE [dbo].[TablaTarjetasAmarillas]  WITH CHECK ADD  CONSTRAINT [FK_TablaTarjetasAmarillas_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[TablaTarjetasAmarillas] CHECK CONSTRAINT [FK_TablaTarjetasAmarillas_Ligas]
GO
ALTER TABLE [dbo].[TablaTarjetasRojas]  WITH CHECK ADD  CONSTRAINT [FK_TablaTarjetasRojas_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[TablaTarjetasRojas] CHECK CONSTRAINT [FK_TablaTarjetasRojas_Alumnos]
GO
ALTER TABLE [dbo].[TablaTarjetasRojas]  WITH CHECK ADD  CONSTRAINT [FK_TablaTarjetasRojas_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[TablaTarjetasRojas] CHECK CONSTRAINT [FK_TablaTarjetasRojas_Equipos]
GO
ALTER TABLE [dbo].[TablaTarjetasRojas]  WITH CHECK ADD  CONSTRAINT [FK_TablaTarjetasRojas_Ligas] FOREIGN KEY([League])
REFERENCES [dbo].[Ligas] ([LeagueId])
GO
ALTER TABLE [dbo].[TablaTarjetasRojas] CHECK CONSTRAINT [FK_TablaTarjetasRojas_Ligas]
GO
ALTER TABLE [dbo].[TarjetasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasPartidos_Alumnos] FOREIGN KEY([Student])
REFERENCES [dbo].[Alumnos] ([StudentId])
GO
ALTER TABLE [dbo].[TarjetasPartidos] CHECK CONSTRAINT [FK_TarjetasPartidos_Alumnos]
GO
ALTER TABLE [dbo].[TarjetasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasPartidos_Equipos] FOREIGN KEY([Team])
REFERENCES [dbo].[Equipos] ([TeamId])
GO
ALTER TABLE [dbo].[TarjetasPartidos] CHECK CONSTRAINT [FK_TarjetasPartidos_Equipos]
GO
ALTER TABLE [dbo].[TarjetasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasPartidos_FaltasPartidos] FOREIGN KEY([FoulId])
REFERENCES [dbo].[FaltasPartidos] ([FoulId])
GO
ALTER TABLE [dbo].[TarjetasPartidos] CHECK CONSTRAINT [FK_TarjetasPartidos_FaltasPartidos]
GO
ALTER TABLE [dbo].[TarjetasPartidos]  WITH CHECK ADD  CONSTRAINT [FK_TarjetasPartidos_Partidos] FOREIGN KEY([Match])
REFERENCES [dbo].[Partidos] ([MatchId])
GO
ALTER TABLE [dbo].[TarjetasPartidos] CHECK CONSTRAINT [FK_TarjetasPartidos_Partidos]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
USE [master]
GO
ALTER DATABASE [AcademiaFutbol] SET  READ_WRITE 
GO
