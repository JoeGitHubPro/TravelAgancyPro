USE [master]
GO
/****** Object:  Database [TravelAgancy]    Script Date: 16/02/2023 19:52:52 ******/
CREATE DATABASE [TravelAgancy]
 CONTAINMENT = NONE
GO
ALTER DATABASE [TravelAgancy] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TravelAgancy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TravelAgancy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TravelAgancy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TravelAgancy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TravelAgancy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TravelAgancy] SET ARITHABORT OFF 
GO
ALTER DATABASE [TravelAgancy] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TravelAgancy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TravelAgancy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TravelAgancy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TravelAgancy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TravelAgancy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TravelAgancy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TravelAgancy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TravelAgancy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TravelAgancy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TravelAgancy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TravelAgancy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TravelAgancy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TravelAgancy] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TravelAgancy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TravelAgancy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TravelAgancy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TravelAgancy] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TravelAgancy] SET  MULTI_USER 
GO
ALTER DATABASE [TravelAgancy] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TravelAgancy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TravelAgancy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TravelAgancy] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TravelAgancy] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TravelAgancy] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TravelAgancy] SET QUERY_STORE = OFF
GO
USE [TravelAgancy]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Subscription] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DestinationBack]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DestinationBack](
	[DestinationBackID] [int] IDENTITY(1,1) NOT NULL,
	[DestinationNameB] [nvarchar](max) NULL,
	[TravelID] [int] NULL,
 CONSTRAINT [PK_DestinationBack_1] PRIMARY KEY CLUSTERED 
(
	[DestinationBackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DestinationGo]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DestinationGo](
	[DestinationGoID] [int] IDENTITY(1,1) NOT NULL,
	[DestinationName] [nvarchar](max) NULL,
	[TravelID] [int] NULL,
 CONSTRAINT [PK_DestinationGo_1] PRIMARY KEY CLUSTERED 
(
	[DestinationGoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeBack]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeBack](
	[TimeBackID] [int] IDENTITY(1,1) NOT NULL,
	[TimeB] [smalldatetime] NULL,
	[DestinationBackID] [int] NULL,
 CONSTRAINT [PK_TimeBack] PRIMARY KEY CLUSTERED 
(
	[TimeBackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeGo]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeGo](
	[TimeGoID] [int] IDENTITY(1,1) NOT NULL,
	[Time] [smalldatetime] NULL,
	[DestinationGoID] [int] NULL,
 CONSTRAINT [PK_TimeGo] PRIMARY KEY CLUSTERED 
(
	[TimeGoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TimeLine]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeLine](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [nvarchar](128) NOT NULL,
	[Header] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NULL,
	[PostTime] [datetime] NULL,
 CONSTRAINT [PK_TimeLine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Travel]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travel](
	[TravelID] [int] IDENTITY(1,1) NOT NULL,
	[TravelName] [nvarchar](max) NULL,
	[UserCreatorID] [nvarchar](128) NULL,
	[NoOfSites] [int] NULL,
	[TravelDescription] [nvarchar](max) NULL,
	[TravelAppointment] [nvarchar](max) NULL,
	[ImagePath] [nvarchar](max) NULL,
 CONSTRAINT [PK_Travel] PRIMARY KEY CLUSTERED 
(
	[TravelID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Travelers]    Script Date: 16/02/2023 19:52:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Travelers](
	[UserID] [nvarchar](128) NULL,
	[TravelID] [int] NULL,
	[DestinationGoID] [int] NULL,
	[DestinationBackID] [int] NULL,
	[TimeGoID] [int] NULL,
	[TimeBackID] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceNo] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Travelers_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 16/02/2023 19:52:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 16/02/2023 19:52:53 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UserId]    Script Date: 16/02/2023 19:52:53 ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 16/02/2023 19:52:53 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetUsers] ADD  DEFAULT ((0)) FOR [Subscription]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[DestinationBack]  WITH CHECK ADD  CONSTRAINT [FK_DestinationBack_Travel] FOREIGN KEY([TravelID])
REFERENCES [dbo].[Travel] ([TravelID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DestinationBack] CHECK CONSTRAINT [FK_DestinationBack_Travel]
GO
ALTER TABLE [dbo].[DestinationGo]  WITH CHECK ADD  CONSTRAINT [FK_DestinationGo_Travel] FOREIGN KEY([TravelID])
REFERENCES [dbo].[Travel] ([TravelID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DestinationGo] CHECK CONSTRAINT [FK_DestinationGo_Travel]
GO
ALTER TABLE [dbo].[TimeBack]  WITH CHECK ADD  CONSTRAINT [FK_TimeBack_DestinationBack] FOREIGN KEY([DestinationBackID])
REFERENCES [dbo].[DestinationBack] ([DestinationBackID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeBack] CHECK CONSTRAINT [FK_TimeBack_DestinationBack]
GO
ALTER TABLE [dbo].[TimeGo]  WITH CHECK ADD  CONSTRAINT [FK_TimeGo_DestinationGo] FOREIGN KEY([DestinationGoID])
REFERENCES [dbo].[DestinationGo] ([DestinationGoID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TimeGo] CHECK CONSTRAINT [FK_TimeGo_DestinationGo]
GO
ALTER TABLE [dbo].[TimeLine]  WITH CHECK ADD  CONSTRAINT [FK_TimeLine_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[TimeLine] CHECK CONSTRAINT [FK_TimeLine_AspNetUsers]
GO
ALTER TABLE [dbo].[Travel]  WITH CHECK ADD  CONSTRAINT [FK_Travel_AspNetUsers] FOREIGN KEY([UserCreatorID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Travel] CHECK CONSTRAINT [FK_Travel_AspNetUsers]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD  CONSTRAINT [FK_Travelers_AspNetUsers] FOREIGN KEY([UserID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Travelers] CHECK CONSTRAINT [FK_Travelers_AspNetUsers]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD  CONSTRAINT [FK_Travelers_DestinationBack] FOREIGN KEY([DestinationBackID])
REFERENCES [dbo].[DestinationBack] ([DestinationBackID])
GO
ALTER TABLE [dbo].[Travelers] CHECK CONSTRAINT [FK_Travelers_DestinationBack]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD  CONSTRAINT [FK_Travelers_DestinationGo] FOREIGN KEY([DestinationGoID])
REFERENCES [dbo].[DestinationGo] ([DestinationGoID])
GO
ALTER TABLE [dbo].[Travelers] CHECK CONSTRAINT [FK_Travelers_DestinationGo]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD  CONSTRAINT [FK_Travelers_TimeBack] FOREIGN KEY([TimeBackID])
REFERENCES [dbo].[TimeBack] ([TimeBackID])
GO
ALTER TABLE [dbo].[Travelers] CHECK CONSTRAINT [FK_Travelers_TimeBack]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD  CONSTRAINT [FK_Travelers_TimeGo] FOREIGN KEY([TimeGoID])
REFERENCES [dbo].[TimeGo] ([TimeGoID])
GO
ALTER TABLE [dbo].[Travelers] CHECK CONSTRAINT [FK_Travelers_TimeGo]
GO
ALTER TABLE [dbo].[Travelers]  WITH CHECK ADD  CONSTRAINT [FK_Travelers_Travel] FOREIGN KEY([TravelID])
REFERENCES [dbo].[Travel] ([TravelID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Travelers] CHECK CONSTRAINT [FK_Travelers_Travel]
GO
USE [master]
GO
ALTER DATABASE [TravelAgancy] SET  READ_WRITE 
GO
