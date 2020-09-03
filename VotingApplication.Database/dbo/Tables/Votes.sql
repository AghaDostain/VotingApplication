CREATE TABLE [dbo].[Votes] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [VoterId]     INT           NOT NULL,
    [CandidateId] INT           NOT NULL,
    [CategoryId]  INT           NOT NULL,
    [CreatedOn]   DATETIME2 (7) NULL,
    [UpdatedOn]   DATETIME2 (7) NULL,
    CONSTRAINT [PK_Votes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Votes_Candidates] FOREIGN KEY ([CandidateId]) REFERENCES [dbo].[Candidates] ([Id]),
    CONSTRAINT [FK_Votes_Categories] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]),
    CONSTRAINT [FK_Votes_Voters] FOREIGN KEY ([VoterId]) REFERENCES [dbo].[Voters] ([Id])
);

