USE [TestDb]
GO

SELECT ID,UserId,Status 
FROM
    (SELECT *, Row_Number() OVER(ORDER BY Id) AS RowNumber             
    FROM [dbo].[UserStatus]) as tbl1
WHERE tbl1.RowNumber % 2 = 0