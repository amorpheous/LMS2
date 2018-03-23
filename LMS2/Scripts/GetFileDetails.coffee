# CoffeeScript
CREATE Procedure [dbo].[GetFileDetails]  
(  
@Id int=null  
  
  
)  
as  
begin  
  
select Id,FileName,FileContent from FileDetails  
where Id=isnull(@Id,Id)  
End  