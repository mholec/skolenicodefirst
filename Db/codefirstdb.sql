USE [master]
GO
/****** Object:  Database [codefirstdb]    Script Date: 09-Dec-15 12:04:32 PM ******/
CREATE DATABASE [codefirstdb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'codefirstdb', FILENAME = N'D:\SQLDatabases\codefirstdb.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'codefirstdb_log', FILENAME = N'D:\SQLDatabases\codefirstdb_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [codefirstdb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [codefirstdb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [codefirstdb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [codefirstdb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [codefirstdb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [codefirstdb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [codefirstdb] SET ARITHABORT OFF 
GO
ALTER DATABASE [codefirstdb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [codefirstdb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [codefirstdb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [codefirstdb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [codefirstdb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [codefirstdb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [codefirstdb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [codefirstdb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [codefirstdb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [codefirstdb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [codefirstdb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [codefirstdb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [codefirstdb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [codefirstdb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [codefirstdb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [codefirstdb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [codefirstdb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [codefirstdb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [codefirstdb] SET  MULTI_USER 
GO
ALTER DATABASE [codefirstdb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [codefirstdb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [codefirstdb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [codefirstdb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [codefirstdb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [codefirstdb]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 09-Dec-15 12:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Books]    Script Date: 09-Dec-15 12:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Added] [datetime] NOT NULL,
	[Url] [nvarchar](max) NULL,
	[Discriminator] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.Books] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categories]    Script Date: 09-Dec-15 12:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Parameters]    Script Date: 09-Dec-15 12:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parameters](
	[ParameterId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_dbo.Parameters] PRIMARY KEY CLUSTERED 
(
	[ParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParameterValues]    Script Date: 09-Dec-15 12:04:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParameterValues](
	[ParameterValueId] [int] IDENTITY(1,1) NOT NULL,
	[ParameterId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
	[Value] [nvarchar](300) NOT NULL,
 CONSTRAINT [PK_dbo.ParameterValues] PRIMARY KEY CLUSTERED 
(
	[ParameterValueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__MigrationHistory] ([MigrationId], [ContextKey], [Model], [ProductVersion]) VALUES (N'201511170950538_InitialCreate', N'Dotazovani.BookStoreContext', 0x1F8B0800000000000400DD5CDB6E1B37107D2FD07F58EC535A385A5F102035A4048E6C1746E338B0ECA06F06BD4BC944F6A22E29C36AD12FEB433FA9BFD0D93B97B7BDE89A2040222D39C3E1CC1972C83DCA7FFFFC3B7CFF12F8D6338E2989C2917D3438B42D1CBA9147C2D9C85EB0E9EBB7F6FB773FFE30BCF08217EB4BD1EF24E90792211DD94F8CCD4F1D87BA4F3840741010378E68346503370A1CE445CEF1E1E12FCED1918341850DBA2C6B78BB08190970FA05BE8EA3D0C573B640FE75E4619FE6CFA165926AB53EA100D33972F1C83E8F18FA337A4621B1AD339F20B06082FDA96DA130842606F69DDE533C617114CE26737880FCBBE51C43BF29F229CEED3EADBAB79DC2E1713205A7122C54B90BCAA2A0A3C2A393DC278E28DECBB376E933F0DA0578972D9359A79E1BD91FA2E8AB6D89039D8EFD38E9C43B7590CA124C0789CC8155B51C94E10794247F0EACF1C2678B188F42BC6031F20FACCF8B479FB8BFE1E55DF41587A370E1FBBC61601AB4D51EC0A3CF7134C7315BDEE22967EE95675B4E5DD611854B51412E9BD455C84E8E6DEB1318811E7D5CC69F73C0844531FE158738460C7B9F11633886F05D7938F5A0648130DE18A46651BC6C1ED3ACE78E301F172A00B9907CB6758D5E3EE270C69E202D0F21DD2EC90BF68A27B9DAFB9040AE82108B17B8F3B0679E874BCBCF612E779093CD5A3EA167324BFDA771876DDD623FED409FC83CCBCF144E0F558FCB380A6E233F0F5AD9F0308916B19BF82252B5DEA17886597B8B3EA318FE85A07E41FE0253BD615247C13EA15D6DA6D84965EDD0A992D398B295ABBAA56D21B7A3D4E553A26BFAB64FA7F5A530C40C3A4A239A8592BF0DE9FA663DD9AA4575023603969B93AC00A63AC90A6CB74EFB27E27BE045A545A5D6CCD1BC4D42936495D8DED5AE62C4D5AC12335D6775AF24AFAF185D53BD2EBDA384AF1BD127ED650D5B4CFE6CE45537F076858759470E01EDAA72B2A622C0B8ACAC6F8754AE31BA6DB4F37EAEB4B36C7D906D14DB24FBA40E2ADBBA2776EF9CDE753AAF94C9DB4CE21D6FC686CAB2131EC57D460BD85E78BCE87302BC58D711D0FA8028CE23542C28B631A8F7B16F88297C6C15D47EA90BC3010EFB388C13DD98DBEA933AA33472496A9A504417A54DDDCD17A16735D439D5785521790DE692391808AE1AD93F4BD9A1575B2EB3CD6A0F0783234933AC4C385144903F86E40267818BE5658C842E9923DF6C8420D6F1FC9240A81C486C39C7731C260B96D9BB6D2CA84E24F2F8E530C2C2DCE4A5A1C301C58C9FFA11421766CDA15DC46A7BDC680E28CDA839129D3ABC09CFB10F2BA775E666B77163445DE4C96B3AAC08DE1AD0A6347D8B5853C662F5F1B780356983D4A143BF5B5600E14AAE0D22C4609302B4E2F9AE291F7AE14FE79C968B8DAEDCEB84419D33D660C3B6D63CF180635CA9B4F781E615704350341FC0B60C47937FDAC0417DF9DF7D45D4F8633513D60EC6ACFC0419061238E60C488F4549037E618A42F49EE2BC16A579B92BA223513CC1AC7E695895BBDAA252219CEF1404AB34543B738316E90A41522502B4AD42A32E490D170A698AD59520D74B736B28A2A3B9B82E275077A984B3E67ABA95A61AEAA06F0B370837C8B2130CF5618B0A91333B07A461EEEA9A705333974FEBF2E4CD054BBB9285B39FC7AFC10FDA4A43A5AA307E3D4890D46A0061DC3CDB6F9FDDE1A1DBF5D6E29AE2CEA05C9E2B62829331130A0683A3A1300CAFD17C4EC2194769C89F58938CCF307E3DE9FEC23FC874382E55BCF72FAD2D47829D04CDB0D00A4383A59724A6EC1C31F488920B94B11748DDA4CD48B32817C3F1FB8D1CBD62952E7A279F33892B9A7CBE99BEE2AE56122D3F29F6EC5CFA12E61524FB7E6A9F801E59CC4A0825C847B1E6FA7E1CF98B2034D7007A2DFC718AD7643A66E9B5E59C005E51FEA8BD8EFC053FAF237F24EB183A824FA5DA478A5D97E0F2D765EAE0EC654CD37B485E45FA40290FD9E191F45091AE33E59D2B2F7D4EA81B93808408E6B6DB28F0D79C7B170BC997B54BD93DF5E837E2CA1DF8B068AF3689565B0857DEF50C89AE4E6D1116BDE876D6FFEA1A98D7A5BF1CD66BCA5E90F15AB2277B13E7E6E2B1DD8A563F3C760F79930243A804028310322341A29566ADD26EFAD6B329E687735E89F2BCBE0F905A1D4DAB00A90786D614E93D497AE904257629472F4F52C28969989F5E9A99E1D27126EB625BE09A67E2254799C992321C0C920E83C91FFED827E9554FD1E11A023FC59465EF60EDE3C3A3638164BE3F846F8752CF579CFE44D6773D565BA45F93C4B38DDC8E8E242999229A0E23DD8E5E851E7E19D97FA562A7D6D5EF0F95E481751343B04FAD43EBEFD5A8DAE1338ADD2714CB64ED5598D81E58CA5A31B1F5A489C2B257017AF98957241323643D423D689AEBF1DB062BBBF39D7B0076BDA4E38D0057E419B7856D21A7036D9B78F20C296518DF3421B62FA1B5472C37C727DD545CABEDB973680BD1959624C5B2DB62F44C6AA5816B8C5525B04E1AD7C21E8CCA5540B52656E346A0B4B9345D9D25D69FC025EBCA2AA95E3CB395D860BBE07FA5736D33EE37C1FAEA84860D721D7A30CDBE19E4686E11BF0BF6D67EF0B5EA3FB4D83E4D6B37C42CDDA5D877C1C7DA15F16AD7986ABD58AC8154D503493BE751C96FB835B787B59F40693852D975129CCF1F238874568429590A3AFAD4D2489E52A937105CCCE4AA16DC2AD5784D5409EDA066FE9571287994EDF1B3546C2289C76628625B48EF9283D57F9A7C22546F29F79764A526FCB46355D51246F52268AFB9548D51DAF8A43BB0A4E4BB7C58F2B9FF0B06361D4A66958AE4ED7588DDDA625FF6B90AA751B1E70816155D8413F63566C8839DE02C66648A5C06CD2EA634FD795941DA081EB17715DE2CD87CC160CA3878F46BA992EC5DA6F1532A58DDE6E1CD3CFD65E03AA6006692E482F826FCB020BE57DA7DA9B80DD0A84836C5FCDA2289254BAE2F66CB52D3A7286CA928775FB997DFE160EE83327A134ED033EE63DB3DC51FF10CB9CBE2958C5E497320EA6E1F9E13340388D35C47250F5F01C35EF0F2EE7FC956AC6912490000, N'6.1.3-40302')
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (2, 1, N'Nový pejsci a kočičky PO', CAST(N'2015-11-17 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (3, 4, N'Superb', CAST(N'2015-11-15 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (4, 4, N'Jawa 50 Pionýr
Jawa 50 Pionýr', CAST(N'2015-11-24 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (5, 4, N'Škoda Felicia 1994-2001
Škoda Felicia 1994-2001', CAST(N'2015-10-14 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (7, 6, N'Judikatura k rekodifikaci - Právní jednání
novinka
Judikatura k rekodifikaci - Právní jednání', CAST(N'2015-11-12 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (8, 6, N'Správa a vymáhání pohledávek v praxi
novinka
Správa a vymáhání pohledávek v praxi', CAST(N'2015-12-12 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (9, 8, N'Vražedné struny
novinka
Vražedné struny', CAST(N'2015-11-12 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (10, 8, N'Lupiči nedobytných pokladen
novinka
Lupiči nedobytných pokladen', CAST(N'2015-10-12 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (11, 10, N'Osmnáct století Izraele
Osmnáct století Izraele', CAST(N'2015-04-12 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (12, 10, N'Izraelské osudy
Izraelské osudy', CAST(N'2015-11-12 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (13, 9, N'Adolf Hitler
Adolf Hitler', CAST(N'2015-02-19 00:00:00.000' AS DateTime), NULL, N'Ebook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (15, 4, N'Superb - kompletní průvodce', CAST(N'2015-11-15 00:00:00.000' AS DateTime), NULL, N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (25, 8, N'Lupiči nedobytných pokladen
novinka
Lupiči nedobytných pokladen', CAST(N'2015-03-12 00:00:00.000' AS DateTime), NULL, N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (27, 6, N'Správa a vymáhání pohledávek v praxi
novinka
Správa a vymáhání pohledávek v praxi', CAST(N'2014-12-21 00:00:00.000' AS DateTime), NULL, N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (28, 4, N'Škoda Felicia 1994-2001
Škoda Felicia 1994-2001', CAST(N'2014-11-11 00:00:00.000' AS DateTime), NULL, N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (29, 7, N'O pejskovi a kočičce', CAST(N'2015-11-17 00:00:00.000' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (31, 7, N'O pejskovi a kočičce', CAST(N'2015-11-17 00:00:00.000' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (33, 7, N'O pejskovi a kočičce', CAST(N'2015-11-17 00:00:00.000' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (34, 1, N'Michael Jackson', CAST(N'2015-11-18 22:07:05.837' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (35, 11, N'Michael Jackson', CAST(N'2015-11-18 22:07:08.100' AS DateTime), NULL, N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (36, 7, N'O pejskovi a kočičce', CAST(N'2015-11-17 00:00:00.000' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (37, 1, N'Michael Jackson', CAST(N'2015-11-18 22:11:40.730' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (38, 12, N'Michael Jackson', CAST(N'2015-11-18 22:11:40.737' AS DateTime), NULL, N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (39, 13, N'Jezevčík', CAST(N'2015-11-18 22:11:45.473' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (41, 1, N'Michael Jackson', CAST(N'2015-11-18 22:12:49.257' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (42, 1, N'Tipy a triky pro iPhone 6', CAST(N'2015-11-18 22:35:26.253' AS DateTime), N'sss', N'PrintedBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (44, 7, N'O pejskovi a kočičce', CAST(N'2015-11-17 00:00:00.000' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (45, 1, N'Michael Jackson', CAST(N'2015-11-18 22:16:40.720' AS DateTime), NULL, N'EBook')
INSERT [dbo].[Books] ([BookId], [CategoryId], [Title], [Added], [Url], [Discriminator]) VALUES (46, 16, N'Michael Jackson', CAST(N'2015-11-18 22:16:40.730' AS DateTime), NULL, N'PrintedBook')
SET IDENTITY_INSERT [dbo].[Books] OFF
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (1, NULL, N'Beletrie')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (2, NULL, N'Historie')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (3, NULL, N'Odborná')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (4, 3, N'Auto moto')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (5, 3, N'Počítače')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (6, 3, N'Právo')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (7, 3, N'Psychologická kniha')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (8, 1, N'Detektivky')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (9, 2, N'Dějiny')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (10, 9, N'18. století')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (11, NULL, N'Hudební knihy')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (12, NULL, N'Hudební knihy')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (13, NULL, N'Zvířata')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (14, NULL, N'Hudební knihy')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (15, NULL, N'Zvířata')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (16, NULL, N'Hudební knihy')
INSERT [dbo].[Categories] ([CategoryId], [ParentId], [Name]) VALUES (17, NULL, N'Zvířata')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Parameters] ON 

INSERT [dbo].[Parameters] ([ParameterId], [Name]) VALUES (1, N'Počet stran')
INSERT [dbo].[Parameters] ([ParameterId], [Name]) VALUES (2, N'Rok vydání')
SET IDENTITY_INSERT [dbo].[Parameters] OFF
SET IDENTITY_INSERT [dbo].[ParameterValues] ON 

INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (1, 1, 2, N'112')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (2, 2, 2, N'1994')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (3, 1, 4, N'214')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (4, 2, 4, N'2008')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (5, 1, 3, N'165')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (6, 2, 3, N'2011')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (7, 1, 5, N'321')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (8, 2, 5, N'2007')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (10, 1, 7, N'197')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (11, 2, 7, N'2014')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (12, 1, 8, N'134')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (13, 2, 8, N'2012')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (14, 1, 9, N'325')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (15, 2, 9, N'1998')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (16, 1, 10, N'214')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (17, 2, 10, N'1997')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (18, 1, 11, N'347')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (19, 2, 11, N'2001')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (20, 1, 12, N'698')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (21, 2, 12, N'1989')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (22, 1, 13, N'287')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (23, 2, 13, N'1994')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (24, 1, 15, N'129')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (25, 2, 15, N'1998')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (26, 1, 25, N'325')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (27, 2, 25, N'1999')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (28, 1, 27, N'287')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (29, 2, 27, N'1996')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (30, 1, 28, N'387')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (31, 2, 28, N'2014')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (32, 1, 39, N'135')
INSERT [dbo].[ParameterValues] ([ParameterValueId], [ParameterId], [BookId], [Value]) VALUES (33, 2, 39, N'2015')
SET IDENTITY_INSERT [dbo].[ParameterValues] OFF
/****** Object:  Index [IX_CategoryId]    Script Date: 09-Dec-15 12:04:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_CategoryId] ON [dbo].[Books]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParentId]    Script Date: 09-Dec-15 12:04:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParentId] ON [dbo].[Categories]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_BookId]    Script Date: 09-Dec-15 12:04:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_BookId] ON [dbo].[ParameterValues]
(
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ParameterId]    Script Date: 09-Dec-15 12:04:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_ParameterId] ON [dbo].[ParameterValues]
(
	[ParameterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Books_dbo.Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_dbo.Books_dbo.Categories_CategoryId]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_dbo.Categories_dbo.Categories_ParentId]
GO
ALTER TABLE [dbo].[ParameterValues]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ParameterValues_dbo.Books_BookId] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([BookId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParameterValues] CHECK CONSTRAINT [FK_dbo.ParameterValues_dbo.Books_BookId]
GO
ALTER TABLE [dbo].[ParameterValues]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ParameterValues_dbo.Parameters_ParameterId] FOREIGN KEY([ParameterId])
REFERENCES [dbo].[Parameters] ([ParameterId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ParameterValues] CHECK CONSTRAINT [FK_dbo.ParameterValues_dbo.Parameters_ParameterId]
GO
USE [master]
GO
ALTER DATABASE [codefirstdb] SET  READ_WRITE 
GO
