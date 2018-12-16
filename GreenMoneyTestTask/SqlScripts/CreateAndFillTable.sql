USE [TestDb]
GO
CREATE TABLE [dbo].[UserStatus](
	[ID] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Status] [int] NOT NULL
) ON [PRIMARY]
GO

INSERT INTO [dbo].[UserStatus] 
(ID, UserId, Status) VALUES 
(1,85,2),
(2,85,3),
(3,85,4),
(4,85,1),
(5,86,2),
(6,86,4),
(7,86,1),
(8,86,3)