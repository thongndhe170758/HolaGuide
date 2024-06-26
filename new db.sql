USE [HolaGuide_Test]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](200) NOT NULL,
	[UserID] [int] NULL,
	[PostDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceID] [int] NULL,
	[Value] [nvarchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Longtitude] [float] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Description] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SaveService]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaveService](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ServiceID] [int] NULL,
	[UserID] [int] NULL,
	[SaveDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryID] [int] NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Price] [varchar](50) NOT NULL,
	[LocationID] [int] NULL,
	[Title] [nvarchar](200) NULL,
	[OwnerID] [int] NULL,
	[CreateDate] [datetime] NULL,
	[ContactNumber] [char](11) NULL,
	[IsVerified] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subcription]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subcription](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NOT NULL,
	[Price] [float] NOT NULL,
	[Duration] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Role] [int] NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[IsSubcripted] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSubcription]    Script Date: 5/27/2024 4:47:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSubcription](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[SubcriptionID] [int] NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([ID], [Name]) VALUES (1, N'Nhà Trọ')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (2, N'Ăn Uống')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (3, N'Giải Trí')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (4, N'Y Tế')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (5, N'Mua Sắm')
INSERT [dbo].[Category] ([ID], [Name]) VALUES (6, N'Dịch Vụ Khác')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (2, 6, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQc6qzUmDjRiSx8LF1-FKfc_bvsgKHpa_LoKA&s')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (3, 6, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRtOp7C3QCiKcCEU2cQn8QJKHgbo3mGYldI5g&s')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (4, 6, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSa2q-oI1bZpbTdWfM0ANp0Y8R7YvMQ251oCA&s')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (5, 6, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzMzABbHE0V8fZxE9sytQYBgTNY1cedJc00w&s')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (6, 6, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgaa5YGD1J4OjdGD0bzRe9fY2KNv_---7DgA&s')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (7, 8, N'https://hoalac247.com/uploads/images/202304/image_750x_64366d52bc616.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (8, 8, N'https://hoalac247.com/uploads/images/202304/image_750x_64366d5fbdc7b.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (9, 8, N'https://hoalac247.com/uploads/images/202304/image_750x_64366d72761ce.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (10, 10, N'https://lh3.googleusercontent.com/p/AF1QipMerY3qHeIwcqe49JfdxqK1DzRqjgZ42R19gElz=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (11, 10, N'https://lh3.googleusercontent.com/p/AF1QipNH7JyfT4wNjpxuM3z7UT1TNVe4senf5GuJT3JK=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (12, 10, N'https://lh3.googleusercontent.com/p/AF1QipODmUg6GFAgDcQxM76LZ03K0-rqzIO8nHFxa3zT=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (13, 12, N'https://lh3.googleusercontent.com/p/AF1QipMN1__ZMdIwfV5RGW84kFX7j_gNNTXbKIteMVEL=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (14, 12, N'https://lh3.googleusercontent.com/p/AF1QipMJHn4IQh35RuM06hwSWwD4HmSyN4HitDuJD7o2=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (16, 12, N'https://lh3.googleusercontent.com/p/AF1QipO5-VYnUi2zxOxKWtpMI1qhrm1LATU7-amWmxHn=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (17, 13, N'https://lh3.googleusercontent.com/p/AF1QipN7c9yXw6YGfoTqm4fLGV0FqhKrXv4uBr6EQ9xL=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (18, 13, N'https://lh3.googleusercontent.com/p/AF1QipOb-ZbrMWIe1ydrbg6bAdV7yTVQlVBCYs-OmoCf=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (19, 13, N'https://lh3.googleusercontent.com/p/AF1QipNFfWD5YX4zzC5zwJz0SWTGjOX0AXZ2x4s8bFdk=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (20, 14, N'https://lh3.googleusercontent.com/p/AF1QipM2hvjRfWYzn7aktVkcHSc9LQpOwJn0rQ8mZ86s=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (21, 14, N'https://lh3.googleusercontent.com/p/AF1QipM9Cb5Aaljw4pe8TinpLbHmLI3hC30NSZeuT3Q4=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (22, 14, N'https://lh3.googleusercontent.com/p/AF1QipNJB3jCRva8lT2gNgVJw3KGJsyV7oJe4aGOEJSC=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (23, 16, N'https://hoalac247.com/uploads/images/202308/image_750x_64ddedc1ac006.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (24, 16, N'https://hoalac247.com/uploads/images/202308/image_750x_64ddedc4ccc0c.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (25, 16, N'https://hoalac247.com/uploads/images/202308/image_750x_64ddedc342007.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (26, 17, N'https://lh3.googleusercontent.com/p/AF1QipO4FMd_4PIhOfP2CFMCdJe6hrG61am07QR74bYF=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (27, 17, N'https://lh3.googleusercontent.com/p/AF1QipN99IOwnIHfOXh6ap_bOB5WRZMFz7uOwOyM5957=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (28, 17, N'https://lh3.googleusercontent.com/p/AF1QipNKTuNshzsw2vXIeUjYy4cj6qWA2eHY91gdPJdA=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (29, 18, N'https://hoalac247.com/uploads/images/202308/image_750x_64e07c861471c.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (30, 18, N'https://hoalac247.com/uploads/images/202308/image_750x_64e07c8a1e6f1.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (31, 18, N'https://hoalac247.com/uploads/images/202308/image_750x_64e07c8babe61.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (33, 20, N'https://lh3.googleusercontent.com/p/AF1QipMeCgc-fV4Hxy3ymLeqzAndf0q_J_cCXrLiDdtH=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (36, 21, N'https://hoalac247.com/uploads/images/202302/image_750x_63f31fd47489e.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (37, 21, N'https://hoalac247.com/uploads/images/202302/image_750x_63f3247825b3b.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (38, 21, N'https://hoalac247.com/uploads/images/202302/image_750x_63f32333162de.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (39, 26, N'https://hoalac247.com/uploads/images/202308/image_750x_64ddd02ee60c0.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (40, 26, N'https://hoalac247.com/uploads/images/202308/image_750x_64ddd03076a3c.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (41, 26, N'https://hoalac247.com/uploads/images/202308/image_750x_64ddcf5893cb0.jpg')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (42, 28, N'https://lh3.googleusercontent.com/p/AF1QipOhKGCll6QuDAaPwAAlAZYk3fQwOuj_hxPCesa5=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (43, 28, N'https://lh3.googleusercontent.com/p/AF1QipOYV5KeK8y0MogqRSWS75HcKxK2gfD34xqMPgbW=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (44, 28, N'https://lh3.googleusercontent.com/p/AF1QipNQogoJzzJ-GgdiQMFaQjzq5_ZqMqcVOT0xY0Jx=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (45, 29, N'https://lh3.googleusercontent.com/p/AF1QipMsOCqJcLtk3_X4SSLqWAUEO5NhkWn3jsLxuodi=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (46, 29, N'https://lh3.googleusercontent.com/p/AF1QipOMg1Fp9UnnWiHvxVDsIn3Vdu_o_Pb6D1cpmHdO=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (47, 29, N'https://lh3.googleusercontent.com/p/AF1QipNsD8OE_SGW-TUXIzKsH5XGjAP_2caYH8IO4OpM=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (48, 30, N'https://lh3.googleusercontent.com/p/AF1QipPtzkA_W2alacrQCP8N_WTuiLVBlxOYw6AogSiW=s680-w680-h510')
INSERT [dbo].[Image] ([ID], [ServiceID], [Value]) VALUES (49, 30, N'https://lh3.googleusercontent.com/p/AF1QipMNwplvX2CbQjfgGunziIjPdmVOmTaJZ-z1gNW8=s680-w680-h510')
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[Location] ON 

INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (1, 105.5255548, 21.0128198, N'Số 68, thôn 3, thạch hòa, thạch thất, hà nội')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (2, 105.51884450126063, 21.013272366079072, N'Nhà Trọ Tuân Cường 2 ')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (4, 105.51748917105815, 21.008812383393465, N'KTX T-Linh')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (5, 105.53582271941737, 21.028794435504718, N'Tòa Nhà Mia House')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (6, 105.51957128465868, 21.00449789730455, N'KTX Nhà Ông Bà')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (7, 105.5495594, 21.017862072988294, N'Tony House Hoà Lạc')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (10, 105.5513947, 21.021181738281655, N'Hanoi House 3')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (11, 105.53175246136526, 20.985777342493936, N'New House')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (12, 105.52250688465868, 20.998485344941809, N'An House')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (14, 105.52057236136527, 21.001611624345582, N'Nhà Trọ Tuấn Cường')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (15, 105.51985312698803, 21.001589982280592, N'Nhà Trọ Thanh Thảo')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (20, 105.5553456422811, 21.020254641306604, N'Nhà Trọ Young House 8 ')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (21, 105.51926174232933, 21.022725272164429, N'Nhà Trọ Minh Khang')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (22, 105.52481417116468, 21.029533620923992, N'Ngọc My House')
INSERT [dbo].[Location] ([ID], [Longtitude], [Latitude], [Description]) VALUES (23, 105.52469582883532, 21.024257826418246, N'Nhà Trọ Quỳnh Hải')
SET IDENTITY_INSERT [dbo].[Location] OFF
GO
SET IDENTITY_INSERT [dbo].[Service] ON 

INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (6, 1, N'Chung cư mini 68', N'1.500.000 - 3.000.000', 1, N'Trọ mới xây, điện nước, wifi miễn phí, có máy giặt chung, bảo mật tuyệt đối', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (7, 1, N'Trọ Tuấn Phong', N'1.500.000 - 3.000.000', 1, N'Vừa Mới Xây', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (8, 1, N'Nhà Trọ Tuân Cường 2 ', N'2.000.000-2.900.000', 2, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (10, 1, N'KTX T-Linh', N'2.500.000', 4, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (12, 1, N'Tòa Nhà Mia House', N'2.400.000', 5, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (13, 1, N'KTX Nhà Ông Bà', N'2.800.000-3.200.000', 6, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (14, 1, N'Tony House Hoà Lạc', N'2.900.000-4.000.000', 7, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (16, 1, N'Hanoi House 3', N'3.600.000–3.800.000', 10, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (17, 1, N'New House', N'3.000.000–3.500.000', 11, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (18, 1, N'An House', N'2.200.000-2.400.000', 12, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (20, 1, N'Nhà Trọ Tuấn Cường', N'1.600.000-2.100.000', 14, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (21, 1, N'Nhà Trọ Thanh Thảo', N'1.800.000', 15, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (26, 1, N'Nhà Trọ Young House 8 ', N'2.000.000', 20, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (28, 1, N'Nhà Trọ Minh Khang', N'2.500.000', 21, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (29, 1, N'Ngọc My House', N'2.300.000', 22, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
INSERT [dbo].[Service] ([ID], [CategoryID], [Name], [Price], [LocationID], [Title], [OwnerID], [CreateDate], [ContactNumber], [IsVerified]) VALUES (30, 1, N'Nhà Trọ Quỳnh Hải', N'2.000.000', 23, N'Nhà Đẹp', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Service] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Role], [Email], [Password], [IsSubcripted]) VALUES (2, 1, N'daohqhe170948@fpt.edu.vn', N'27062003x', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[SaveService]  WITH CHECK ADD FOREIGN KEY([ServiceID])
REFERENCES [dbo].[Service] ([ID])
GO
ALTER TABLE [dbo].[SaveService]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([ID])
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD FOREIGN KEY([LocationID])
REFERENCES [dbo].[Location] ([ID])
GO
ALTER TABLE [dbo].[Service]  WITH CHECK ADD FOREIGN KEY([OwnerID])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[UserSubcription]  WITH CHECK ADD FOREIGN KEY([SubcriptionID])
REFERENCES [dbo].[Subcription] ([ID])
GO
ALTER TABLE [dbo].[UserSubcription]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
GO
