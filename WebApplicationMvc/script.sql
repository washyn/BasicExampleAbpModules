USE [master]
GO
/****** Object:  Database [Prueba]    Script Date: 6/15/2022 7:59:49 AM ******/
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
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/15/2022 7:59:49 AM ******/
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
/****** Object:  Table [dbo].[Atencions]    Script Date: 6/15/2022 7:59:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atencions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Diagnostico] [nvarchar](max) NULL,
	[Recomendaciones] [nvarchar](max) NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Receta] [nvarchar](max) NULL,
	[UsuarioDoctorId] [int] NOT NULL,
	[UsuarioPacienteId] [int] NOT NULL,
 CONSTRAINT [PK_Atencions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 6/15/2022 7:59:49 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](max) NULL,
	[Descripcion] [nvarchar](max) NULL,
	[Estado] [int] NOT NULL,
	[FechaHora] [datetime2](7) NOT NULL,
	[UsuarioDoctorId] [int] NOT NULL,
	[UsuarioPacienteId] [int] NOT NULL,
 CONSTRAINT [PK_Citas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/15/2022 7:59:49 AM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612211654_addedCitas', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612211843_changedCitas', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612212235_changedCitas2', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220612223528_changedCitas7676', N'5.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220614024648_adedAtenmtiopn', N'5.0.5')
GO
SET IDENTITY_INSERT [dbo].[Atencions] ON 

INSERT [dbo].[Atencions] ([Id], [Diagnostico], [Recomendaciones], [Fecha], [Receta], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (1, N'Diagnostico , esta mal', N'cuidese', CAST(N'2022-06-13T19:48:48.6590588' AS DateTime2), N'Tomar muchas pildoras', 2011, 1003)
SET IDENTITY_INSERT [dbo].[Atencions] OFF
GO
SET IDENTITY_INSERT [dbo].[Citas] ON 

INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (1, N'Pediatría', N'Decripcion de cita', 2, CAST(N'2022-06-09T03:46:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (2, N'Cardiologia', N'Descripcion', 2, CAST(N'2022-06-12T15:53:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (3, N'Cardiologia', N'asddasuiasdsdasaasd', 2, CAST(N'2022-06-12T17:42:00.0000000' AS DateTime2), 1, 3)
INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (4, N'Cardiologia', N'Decripcion de cita', 0, CAST(N'2022-06-13T19:03:00.0000000' AS DateTime2), 2011, 3)
INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (5, N'Cardiologia', N'Decripcion de cita', 0, CAST(N'2022-06-13T19:39:00.0000000' AS DateTime2), 2011, 1003)
INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (6, N'Cardiologia', N'Decripcion de cita', 0, CAST(N'2022-06-13T19:49:00.0000000' AS DateTime2), 2011, 1003)
INSERT [dbo].[Citas] ([Id], [Categoria], [Descripcion], [Estado], [FechaHora], [UsuarioDoctorId], [UsuarioPacienteId]) VALUES (7, N'Cardiologia', N'Decripcion de cita', 1, CAST(N'2022-06-13T08:08:00.0000000' AS DateTime2), 2011, 3)
SET IDENTITY_INSERT [dbo].[Citas] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (1, N'ROMULO', N'HUILLCA', N'admin', N'MTIzcXdl', N'Medico')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (3, N'HUGO', N'BAZAN', N'user', N'MTIzcXdl', N'Paciente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (1003, N'ELSA', N'FLORES', N'user1', N'MTIzcXdl', N'Paciente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (1005, N'MANUEL', N'CHAUCCA', N'user2', N'MTIzcXdl', N'Asistente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (2009, N'paciente', N'paciente', N'paciente', N'cGFjaWVudGU=', N'Paciente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (2010, N'asistente', N'asistente', N'asistente', N'YXNpc3RlbnRl', N'Asistente')
INSERT [dbo].[Usuarios] ([Id], [Nombres], [Apellidos], [User], [Password], [Role]) VALUES (2011, N'doctor', N'doctor', N'doctor', N'ZG9jdG9y', N'Medico')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
/****** Object:  Index [IX_Atencions_UsuarioDoctorId]    Script Date: 6/15/2022 7:59:49 AM ******/
CREATE NONCLUSTERED INDEX [IX_Atencions_UsuarioDoctorId] ON [dbo].[Atencions]
(
	[UsuarioDoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Atencions_UsuarioPacienteId]    Script Date: 6/15/2022 7:59:49 AM ******/
CREATE NONCLUSTERED INDEX [IX_Atencions_UsuarioPacienteId] ON [dbo].[Atencions]
(
	[UsuarioPacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Citas_UsuarioDoctorId]    Script Date: 6/15/2022 7:59:49 AM ******/
CREATE NONCLUSTERED INDEX [IX_Citas_UsuarioDoctorId] ON [dbo].[Citas]
(
	[UsuarioDoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Citas_UsuarioPacienteId]    Script Date: 6/15/2022 7:59:49 AM ******/
CREATE NONCLUSTERED INDEX [IX_Citas_UsuarioPacienteId] ON [dbo].[Citas]
(
	[UsuarioPacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT ((0)) FOR [Estado]
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [FechaHora]
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT ((0)) FOR [UsuarioDoctorId]
GO
ALTER TABLE [dbo].[Citas] ADD  DEFAULT ((0)) FOR [UsuarioPacienteId]
GO
ALTER TABLE [dbo].[Atencions]  WITH CHECK ADD  CONSTRAINT [FK_Atencions_Usuarios_UsuarioDoctorId] FOREIGN KEY([UsuarioDoctorId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Atencions] CHECK CONSTRAINT [FK_Atencions_Usuarios_UsuarioDoctorId]
GO
ALTER TABLE [dbo].[Atencions]  WITH CHECK ADD  CONSTRAINT [FK_Atencions_Usuarios_UsuarioPacienteId] FOREIGN KEY([UsuarioPacienteId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Atencions] CHECK CONSTRAINT [FK_Atencions_Usuarios_UsuarioPacienteId]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Usuarios_UsuarioDoctorId] FOREIGN KEY([UsuarioDoctorId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Usuarios_UsuarioDoctorId]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD  CONSTRAINT [FK_Citas_Usuarios_UsuarioPacienteId] FOREIGN KEY([UsuarioPacienteId])
REFERENCES [dbo].[Usuarios] ([Id])
GO
ALTER TABLE [dbo].[Citas] CHECK CONSTRAINT [FK_Citas_Usuarios_UsuarioPacienteId]
GO
USE [master]
GO
ALTER DATABASE [Prueba] SET  READ_WRITE 
GO
