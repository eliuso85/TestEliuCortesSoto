CREATE OR REPLACE FUNCTION getListActivities()
RETURNS TABLE (
	id_activity int,
	schedule TIMESTAMP,
	title varchar,
	created_at TIMESTAMP,
	status varchar,
	Condition text,
	id_property int,
	titleProp varchar,
	address varchar
)AS $$
BEGIN
  	RETURN QUERY 
		SELECT 
				a.id_activity,
				a.schedule,
				a.title,
				a.created_at,
				a.status,
				CASE WHEN a.status = 'Active' THEN 
					CASE WHEN a.schedule >= now() THEN
							'Pendiente a realizar'
						ELSE
							'Atrasada'
						END
					ELSE 
						CASE WHEN a.status = 'done' THEN
							'Finalizada'
						END
				END as Condition,
				a.id_property,
				p.title as titleProp,
				p.address
				FROM activity  a
					INNER JOIN property p
							ON a.id_property = p.id_property
				ORDER BY a.id_activity ASC;
		
END
$$ LANGUAGE plpgsql;


SELECT * FROM getListActivities();