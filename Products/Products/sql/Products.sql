CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CreateDate], [IsActive], [UpdateDate]) VALUES (2312, N'My Screen', N'Screen', CAST(2750.00 AS Decimal(18, 2)), CAST(N'2025-10-31T17:10:34.910' AS DateTime), 1, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CreateDate], [IsActive], [UpdateDate]) VALUES (3678, N'Office Desk', N'Desk', CAST(1200.00 AS Decimal(18, 2)), CAST(N'2025-10-31T17:10:34.910' AS DateTime), 1, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CreateDate], [IsActive], [UpdateDate]) VALUES (4441, N'HDMI', N'Cable', CAST(125.50 AS Decimal(18, 2)), CAST(N'2025-10-31T17:10:34.910' AS DateTime), 1, NULL)
INSERT [dbo].[Products] ([ProductID], [Name], [Description], [Price], [CreateDate], [IsActive], [UpdateDate]) VALUES (4442, N'later', N'later', CAST(1111.00 AS Decimal(18, 2)), CAST(N'2025-11-01T15:17:07.480' AS DateTime), 0, CAST(N'2025-11-01T17:40:52.747' AS DateTime))
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
GO
ALTER TABLE [dbo].[Products] ADD  CONSTRAINT [DF_Products_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO