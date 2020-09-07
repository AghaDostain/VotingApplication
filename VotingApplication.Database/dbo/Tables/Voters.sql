CREATE TABLE [dbo].[Voters] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (255) NOT NULL,
    [DOB]       DATETIME2 (7) NOT NULL,
    [CreatedOn] DATETIME2 (7) CONSTRAINT [DF_Voters_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn] DATETIME2 (7) CONSTRAINT [DF_Voters_UpdatedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Voters] PRIMARY KEY CLUSTERED ([Id] ASC)
);



