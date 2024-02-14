Create database EduAsyncHub
use EduAsyncHub


CREATE TABLE Usuarios (
    UserID INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    Apellido NVARCHAR(50),
    CorreoElectronico NVARCHAR(100),
    Contraseña NVARCHAR(100),
    Rol NVARCHAR(50)
);

CREATE TABLE Cursos (
    CursoID INT PRIMARY KEY IDENTITY,
    NombreCurso NVARCHAR(100),
    DescripcionCurso NVARCHAR(MAX)
);

CREATE TABLE Mensajes (
    MensajeID INT PRIMARY KEY IDENTITY,
    ContenidoMensaje NVARCHAR(MAX),
    FechaHoraPublicacion DATETIME,
    UserID INT,
    CursoID INT,
    FOREIGN KEY (UserID) REFERENCES Usuarios(UserID),
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID)
);

-- Tablas de Relación
CREATE TABLE Usuarios_Cursos (
    UsuarioCursoID INT PRIMARY KEY IDENTITY,
    UserID INT,
    CursoID INT,
    FOREIGN KEY (UserID) REFERENCES Usuarios(UserID),
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID)
);

CREATE TABLE Asistencia (
    AsistenciaID INT PRIMARY KEY IDENTITY,
    FechaAsistencia DATE,
    EstadoAsistencia NVARCHAR(50),
    UserID INT,
    CursoID INT,
    FOREIGN KEY (UserID) REFERENCES Usuarios(UserID),
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID)
);

CREATE TABLE Calificaciones (
    CalificacionID INT PRIMARY KEY IDENTITY,
    ValorCalificacion DECIMAL(5,2),
    TipoEvaluacion NVARCHAR(50),
    PeriodoEvaluacion NVARCHAR(2),
    UserID INT,
    CursoID INT,
    FOREIGN KEY (UserID) REFERENCES Usuarios(UserID),
    FOREIGN KEY (CursoID) REFERENCES Cursos(CursoID)
);
