create database Hospital;
use Hospital;
create table Usuarios(
id_usuario int not null identity(1,1) ,
nombre nvarchar(20) null,
apellido nvarchar(20) null, 
dni nvarchar(8) null,
ruc nvarchar(15) null,
celular nvarchar(20) null,
correo nvarchar(50) null,
fecha_nacimiento datetime,
clave nvarchar(50) null,
primary key(id_usuario),
)
go

insert into Usuarios (nombre,apellido,dni,ruc,celular,correo,fecha_nacimiento,clave)
values( 'juan carlos','soza izquierdo','12345678','123456780','999999999','jc@gmail.com', '05-04-1999', 'juancho12344');
go

create table Medicos(
id_medico int not null identity(1,1),
nombre nvarchar(20)  null,
apellido nvarchar(20)  null,
especialidad nvarchar(20) not null,
dni nvarchar(8) null, 
certificado varchar(20)  null,
id_usuario int not null,

primary key(id_medico),

foreign key (id_usuario) references Usuarios (id_usuario)
);
go

insert into Medicos(nombre,apellido,especialidad,dni,certificado,id_usuario)
values('Aldair Antonio', 'Roberto Santa Rosa', 'Cardiologo', '12345009','Colegiado', 1)
go

select * from Medicos



drop table Farmacias

create table Farmacias(
id_farmacia int not null identity(1,1),
nombre nvarchar(100) null,
pais nvarchar(30) null,
departamento nvarchar(30) null,
distrito nvarchar(30) null,
primary key(id_farmacia))
go

insert into Farmacias(nombre, pais,departamento,distrito)
values(' San Cristobal', 'Perú', 'Callao', 'Chorrillos-Cedros')
select * from Farmacias


create table Medicamentos(
id_medicamento int not null identity(1,1),
nombre nvarchar(100) null,
stock nvarchar(100) null,
categoria nvarchar(100) null,
precio nvarchar(1000) null,
fecha datetime,
primary key(id_medicamento),
id_usuario int not null, 
id_farmacia int not null
foreign key(id_usuario) references Usuarios(id_usuario),
foreign key(id_farmacia) references Farmacias(id_farmacia)
)
go

insert into Medicamentos(nombre, stock,categoria,precio,fecha,id_usuario,id_farmacia)
values('aspirina', '5', 'Tabletas', 's/2.00','05/13/2018',1,1)
select * from Medicamentos
drop table Facturas
create table Facturas(
id_factura int not null identity(1,1),
nombre nvarchar(100) null,
dni nvarchar(8) null,
ruc nvarchar(15) null,
direccion nvarchar(100) null,
telefono nvarchar(20) null,
total nvarchar(1000) null,
tipo_pago nvarchar(100) null,
estado nvarchar(100) null,
fecha datetime,
id_usuario int not null,
id_medicamento int not null,
primary key(id_factura),
foreign key(id_usuario) References Usuarios(id_usuario),
foreign key(id_medicamento) References Medicamentos(id_medicamento))


go

insert into Facturas (nombre, dni, ruc, direccion,telefono,total,tipo_pago,estado,fecha,id_usuario,id_medicamento)
values('Compra Medicamentos Por Mayor', '12345678','123456780','Pasaje San Cristobal','999999999', 's/50.00', 'efectivo', 'buen estado', '05/13/2022',1,6)
go
select * from Facturas


create table Reserva_Cita
(id_cita int not null identity(1,1),
id_medico int not null,
primary key(id_cita),
foreign key(id_medico) references Medicos(id_medico))
go

insert into Reserva_Cita(  id_medico)
 values(2)
 go

 select * from Reserva_Cita

 
create table Reserva_Medicamento(
id_reservamedicamento int not null identity(1,1),
id_medicamento int not null,
primary key(id_reservamedicamento),
foreign key(id_medicamento) references Medicamentos(id_medicamento))
go


insert into Reserva_Medicamento(id_medicamento)
values(6)
go
select * from Reserva_Medicamento