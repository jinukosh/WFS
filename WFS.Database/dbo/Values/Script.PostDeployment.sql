/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.					
--------------------------------------------------------------------------------------
*/

GO
SET IDENTITY_INSERT [dbo].[CommonUserType] ON 
GO
INSERT [dbo].[CommonUserType] ([Id], [Name], [IsDeleted]) VALUES (1, N'Admin', 0)
GO
INSERT [dbo].[CommonUserType] ([Id], [Name], [IsDeleted]) VALUES (2, N'User', 0)
GO
INSERT [dbo].[CommonUserType] ([Id], [Name], [IsDeleted]) VALUES (3, N'Client', 0)
GO
SET IDENTITY_INSERT [dbo].[CommonUserType] OFF
GO

SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [UserType], [CreatedDate], [CreatedIpAddress], [CreatedUserId], [UpdatedDate], [UpdatedIpAddress], [UpdatedUserId], [IsDeleted]) VALUES (1, N'Adam Smith', N'admin@admin.com', '1', 1, CAST(N'2015-01-01 00:00:00.000' AS DateTime), N'192.168.1.1', NULL, NULL, N'192.168.1.1', NULL, 0)
GO
INSERT [dbo].[User] ([Id], [Name], [Email], [Password], [UserType], [CreatedDate], [CreatedIpAddress], [CreatedUserId], [UpdatedDate], [UpdatedIpAddress], [UpdatedUserId], [IsDeleted]) VALUES (2, N'Joe Simpson', N'user@user.com', '1',  2, CAST(N'2015-01-01 00:00:00.000' AS DateTime), N'192.168.1.1', 1, CAST(N'2015-11-16 16:01:22.910' AS DateTime), N'192.168.1.1', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO

SET IDENTITY_INSERT [dbo].[Note] ON 
GO
INSERT [dbo].[Note] ([Id], [Name],[Details],[Color], [UserId], [IsDeleted]) VALUES (1, N'Blue Note','111111111111111111','Blue', 1, 0)
GO
INSERT [dbo].[Note] ([Id], [Name],[Details],[Color], [UserId], [IsDeleted]) VALUES (2, N'Red Note','2222222222222222222','Blue', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Note] OFF
GO

SET IDENTITY_INSERT [dbo].[LogLogin] ON 
GO
INSERT [dbo].[LogLogin] ([Id], [UserId], [LogDate], [LoginLogType], [ExceptionString], [Comment], [IsDeleted]) VALUES (2174, 1, CAST(N'2016-01-07 21:27:47.807' AS DateTime), N'SUCCESS', NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[LogLogin] OFF
GO
