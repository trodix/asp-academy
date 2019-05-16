
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/16/2019 13:00:53
-- Generated from EDMX file: C:\Users\Admin\source\repos\WebApplication3\WebApplication3\Models\ModelStat.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [statbase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AcademyStatistic]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StatisticSet] DROP CONSTRAINT [FK_AcademyStatistic];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AcademySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AcademySet];
GO
IF OBJECT_ID(N'[dbo].[StatisticSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StatisticSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AcademySet'
CREATE TABLE [dbo].[AcademySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Area] int  NOT NULL,
    [Region] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StatisticSet'
CREATE TABLE [dbo].[StatisticSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Published] bit  NOT NULL,
    [Score] float  NOT NULL,
    [AcademyId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AcademySet'
ALTER TABLE [dbo].[AcademySet]
ADD CONSTRAINT [PK_AcademySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatisticSet'
ALTER TABLE [dbo].[StatisticSet]
ADD CONSTRAINT [PK_StatisticSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AcademyId] in table 'StatisticSet'
ALTER TABLE [dbo].[StatisticSet]
ADD CONSTRAINT [FK_AcademyStatistic]
    FOREIGN KEY ([AcademyId])
    REFERENCES [dbo].[AcademySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademyStatistic'
CREATE INDEX [IX_FK_AcademyStatistic]
ON [dbo].[StatisticSet]
    ([AcademyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------