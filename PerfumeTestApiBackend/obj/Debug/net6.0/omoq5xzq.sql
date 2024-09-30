IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Perfumerias] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(50) NOT NULL,
    [Address] nvarchar(100) NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Perfumerias] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Perfumes] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(20) NOT NULL,
    [Price] decimal(9,2) NOT NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Perfumes] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Generos] (
    [Id] int NOT NULL IDENTITY,
    [TypeGender] nvarchar(20) NOT NULL,
    [PerfumeID] int NOT NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Generos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Generos_Perfumes_PerfumeID] FOREIGN KEY ([PerfumeID]) REFERENCES [Perfumes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Marcas] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [PerfumeID] int NOT NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Marcas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Marcas_Perfumes_PerfumeID] FOREIGN KEY ([PerfumeID]) REFERENCES [Perfumes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Stock] (
    [PerfumeID] int NOT NULL,
    [PerfumeryID] int NOT NULL,
    [Amount] int NOT NULL,
    CONSTRAINT [PK_Stock] PRIMARY KEY ([PerfumeID], [PerfumeryID]),
    CONSTRAINT [FK_Stock_Perfumerias_PerfumeryID] FOREIGN KEY ([PerfumeryID]) REFERENCES [Perfumerias] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Stock_Perfumes_PerfumeID] FOREIGN KEY ([PerfumeID]) REFERENCES [Perfumes] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Volumes] (
    [Id] int NOT NULL IDENTITY,
    [Quantity] int NOT NULL,
    [PerfumeID] int NOT NULL,
    [Available] bit NOT NULL,
    CONSTRAINT [PK_Volumes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Volumes_Perfumes_PerfumeID] FOREIGN KEY ([PerfumeID]) REFERENCES [Perfumes] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Generos_PerfumeID] ON [Generos] ([PerfumeID]);
GO

CREATE INDEX [IX_Marcas_PerfumeID] ON [Marcas] ([PerfumeID]);
GO

CREATE INDEX [IX_Stock_PerfumeryID] ON [Stock] ([PerfumeryID]);
GO

CREATE INDEX [IX_Volumes_PerfumeID] ON [Volumes] ([PerfumeID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240930034508_Init', N'6.0.10');
GO

COMMIT;
GO

