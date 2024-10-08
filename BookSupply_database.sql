USE [HiTechDB]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[AuthorId] [numeric](7, 0) IDENTITY(1111111,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[StatusID] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuthorsBooks]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuthorsBooks](
	[AuthorId] [numeric](7, 0) NOT NULL,
	[ISBN] [numeric](10, 0) NOT NULL,
	[YearPublished] [numeric](4, 0) NOT NULL,
	[Edition] [numeric](2, 0) NOT NULL,
 CONSTRAINT [PK_AuthorsBooks] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[ISBN] [numeric](10, 0) NOT NULL,
	[BookTitle] [nvarchar](255) NULL,
	[UnitPrice] [numeric](4, 2) NOT NULL,
	[Quantity] [numeric](4, 0) NOT NULL,
	[PublisherId] [numeric](5, 0) NOT NULL,
	[CategoryId] [numeric](3, 0) NOT NULL,
	[Status] [numeric](3, 0) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [numeric](3, 0) IDENTITY(1,1) NOT NULL,
	[CategName] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[CustomerId] [numeric](7, 0) IDENTITY(1111111,1) NOT NULL,
	[CustomerName] [nvarchar](30) NOT NULL,
	[StreetName] [nvarchar](30) NOT NULL,
	[Province] [nvarchar](2) NOT NULL,
	[PostalCode] [nvarchar](6) NOT NULL,
	[PhoneNumber] [numeric](10, 0) NOT NULL,
	[ContactEmail] [nvarchar](30) NOT NULL,
	[CreditLimit] [numeric](6, 2) NOT NULL,
	[Status] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeId] [numeric](7, 0) IDENTITY(1111111,1) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[PhoneNumber] [numeric](10, 0) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[JobId] [numeric](3, 0) NOT NULL,
	[StatusId] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK_Employees2_1] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jobs]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jobs](
	[JobId] [numeric](3, 0) NOT NULL,
	[JobTitle] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[JobId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderLines]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderLines](
	[OrderId] [numeric](7, 0) NOT NULL,
	[ISBN] [numeric](10, 0) NOT NULL,
	[QuantityOrdered] [numeric](5, 0) NOT NULL,
 CONSTRAINT [PK_OrderLines] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ISBN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderId] [numeric](7, 0) IDENTITY(1,1) NOT NULL,
	[OrderDate] [date] NOT NULL,
	[ShippingDate] [date] NULL,
	[OrderStatus] [numeric](3, 0) NOT NULL,
	[CustomerId] [numeric](7, 0) NOT NULL,
	[EmployeeId] [numeric](7, 0) NOT NULL,
	[OrderType] [nchar](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Publishers]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Publishers](
	[PublisherId] [numeric](5, 0) IDENTITY(11111,1) NOT NULL,
	[PublisherName] [nvarchar](30) NOT NULL,
	[WebAddress] [nvarchar](50) NULL,
	[StatusId] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK_Publishers] PRIMARY KEY CLUSTERED 
(
	[PublisherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Statuses]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Statuses](
	[StatusId] [numeric](3, 0) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Statuses] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserAccounts]    Script Date: 4/22/2024 9:47:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAccounts](
	[UserId] [numeric](7, 0) IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[EmployeeId] [numeric](7, 0) NOT NULL,
	[JobId] [numeric](3, 0) NOT NULL,
	[StatusId] [numeric](3, 0) NOT NULL,
 CONSTRAINT [PK_UserAccounts1] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111114 AS Numeric(7, 0)), N'Robert', N'Martin', N'robert.martin@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111118 AS Numeric(7, 0)), N'John', N'Doe', N'john.doe@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111119 AS Numeric(7, 0)), N'Jane', N'Smith', N'jane.smith@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111135 AS Numeric(7, 0)), N'Eric', N'Matthes', N'eric@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111136 AS Numeric(7, 0)), N'Harrison', N'Ferrone', N'harrison@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111137 AS Numeric(7, 0)), N'Laurence Lars', N'Svekis', N'laurence@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111138 AS Numeric(7, 0)), N'Maaike', N'Van Putten', N'maaike@example.com', CAST(3 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111139 AS Numeric(7, 0)), N'Rob', N'Percival', N'rob@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111140 AS Numeric(7, 0)), N'Julie', N'Meloni', N'julie.meloni@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111141 AS Numeric(7, 0)), N'Jennifer', N'Kyrnin', N'jennifer.kyrnin@example.com', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111142 AS Numeric(7, 0)), N'John', N'Michael', N'', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Authors] ([AuthorId], [FirstName], [LastName], [Email], [StatusID]) VALUES (CAST(1111143 AS Numeric(7, 0)), N'Silva', N'Joao', N'silva@email.com', CAST(1 AS Numeric(3, 0)))
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111114 AS Numeric(7, 0)), CAST(132350882 AS Numeric(10, 0)), CAST(2008 AS Numeric(4, 0)), CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111114 AS Numeric(7, 0)), CAST(1111111111 AS Numeric(10, 0)), CAST(1924 AS Numeric(4, 0)), CAST(69 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111114 AS Numeric(7, 0)), CAST(1234567890 AS Numeric(10, 0)), CAST(1983 AS Numeric(4, 0)), CAST(2 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111114 AS Numeric(7, 0)), CAST(1234567891 AS Numeric(10, 0)), CAST(2020 AS Numeric(4, 0)), CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111114 AS Numeric(7, 0)), CAST(2233445566 AS Numeric(10, 0)), CAST(2024 AS Numeric(4, 0)), CAST(2 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111114 AS Numeric(7, 0)), CAST(9639639633 AS Numeric(10, 0)), CAST(2022 AS Numeric(4, 0)), CAST(2 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111118 AS Numeric(7, 0)), CAST(2233445566 AS Numeric(10, 0)), CAST(2024 AS Numeric(4, 0)), CAST(2 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111118 AS Numeric(7, 0)), CAST(9639639633 AS Numeric(10, 0)), CAST(2022 AS Numeric(4, 0)), CAST(2 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111135 AS Numeric(7, 0)), CAST(1718502702 AS Numeric(10, 0)), CAST(2023 AS Numeric(4, 0)), CAST(3 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111136 AS Numeric(7, 0)), CAST(1837636877 AS Numeric(10, 0)), CAST(2022 AS Numeric(4, 0)), CAST(7 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111137 AS Numeric(7, 0)), CAST(1800562527 AS Numeric(10, 0)), CAST(2021 AS Numeric(4, 0)), CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111138 AS Numeric(7, 0)), CAST(1800562527 AS Numeric(10, 0)), CAST(2021 AS Numeric(4, 0)), CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111139 AS Numeric(7, 0)), CAST(1800562527 AS Numeric(10, 0)), CAST(2021 AS Numeric(4, 0)), CAST(1 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111140 AS Numeric(7, 0)), CAST(672338084 AS Numeric(10, 0)), CAST(2018 AS Numeric(4, 0)), CAST(3 AS Numeric(2, 0)))
INSERT [dbo].[AuthorsBooks] ([AuthorId], [ISBN], [YearPublished], [Edition]) VALUES (CAST(1111141 AS Numeric(7, 0)), CAST(672338084 AS Numeric(10, 0)), CAST(2018 AS Numeric(4, 0)), CAST(3 AS Numeric(2, 0)))
GO
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(132350882 AS Numeric(10, 0)), N'Clean Code: A Handbook of Agile Software Craftsmanship', CAST(62.49 AS Numeric(4, 2)), CAST(100 AS Numeric(4, 0)), CAST(11114 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(672338084 AS Numeric(10, 0)), N'HTML, CSS, and JavaScript All in One: Covering HTML5, CSS3, and ES6, Sams Teach Yourself', CAST(49.99 AS Numeric(4, 2)), CAST(25 AS Numeric(4, 0)), CAST(11111 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(1111111111 AS Numeric(10, 0)), N'mudei', CAST(1.99 AS Numeric(4, 2)), CAST(99 AS Numeric(4, 0)), CAST(11111 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(3 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(1234567890 AS Numeric(10, 0)), N'Test Bokk', CAST(2.99 AS Numeric(4, 2)), CAST(3 AS Numeric(4, 0)), CAST(11114 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(3 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(1234567891 AS Numeric(10, 0)), N'mudei denovo', CAST(36.00 AS Numeric(4, 2)), CAST(33 AS Numeric(4, 0)), CAST(11114 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(4 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(1718502702 AS Numeric(10, 0)), N'Python Crash Course, 3rd Edition: A Hands-On, Project-Based Introduction to Programming', CAST(44.00 AS Numeric(4, 2)), CAST(50 AS Numeric(4, 0)), CAST(11112 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(1800562527 AS Numeric(10, 0)), N'JavaScript from Beginner to Professional: Learn', CAST(50.99 AS Numeric(4, 2)), CAST(30 AS Numeric(4, 0)), CAST(11114 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(1837636877 AS Numeric(10, 0)), N'Learning C# by Developing Games with Unity - Seventh Edition: Get to grips with coding in C#', CAST(50.99 AS Numeric(4, 2)), CAST(5 AS Numeric(4, 0)), CAST(11113 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(2233445566 AS Numeric(10, 0)), N'Teste book with more than 1 author', CAST(25.32 AS Numeric(4, 2)), CAST(25 AS Numeric(4, 0)), CAST(11119 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(4 AS Numeric(3, 0)))
INSERT [dbo].[Books] ([ISBN], [BookTitle], [UnitPrice], [Quantity], [PublisherId], [CategoryId], [Status]) VALUES (CAST(9639639633 AS Numeric(10, 0)), N'Here we go', CAST(20.00 AS Numeric(4, 2)), CAST(20 AS Numeric(4, 0)), CAST(11112 AS Numeric(5, 0)), CAST(1 AS Numeric(3, 0)), CAST(4 AS Numeric(3, 0)))
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategName]) VALUES (CAST(1 AS Numeric(3, 0)), N'Computer')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [StreetName], [Province], [PostalCode], [PhoneNumber], [ContactEmail], [CreditLimit], [Status]) VALUES (CAST(1111111 AS Numeric(7, 0)), N'gab menn', N'Will', N'QC', N'h3j1r3', CAST(1234567890 AS Numeric(10, 0)), N'mene@gmaill.coomm', CAST(0.00 AS Numeric(6, 2)), N'2')
INSERT [dbo].[Customers] ([CustomerId], [CustomerName], [StreetName], [Province], [PostalCode], [PhoneNumber], [ContactEmail], [CreditLimit], [Status]) VALUES (CAST(1111113 AS Numeric(7, 0)), N'Abel Ferreira', N'Will', N'BC', N'H3J1R3', CAST(1234567890 AS Numeric(10, 0)), N'abebl@test.com', CAST(0.00 AS Numeric(6, 2)), N'1')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111118 AS Numeric(7, 0)), N'Brown', N'Henry', CAST(4758962532 AS Numeric(10, 0)), N'henry.brown@book.com', CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111119 AS Numeric(7, 0)), N'Teste', N'Pedro', CAST(4445556666 AS Numeric(10, 0)), N'pedro@test.com', CAST(1 AS Numeric(3, 0)), CAST(2 AS Numeric(3, 0)))
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111120 AS Numeric(7, 0)), N'Wang', N'Peter', CAST(4359998521 AS Numeric(10, 0)), N'peter@wang.com', CAST(3 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111121 AS Numeric(7, 0)), N'Brown', N'Mary', CAST(1234567890 AS Numeric(10, 0)), N'mary@example.com', CAST(4 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111122 AS Numeric(7, 0)), N'Bouchard', N'Jennifer', CAST(9876543210 AS Numeric(10, 0)), N'jennifer@example.com', CAST(4 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111123 AS Numeric(7, 0)), N'Moore', N'Thomas', CAST(5144635722 AS Numeric(10, 0)), N'thomas@test.com', CAST(2 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Employees] ([EmployeeId], [LastName], [FirstName], [PhoneNumber], [Email], [JobId], [StatusId]) VALUES (CAST(1111124 AS Numeric(7, 0)), N'R', N'Rony', CAST(1234567890 AS Numeric(10, 0)), N'rony@test2.com', CAST(1 AS Numeric(3, 0)), CAST(2 AS Numeric(3, 0)))
SET IDENTITY_INSERT [dbo].[Employees] OFF
GO
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (CAST(1 AS Numeric(3, 0)), N'Manager ')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (CAST(2 AS Numeric(3, 0)), N'Sales Manager')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (CAST(3 AS Numeric(3, 0)), N'Inventory Controller')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (CAST(4 AS Numeric(3, 0)), N'Order Clerks')
INSERT [dbo].[Jobs] ([JobId], [JobTitle]) VALUES (CAST(5 AS Numeric(3, 0)), N'Job Title for JobId 5')
GO
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (CAST(1 AS Numeric(7, 0)), CAST(132350882 AS Numeric(10, 0)), CAST(10 AS Numeric(5, 0)))
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (CAST(3 AS Numeric(7, 0)), CAST(1111111111 AS Numeric(10, 0)), CAST(2 AS Numeric(5, 0)))
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (CAST(3 AS Numeric(7, 0)), CAST(1837636877 AS Numeric(10, 0)), CAST(10 AS Numeric(5, 0)))
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (CAST(5 AS Numeric(7, 0)), CAST(132350882 AS Numeric(10, 0)), CAST(3 AS Numeric(5, 0)))
INSERT [dbo].[OrderLines] ([OrderId], [ISBN], [QuantityOrdered]) VALUES (CAST(5 AS Numeric(7, 0)), CAST(1837636877 AS Numeric(10, 0)), CAST(15 AS Numeric(5, 0)))
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(1 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(2 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Email  ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(2 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(3 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Fax    ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(3 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(3 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Fax    ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(4 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(2 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Fax    ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(5 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(2 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Fax    ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(6 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(2 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Fax    ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(7 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-22' AS Date), CAST(2 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111122 AS Numeric(7, 0)), N'Fax    ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(8 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-26' AS Date), CAST(2 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111118 AS Numeric(7, 0)), N'Email  ')
INSERT [dbo].[Orders] ([OrderId], [OrderDate], [ShippingDate], [OrderStatus], [CustomerId], [EmployeeId], [OrderType]) VALUES (CAST(9 AS Numeric(7, 0)), CAST(N'2024-04-22' AS Date), CAST(N'2024-04-26' AS Date), CAST(1 AS Numeric(3, 0)), CAST(1111111 AS Numeric(7, 0)), CAST(1111119 AS Numeric(7, 0)), N'Fax    ')
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11111 AS Numeric(5, 0)), N'Premier Press', NULL, CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11112 AS Numeric(5, 0)), N'Wrox', NULL, CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11113 AS Numeric(5, 0)), N'Murach', NULL, CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11114 AS Numeric(5, 0)), N'Prentice Hall', NULL, CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11115 AS Numeric(5, 0)), N'Testeeee', N'www.eita.com', CAST(2 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11116 AS Numeric(5, 0)), N'Testado', N'', CAST(3 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11117 AS Numeric(5, 0)), N'TestePub', N'naotem', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11118 AS Numeric(5, 0)), N'', N'', CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[Publishers] ([PublisherId], [PublisherName], [WebAddress], [StatusId]) VALUES (CAST(11119 AS Numeric(5, 0)), N'mudeionome', N'', CAST(3 AS Numeric(3, 0)))
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (CAST(1 AS Numeric(3, 0)), N'active')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (CAST(2 AS Numeric(3, 0)), N'inactive')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (CAST(3 AS Numeric(3, 0)), N'deleted')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (CAST(4 AS Numeric(3, 0)), N'available ')
INSERT [dbo].[Statuses] ([StatusId], [Description]) VALUES (CAST(5 AS Numeric(3, 0)), N'unavailable ')
GO
SET IDENTITY_INSERT [dbo].[UserAccounts] ON 

INSERT [dbo].[UserAccounts] ([UserId], [Username], [Password], [EmployeeId], [JobId], [StatusId]) VALUES (CAST(19 AS Numeric(7, 0)), N'adm', N'123', CAST(1111118 AS Numeric(7, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[UserAccounts] ([UserId], [Username], [Password], [EmployeeId], [JobId], [StatusId]) VALUES (CAST(20 AS Numeric(7, 0)), N'Peter', N'123', CAST(1111120 AS Numeric(7, 0)), CAST(3 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[UserAccounts] ([UserId], [Username], [Password], [EmployeeId], [JobId], [StatusId]) VALUES (CAST(21 AS Numeric(7, 0)), N'Mary', N'123', CAST(1111121 AS Numeric(7, 0)), CAST(4 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[UserAccounts] ([UserId], [Username], [Password], [EmployeeId], [JobId], [StatusId]) VALUES (CAST(22 AS Numeric(7, 0)), N'Jennifer', N'123', CAST(1111122 AS Numeric(7, 0)), CAST(4 AS Numeric(3, 0)), CAST(2 AS Numeric(3, 0)))
INSERT [dbo].[UserAccounts] ([UserId], [Username], [Password], [EmployeeId], [JobId], [StatusId]) VALUES (CAST(23 AS Numeric(7, 0)), N'Thomas', N'123', CAST(1111123 AS Numeric(7, 0)), CAST(2 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
INSERT [dbo].[UserAccounts] ([UserId], [Username], [Password], [EmployeeId], [JobId], [StatusId]) VALUES (CAST(24 AS Numeric(7, 0)), N'Rony', N'12345', CAST(1111124 AS Numeric(7, 0)), CAST(1 AS Numeric(3, 0)), CAST(1 AS Numeric(3, 0)))
SET IDENTITY_INSERT [dbo].[UserAccounts] OFF
GO
ALTER TABLE [dbo].[Authors]  WITH CHECK ADD  CONSTRAINT [FK_Authors_Statuses] FOREIGN KEY([StatusID])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[Authors] CHECK CONSTRAINT [FK_Authors_Statuses]
GO
ALTER TABLE [dbo].[AuthorsBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorsBooks_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([AuthorId])
GO
ALTER TABLE [dbo].[AuthorsBooks] CHECK CONSTRAINT [FK_AuthorsBooks_Authors]
GO
ALTER TABLE [dbo].[AuthorsBooks]  WITH CHECK ADD  CONSTRAINT [FK_AuthorsBooks_Books] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[AuthorsBooks] CHECK CONSTRAINT [FK_AuthorsBooks_Books]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Categories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Categories]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Publishers] FOREIGN KEY([PublisherId])
REFERENCES [dbo].[Publishers] ([PublisherId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Publishers]
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD  CONSTRAINT [FK_Books_Statuses] FOREIGN KEY([Status])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[Books] CHECK CONSTRAINT [FK_Books_Statuses]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Jobs]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Statuses] FOREIGN KEY([StatusId])
REFERENCES [dbo].[Statuses] ([StatusId])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Statuses]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Books] FOREIGN KEY([ISBN])
REFERENCES [dbo].[Books] ([ISBN])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Books]
GO
ALTER TABLE [dbo].[OrderLines]  WITH CHECK ADD  CONSTRAINT [FK_OrderLines_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([OrderId])
GO
ALTER TABLE [dbo].[OrderLines] CHECK CONSTRAINT [FK_OrderLines_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Employees]
GO
ALTER TABLE [dbo].[UserAccounts]  WITH CHECK ADD  CONSTRAINT [FK_UserAccounts_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeId])
GO
ALTER TABLE [dbo].[UserAccounts] CHECK CONSTRAINT [FK_UserAccounts_Employees]
GO
ALTER TABLE [dbo].[UserAccounts]  WITH CHECK ADD  CONSTRAINT [FK_UserAccounts_Jobs] FOREIGN KEY([JobId])
REFERENCES [dbo].[Jobs] ([JobId])
GO
ALTER TABLE [dbo].[UserAccounts] CHECK CONSTRAINT [FK_UserAccounts_Jobs]
GO
