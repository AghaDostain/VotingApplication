CREATE TABLE [dbo].[Categories] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (255) NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
DENY UPDATE
    ON OBJECT::[dbo].[Categories] TO [VotingAppUser]
    AS [dbo];


GO
DENY DELETE
    ON OBJECT::[dbo].[Categories] TO [VotingAppUser]
    AS [dbo];

