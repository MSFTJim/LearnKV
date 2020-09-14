-- Insert rows into table 'Players'
INSERT INTO Players
   ([PlayerName], [GameID], [PlayerType])
VALUES
   ( N'Frances', 'ABCDE', 1),
   ( N'Jennifer', 'ABCDE', 1),
   ( N'Nick', 'ABCDE', 1),
   ( N'Jim', 'ABCDE', 0)
GO
-- Query the total count
SELECT COUNT(*) as PlayerCount FROM dbo.Players;
-- Query all information
SELECT * FROM dbo.Players 
GO