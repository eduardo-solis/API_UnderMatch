USE [BDUnderMatch]
GO
/****** Object:  Table [dbo].[tblPersonas]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPersonas](
	[IdPersona] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](80) NOT NULL,
	[PrimerApellido] [varchar](80) NOT NULL,
	[SegundoApellido] [varchar](80) NULL,
	[FechaNacimiento] [varchar](10) NOT NULL,
	[Sexo] [varchar](30) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[Telefono2] [varchar](10) NULL,
	[Correo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblPersona] PRIMARY KEY CLUSTERED 
(
	[IdPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblJugadores]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblJugadores](
	[IdJugador] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[NumDorsal] [varchar](3) NOT NULL,
	[SobreNombre] [varchar](100) NULL,
	[Posicion] [varchar](100) NOT NULL,
	[Capitan] [int] NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblJugador] PRIMARY KEY CLUSTERED 
(
	[IdJugador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctgCategorias]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgCategorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ctgCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctgTipoArbitros]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgTipoArbitros](
	[IdTipoArbitro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ctgTipoArbitro] PRIMARY KEY CLUSTERED 
(
	[IdTipoArbitro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctgTipoEmpleados]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgTipoEmpleados](
	[IdTipoEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ctgTipoEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdTipoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctgTipoProveedores]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgTipoProveedores](
	[IdTipoProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ctgTipoProveedor] PRIMARY KEY CLUSTERED 
(
	[IdTipoProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jugadores_Equipos]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jugadores_Equipos](
	[IdRelacionJugadorEquipo] [int] IDENTITY(1,1) NOT NULL,
	[IdJugador] [int] NOT NULL,
	[IdEquipo] [int] NOT NULL,
 CONSTRAINT [PK_Jugador_Equipo] PRIMARY KEY CLUSTERED 
(
	[IdRelacionJugadorEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblArbitros]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblArbitros](
	[IdArbitro] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[CostoArbitraje] [decimal](18, 2) NOT NULL,
	[Categoria] [int] NOT NULL,
	[TipoArbitro] [int] NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblArbitro] PRIMARY KEY CLUSTERED 
(
	[IdArbitro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCanchas]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCanchas](
	[IdCancha] [int] IDENTITY(1,1) NOT NULL,
	[IdPlantel] [int] NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[TipoCancha] [varchar](50) NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblCanchas] PRIMARY KEY CLUSTERED 
(
	[IdCancha] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEmpleados]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmpleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdPlantel] [int] NOT NULL,
	[Calle] [varchar](100) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Colonia] [varchar](100) NOT NULL,
	[CodigoPostal] [varchar](5) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[Curp] [varchar](18) NOT NULL,
	[TipoEmpleado] [int] NOT NULL,
	[Rfc] [varchar](13) NOT NULL,
	[Nss] [varchar](11) NOT NULL,
	[Salario] [decimal](18, 2) NOT NULL,
	[Horario] [varchar](50) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEquipos]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEquipos](
	[IdEquipo] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Categoria] [int] NOT NULL,
	[AnioFundacion] [varchar](4) NOT NULL,
	[Zona] [varchar](100) NOT NULL,
	[ColorVisitante] [varchar](100) NOT NULL,
	[ColorLocal] [varchar](100) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblEquipo] PRIMARY KEY CLUSTERED 
(
	[IdEquipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPartidos]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPartidos](
	[IdPartido] [int] IDENTITY(1,1) NOT NULL,
	[IdCancha] [int] NOT NULL,
	[IdTemporada] [int] NULL,
	[Jornada] [int] NULL,
	[Dia] [varchar](10) NOT NULL,
	[Hora] [varchar](5) NOT NULL,
	[Equipo1] [int] NOT NULL,
	[Equipo2] [int] NOT NULL,
	[GolesEquipo1] [int] NULL,
	[GolesEquipo2] [int] NULL,
	[Ganador] [int] NULL,
	[Perdedor] [int] NULL,
	[IdArbitro] [int] NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblPartidos] PRIMARY KEY CLUSTERED 
(
	[IdPartido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPlanteles]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPlanteles](
	[IdPlantel] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Calle] [varchar](100) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Colonia] [varchar](100) NOT NULL,
	[CodigoPostal] [varchar](5) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblPlanteles] PRIMARY KEY CLUSTERED 
(
	[IdPlantel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProveedores]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProveedores](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Rfc] [varchar](13) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[Calle] [varchar](100) NOT NULL,
	[Numero] [varchar](50) NOT NULL,
	[Colonia] [varchar](100) NOT NULL,
	[CodigoPostal] [varchar](5) NOT NULL,
	[Ciudad] [varchar](100) NOT NULL,
	[Estado] [varchar](100) NOT NULL,
	[TipoProveedor] [int] NOT NULL,
	[Correo] [varchar](100) NOT NULL,
	[Telefono] [varchar](10) NOT NULL,
	[IdPlantel] [int] NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblProveedor] PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTemporadas]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTemporadas](
	[IdTemporada] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaInicio] [date] NOT NULL,
	[FechaFin] [date] NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblTemporadas] PRIMARY KEY CLUSTERED 
(
	[IdTemporada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jugadores_Equipos]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Equipo_tblEquipo] FOREIGN KEY([IdEquipo])
REFERENCES [dbo].[tblEquipos] ([IdEquipo])
GO
ALTER TABLE [dbo].[Jugadores_Equipos] CHECK CONSTRAINT [FK_Jugador_Equipo_tblEquipo]
GO
ALTER TABLE [dbo].[Jugadores_Equipos]  WITH CHECK ADD  CONSTRAINT [FK_Jugador_Equipo_tblJugador] FOREIGN KEY([IdJugador])
REFERENCES [dbo].[tblJugadores] ([IdJugador])
GO
ALTER TABLE [dbo].[Jugadores_Equipos] CHECK CONSTRAINT [FK_Jugador_Equipo_tblJugador]
GO
ALTER TABLE [dbo].[tblArbitros]  WITH CHECK ADD  CONSTRAINT [FK_tblArbitro_ctgCategoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[ctgCategorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tblArbitros] CHECK CONSTRAINT [FK_tblArbitro_ctgCategoria]
GO
ALTER TABLE [dbo].[tblArbitros]  WITH CHECK ADD  CONSTRAINT [FK_tblArbitro_ctgTipoArbitro] FOREIGN KEY([TipoArbitro])
REFERENCES [dbo].[ctgTipoArbitros] ([IdTipoArbitro])
GO
ALTER TABLE [dbo].[tblArbitros] CHECK CONSTRAINT [FK_tblArbitro_ctgTipoArbitro]
GO
ALTER TABLE [dbo].[tblArbitros]  WITH CHECK ADD  CONSTRAINT [FK_tblArbitro_tblPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[tblPersonas] ([IdPersona])
GO
ALTER TABLE [dbo].[tblArbitros] CHECK CONSTRAINT [FK_tblArbitro_tblPersona]
GO
ALTER TABLE [dbo].[tblCanchas]  WITH CHECK ADD  CONSTRAINT [FK_tblCanchas_tblPlanteles] FOREIGN KEY([IdPlantel])
REFERENCES [dbo].[tblPlanteles] ([IdPlantel])
GO
ALTER TABLE [dbo].[tblCanchas] CHECK CONSTRAINT [FK_tblCanchas_tblPlanteles]
GO
ALTER TABLE [dbo].[tblEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpleado_ctgTipoEmpleado] FOREIGN KEY([TipoEmpleado])
REFERENCES [dbo].[ctgTipoEmpleados] ([IdTipoEmpleado])
GO
ALTER TABLE [dbo].[tblEmpleados] CHECK CONSTRAINT [FK_tblEmpleado_ctgTipoEmpleado]
GO
ALTER TABLE [dbo].[tblEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpleado_tblPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[tblPersonas] ([IdPersona])
GO
ALTER TABLE [dbo].[tblEmpleados] CHECK CONSTRAINT [FK_tblEmpleado_tblPersona]
GO
ALTER TABLE [dbo].[tblEmpleados]  WITH CHECK ADD  CONSTRAINT [FK_tblEmpleados_tblPlanteles] FOREIGN KEY([IdPlantel])
REFERENCES [dbo].[tblPlanteles] ([IdPlantel])
GO
ALTER TABLE [dbo].[tblEmpleados] CHECK CONSTRAINT [FK_tblEmpleados_tblPlanteles]
GO
ALTER TABLE [dbo].[tblEquipos]  WITH CHECK ADD  CONSTRAINT [FK_tblEquipo_ctgCategoria] FOREIGN KEY([Categoria])
REFERENCES [dbo].[ctgCategorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[tblEquipos] CHECK CONSTRAINT [FK_tblEquipo_ctgCategoria]
GO
ALTER TABLE [dbo].[tblJugadores]  WITH CHECK ADD  CONSTRAINT [FK_tblJugador_tblPersona] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[tblPersonas] ([IdPersona])
GO
ALTER TABLE [dbo].[tblJugadores] CHECK CONSTRAINT [FK_tblJugador_tblPersona]
GO
ALTER TABLE [dbo].[tblPartidos]  WITH CHECK ADD  CONSTRAINT [FK_tblPartidos_tblArbitros] FOREIGN KEY([IdArbitro])
REFERENCES [dbo].[tblArbitros] ([IdArbitro])
GO
ALTER TABLE [dbo].[tblPartidos] CHECK CONSTRAINT [FK_tblPartidos_tblArbitros]
GO
ALTER TABLE [dbo].[tblPartidos]  WITH CHECK ADD  CONSTRAINT [FK_tblPartidos_tblCanchas] FOREIGN KEY([IdCancha])
REFERENCES [dbo].[tblCanchas] ([IdCancha])
GO
ALTER TABLE [dbo].[tblPartidos] CHECK CONSTRAINT [FK_tblPartidos_tblCanchas]
GO
ALTER TABLE [dbo].[tblPartidos]  WITH CHECK ADD  CONSTRAINT [FK_tblPartidos_tblEquipos] FOREIGN KEY([Equipo1])
REFERENCES [dbo].[tblEquipos] ([IdEquipo])
GO
ALTER TABLE [dbo].[tblPartidos] CHECK CONSTRAINT [FK_tblPartidos_tblEquipos]
GO
ALTER TABLE [dbo].[tblPartidos]  WITH CHECK ADD  CONSTRAINT [FK_tblPartidos_tblEquipos1] FOREIGN KEY([Equipo2])
REFERENCES [dbo].[tblEquipos] ([IdEquipo])
GO
ALTER TABLE [dbo].[tblPartidos] CHECK CONSTRAINT [FK_tblPartidos_tblEquipos1]
GO
ALTER TABLE [dbo].[tblPartidos]  WITH CHECK ADD  CONSTRAINT [FK_tblPartidos_tblTemporadas] FOREIGN KEY([IdTemporada])
REFERENCES [dbo].[tblTemporadas] ([IdTemporada])
GO
ALTER TABLE [dbo].[tblPartidos] CHECK CONSTRAINT [FK_tblPartidos_tblTemporadas]
GO
ALTER TABLE [dbo].[tblProveedores]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedor_ctgTipoProveedor] FOREIGN KEY([TipoProveedor])
REFERENCES [dbo].[ctgTipoProveedores] ([IdTipoProveedor])
GO
ALTER TABLE [dbo].[tblProveedores] CHECK CONSTRAINT [FK_tblProveedor_ctgTipoProveedor]
GO
ALTER TABLE [dbo].[tblProveedores]  WITH CHECK ADD  CONSTRAINT [FK_tblProveedores_tblPlanteles] FOREIGN KEY([IdPlantel])
REFERENCES [dbo].[tblPlanteles] ([IdPlantel])
GO
ALTER TABLE [dbo].[tblProveedores] CHECK CONSTRAINT [FK_tblProveedores_tblPlanteles]
GO

/****** Object:  View [dbo].[viewJugadores]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewJugadores]
AS
SELECT        dbo.tblPersonas.Nombre, dbo.tblPersonas.PrimerApellido, dbo.tblPersonas.SegundoApellido, dbo.tblPersonas.FechaNacimiento, dbo.tblPersonas.Sexo, dbo.tblPersonas.Telefono, dbo.tblPersonas.Telefono2, 
                         dbo.tblPersonas.Correo, dbo.tblJugadores.IdJugador, dbo.tblJugadores.IdPersona, dbo.tblJugadores.NumDorsal, dbo.tblJugadores.SobreNombre, dbo.tblJugadores.Posicion, dbo.tblJugadores.Capitan, 
                         dbo.tblJugadores.Estatus, dbo.tblEquipos.IdEquipo, dbo.tblEquipos.Nombre AS NombreEquipo
FROM            dbo.tblJugadores INNER JOIN
                         dbo.tblPersonas ON dbo.tblJugadores.IdPersona = dbo.tblPersonas.IdPersona
						 LEFT JOIN
                         dbo.Jugadores_Equipos ON dbo.tblJugadores.IdJugador = dbo.Jugadores_Equipos.IdJugador
						 LEFT JOIN
						 dbo.tblEquipos ON dbo.tblEquipos.IdEquipo = dbo.Jugadores_Equipos.IdEquipo
GO

/****** Object:  StoredProcedure [dbo].[tblJugadoresAgregar]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Daniel Garcia Correa
-- Create date: 29/10/2022
-- Description:	Procedimiento almacenado para guardar a un jugador
-- =============================================
CREATE PROCEDURE [dbo].[tblJugadoresAgregar] 
	-- Datos de la persona
	@Nombre varchar(80),
	@PrimerApellido	varchar(80),
	@SegundoApellido varchar(80),
	@FechaNacimiento varchar(10),
	@Sexo varchar(30),
	@Telefono varchar(10),
	@Telefono2 varchar(10),
	@Correo varchar(100),

	-- Datos del jugador
	@NumDorsal varchar(3),
	@SobreNombre varchar(100),
	@Posicion varchar(100),
	@Capitan int,
	@IdEquipo int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID_PERSONA INT;
	DECLARE @ID_JUGADOR INT;

    -- Registramos primero a la persona
	INSERT INTO tblPersonas (Nombre, PrimerApellido,SegundoApellido, FechaNacimiento, Sexo,Telefono, Telefono2, Correo)
		VALUES (@Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Sexo, @Telefono, @Telefono2, @Correo);

	SET @ID_PERSONA = (SELECT SCOPE_IDENTITY());

	INSERT INTO tblJugadores (NumDorsal, SobreNombre, Posicion, Capitan, IdPersona, Estatus)
		VALUES (@NumDorsal, @SobreNombre, @Posicion, @Capitan, @ID_PERSONA, 1);
	
	SET @ID_JUGADOR = (SELECT SCOPE_IDENTITY());

	INSERT INTO Jugadores_Equipos(IdJugador, IdEquipo) VALUES(@ID_JUGADOR, @IdEquipo)

END
GO
/****** Object:  StoredProcedure [dbo].[tblJugadoresEliminar]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[tblJugadoresEliminar]
	@IdJugador int,
	@Eliminar int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if (@Eliminar = 1)
		UPDATE tblJugadores SET Estatus = 0 WHERE IdJugador = @IdJugador;
	else
		UPDATE tblJugadores SET Estatus = 1 WHERE IdJugador = @IdJugador;
END
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[tblJugadoresActivar]
	@IdJugador int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE tblJugadores SET Estatus = 1 WHERE IdJugador = @IdJugador;
END
GO

/****** Object:  StoredProcedure [dbo].[tblJugadoresModificar]    Script Date: 30/10/2022 09:26:09 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Daniel Garcia Correa
-- Create date: 29/10/2022
-- Description:	Procedimiento almacenado para guardar a un jugador
-- =============================================
CREATE PROCEDURE [dbo].[tblJugadoresModificar]
	-- Datos de la persona
	@IdPersona int,
	@Nombre varchar(80),
	@PrimerApellido	varchar(80),
	@SegundoApellido varchar(80),
	@FechaNacimiento varchar(10),
	@Sexo varchar(30),
	@Telefono varchar(10),
	@Telefono2 varchar(10),
	@Correo varchar(100),

	-- Datos del jugador
	@IdJugador int,
	@NumDorsal varchar(3),
	@SobreNombre varchar(100),
	@Posicion varchar(100),
	@Capitan int,
	@IdEquipo int
AS
BEGIN
	SET NOCOUNT ON;

    -- Modificamos los datos de la persona
	UPDATE tblPersonas SET 
		Nombre = @Nombre, 
		PrimerApellido = @PrimerApellido, 
		SegundoApellido = @SegundoApellido,
		FechaNacimiento = @FechaNacimiento,
		Sexo = @Sexo,
		Telefono = @Telefono,
		Telefono2 = @Telefono2,
		Correo = @Correo
		WHERE IdPersona = @IdPersona;

	-- Modificamos los datos del jugador
	UPDATE tblJugadores SET
		NumDorsal = @NumDorsal,
		SobreNombre = @SobreNombre,
		Posicion = @Posicion,
		Capitan = @Capitan
		WHERE IdJugador = @IdJugador;

	UPDATE Jugadores_Equipos SET
		IdEquipo = @IdEquipo
		WHERE IdJugador = @IdJugador;
END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblJugadores"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPersonas"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 428
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewJugadores'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewJugadores'
GO
