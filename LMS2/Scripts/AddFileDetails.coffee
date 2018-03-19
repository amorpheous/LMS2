# CoffeeScript
Create Procedure [dbo].[AddFileDetails]  
(  
@FileName varchar(60),  
@FileContent varBinary(Max)  
)  
as  
begin  
Set NoCount on  
Insert into FileDetails values(@FileName,@FileContent)  
  
End  