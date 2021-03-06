USE [master]
GO
/****** Object:  Database [ExcelTeamplate]    Script Date: 03/06/2019 15:40:43 ******/
CREATE DATABASE [ExcelTeamplate] ON  PRIMARY 
( NAME = N'ExcelTeamplate', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ExcelTeamplate.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ExcelTeamplate_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\ExcelTeamplate_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ExcelTeamplate] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ExcelTeamplate].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ExcelTeamplate] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [ExcelTeamplate] SET ANSI_NULLS OFF
GO
ALTER DATABASE [ExcelTeamplate] SET ANSI_PADDING OFF
GO
ALTER DATABASE [ExcelTeamplate] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [ExcelTeamplate] SET ARITHABORT OFF
GO
ALTER DATABASE [ExcelTeamplate] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [ExcelTeamplate] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [ExcelTeamplate] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [ExcelTeamplate] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [ExcelTeamplate] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [ExcelTeamplate] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [ExcelTeamplate] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [ExcelTeamplate] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [ExcelTeamplate] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [ExcelTeamplate] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [ExcelTeamplate] SET  ENABLE_BROKER
GO
ALTER DATABASE [ExcelTeamplate] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [ExcelTeamplate] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [ExcelTeamplate] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [ExcelTeamplate] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [ExcelTeamplate] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [ExcelTeamplate] SET READ_COMMITTED_SNAPSHOT ON
GO
ALTER DATABASE [ExcelTeamplate] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [ExcelTeamplate] SET  READ_WRITE
GO
ALTER DATABASE [ExcelTeamplate] SET RECOVERY FULL
GO
ALTER DATABASE [ExcelTeamplate] SET  MULTI_USER
GO
ALTER DATABASE [ExcelTeamplate] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [ExcelTeamplate] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'ExcelTeamplate', N'ON'
GO
USE [ExcelTeamplate]
GO
/****** Object:  Table [dbo].[Logs]    Script Date: 03/06/2019 15:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientIp] [nvarchar](max) NULL,
	[ActionType] [int] NOT NULL,
	[AddTime] [datetime2](7) NOT NULL,
	[Remark] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fields]    Script Date: 03/06/2019 15:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fields](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FieldName] [nvarchar](max) NULL,
	[FieldText] [nvarchar](max) NULL,
	[FieldType] [int] NOT NULL,
	[FieldLength] [int] NOT NULL,
	[FieldRequired] [bit] NOT NULL,
	[FieldState] [bit] NOT NULL,
	[AddTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Fields] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段表自增主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'FieldName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段中文名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'FieldText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'FieldType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'FieldLength'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段是否必需' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'FieldRequired'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'FieldState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Fields', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
/****** Object:  Table [dbo].[Datas]    Script Date: 03/06/2019 15:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Datas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataType] [int] NOT NULL,
	[AddTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Datas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attaches]    Script Date: 03/06/2019 15:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attaches](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BId] [int] NOT NULL,
	[FileName] [nvarchar](max) NULL,
	[FilePath] [nvarchar](max) NULL,
	[ClientIP] [nvarchar](max) NULL,
	[FileState] [int] NOT NULL,
	[FileSize] [float] NOT NULL,
	[AddTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Attaches] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 03/06/2019 15:40:43 ******/
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mains]    Script Date: 03/06/2019 15:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mains](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DataId] [int] NOT NULL,
	[AttachId] [int] NOT NULL,
	[ClientIP] [nvarchar](max) NULL,
	[Token] [nvarchar](max) NULL,
	[AddTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Mains] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Mains_AttachId] ON [dbo].[Mains] 
(
	[AttachId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Mains_DataId] ON [dbo].[Mains] 
(
	[DataId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Mains_Attaches_AttachId]    Script Date: 03/06/2019 15:40:43 ******/
ALTER TABLE [dbo].[Mains]  WITH CHECK ADD  CONSTRAINT [FK_Mains_Attaches_AttachId] FOREIGN KEY([AttachId])
REFERENCES [dbo].[Attaches] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mains] CHECK CONSTRAINT [FK_Mains_Attaches_AttachId]
GO
/****** Object:  ForeignKey [FK_Mains_Datas_DataId]    Script Date: 03/06/2019 15:40:43 ******/
ALTER TABLE [dbo].[Mains]  WITH CHECK ADD  CONSTRAINT [FK_Mains_Datas_DataId] FOREIGN KEY([DataId])
REFERENCES [dbo].[Datas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mains] CHECK CONSTRAINT [FK_Mains_Datas_DataId]
GO
