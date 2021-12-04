----StoreProcedure  para Cancelar las actividades.
create or replace procedure SP_cancelActivity
(
	pID_ACTIVITY int
)
LANGUAGE  plpgsql  AS $$
begin
	update ACTIVITY set STATUS='cancel', UPDATE_AT = now()
	where id_activity = pID_ACTIVITY;
end
$$;

--call SP_cancelActivity (2)
--select * from ACTIVITY