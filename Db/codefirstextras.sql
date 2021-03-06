USE [master]
GO
/****** Object:  Database [codefirstextras]    Script Date: 09-Dec-15 12:02:54 PM ******/
CREATE DATABASE [codefirstextras]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'codefirstextras', FILENAME = N'D:\SQLDatabases\codefirstextras.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'codefirstextras_log', FILENAME = N'D:\SQLDatabases\codefirstextras_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [codefirstextras] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [codefirstextras].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [codefirstextras] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [codefirstextras] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [codefirstextras] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [codefirstextras] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [codefirstextras] SET ARITHABORT OFF 
GO
ALTER DATABASE [codefirstextras] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [codefirstextras] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [codefirstextras] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [codefirstextras] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [codefirstextras] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [codefirstextras] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [codefirstextras] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [codefirstextras] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [codefirstextras] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [codefirstextras] SET  ENABLE_BROKER 
GO
ALTER DATABASE [codefirstextras] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [codefirstextras] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [codefirstextras] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [codefirstextras] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [codefirstextras] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [codefirstextras] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [codefirstextras] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [codefirstextras] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [codefirstextras] SET  MULTI_USER 
GO
ALTER DATABASE [codefirstextras] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [codefirstextras] SET DB_CHAINING OFF 
GO
ALTER DATABASE [codefirstextras] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [codefirstextras] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [codefirstextras] SET DELAYED_DURABILITY = DISABLED 
GO
USE [codefirstextras]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 09-Dec-15 12:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Description] [nvarchar](500) NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[TopArticles]    Script Date: 09-Dec-15 12:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TopArticles]
AS
SELECT        TOP (3) Id, Title, Description
FROM            dbo.Articles

GO
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Title], [Description]) VALUES (1, N'Chci změnit titulek', N'Pohádka')
INSERT [dbo].[Articles] ([Id], [Title], [Description]) VALUES (2, N'Entity Framework', N'Odborná knížka o EF')
INSERT [dbo].[Articles] ([Id], [Title], [Description]) VALUES (3, N'O Praze', N'Historický blábol')
INSERT [dbo].[Articles] ([Id], [Title], [Description]) VALUES (4, N'Škoda 120', N'Příručka mechanika')
INSERT [dbo].[Articles] ([Id], [Title], [Description]) VALUES (5, N'iPhone', N'Tipy a triky')
SET IDENTITY_INSERT [dbo].[Articles] OFF
/****** Object:  StoredProcedure [dbo].[GetArticle]    Script Date: 09-Dec-15 12:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetArticle]
@id int
AS 

    SET NOCOUNT ON;
    SELECT *
    FROM Articles
	WHERE Id = @id

GO
/****** Object:  StoredProcedure [dbo].[GetArticles]    Script Date: 09-Dec-15 12:02:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetArticles]
AS 

    SET NOCOUNT ON;
    SELECT *
    FROM Articles

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Articles"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 210
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TopArticles'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TopArticles'
GO
USE [master]
GO
ALTER DATABASE [codefirstextras] SET  READ_WRITE 
GO
