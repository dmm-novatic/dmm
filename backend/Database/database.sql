-- Model generate command:
-- Scaffold-DbContext "Server=DESKTOP-4PAUV2F;Database=GW;UID=sa;PWD=123456;" Microsoft.EntityFrameworkCore.SqlServer -f -OutputDir Models



CREATE TABLE [AccountType](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL   ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [AccountType] ADD  CONSTRAINT [DF_AccountType_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Account](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[AccountTypeID] [int] NOT NULL   ,
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL   ,
	[Email] [nvarchar] (255) NOT NULL   ,
	[Username] [nvarchar] (255) NOT NULL   ,
	[Password] [nvarchar] (255) NOT NULL   ,
	[Photo] [ntext]  NULL   ,
	[Description] [ntext]  NULL   ,
	[Info] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Account] ADD  CONSTRAINT [DF_Account_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE account
                ADD CONSTRAINT FK_account_accountTypeID
                FOREIGN KEY (accountTypeID) REFERENCES accountType(ID);

CREATE TABLE [AccountMeta](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[AccountID] [int] NOT NULL   ,
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [AccountMeta] ADD  CONSTRAINT [DF_AccountMeta_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE accountMeta
                ADD CONSTRAINT FK_accountMeta_accountID
                FOREIGN KEY (accountID) REFERENCES account(ID);

CREATE TABLE [Authentication](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[AccountID] [int] NOT NULL   ,
	[Token] [nvarchar] (255) NOT NULL   ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
	[ValidTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Authentication] ADD  CONSTRAINT [DF_Authentication_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE authentication
                ADD CONSTRAINT FK_authentication_accountID
                FOREIGN KEY (accountID) REFERENCES account(ID);


				

CREATE TABLE [ViewStatus](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [ViewStatus] ADD  CONSTRAINT [DF_ViewStatus_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Notification](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL   ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
	[ViewStatus] [int] NOT NULL   ,
);
	ALTER TABLE [Notification] ADD  CONSTRAINT [DF_Notification_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Message](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL   ,
	[Sender] [ntext]  NOT NULL   ,
	[Source] [nvarchar] (255) NOT NULL   ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
	[ViewStatus] [int] NOT NULL   ,
);
	ALTER TABLE [Message] ADD  CONSTRAINT [DF_Message_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Province](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Province] ADD  CONSTRAINT [DF_Province_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [SystemConfig](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Code] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [SystemConfig] ADD  CONSTRAINT [DF_SystemConfig_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Menu](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[ParentID] [int] NULL   ,
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[Url] [ntext]  NOT NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Menu] ADD  CONSTRAINT [DF_Menu_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [PostType](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [PostType] ADD  CONSTRAINT [DF_PostType_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [PostCategory](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [PostCategory] ADD  CONSTRAINT [DF_PostCategory_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [PostLayout](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [PostLayout] ADD  CONSTRAINT [DF_PostLayout_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Tag](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Tag] ADD  CONSTRAINT [DF_Tag_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    


CREATE TABLE [Post](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[PostTypeID] [int] NOT NULL   ,
	[PostAccountID] [int] NOT NULL   ,
	[PostCategoryID] [int] NOT NULL   ,
	[PostLayoutID] [int] NOT NULL   ,
	[PostPublishStatusID] [int] NOT NULL   ,
	[PostCommentStatusID] [int] NOT NULL   ,
	[Active] [int] NOT NULL   ,
	[Url] [nvarchar] (255) NULL UNIQUE ,
	[GuID] [nvarchar] (255) NULL UNIQUE ,
	[Photo] [nvarchar] (255) NULL   ,
	[Video] [nvarchar] (255) NULL   ,
	[ViewCount] [int] NULL   ,
	[CommentCount] [int] NULL   ,
	[LikeCount] [int] NULL   ,
	[Name] [nvarchar] (255) NOT NULL   ,
	[Description] [ntext]  NULL   ,
	[Text] [ntext]  NULL   ,
	[Name2] [nvarchar] (255) NULL   ,
	[Description2] [ntext]  NULL   ,
	[Text2] [ntext]  NULL   ,
	[PublishedTime] [datetime] NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Post] ADD  CONSTRAINT [DF_Post_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE post
                ADD CONSTRAINT FK_post_postTypeID
                FOREIGN KEY (postTypeID) REFERENCES postType(ID);
                
ALTER TABLE post
                ADD CONSTRAINT FK_post_postAccountID
                FOREIGN KEY (postAccountID) REFERENCES account(ID);
                
ALTER TABLE post
                ADD CONSTRAINT FK_post_postCategoryID
                FOREIGN KEY (postCategoryID) REFERENCES postCategory(ID);
                
ALTER TABLE post
                ADD CONSTRAINT FK_post_postLayoutID
                FOREIGN KEY (postLayoutID) REFERENCES postLayout(ID);

CREATE TABLE [PostMeta](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[PostID] [int] NOT NULL   ,
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [PostMeta] ADD  CONSTRAINT [DF_PostMeta_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE postMeta
                ADD CONSTRAINT FK_postMeta_postID
                FOREIGN KEY (postID) REFERENCES post(ID);

CREATE TABLE [PostTag](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[PostID] [int] NOT NULL   ,
	[TagID] [int] NOT NULL   ,
	[Active] [int] NOT NULL   ,
	[Name] [nvarchar] (255) NOT NULL UNIQUE ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [PostTag] ADD  CONSTRAINT [DF_PostTag_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE postTag
                ADD CONSTRAINT FK_postTag_postID
                FOREIGN KEY (postID) REFERENCES post(ID);
                
ALTER TABLE postTag
                ADD CONSTRAINT FK_postTag_tagID
                FOREIGN KEY (tagID) REFERENCES tag(ID);

CREATE TABLE [Comment](
        [ID] [int] PRIMARY KEY IDENTITY(10001,1),
	[PostID] [int] NOT NULL   ,
	[AccountID] [int] NOT NULL   ,
	[Active] [int] NOT NULL   ,
	[Approve] [int] NOT NULL   ,
	[Name] [ntext]  NOT NULL   ,
	[Description] [ntext]  NULL   ,
	[CreatedTime] [datetime] NOT NULL   ,
);
	ALTER TABLE [Comment] ADD  CONSTRAINT [DF_Comment_CreatedTime]  DEFAULT (getdate()) FOR [CreatedTime];
    

                
ALTER TABLE comment
                ADD CONSTRAINT FK_comment_postID
                FOREIGN KEY (postID) REFERENCES post(ID);
                
ALTER TABLE comment
                ADD CONSTRAINT FK_comment_accountID
                FOREIGN KEY (accountID) REFERENCES account(ID);