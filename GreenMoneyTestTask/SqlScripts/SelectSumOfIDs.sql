USE [TestDb]
GO

SELECT SUM(ID) 
FROM 
	(SELECT ID FROM [dbo].[UserStatus] 
	WHERE UserId = 86) AS tbl1

