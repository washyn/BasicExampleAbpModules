USE [master]
GO
/****** Object:  Database [Prueba]    Script Date: 6/8/2022 8:35:42 AM ******/
CREATE DATABASE [Prueba]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Prueba', FILENAME = N'C:\Users\user\Prueba.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Prueba_log', FILENAME = N'C:\Users\user\Prueba_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Prueba] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Prueba].[dbo].[sp_fulltext_database] @action = 'enable'
end
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/8/2022 8:35:42 AM ******/
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
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/8/2022 8:35:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](max) NULL,
	[Apellidos] [nvarchar](max) NULL,
	[User] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220605220021_adeduserrolprop', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220608002032_changedpropertynames', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (1, N'ROMULO', N'HUILLCA', N'admin', N'MTIzcXdl', N'Medico')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (3, N'HUGO', N'BAZAN', N'user', N'MTIzcXdl', N'Paciente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (1003, N'ELSA', N'FLORES', N'user1', N'MTIzcXdl', N'Paciente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (1005, N'MANUEL', N'CHAUCCA', N'user2', N'MTIzcXdl', N'Asistente')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
USE [master]
GO
ALTER DATABASE [Prueba] SET  READ_WRITE 
GO
