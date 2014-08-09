
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/19/2014 14:44:39
-- Generated from EDMX file: E:\projects\网站建设\website\鄂尔多斯产权交易中心\Test\Blog.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BlogDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CommentPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Comments] DROP CONSTRAINT [FK_CommentPost];
GO
IF OBJECT_ID(N'[dbo].[FK_BlogUserPost]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Post] DROP CONSTRAINT [FK_BlogUserPost];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BlogUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BlogUser];
GO
IF OBJECT_ID(N'[dbo].[Post]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Post];
GO
IF OBJECT_ID(N'[dbo].[Comments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Comments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BlogUser'
CREATE TABLE [dbo].[BlogUser] (
    [BlogID] int IDENTITY(1,1) NOT NULL,
    [BlogName] varchar(50)  NULL
);
GO

-- Creating table 'Post'
CREATE TABLE [dbo].[Post] (
    [PostID] int IDENTITY(1,1) NOT NULL,
    [PostTitle] nchar(10)  NULL,
    [PostContent] varchar(50)  NULL,
    [BlogID] int  NULL,
    [BlogUser_BlogID] int  NOT NULL
);
GO

-- Creating table 'Comment'
CREATE TABLE [dbo].[Comment] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [PostID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BlogID] in table 'BlogUser'
ALTER TABLE [dbo].[BlogUser]
ADD CONSTRAINT [PK_BlogUser]
    PRIMARY KEY CLUSTERED ([BlogID] ASC);
GO

-- Creating primary key on [PostID] in table 'Post'
ALTER TABLE [dbo].[Post]
ADD CONSTRAINT [PK_Post]
    PRIMARY KEY CLUSTERED ([PostID] ASC);
GO

-- Creating primary key on [ID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [PK_Comment]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PostID] in table 'Comment'
ALTER TABLE [dbo].[Comment]
ADD CONSTRAINT [FK_CommentPost]
    FOREIGN KEY ([PostID])
    REFERENCES [dbo].[Post]
        ([PostID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CommentPost'
CREATE INDEX [IX_FK_CommentPost]
ON [dbo].[Comment]
    ([PostID]);
GO

-- Creating foreign key on [BlogUser_BlogID] in table 'Post'
ALTER TABLE [dbo].[Post]
ADD CONSTRAINT [FK_BlogUserPost]
    FOREIGN KEY ([BlogUser_BlogID])
    REFERENCES [dbo].[BlogUser]
        ([BlogID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BlogUserPost'
CREATE INDEX [IX_FK_BlogUserPost]
ON [dbo].[Post]
    ([BlogUser_BlogID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------