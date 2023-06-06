create Procedure CheckAdmin
@username Nvarchar(30),
@password nvarchar(30),
@result int OUTPUT
as 
begin 
	select @result = COUNT(*) 
	from Admins as A
	where A.[Username]=@username AND A.[Password] =@password 

end
