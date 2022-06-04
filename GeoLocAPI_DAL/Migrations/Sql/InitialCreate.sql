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

CREATE TABLE [GeoLocations] (
    [Id] uniqueidentifier NOT NULL,
    [HostAddress] nvarchar(max) NULL,
    [ContinentCode] nvarchar(max) NULL,
    [ContinentName] nvarchar(max) NULL,
    [CountryCode] nvarchar(max) NULL,
    [CountryName] nvarchar(max) NULL,
    [RegionCode] nvarchar(max) NULL,
    [RegionName] nvarchar(max) NULL,
    [Zip] nvarchar(max) NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    CONSTRAINT [PK_GeoLocations] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [LoginModels] (
    [Id] uniqueidentifier NOT NULL,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_LoginModels] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ContinentCode', N'ContinentName', N'CountryCode', N'CountryName', N'HostAddress', N'Latitude', N'Longitude', N'RegionCode', N'RegionName', N'Zip') AND [object_id] = OBJECT_ID(N'[GeoLocations]'))
    SET IDENTITY_INSERT [GeoLocations] ON;
INSERT INTO [GeoLocations] ([Id], [ContinentCode], [ContinentName], [CountryCode], [CountryName], [HostAddress], [Latitude], [Longitude], [RegionCode], [RegionName], [Zip])
VALUES ('65ebc216-74b4-4e2a-8527-d1f870eea3e4', NULL, NULL, N'No code', N'No name', N'127.0.0.1', NULL, NULL, NULL, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ContinentCode', N'ContinentName', N'CountryCode', N'CountryName', N'HostAddress', N'Latitude', N'Longitude', N'RegionCode', N'RegionName', N'Zip') AND [object_id] = OBJECT_ID(N'[GeoLocations]'))
    SET IDENTITY_INSERT [GeoLocations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] ON;
INSERT INTO [LoginModels] ([Id], [Password], [Username])
VALUES ('50e66a5f-61a6-457d-9cba-b9d3e5430bd3', N'$2b$10$bDz8iRZjG3zfJdi2nBezBe1UKYIuBbb/uRCUnH67mRAujtDR4LO0q', N'user1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] ON;
INSERT INTO [LoginModels] ([Id], [Password], [Username])
VALUES ('e271c897-cf27-4e2e-b80d-69cce9d79e45', N'$2b$10$WibErh/bDXtrdWxh/OkjpuJpE6JYtuMxUiEexcycimIz9fgQV5jTy', N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220604202452_InitialCreate', N'6.0.5');
GO

COMMIT;
GO

