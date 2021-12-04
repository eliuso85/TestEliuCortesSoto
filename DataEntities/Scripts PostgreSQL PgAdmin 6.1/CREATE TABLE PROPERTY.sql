--- Creacion de la tabla Property
CREATE TABLE PROPERTY(

	ID_PROPERTY INT NOT NULL,
	TITLE VARCHAR(255) NOT NULL,
	ADDRESS VARCHAR (255),
	DESCRIPTION VARCHAR (255),
	CREATED_AT TIMESTAMP NOT NULL,
	UPDATE_AT TIMESTAMP NOT NULL,
	DISABLED_AT TIMESTAMP NOT NULL,
	STATUS VARCHAR (35) NOT NULL,
	PRIMARY KEY(ID_PROPERTY)
	
);


CREATE SEQUENCE SQ_PROPERTY_ID
START 1
INCREMENT 1 
MINVALUE 1
OWNED BY PROPERTY.ID_PROPERTY;

SELECT *  FROM property;
ALTER SEQUENCE SQ_PROPERTY_ID RESTART;
