
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/21/2013 17:03:09
-- Generated from EDMX file: E:\PROYECTOS\Colombia\Colpensiones\Desarrollos\DESARROLLO\2GJ Ayudante\Colpensiones2GJ\Colpensiones2GJ\BDLiquidador.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Liquidador];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CasosBAVal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CasosBAVal];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CasosBAVal'
CREATE TABLE [dbo].[CasosBAVal] (
    [IdCase] int  NOT NULL,
    [RadNumber] nvarchar(30)  NOT NULL,
    [IdCaseState] int  NOT NULL,
    [CaseClose] tinyint  NOT NULL,
    [IdWorkFlow] int  NOT NULL,
    [IdParentCase] int  NULL
);
GO

-- Creating table 'CasosDecididos'
CREATE TABLE [dbo].[CasosDecididos] (
    [idCase] bigint IDENTITY(1,1) NOT NULL,
    [RadNumber] nvarchar(max)  NOT NULL,
    [SOP] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCase] in table 'CasosBAVal'
ALTER TABLE [dbo].[CasosBAVal]
ADD CONSTRAINT [PK_CasosBAVal]
    PRIMARY KEY CLUSTERED ([IdCase] ASC);
GO

-- Creating primary key on [idCase] in table 'CasosDecididos'
ALTER TABLE [dbo].[CasosDecididos]
ADD CONSTRAINT [PK_CasosDecididos]
    PRIMARY KEY CLUSTERED ([idCase] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------