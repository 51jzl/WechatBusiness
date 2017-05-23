USE [master]
GO
/****** Object:  Database [HNSYS]    Script Date: 10/27/2015 19:04:58 ******/
CREATE DATABASE [HNSYS] ON  PRIMARY 
( NAME = N'HNSYS', FILENAME = N'D:\Development Tools\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\HNSYS.mdf' , SIZE = 26880KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HNSYS_log', FILENAME = N'D:\Development Tools\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\HNSYS_log.LDF' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HNSYS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HNSYS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HNSYS] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [HNSYS] SET ANSI_NULLS OFF
GO
ALTER DATABASE [HNSYS] SET ANSI_PADDING OFF
GO
ALTER DATABASE [HNSYS] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [HNSYS] SET ARITHABORT OFF
GO
ALTER DATABASE [HNSYS] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [HNSYS] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [HNSYS] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [HNSYS] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [HNSYS] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [HNSYS] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [HNSYS] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [HNSYS] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [HNSYS] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [HNSYS] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [HNSYS] SET  ENABLE_BROKER
GO
ALTER DATABASE [HNSYS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [HNSYS] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [HNSYS] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [HNSYS] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [HNSYS] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [HNSYS] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [HNSYS] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [HNSYS] SET  READ_WRITE
GO
ALTER DATABASE [HNSYS] SET RECOVERY FULL
GO
ALTER DATABASE [HNSYS] SET  MULTI_USER
GO
ALTER DATABASE [HNSYS] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [HNSYS] SET DB_CHAINING OFF
GO
EXEC sys.sp_db_vardecimal_storage_format N'HNSYS', N'ON'
GO
USE [HNSYS]
GO
/****** Object:  Table [dbo].[DictValue]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DictValue](
	[ValID] [int] IDENTITY(1,1) NOT NULL,
	[KeyID] [int] NOT NULL,
	[ValName] [nvarchar](50) NOT NULL,
	[FirstPY] [varchar](50) NULL,
	[Sort] [int] NOT NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_DictValue] PRIMARY KEY CLUSTERED 
(
	[ValID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictValue', @level2type=N'COLUMN',@level2name=N'ValID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主表ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictValue', @level2type=N'COLUMN',@level2name=N'KeyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictValue', @level2type=N'COLUMN',@level2name=N'ValName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拼音码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictValue', @level2type=N'COLUMN',@level2name=N'FirstPY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictValue', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典表子表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictValue'
GO
/****** Object:  Table [dbo].[DictKey]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DictKey](
	[KeyID] [int] IDENTITY(1,1) NOT NULL,
	[KeyName] [nvarchar](50) NOT NULL,
	[Sort] [int] NOT NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_DictKey] PRIMARY KEY CLUSTERED 
(
	[KeyID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictKey', @level2type=N'COLUMN',@level2name=N'KeyID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictKey', @level2type=N'COLUMN',@level2name=N'KeyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictKey', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictKey', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典主表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictKey'
GO
/****** Object:  Table [dbo].[CharPY]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CharPY](
	[PYID] [int] IDENTITY(10000,1) NOT NULL,
	[CharName] [varchar](4) NOT NULL,
	[PY] [varchar](10) NOT NULL,
	[FirstPY] [char](1) NOT NULL,
 CONSTRAINT [PK_CharPY] PRIMARY KEY CLUSTERED 
(
	[PYID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CharPY', @level2type=N'COLUMN',@level2name=N'PYID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字符' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CharPY', @level2type=N'COLUMN',@level2name=N'CharName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拼音' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CharPY', @level2type=N'COLUMN',@level2name=N'PY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拼音首字母' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CharPY', @level2type=N'COLUMN',@level2name=N'FirstPY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拼音表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CharPY'
GO
/****** Object:  Table [dbo].[Button]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Button](
	[BtnID] [int] IDENTITY(1,1) NOT NULL,
	[BtnCode] [varchar](50) NOT NULL,
	[BtnName] [varchar](50) NOT NULL,
	[BtnTitle] [varchar](50) NOT NULL,
	[BtnClick] [varchar](50) NOT NULL,
	[Icon] [varchar](50) NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Action] [varchar](50) NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_Button] PRIMARY KEY CLUSTERED 
(
	[BtnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'BtnID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮控件ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'BtnCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'BtnName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮Title' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'BtnTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮执行的JS事件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'BtnClick'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮类型 0通用 1 System 2用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'动作 对应控制器中方法名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'Action'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Button'
GO
/****** Object:  Table [dbo].[Area]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Area](
	[AreaID] [bigint] NOT NULL,
	[AreaName] [nvarchar](50) NOT NULL,
	[ParentID] [bigint] NOT NULL,
	[Mark] [int] NOT NULL,
 CONSTRAINT [PK_Area] PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersRole]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersRole](
	[UserID] [int] NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_UsersRole] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsersRole', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsersRole', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsersRole'
GO
/****** Object:  Table [dbo].[UsersOrganize]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersOrganize](
	[UserID] [int] NOT NULL,
	[OrgID] [int] NOT NULL,
 CONSTRAINT [PK_UsersOrganize] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[OrgID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsersOrganize', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'部门ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsersOrganize', @level2type=N'COLUMN',@level2name=N'OrgID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户部门关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UsersOrganize'
GO
/****** Object:  Table [dbo].[Users]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](50) NOT NULL,
	[FirstPY] [varchar](20) NULL,
	[LoginName] [varchar](50) NULL,
	[Pwd] [varchar](16) NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[Gender] [tinyint] NOT NULL,
	[Birthday] [date] NULL,
	[Email] [varchar](50) NULL,
	[Tel] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[QQ] [varchar](12) NULL,
	[Description] [nvarchar](200) NULL,
	[ProFessTitle] [nvarchar](50) NULL,
	[IDCard] [varchar](18) NULL,
	[NativePlace] [nvarchar](100) NULL,
	[HomeAddress] [nvarchar](100) NULL,
	[Nation] [nvarchar](50) NULL,
	[Major] [nvarchar](50) NULL,
	[Education] [nvarchar](50) NULL,
	[School] [nvarchar](50) NULL,
	[Degree] [nvarchar](50) NULL,
	[JoinInDate] [date] NULL,
	[DimissionDate] [date] NULL,
	[DimissionCause] [nvarchar](100) NULL,
	[DeleteMark] [tinyint] NOT NULL,
	[CreateID] [int] NOT NULL,
	[CreateName] [nvarchar](20) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsAdmin] [tinyint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'助记码 拼音首字母' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'FirstPY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Pwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别 0男 1女' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Gender'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生日' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Birthday'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电子邮箱' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'固定电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Tel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移动电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'QQ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'ProFessTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IDCard'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'家庭住址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'HomeAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Nation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'专业' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Major'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最高学历' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Education'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'毕业院校' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'School'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最高学位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'Degree'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入职日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'JoinInDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离职日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DimissionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'离职原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DimissionCause'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标记 0正常 1删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreateName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否系统管理员 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users', @level2type=N'COLUMN',@level2name=N'IsAdmin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Users'
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
	[IsDefault] [tinyint] NOT NULL,
	[Sort] [int] NOT NULL,
	[Remark] [nvarchar](200) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'RoleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否默认角色 0否 1是 不允许删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'IsDefault'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Roles'
GO
/****** Object:  Table [dbo].[RoleModule]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModule](
	[RoleID] [int] NOT NULL,
	[ModID] [int] NOT NULL,
 CONSTRAINT [PK_RoleModule] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[ModID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModule', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModule', @level2type=N'COLUMN',@level2name=N'ModID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色节点权限' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModule'
GO
/****** Object:  Table [dbo].[RoleModButton]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleModButton](
	[RoleID] [int] NOT NULL,
	[ModID] [int] NOT NULL,
	[BtnID] [int] NOT NULL,
 CONSTRAINT [PK_ModuleButton] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC,
	[ModID] ASC,
	[BtnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModButton', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModButton', @level2type=N'COLUMN',@level2name=N'ModID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModButton', @level2type=N'COLUMN',@level2name=N'BtnID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色页面按钮表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleModButton'
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Organization](
	[OrgID] [int] IDENTITY(1,1) NOT NULL,
	[OrgCode] [varchar](50) NOT NULL,
	[OrgName] [nvarchar](50) NOT NULL,
	[Manager] [nvarchar](20) NOT NULL,
	[AssistantManager] [nvarchar](20) NULL,
	[InnerPhone] [varchar](20) NULL,
	[OuterPhone] [varchar](20) NULL,
	[Fax] [varchar](20) NULL,
	[Sort] [int] NOT NULL,
	[Address] [nvarchar](100) NULL,
	[Remark] [nvarchar](200) NULL,
	[ParentID] [int] NOT NULL,
	[DeleteMark] [tinyint] NOT NULL,
	[CreateID] [int] NOT NULL,
	[CreateName] [nvarchar](20) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrgID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'OrgID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'OrgName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Manager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'副负责人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'AssistantManager'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内线电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'InnerPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外线电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'OuterPhone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Fax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所在地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级ID 0代表顶级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'删除标志 0正常 1删除' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'DeleteMark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'CreateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加人名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'CreateName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization', @level2type=N'COLUMN',@level2name=N'CreateDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Organization'
GO
/****** Object:  Table [dbo].[ModuleButton]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModuleButton](
	[ModID] [int] NOT NULL,
	[BtnID] [int] NOT NULL,
 CONSTRAINT [PK_ModuleButton_1] PRIMARY KEY CLUSTERED 
(
	[ModID] ASC,
	[BtnID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节点ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModuleButton', @level2type=N'COLUMN',@level2name=N'ModID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'按钮ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModuleButton', @level2type=N'COLUMN',@level2name=N'BtnID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'页面按钮表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ModuleButton'
GO
/****** Object:  Table [dbo].[Module]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Module](
	[ModID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NOT NULL,
	[Targe] [varchar](20) NOT NULL,
	[ModName] [nvarchar](20) NOT NULL,
	[ModTitle] [nvarchar](20) NOT NULL,
	[Link] [varchar](100) NULL,
	[Icon] [varchar](50) NULL,
	[IsEnd] [tinyint] NOT NULL,
	[IsEnable] [tinyint] NOT NULL,
	[Type] [tinyint] NOT NULL,
	[Sort] [int] NOT NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ModID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ModID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级节点 0为顶级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接目标 Iframe Open' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Targe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ModName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块Title' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'ModTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'链接地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Link'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Icon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否末级节点 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'IsEnd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'IsEnable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单类型 0通用 1管理员 2用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Module'
GO
/****** Object:  Table [dbo].[LoginLog]    Script Date: 10/27/2015 19:04:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoginLog](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[LoginName] [varchar](50) NOT NULL,
	[State] [int] NOT NULL,
	[LoginIP] [varchar](20) NOT NULL,
	[IPAddress] [nvarchar](50) NULL,
	[LoginTime] [datetime] NOT NULL,
 CONSTRAINT [PK_LoginLog] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'LogID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录账户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'LoginName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录状态 0失败 1成功' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'LoginIP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'IP所在地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'IPAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录日志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LoginLog'
GO
/****** Object:  UserDefinedFunction [dbo].[FUN_GETFULLPY]    Script Date: 10/27/2015 19:05:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[FUN_GETFULLPY](@character varchar(50))
returns varchar(1000)
as
begin
declare @fullpy varchar(1000)
declare @word nchar(1)
set @fullpy=''
while len(@character)>0
	begin
	set @word = left(@character,1)
	if (unicode(@word)between 19968 and 19968+20901)  
		select top 1 @fullpy=@fullpy+py from CharPY where CharName=@word
	else
		set @fullpy=@fullpy+@word
	set @character=right(@character,len(@character)-1)
	end
	return @fullpy
end
GO
/****** Object:  UserDefinedFunction [dbo].[FUN_GETFIRSTPY]    Script Date: 10/27/2015 19:05:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE function [dbo].[FUN_GETFIRSTPY](@character varchar(50))
returns varchar(1000)
as
begin
declare @fullpy varchar(1000)
declare @word nchar(1)
set @fullpy='' 
while len(@character)>0
	begin
	set @word = left(@character,1)
	if (unicode(@word)between 19968 and 19968+20901)  
		select top 1 @fullpy=@fullpy+FirstPY from CharPY where CharName=@word
	else
		set @fullpy=@fullpy+@word
	set @character=right(@character,len(@character)-1)
	end
	return @fullpy
end
GO
/****** Object:  Default [DF_Button_Type]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Button] ADD  CONSTRAINT [DF_Button_Type]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_Users_DeleteMark]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
/****** Object:  Default [DF_Users_IsAdmin]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsAdmin]  DEFAULT ((0)) FOR [IsAdmin]
GO
/****** Object:  Default [DF_Roles_IsDefault]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Roles] ADD  CONSTRAINT [DF_Roles_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO
/****** Object:  Default [DF_Organization_DeleteMark]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF_Organization_DeleteMark]  DEFAULT ((0)) FOR [DeleteMark]
GO
/****** Object:  Default [DF_Organization_CreateDate]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Organization] ADD  CONSTRAINT [DF_Organization_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  Default [DF_Module_IsEnable]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_IsEnable]  DEFAULT ((1)) FOR [IsEnable]
GO
/****** Object:  Default [DF_Module_type]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[Module] ADD  CONSTRAINT [DF_Module_type]  DEFAULT ((0)) FOR [Type]
GO
/****** Object:  Default [DF_LoginLog_LoginTime]    Script Date: 10/27/2015 19:04:59 ******/
ALTER TABLE [dbo].[LoginLog] ADD  CONSTRAINT [DF_LoginLog_LoginTime]  DEFAULT (getdate()) FOR [LoginTime]
GO
