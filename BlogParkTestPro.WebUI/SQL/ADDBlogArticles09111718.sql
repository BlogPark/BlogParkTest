/*
   2014年9月11日17:17:40
   用户: sa
   服务器: localhost
   数据库: BlogPark
   应用程序: 
*/

/* 为了防止任何可能出现的数据丢失问题，您应该先仔细检查此脚本，然后再在数据库设计器的上下文之外运行此脚本。*/
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
ALTER TABLE dbo.BlogArticles ADD
	ISEssence int NULL,
	ISEditorRecommends int NULL,
	ISCandidate int NULL
GO
DECLARE @v sql_variant 
SET @v = N'是否精华'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'ISEssence'
GO
DECLARE @v sql_variant 
SET @v = N'是否编辑推荐'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'ISEditorRecommends'
GO
DECLARE @v sql_variant 
SET @v = N'是否候选'
EXECUTE sp_addextendedproperty N'MS_Description', @v, N'SCHEMA', N'dbo', N'TABLE', N'BlogArticles', N'COLUMN', N'ISCandidate'
GO
ALTER TABLE dbo.BlogArticles SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.BlogArticles', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.BlogArticles', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.BlogArticles', 'Object', 'CONTROL') as Contr_Per 