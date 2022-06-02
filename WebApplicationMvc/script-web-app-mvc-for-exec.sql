USE [master]
GO
/****** Object:  Database [Prueba]    Script Date: 5/31/2022 9:39:14 PM ******/
CREATE DATABASE [Prueba]
GO
ALTER DATABASE [Prueba] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Prueba] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Prueba] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Prueba] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Prueba] SET ARITHABORT OFF 
GO
ALTER DATABASE [Prueba] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Prueba] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Prueba] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Prueba] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Prueba] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Prueba] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Prueba] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Prueba] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Prueba] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Prueba] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Prueba] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Prueba] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Prueba] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Prueba] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Prueba] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Prueba] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Prueba] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Prueba] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Prueba] SET  MULTI_USER 
GO
ALTER DATABASE [Prueba] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Prueba] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Prueba] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Prueba] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Prueba] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Prueba] SET QUERY_STORE = OFF
GO
USE [Prueba]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Prueba]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/31/2022 9:39:14 PM ******/
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
/****** Object:  Table [dbo].[Detalles]    Script Date: 5/31/2022 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Entero] [int] NOT NULL,
	[Flotante] [real] NOT NULL,
	[Enum] [int] NOT NULL,
	[Cadena] [nvarchar](max) NULL,
	[FechaHora] [datetime2](7) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Hora] [datetime2](7) NOT NULL,
	[decimanl] [decimal](18, 2) NOT NULL,
	[booleano] [bit] NOT NULL,
	[NombreArchivo] [nvarchar](max) NULL,
	[Archivo] [nvarchar](max) NULL,
	[MaestroId] [int] NULL,
	[MaestroId1] [bigint] NULL,
 CONSTRAINT [PK_Detalles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Maestros]    Script Date: 5/31/2022 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Maestros](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[NombreEntero] [int] NULL,
	[Flotante] [real] NULL,
	[Enum] [int] NULL,
	[CualquierNombreDeCadena] [nvarchar](max) NULL,
	[FechaHora] [datetime2](7) NULL,
	[Fecha] [datetime2](7) NULL,
	[Hora] [datetime2](7) NULL,
	[Decimal] [decimal](18, 2) NULL,
	[Booleano] [bit] NULL,
	[FechaActualizacion] [datetime2](7) NOT NULL,
	[FechaCreacion] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Maestros] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/31/2022 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USUARIOS]    Script Date: 5/31/2022 9:39:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USUARIOS](
	[Identificador] [int] IDENTITY(1,1) NOT NULL,
	[STR_NOMB] [nvarchar](max) NULL,
	[STR_APE] [nvarchar](max) NULL,
	[STR_USUARIO] [nvarchar](max) NULL,
	[STR_CONTRA] [nvarchar](max) NULL,
	[RolId] [int] NULL,
 CONSTRAINT [PK_USUARIOS] PRIMARY KEY CLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210511025631_first', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210514212932_maestro', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210514213427_addeddefaultvalue', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210514213555_adedfields', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210520021911_adedUsertable', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210520023653_changedUser', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210530032358_adedRol', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210530033549_changedAsOptionalRol', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[Detalles] ON 

INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (4004, 554, 44444, 0, NULL, CAST(N'2021-05-23T19:53:00.0000000' AS DateTime2), CAST(N'2021-05-07T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-16T19:52:00.0000000' AS DateTime2), CAST(55454.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (4005, 44444, 4444, 1, N'44444444', CAST(N'2021-05-14T19:53:00.0000000' AS DateTime2), CAST(N'2021-05-13T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-16T19:52:00.0000000' AS DateTime2), CAST(44444444.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (4006, 4545, 555555, 1, N'rewrwe', CAST(N'2021-05-15T19:52:00.0000000' AS DateTime2), CAST(N'2021-05-15T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-16T19:54:00.0000000' AS DateTime2), CAST(5855.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (4007, 4, 44545, 1, N'45345435', CAST(N'2021-05-08T19:52:00.0000000' AS DateTime2), CAST(N'2021-05-07T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-16T19:54:00.0000000' AS DateTime2), CAST(54353.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5004, 444, 44444, 1, N'gfkjlgfk', CAST(N'2021-05-14T22:02:00.0000000' AS DateTime2), CAST(N'2021-04-30T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-16T19:02:00.0000000' AS DateTime2), CAST(4444.00 AS Decimal(18, 2)), 1, NULL, NULL, 3, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5005, 44444444, 44444444, 0, N'444444', CAST(N'2021-05-16T23:00:00.0000000' AS DateTime2), CAST(N'2021-05-14T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-16T20:02:00.0000000' AS DateTime2), CAST(444444444.00 AS Decimal(18, 2)), 0, NULL, NULL, 3, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5008, 32, 45.25, 0, N'cristopher', CAST(N'2021-05-23T21:46:00.0000000' AS DateTime2), CAST(N'1988-12-08T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-23T22:45:00.0000000' AS DateTime2), CAST(32.50 AS Decimal(18, 2)), 1, NULL, NULL, 40003, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5009, 2, 2, 2, N'sdasdsa', CAST(N'2021-05-23T23:49:00.0000000' AS DateTime2), CAST(N'2021-05-23T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-23T23:49:00.0000000' AS DateTime2), CAST(4554.00 AS Decimal(18, 2)), 1, NULL, NULL, 40006, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5010, 2, 34, 0, NULL, CAST(N'2021-08-12T02:00:00.0000000' AS DateTime2), CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-03T00:00:00.0000000' AS DateTime2), CAST(54.00 AS Decimal(18, 2)), 0, NULL, NULL, 40006, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5011, 345, 55, 0, N'555555555555555555555555555', CAST(N'2021-08-03T12:59:00.0000000' AS DateTime2), CAST(N'2021-08-03T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-03T00:59:00.0000000' AS DateTime2), CAST(45534.00 AS Decimal(18, 2)), 0, NULL, NULL, 70008, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5012, 66, 6.666667E+08, 2, N'6666666666666666666', CAST(N'2021-08-12T13:00:00.0000000' AS DateTime2), CAST(N'2021-08-12T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-03T13:03:00.0000000' AS DateTime2), CAST(66666.00 AS Decimal(18, 2)), 0, NULL, NULL, 40006, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5014, 78, 1212, 1, N'Created from api', CAST(N'2021-05-08T22:55:00.0000000' AS DateTime2), CAST(N'2021-05-13T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-13T22:58:00.0000000' AS DateTime2), CAST(4554.00 AS Decimal(18, 2)), 1, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5015, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5016, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5017, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5018, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5019, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5020, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (5021, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (6021, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (6022, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (6023, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (7021, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (8021, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
INSERT [dbo].[Detalles] ([Id], [Entero], [Flotante], [Enum], [Cadena], [FechaHora], [Fecha], [Hora], [decimanl], [booleano], [NombreArchivo], [Archivo], [MaestroId], [MaestroId1]) VALUES (8022, 0, 0, 0, NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-25T00:00:00.0000000' AS DateTime2), CAST(0.00 AS Decimal(18, 2)), 0, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Detalles] OFF
GO
SET IDENTITY_INSERT [dbo].[Maestros] ON 

INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (40006, 2, 666, 0, N'cacc', CAST(N'2021-05-23T23:49:00.0000000' AS DateTime2), NULL, NULL, CAST(32.50 AS Decimal(18, 2)), 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-05-23T19:45:32.2863127' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (50010, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-02T16:57:53.3277783' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (60008, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-02T17:03:35.9465913' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (70008, NULL, NULL, NULL, N'asdaskd asdas das asd asd as', NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-03T12:20:02.5504970' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (80008, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-03T12:53:23.0439051' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (80009, NULL, NULL, 1, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-03T12:54:00.7010916' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (80010, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-07T22:05:30.3038811' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (80011, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-07T22:05:38.7300634' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (80012, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-07T22:05:49.1781824' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (80013, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2021-08-12T12:54:10.7518010' AS DateTime2))
INSERT [dbo].[Maestros] ([Id], [NombreEntero], [Flotante], [Enum], [CualquierNombreDeCadena], [FechaHora], [Fecha], [Hora], [Decimal], [Booleano], [FechaActualizacion], [FechaCreacion]) VALUES (90013, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2022-05-18T11:58:12.1113752' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Maestros] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Nombre], [Descripcion]) VALUES (5, N'Admin', N'Admin')
INSERT [dbo].[Roles] ([Id], [Nombre], [Descripcion]) VALUES (6, N'Usuario', N'Usuario')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[USUARIOS] ON 

INSERT [dbo].[USUARIOS] ([Identificador], [STR_NOMB], [STR_APE], [STR_USUARIO], [STR_CONTRA], [RolId]) VALUES (1, N'Chester', N'Apellido', N'admin', N'MTIzcXdl', 5)
INSERT [dbo].[USUARIOS] ([Identificador], [STR_NOMB], [STR_APE], [STR_USUARIO], [STR_CONTRA], [RolId]) VALUES (2, N'Pepe', N'Apellido', N'user', N'MTIzcXdl', 6)
SET IDENTITY_INSERT [dbo].[USUARIOS] OFF
GO
/****** Object:  Index [IX_Detalles_MaestroId1]    Script Date: 5/31/2022 9:39:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Detalles_MaestroId1] ON [dbo].[Detalles]
(
	[MaestroId1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_USUARIOS_RolId]    Script Date: 5/31/2022 9:39:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_USUARIOS_RolId] ON [dbo].[USUARIOS]
(
	[RolId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Maestros] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaActualizacion]
GO
ALTER TABLE [dbo].[Maestros] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[Detalles]  WITH CHECK ADD  CONSTRAINT [FK_Detalles_Maestros_MaestroId1] FOREIGN KEY([MaestroId1])
REFERENCES [dbo].[Maestros] ([Id])
GO
ALTER TABLE [dbo].[Detalles] CHECK CONSTRAINT [FK_Detalles_Maestros_MaestroId1]
GO
ALTER TABLE [dbo].[USUARIOS]  WITH CHECK ADD  CONSTRAINT [FK_USUARIOS_Roles_RolId] FOREIGN KEY([RolId])
REFERENCES [dbo].[Roles] ([Id])
GO
ALTER TABLE [dbo].[USUARIOS] CHECK CONSTRAINT [FK_USUARIOS_Roles_RolId]
GO
USE [master]
GO
ALTER DATABASE [Prueba] SET  READ_WRITE 
GO
