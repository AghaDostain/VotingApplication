CREATE TABLE [dbo].[Candidates] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (255) NULL,
    [DOB]         DATETIME2 (7) NULL,
    [Gender]      CHAR (1)      NULL,
    [PartyName]   VARCHAR (255) NULL,
    [CatergoryId] INT           NOT NULL,
    [CreatedOn]   DATETIME2 (7) NULL,
    [UpdatedOn]   DATETIME2 (7) NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Candidates_Categories] FOREIGN KEY ([CatergoryId]) REFERENCES [dbo].[Categories] ([Id])
);

