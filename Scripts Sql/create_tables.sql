CREATE DATABASE [GameStore]
GO

CREATE TABLE [Category](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(150) NOT NULL,

    CONSTRAINT [pk_Category] PRIMARY KEY ([Id])
)

CREATE TABLE [Publisher](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(150) NOT NULL,

    CONSTRAINT [pk_Publisher] PRIMARY KEY ([Id])
)

CREATE TABLE [Game](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(150) NOT NULL,
    [Price] DECIMAL(18,2) NOT NULL,
    [fkCategory] INT NOT NULL,
    [fkPublisher] INT NOT NULL,

    CONSTRAINT [pk_Game] PRIMARY KEY ([Id]),
    CONSTRAINT [fk_Game_Category] FOREIGN KEY ([fkCategory]) REFERENCES [Category]([Id]),
    CONSTRAINT [fk_Game_Publisher] FOREIGN KEY ([fkPublisher]) REFERENCES [Publisher]([Id])
)