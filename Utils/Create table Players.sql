-- Create a new table called 'Players' in schema 'dbo'
-- Drop the table if it already exists

IF OBJECT_ID('dbo.Players', 'U') IS NOT NULL
DROP TABLE dbo.Players
GO
-- Create the table in the specified schema
CREATE TABLE dbo.Players
(
    PlayersId INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- primary key column
    GameID [CHAR] (5),
    PlayerName [NVARCHAR](50),
    PlayerType [BIT],
    PlayerPicture [VARBINARY](max)
    -- specify more columns here
);
GO