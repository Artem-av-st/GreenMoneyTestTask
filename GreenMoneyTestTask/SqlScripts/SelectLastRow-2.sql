USE [TestDb]
GO

SELECT * 
FROM [dbo].[UserStatus]
WHERE UserId = 85
ORDER BY Id
OFFSET
	(SELECT COUNT(ID) 
	FROM UserStatus 
	WHERE UserId = 85)-1 
ROWS