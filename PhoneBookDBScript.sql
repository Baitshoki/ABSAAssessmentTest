USE [DB_PHONEBOOK]
GO
/****** Object:  Table [dbo].[PhoneBook]    Script Date: 2021/01/08 14:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhoneBook](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](15) NULL,
 CONSTRAINT [PK_PhoneBook] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PhoneBook] ON 

INSERT [dbo].[PhoneBook] ([Id], [Name], [PhoneNumber]) VALUES (1, N'Baitshoki Kubu', N'0810458122')
INSERT [dbo].[PhoneBook] ([Id], [Name], [PhoneNumber]) VALUES (2, N'Tswelelang Omphemetse', N'0714201728')
INSERT [dbo].[PhoneBook] ([Id], [Name], [PhoneNumber]) VALUES (3, N'Mildred Boomslan', N'0674452019')
INSERT [dbo].[PhoneBook] ([Id], [Name], [PhoneNumber]) VALUES (4, N'Donald Masselo Moore', N'0828103048')
INSERT [dbo].[PhoneBook] ([Id], [Name], [PhoneNumber]) VALUES (5, N'Silvier Xervier Marcus', N'0791032556')
SET IDENTITY_INSERT [dbo].[PhoneBook] OFF
GO
