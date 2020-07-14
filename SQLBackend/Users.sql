CREATE TABLE [dbo].[Users]
(
    [UserId] INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    [LastName] NVARCHAR(20) NULL,
    [FirstName] NVARCHAR(20) NULL,
    [City] NVARCHAR(20) NULL,
    [State] NVARCHAR(20) NULL,
    [Country] NVARCHAR(20) NULL
)
