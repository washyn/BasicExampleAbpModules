-- For roles
SET IDENTITY_INSERT Roles ON
GO
insert into Roles (Id, Nombre) values (1, 'Admin');
insert into Roles (Id, Nombre) values (2, 'Usuario');
GO
SET IDENTITY_INSERT Roles OFF

----------------------------------------------------------------------------
-- For users

SET IDENTITY_INSERT USUARIOS ON
GO
insert into USUARIOS (Identificador, STR_NOMB, STR_APE, STR_USUARIO, STR_CONTRA, RolId) values (1,'chester','apellido','admin','YWRtaW4=',1);
insert into USUARIOS (Identificador, STR_NOMB, STR_APE, STR_USUARIO, STR_CONTRA, RolId) values (2,'chester2','apellido2','usuario','dXN1YXJpbw==',2);
GO
SET IDENTITY_INSERT USUARIOS OFF
