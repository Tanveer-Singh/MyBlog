USE [MyBlog]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 18/09/2014 10:32:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Posts](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[PostHeading] [varchar](20) NULL,
	[SecondaryText] [varchar](20) NULL,
	[Title] [varchar](20) NULL,
	[PostDescription] [varchar](100) NULL,
	[PostImage] [varchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[PostActive] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/09/2014 10:32:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Email] [varchar](70) NULL,
	[Active] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

GO
INSERT [dbo].[Posts] ([PostID], [UserID], [PostHeading], [SecondaryText], [Title], [PostDescription], [PostImage], [CreatedDate], [PostActive]) VALUES (1, 1, N'TestPost', NULL, N'Test Tittle', N'This is Test Post from DB', NULL, CAST(0x0000A37900ACC1BF AS DateTime), 0)
GO
INSERT [dbo].[Posts] ([PostID], [UserID], [PostHeading], [SecondaryText], [Title], [PostDescription], [PostImage], [CreatedDate], [PostActive]) VALUES (2, 0, NULL, NULL, NULL, NULL, NULL, CAST(0x0000A37B00A4023C AS DateTime), 0)
GO
INSERT [dbo].[Posts] ([PostID], [UserID], [PostHeading], [SecondaryText], [Title], [PostDescription], [PostImage], [CreatedDate], [PostActive]) VALUES (3, 0, N'test', N'test', N'tess', N'aaada', NULL, CAST(0x0000A38400C130BF AS DateTime), 0)
GO
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([UserID], [FirstName], [LastName], [Email], [Active], [CreatedDate]) VALUES (1, N'admin', N'admin', N'admin@email.com', 0, CAST(0x0000A37900A54949 AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (NULL) FOR [PostImage]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Posts] ADD  DEFAULT ((0)) FOR [PostActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT ((0)) FOR [Active]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
