

USE EduAsyncHub;

-- Tabla de Roles
CREATE TABLE Roles (
    RolID INT PRIMARY KEY,
    NombreRol VARCHAR(50) NOT NULL
);

-- Inserción de roles
INSERT INTO Roles (RolID, NombreRol) VALUES
    (1, 'Estudiante'),
    (2, 'Profesor'),
    (3, 'Administrador');

-- Verificar roles
SELECT * FROM Roles;

-- Tabla de Grados Escolares
CREATE TABLE GradosEscolares (
    GradoID INT PRIMARY KEY,
    NombreGrado VARCHAR(100) NOT NULL
);

-- Inserción de grados escolares
INSERT INTO GradosEscolares (GradoID, NombreGrado) VALUES
    (1, 'Primero de Primaria'),
    (2, 'Segundo de Primaria'),
    (3, 'Tercero de Primaria'),
    (4, 'Cuarto de Primaria'),
    (5, 'Quinto de Primaria'),
    (6, 'Sexto de Primaria'),
    (7, 'Primero de Secundaria'),
    (8, 'Segundo de Secundaria'),
    (9, 'Tercero de Secundaria'),
    (10, 'Cuarto de Secundaria'),
    (11, 'Quinto de Secundaria'),
    (12, 'Sexto de Secundaria');


-- Verificar grados escolares
SELECT * FROM GradosEscolares;


-- Tabla de Usuarios
CREATE TABLE Usuarios (
    UsuarioID VARCHAR(10) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    CorreoElectronico VARCHAR(100) UNIQUE NOT NULL,
    Contraseña VARCHAR(255) NOT NULL,
    RolID INT,
    FOREIGN KEY (RolID) REFERENCES Roles(RolID)
);

-- Verificar Usuarios
SELECT * FROM Usuarios;

-- Tabla de Estudiantes
CREATE TABLE Estudiantes (
    EstudianteID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID VARCHAR(10) UNIQUE,
    GradoID INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID),
    FOREIGN KEY (GradoID) REFERENCES GradosEscolares(GradoID)
);

-- Verificar Estudiantes
SELECT * FROM Estudiantes;

-- Tabla de Profesores
CREATE TABLE Profesores (
    ProfesorID INT PRIMARY KEY IDENTITY(1,1),
    UsuarioID VARCHAR(10) UNIQUE,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);


-- Verificar Profesores
SELECT * FROM Profesores;

-- Tabla de Materias
CREATE TABLE Materias (
    MateriaID INT PRIMARY KEY IDENTITY(1,1),
    NombreMateria VARCHAR(100) NOT NULL
);

-- Inserción de materias
INSERT INTO Materias (NombreMateria) VALUES
    ('Lengua Española'),
    ('Ciencias Matematicas'),
    ('Ciencias Naturales'),
    ('Ciencias Sociales'),
    ('Civica'),
    ('Informatica'),
    ('Formacion Humana, Integral y Religiosa'),
    ('Educacion Fisica'),
    ('Educacion Sexual'),
    ('Ingles'),
    ('Frances'),
    ('Educacion Artistica');

-- Verificar Materias
SELECT * FROM Materias;

-- Tabla de Asistencias
CREATE TABLE Asistencias (
    AsistenciaID INT PRIMARY KEY IDENTITY(1,1),
    EstudianteID INT,
    MateriaID INT,
    ProfesorID INT,
    FechaAsistencia DATE NOT NULL,
    Asistio BIT,
    FOREIGN KEY (EstudianteID) REFERENCES Estudiantes(EstudianteID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID),
    FOREIGN KEY (ProfesorID) REFERENCES Profesores(ProfesorID)
);

-- Verificar Asistencias
SELECT * FROM Asistencias;

-- Tabla de Calificaciones
CREATE TABLE Calificaciones (
    CalificacionID INT PRIMARY KEY IDENTITY(1,1),
    EstudianteID INT,
    MateriaID INT,
    ProfesorID INT,
    Periodo INT, -- Nuevo campo para identificar el periodo
    Calificacion FLOAT NOT NULL,
    FechaPublicacion DATE NOT NULL,
    FOREIGN KEY (EstudianteID) REFERENCES Estudiantes(EstudianteID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID),
    FOREIGN KEY (ProfesorID) REFERENCES Profesores(ProfesorID)
);

-- Verificar Calificaciones
SELECT * FROM Calificaciones;

-- Tabla de NotaTotal
CREATE TABLE NotaTotal (
    NotaTotalID INT PRIMARY KEY IDENTITY(1,1),
    EstudianteID INT UNIQUE,
    MateriaID INT,
    NotaTotal FLOAT,
    FOREIGN KEY (EstudianteID) REFERENCES Estudiantes(EstudianteID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID)
);

-- Verificar NotasTotales
SELECT * FROM NotaTotal;


-- Modificar la tabla EstudianteMateria
CREATE TABLE EstudianteMateria (
    InscripcionMateriaID INT PRIMARY KEY IDENTITY(1,1),
    EstudianteID INT,
    MateriaID INT,
    GradoID INT,
    FOREIGN KEY (EstudianteID) REFERENCES Estudiantes(EstudianteID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID),
    FOREIGN KEY (GradoID) REFERENCES GradosEscolares(GradoID)
);

-- Verificar EstudianteMateria
SELECT * FROM EstudianteMateria;

-- Modificar la tabla ProfesorMateria
CREATE TABLE ProfesorMateria (
    AsignacionProfesorID INT PRIMARY KEY IDENTITY(1,1),
    ProfesorID INT,
    MateriaID INT,
    GradoID INT,
    FOREIGN KEY (ProfesorID) REFERENCES Profesores(ProfesorID),
    FOREIGN KEY (MateriaID) REFERENCES Materias(MateriaID),
    FOREIGN KEY (GradoID) REFERENCES GradosEscolares(GradoID)
);


-- Verificar EstudianteMateria
SELECT * FROM ProfesorMateria;

-- Tabla de Noticias
CREATE TABLE Noticias (
    id INT PRIMARY KEY IDENTITY(1,1),
    img VARCHAR(255),
    title VARCHAR(255),
    date VARCHAR(100),
    description VARCHAR(MAX)
);

-- Verificar la tabla de Noticias
SELECT * FROM Noticias;

-- Tabla de Eventos
CREATE TABLE Eventos (
    id INT PRIMARY KEY IDENTITY(1,1),
    img VARCHAR(255),
    title VARCHAR(255),
    date VARCHAR(100),
    description VARCHAR(MAX)
);

-- Verificar la tabla de Eventos
SELECT * FROM Eventos;


CREATE TABLE CalendarioEspecifico (
    id INT PRIMARY KEY IDENTITY(1,1),
    title VARCHAR(255),
    date  varchar(100),
    hora varchar(100)
);

select* from CalendarioEspecifico;

CREATE TABLE SolicitudAdmision (
    SolicitudID INT PRIMARY KEY IDENTITY(1,1),
    NombreEstudiante VARCHAR(100),
    FechaNacimiento DATE,
    Genero VARCHAR(20),
    DireccionEstudiante VARCHAR(255),
    Grado INT,
    EscuelaActual VARCHAR(100),
    NombrePadreTutor VARCHAR(100),
    RelacionEstudiante VARCHAR(100),
    DireccionPadreTutor VARCHAR(255),
    NumeroTelefono VARCHAR(20),
    CorreoElectronico VARCHAR(100),
    FechaHoraSolicitud DATETIME DEFAULT CURRENT_TIMESTAMP,
    EstadoSolicitud VARCHAR(20),
    NotasComentarios TEXT
);

select* from SolicitudAdmision;

CREATE TABLE Salas (
    Id VARCHAR(255) PRIMARY KEY,
    Nombre VARCHAR(255),
    Fecha VARCHAR(255)
);


select * from Salas
