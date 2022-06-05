
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/10/2022 12:00:17
-- Generated from EDMX file: C:\Users\Mehmet\source\repos\arackiralamamf\arackiralamamf\AracKiralama1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AracKiralama];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AraclarBayiler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bayiler1] DROP CONSTRAINT [FK_AraclarBayiler];
GO
IF OBJECT_ID(N'[dbo].[FK_AraclarOdemeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odemeler1] DROP CONSTRAINT [FK_AraclarOdemeler];
GO
IF OBJECT_ID(N'[dbo].[FK_MusterilerOdemeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Odemeler1] DROP CONSTRAINT [FK_MusterilerOdemeler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Araclar1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Araclar1];
GO
IF OBJECT_ID(N'[dbo].[Bayiler1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bayiler1];
GO
IF OBJECT_ID(N'[dbo].[Musteriler1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Musteriler1];
GO
IF OBJECT_ID(N'[dbo].[Odemeler1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Odemeler1];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Musteriler1'
CREATE TABLE [dbo].[Musteriler1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MusteriAdSoyad] nvarchar(max)  NOT NULL,
    [Telefon] nvarchar(max)  NOT NULL,
    [TcNo] nvarchar(max)  NOT NULL,
    [EhliyetDurumu] nvarchar(max)  NOT NULL,
    [Adres] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Odemeler1'
CREATE TABLE [dbo].[Odemeler1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MusterilerId] int  NOT NULL,
    [AraclarId] int  NOT NULL,
    [OdemeTutar] decimal(18,0)  NOT NULL,
    [OdemeTarih] nvarchar(max)  NOT NULL,
    [VadeFarki] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Araclar1'
CREATE TABLE [dbo].[Araclar1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AracMarka] nvarchar(max)  NOT NULL,
    [AracModel] nvarchar(max)  NOT NULL,
    [AracOzellik] nvarchar(max)  NOT NULL,
    [AracBakımGunu] nvarchar(max)  NOT NULL,
    [AracKm] int  NOT NULL,
    [Hgs] nvarchar(max)  NOT NULL,
    [GunlukTutar] decimal(18,0)  NOT NULL,
    [AracKiraDurumu] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Bayiler1'
CREATE TABLE [dbo].[Bayiler1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AraclarId] int  NOT NULL,
    [BayiAd] nvarchar(max)  NOT NULL,
    [BayiYetkilisi] nvarchar(max)  NOT NULL,
    [BayiAdres] nvarchar(max)  NOT NULL,
    [BayiTelefon] nvarchar(max)  NOT NULL,
    [BayiCiro] decimal(18,0)  NOT NULL
);
GO


-- Creating table 'Users1'
CREATE TABLE [dbo].[Users1] (
    [userID] int IDENTITY(1,1) NOT NULL,
    [userName] nvarchar(max)  NOT NULL,
    [UserPs] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Musteriler1'
ALTER TABLE [dbo].[Musteriler1]
ADD CONSTRAINT [PK_Musteriler1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Odemeler1'
ALTER TABLE [dbo].[Odemeler1]
ADD CONSTRAINT [PK_Odemeler1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Araclar1'
ALTER TABLE [dbo].[Araclar1]
ADD CONSTRAINT [PK_Araclar1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bayiler1'
ALTER TABLE [dbo].[Bayiler1]
ADD CONSTRAINT [PK_Bayiler1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [userID] in table 'Users1'
ALTER TABLE [dbo].[Users1]
ADD CONSTRAINT [PK_Users1]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MusterilerId] in table 'Odemeler1'
ALTER TABLE [dbo].[Odemeler1]
ADD CONSTRAINT [FK_MusterilerOdemeler]
    FOREIGN KEY ([MusterilerId])
    REFERENCES [dbo].[Musteriler1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MusterilerOdemeler'
CREATE INDEX [IX_FK_MusterilerOdemeler]
ON [dbo].[Odemeler1]
    ([MusterilerId]);
GO

-- Creating foreign key on [AraclarId] in table 'Odemeler1'
ALTER TABLE [dbo].[Odemeler1]
ADD CONSTRAINT [FK_AraclarOdemeler]
    FOREIGN KEY ([AraclarId])
    REFERENCES [dbo].[Araclar1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AraclarOdemeler'
CREATE INDEX [IX_FK_AraclarOdemeler]
ON [dbo].[Odemeler1]
    ([AraclarId]);
GO

-- Creating foreign key on [AraclarId] in table 'Bayiler1'
ALTER TABLE [dbo].[Bayiler1]
ADD CONSTRAINT [FK_AraclarBayiler]
    FOREIGN KEY ([AraclarId])
    REFERENCES [dbo].[Araclar1]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AraclarBayiler'
CREATE INDEX [IX_FK_AraclarBayiler]
ON [dbo].[Bayiler1]
    ([AraclarId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------