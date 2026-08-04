-- Ejecutar en la base de datos Carpintec (SQL Server)
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = 'ActividadTaller')
BEGIN
    CREATE TABLE ActividadTaller (
        IdActividad   INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        Fecha         DATE NOT NULL,
        Categoria     VARCHAR(30) NOT NULL,
        Texto         VARCHAR(140) NOT NULL,
        IdUsuario     INT NULL,
        FechaRegistro DATETIME NOT NULL CONSTRAINT DF_ActividadTaller_FechaRegistro DEFAULT (GETDATE()),
        CONSTRAINT FK_ActividadTaller_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
    );

    CREATE INDEX IX_ActividadTaller_Fecha ON ActividadTaller(Fecha);
END
