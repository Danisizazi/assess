USE [AssessmentDb]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 03/11/2025 03:24:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNUmber] [nvarchar](50) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerID], [Name], [Email], [PhoneNUmber], [CreateDate], [IsActive], [UpdateDate]) VALUES (1, N'Tony Stark', N'tony.stark@ironman.com', N'0834567890', CAST(N'2025-10-31T17:10:34.910' AS DateTime), 1, NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Email], [PhoneNUmber], [CreateDate], [IsActive], [UpdateDate]) VALUES (2, N'Kent Beck', N'kbeck@xp.com', N'0112466789', CAST(N'2025-10-31T17:10:34.910' AS DateTime), 1, NULL)
INSERT [dbo].[Customers] ([CustomerID], [Name], [Email], [PhoneNUmber], [CreateDate], [IsActive], [UpdateDate]) VALUES (3, N'Samuel Khan', N'khan@assess.co.za', N'0142352356', CAST(N'2025-10-31T17:10:34.910' AS DateTime), 1, NULL)
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
