USE [WebGaRanKFC]
GO
/****** Object:  Table [dbo].[tbl_ChiTietHoaDon]    Script Date: 05/08/23 4:57:15 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ChiTietHoaDon](
	[maHoaDon] [int] NOT NULL,
	[maMonAn] [int] NOT NULL,
	[maKH] [int] NULL,
	[NgayLap] [date] NULL,
	[SoLuong] [int] NULL,
	[DonViTinh] [nchar](50) NULL,
 CONSTRAINT [PK_tbl_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[maHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_HoaDon]    Script Date: 05/08/23 4:57:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HoaDon](
	[maHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[maKH] [int] NULL,
	[NgayLap] [date] NULL,
	[maNV] [int] NULL,
 CONSTRAINT [PK_tbl_HoaDon] PRIMARY KEY CLUSTERED 
(
	[maHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_KhachHang]    Script Date: 05/08/23 4:57:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_KhachHang](
	[maKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nchar](150) NULL,
	[NgaySinh] [nvarchar](50) NULL,
	[SDT] [nvarchar](15) NULL,
	[Email] [nvarchar](150) NULL,
	[UserName] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbl_KhachHang1] PRIMARY KEY CLUSTERED 
(
	[maKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_Loai]    Script Date: 05/08/23 4:57:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Loai](
	[maLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](100) NULL,
 CONSTRAINT [PK_tbl_Loai] PRIMARY KEY CLUSTERED 
(
	[maLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_MonAn]    Script Date: 05/08/23 4:57:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_MonAn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](150) NULL,
	[Description] [nchar](250) NULL,
	[Price] [float] NULL,
	[Images] [nchar](150) NULL,
	[DonViTinh] [nchar](50) NULL,
	[maLoai] [int] NULL,
 CONSTRAINT [PK_tbl_MonAn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_NhanVien]    Script Date: 05/08/23 4:57:16 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NhanVien](
	[maNV] [int] IDENTITY(1,1) NOT NULL,
	[tenNV] [nvarchar](150) NULL,
	[UserName] [nvarchar](150) NULL,
	[Password] [nvarchar](150) NULL,
 CONSTRAINT [PK_tbl_NhanVien] PRIMARY KEY CLUSTERED 
(
	[maNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbl_KhachHang] ON 

INSERT [dbo].[tbl_KhachHang] ([maKH], [HoTen], [NgaySinh], [SDT], [Email], [UserName], [Password]) VALUES (1, N'Ngô Thành Tiến                                                                                                                                      ', N'22/7/2023', N'0961019252', N'tiencon2016@gmail.com', N'ntt', N'123')
INSERT [dbo].[tbl_KhachHang] ([maKH], [HoTen], [NgaySinh], [SDT], [Email], [UserName], [Password]) VALUES (2, N'Ngô Thành Tiến                                                                                                                                        ', N'04/09/2002', N'2132312', N'tiencon2016@gmail.com', N'ntt1', N'123')
INSERT [dbo].[tbl_KhachHang] ([maKH], [HoTen], [NgaySinh], [SDT], [Email], [UserName], [Password]) VALUES (3, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Loai] ON 

INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (1, N'Món mới')
INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (2, N'ComBo 1 người')
INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (3, N'ComBo nhóm')
INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (4, N'Gà rán - gà quay')
INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (5, N'Burger - Cơm - Mì ý')
INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (6, N'Thức ăn nhẹ')
INSERT [dbo].[tbl_Loai] ([maLoai], [TenLoai]) VALUES (7, N'Thức uống & Tráng miệng')
SET IDENTITY_INSERT [dbo].[tbl_Loai] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_MonAn] ON 

INSERT [dbo].[tbl_MonAn] ([id], [Name], [Description], [Price], [Images], [DonViTinh], [maLoai]) VALUES (2, N'Mỳ ý                                                                                                                                                ', N'Mỳ                                                                                                                                                                                                                                                       ', 30000, N'MY-Y-POP.jpg                                                                                                                                          ', N'Phần                                             ', 2)
INSERT [dbo].[tbl_MonAn] ([id], [Name], [Description], [Price], [Images], [DonViTinh], [maLoai]) VALUES (3, N'2 Bánh Khoai Tây Chiên                                                                                                                               ', N'2 Bánh                                                                                                                                                                                                                                                   ', 16000, N'khoaitaychien1.jpg                                                                                                                                    ', N'Kg                                                ', 6)
INSERT [dbo].[tbl_MonAn] ([id], [Name], [Description], [Price], [Images], [DonViTinh], [maLoai]) VALUES (4, N'3 Bánh Khoai Tây Chiên                                                                                                                               ', N'3 Bánh                                                                                                                                                                                                                                                   ', 25000, N'khoaitaychien2.jpg                                                                                                                                    ', N'Kg                                                ', 6)
INSERT [dbo].[tbl_MonAn] ([id], [Name], [Description], [Price], [Images], [DonViTinh], [maLoai]) VALUES (7, N'Khoai tây chiên                                                                                                                                       ', N'1 phần Khoai tây chiên 1 người ăn                                                                                                                                                                                                                       ', 25000, N'FF-R.jpg                                                                                                                                              ', N'Phần                                             ', 6)
INSERT [dbo].[tbl_MonAn] ([id], [Name], [Description], [Price], [Images], [DonViTinh], [maLoai]) VALUES (8, N'Gà rán                                                                                                                                              ', N'Phần gà rán 2 đùi                                                                                                                                                                                                                                     ', 50000, N'1-Fried-Chicken.jpg                                                                                                                                   ', N'Phần                                             ', 4)
SET IDENTITY_INSERT [dbo].[tbl_MonAn] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_NhanVien] ON 

INSERT [dbo].[tbl_NhanVien] ([maNV], [tenNV], [UserName], [Password]) VALUES (1, N'Tiến', N'nv1', N'123')
SET IDENTITY_INSERT [dbo].[tbl_NhanVien] OFF
GO
ALTER TABLE [dbo].[tbl_ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ChiTietHoaDon_tbl_HoaDon] FOREIGN KEY([maHoaDon])
REFERENCES [dbo].[tbl_HoaDon] ([maHoaDon])
GO
ALTER TABLE [dbo].[tbl_ChiTietHoaDon] CHECK CONSTRAINT [FK_tbl_ChiTietHoaDon_tbl_HoaDon]
GO
ALTER TABLE [dbo].[tbl_ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ChiTietHoaDon_tbl_MonAn] FOREIGN KEY([maMonAn])
REFERENCES [dbo].[tbl_MonAn] ([id])
GO
ALTER TABLE [dbo].[tbl_ChiTietHoaDon] CHECK CONSTRAINT [FK_tbl_ChiTietHoaDon_tbl_MonAn]
GO
ALTER TABLE [dbo].[tbl_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tbl_HoaDon_tbl_KhachHang] FOREIGN KEY([maKH])
REFERENCES [dbo].[tbl_KhachHang] ([maKH])
GO
ALTER TABLE [dbo].[tbl_HoaDon] CHECK CONSTRAINT [FK_tbl_HoaDon_tbl_KhachHang]
GO
ALTER TABLE [dbo].[tbl_HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_tbl_HoaDon_tbl_NhanVien] FOREIGN KEY([maNV])
REFERENCES [dbo].[tbl_NhanVien] ([maNV])
GO
ALTER TABLE [dbo].[tbl_HoaDon] CHECK CONSTRAINT [FK_tbl_HoaDon_tbl_NhanVien]
GO
ALTER TABLE [dbo].[tbl_MonAn]  WITH CHECK ADD  CONSTRAINT [FK_tbl_MonAn_tbl_Loai] FOREIGN KEY([maLoai])
REFERENCES [dbo].[tbl_Loai] ([maLoai])
GO
ALTER TABLE [dbo].[tbl_MonAn] CHECK CONSTRAINT [FK_tbl_MonAn_tbl_Loai]
GO
