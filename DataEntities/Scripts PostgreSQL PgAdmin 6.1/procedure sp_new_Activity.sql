create or replace procedure sp_new_Activity(

	pId_property INT,
	pSchedule TIMESTAMP,
	pTitle VARCHAR(255)
	
)
LANGUAGE PLpGSQL AS $$
BEGIN
	insert into activity (id_property,schedule,title, created_at,update_at,status)
	values (pId_property,pSchedule,pTitle,now(),now(),'Active');
END
$$;	