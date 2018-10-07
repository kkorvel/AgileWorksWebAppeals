CREATE TABLE [dbo].[Appeals] (
    [Appeal_Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Description]       NVARCHAR (MAX) NOT NULL,
    [Entry_DateTime]    DATETIME       NOT NULL,
    [DeadLine_DateTime] DATETIME       NOT NULL,
    CONSTRAINT [PK_Appeals] PRIMARY KEY CLUSTERED ([Appeal_Id] ASC)
);

