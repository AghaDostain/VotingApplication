CREATE TABLE [dbo].[Voters] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (255) NULL,
    [DOB]       DATETIME2 (7) NULL,
    [CreatedOn] DATETIME2 (7) NULL,
    [UpdatedOn] DATETIME2 (7) NULL,
    CONSTRAINT [PK_Voters] PRIMARY KEY CLUSTERED ([Id] ASC)
);

