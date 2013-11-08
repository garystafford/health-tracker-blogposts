/*
	Remove previous data into HealthTrackerCodeFirst database
*/

-- Delete all existing records
DELETE FROM [dbo].[Activities]
DELETE FROM [dbo].[Hydrations]
DELETE FROM [dbo].[Meals]
DELETE FROM [dbo].[People]
--DELETE FROM [dbo].[ActivityTypes]
--DELETE FROM [dbo].[MealTypes]

-- Insert People
SET IDENTITY_INSERT [dbo].[People] ON
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (1, N'John Doe')
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (2, N'Maria Garcia')
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (3, N'Rahul Gupta')
INSERT INTO [dbo].[People] ([PersonId], [Name]) VALUES (4, N'Shreya Chopra')
SET IDENTITY_INSERT [dbo].[People] OFF
