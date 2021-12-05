create or replace procedure sp_Update_Activity(

	pid_activity INT,
	pSchedule TIMESTAMP
		
)
LANGUAGE PLpGSQL AS $$
BEGIN
	update ACTIVITY set Schedule= pSchedule, UPDATE_AT = now()
	where id_activity = pid_activity and STATUS <> 'cancel';
END
$$;	