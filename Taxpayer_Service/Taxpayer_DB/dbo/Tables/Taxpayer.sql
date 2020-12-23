CREATE TABLE [dbo].[Taxpayer] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [SecondaryName] NVARCHAR (50)  NOT NULL,
    [Phone]         NVARCHAR (25)  NOT NULL,
    [Address]       NVARCHAR (200) NOT NULL,
    [Email]         NVARCHAR (50)  NOT NULL,
    [Language]      INT            NOT NULL,
    CONSTRAINT [PK_Taxpayer] PRIMARY KEY CLUSTERED ([ID] ASC)
);

