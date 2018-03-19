# CoffeeScript
CREATE TABLE [dbo].[FileDetails](  
    [Id] [int] IDENTITY(1,1) NOT NULL,  
    [FileName] [varchar](60) NULL,  
    [FileContent] [varbinary](max) NULL  
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]  