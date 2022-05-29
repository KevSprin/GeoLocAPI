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
    [Id] int NOT NULL IDENTITY,
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
    [Id] int NOT NULL IDENTITY,
    [Username] nvarchar(max) NULL,
    [Password] nvarchar(max) NULL,
    CONSTRAINT [PK_LoginModels] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ContinentCode', N'ContinentName', N'CountryCode', N'CountryName', N'HostAddress', N'Latitude', N'Longitude', N'RegionCode', N'RegionName', N'Zip') AND [object_id] = OBJECT_ID(N'[GeoLocations]'))
    SET IDENTITY_INSERT [GeoLocations] ON;
INSERT INTO [GeoLocations] ([Id], [ContinentCode], [ContinentName], [CountryCode], [CountryName], [HostAddress], [Latitude], [Longitude], [RegionCode], [RegionName], [Zip])
VALUES (1, NULL, NULL, N'No code', N'No name', N'127.0.0.1', NULL, NULL, NULL, NULL, NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ContinentCode', N'ContinentName', N'CountryCode', N'CountryName', N'HostAddress', N'Latitude', N'Longitude', N'RegionCode', N'RegionName', N'Zip') AND [object_id] = OBJECT_ID(N'[GeoLocations]'))
    SET IDENTITY_INSERT [GeoLocations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] ON;
INSERT INTO [LoginModels] ([Id], [Password], [Username])
VALUES (1, N'$2b$10$Xr3wOLK7JECj0xeWzXyMluwhhXDpZicMOdBGHnHygQsVu5OxrKRHy', N'admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] ON;
INSERT INTO [LoginModels] ([Id], [Password], [Username])
VALUES (2, N'$2b$10$TFmhQK92JsFXrMLgpRI32.z4.c8H/n1YXMGru.1dwmQ/0ZQ2fhFUa', N'user1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Password', N'Username') AND [object_id] = OBJECT_ID(N'[LoginModels]'))
    SET IDENTITY_INSERT [LoginModels] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220528200617_InitialCreate', N'6.0.5');
GO

COMMIT;
GO

