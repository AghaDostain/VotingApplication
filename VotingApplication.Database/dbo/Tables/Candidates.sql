CREATE TABLE [dbo].[Candidates] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        VARCHAR (255) NULL,
    [CatergoryId] INT           NULL,
    CONSTRAINT [PK_Candidates] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Candidates_Categories] FOREIGN KEY ([CatergoryId]) REFERENCES [dbo].[Categories] ([Id])
);



