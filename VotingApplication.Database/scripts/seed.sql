-- Creates the login VotingAppUser with password '12345'.  
CREATE LOGIN VotingAppUser
    WITH PASSWORD = '12345';  
GO  

-- Creates a database user for the login created above.  
CREATE USER VotingAppUser FOR LOGIN VotingAppUser;  
GO  


DENY DELETE, UPDATE ON Categories TO [VotingAppUser]


USE [Voting]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'President:')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Vice President')
GO
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Secretary:')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Candidates] ON 
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (1, N'Michael Scott', 1)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (2, N'Andy Bernard', 1)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (3, N'Deangelo Vickers', 1)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (4, N'Dwight Schrute', 2)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (5, N'John Halpert', 2)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (6, N'Pam Beasly', 3)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (7, N'Erin Hannon', 3)
GO
INSERT [dbo].[Candidates] ([Id], [Name], [CatergoryId]) VALUES (8, N'Kevin Malone', 3)
GO
SET IDENTITY_INSERT [dbo].[Candidates] OFF
GO
