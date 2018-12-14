SELECT * 
FROM UserStatus 
WHERE UserId = 85
ORDER BY Id
OFFSET
	(SELECT COUNT(ID) 
	FROM 
		(SELECT ID 
		FROM UserStatus 
		Where UserId = 85) as tbl1)-1 
ROWS