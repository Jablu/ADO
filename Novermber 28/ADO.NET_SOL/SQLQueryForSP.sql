create procedure sp_UpdateSlary (@ec int, @sal int)
as
update tbl_employee
set salary = @sal
WHERE ecode = @ec