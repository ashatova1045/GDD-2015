SELECT * FROM gd_MORCIPAN.usuarios;
SELECT * FROM gd_MORCIPAN.roles_usuarios;
SELECT * FROM gd_MORCIPAN.funciones;
SELECT * FROM gd_MORCIPAN.funciones_roles;

INSERT INTO gd_MORCIPAN.funciones_roles 
(rol_id, funcion_id)
VALUES
(2, 7)

EXEC gd_MORCIPAN.spObtenerBonosAfiliado 579901, 'consulta'

	SELECT *
	FROM gd_MORCIPAN.afiliados
	ORDER BY afiliado_numero DESC






