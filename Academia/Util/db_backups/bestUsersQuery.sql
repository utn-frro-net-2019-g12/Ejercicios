INSERT INTO tp2_net.dbo.usuarios (
	-- [id_usuario] --> el ID es autoincremental
	[nombre_usuario],
	[clave],
	[habilitado],
	[nombre],
	[apellido],
	[email],
	[cambia_clave],
	[id_persona]
)
VALUES
    ('nicoAntonelli','laclave','True','Nicolás','Antonelli','nic@nic.com',NULL,NULL),
    ('aleReca','laotraclave','True','Alejandro','Recalde','ale@ale.com',NULL,NULL),
	('retroVitto','masclave','True','Vittorio','Retrivi','vit@vit.com',NULL,NULL);
