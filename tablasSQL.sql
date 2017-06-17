CREATE TABLE Usuario(
	Id INT PRIMARY KEY,
	Nombre VARCHAR(256),
	Correo VARCHAR(256),
	Contrasena VARCHAR(256)
);

CREATE TABLE Conductor(
	Id INT PRIMARY KEY,
	Nombre VARCHAR(256),
	Correo VARCHAR(256),
	Contrasena VARCHAR(256)
);

CREATE TABLE Viaje(
	IdConductor INT NOT NULL,
	IdUsuario INT NOT NULL,
	Destino VARCHAR(256),
	Ubicacion VARCHAR(256),
	Hora VARCHAR(256),
	Tarifa INT,
	Puntuado  VARCHAR(256)
);