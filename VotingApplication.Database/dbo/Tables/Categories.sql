CREATE TABLE [dbo].[Categories] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (2550) NULL,
    [CreatedOn] DATETIME2 (7)  NULL,
    [UpdatedOn] DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);

