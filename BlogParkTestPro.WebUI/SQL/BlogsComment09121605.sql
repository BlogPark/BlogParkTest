/*
   2014年9月12日16:05:25
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
CREATE TABLE dbo.BlogsComment
	(
	CommentID int NOT NULL IDENTITY (1, 1),
	CommentTitle nvarchar(500) NULL,
	CommentContext text NULL,
	CommentUserID int NULL,
	CommentUserName nvarchar(50) NULL,
	CommentTime datetime NULL,
	SupportCount int NULL,
	OppositionCount int NULL,
	IsDeleted int NULL,
	BlogsID int NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
DECLARE @v sql_variant 
SET @v = N'评论ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentID'
GO
DECLARE @v sql_variant 
SET @v = N'评论标题'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentTitle'
GO
DECLARE @v sql_variant 
SET @v = N'评论内容'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentContext'
GO
DECLARE @v sql_variant 
SET @v = N'评论人ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentUserID'
GO
DECLARE @v sql_variant 
SET @v = N'评论人昵称'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentUserName'
GO
DECLARE @v sql_variant 
SET @v = N'评论时间'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'CommentTime'
GO
DECLARE @v sql_variant 
SET @v = N'支持数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'SupportCount'
GO
DECLARE @v sql_variant 
SET @v = N'反对数'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'OppositionCount'
GO
DECLARE @v sql_variant 
SET @v = N'是否被删除'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'IsDeleted'
GO
DECLARE @v sql_variant 
SET @v = N'文章ID'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogsComment', N'COLUMN', N'BlogsID'
GO
ALTER TABLE dbo.BlogsComment ADD CONSTRAINT
	PK_BlogsComment PRIMARY KEY CLUSTERED 
	(
	CommentID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.BlogsComment SET (LOCK_ESCALATION = TABLE)
GO
COMMIT