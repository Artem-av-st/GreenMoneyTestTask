USE [TestDb]
GO

SELECT TOP(1) Id, Status
FROM [dbo].[UserStatus]
WHERE UserId = 85
ORDER BY Id DESC 