/*
   2014年9月12日16:27:55
   用户: sa
   服务器: localhost
   数据库: BlogPark
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
USE BlogPark
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.BlogsComment ADD
	CommentType int NULL,
	SourceCommentID int NULL
GO
DECLARE @v sql_variant 
SET @v = N'评论类型（1 评论 2 回复）'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentType'
GO
DECLARE @v sql_variant 
SET @v = N'回复评论ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'SourceCommentID'
GO
ALTER TABLE dbo.BlogsComment SET (LOCK_ESCALATION = TABLE)
GO
COMMIT