 use EmpresaX;


 CREATE TABLE EMPRESAS(
 IdEmpresas Integer NOT NULL  IDENTITY(1,1) PRIMARY KEY, 
 Nombre varchar(30) NULL,
 Direccion varchar(50) NULL,
 Ciudad varchar(50) NULL,
 Telefono Varchar(20) NULL,
 CodigoPostal varchar(20) NULL,
 Estado varchar(20) NULL
 );


 
 CREATE TABLE CLIENTE(
 IdCliente Integer NOT NULL  IDENTITY(1,1) PRIMARY KEY, 
 Nombre varchar(40) NULL,
 Apellido varchar(40) NULL,
 Cedula varchar(15) NULL,
 Telefono Varchar(20) NULL,
 Nacionalidad varchar(20) NULL,
 EstadoCivil varchar(20) NULL,
 IdEmpresa Integer NOT NULL, 
 CONSTRAINT FK_ClienteEmpresa  FOREIGN KEY (IdEmpresa) REFERENCES Empresas(IdEmpresas)
 );

 CREATE TABLE DIRECCION(
 IdDireccion Integer NOT NULL  IDENTITY(1,1) PRIMARY KEY, 
 Direccion_Principal varchar(100) NULL,
 Direccion_Secundaria varchar(100) NULL,
 Ciudad varchar(20) NULL,
 Provincia varchar(20) NULL,
 Numero varchar(20) NULL,
 CodigoPostal Varchar(10) NULL,
 IdCliente Integer NOT NULL, 
 CONSTRAINT FK_DireccionCliente  FOREIGN KEY (IdCliente) REFERENCES CLIENTE(IdCliente)
 );


INSERT INTO EMPRESAS
values ('EMPRESA X', 'Av. México Esq. Calle Abreu', 'Santo Domingo', '809-970-3724', '10205', 'ACTIVA' )

INSERT INTO CLIENTE
values ('Juan', 'Marmolejos', '40231134797', '809-970-3724', 'Dominicano', 'CASADO', 1 )

INSERT INTO CLIENTE
values ('DAWICH', 'Rodriguez', '40231134797', '809-970-3724', 'Venezolano', 'SOLTERO', 1 )

select * from DIRECCION;


INSERT INTO DIRECCION
values ('Calle Juan Erazo #129', 'Frente a la loteria', 'Santo Domingo', 'Distrito Nacional', '809-987-8657','10141', 10)


select * from CLIENTE; 

select *   from DIRECCION

delete from  DIRECCION where idCliente = 9