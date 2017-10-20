CREATE TABLE [dbo].[Note] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (100) NULL,
	[Details]   NVARCHAR (500) NULL,
	[Color]     NVARCHAR (10) NULL,
	[UserId]     INT  NULL,
    [IsDeleted] BIT            NULL,
    CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Note_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

