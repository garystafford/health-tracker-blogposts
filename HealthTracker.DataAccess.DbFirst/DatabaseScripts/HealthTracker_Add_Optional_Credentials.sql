USE [master]
GO
CREATE LOGIN [DemoLogin] WITH PASSWORD=N'DemoLogin123', DEFAULT_DATABASE=[HealthTracker], 
	DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

GO
USE [HealthTracker]
GO
CREATE USER [DemoUser] FOR LOGIN [DemoLogin] WITH DEFAULT_SCHEMA=[dbo]
GO

CREATE ROLE [DemoRole] AUTHORIZATION [dbo]
GO

USE [HealthTracker]
GO
GRANT ALTER TO [DemoRole] AS [dbo]
GO
GRANT DELETE TO [DemoRole] AS [dbo]
GO
GRANT EXECUTE TO [DemoRole] AS [dbo]
GO
GRANT INSERT TO [DemoRole] AS [dbo]
GO
GRANT SELECT TO [DemoRole] AS [dbo]
GO
GRANT UPDATE TO [DemoRole] AS [dbo]
GO
GRANT VIEW DEFINITION TO [DemoRole] AS [dbo]
GO

GRANT CONNECT TO [DemoUser] AS [dbo]
GO

USE [HealthTracker]
GO
EXEC dbo.sp_addrolemember @rolename=N'DemoRole', @membername=N'DemoUser'
GO
