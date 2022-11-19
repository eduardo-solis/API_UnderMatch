USE [BDUnderMatch]
GO
/****** Object:  Table [dbo].[Empleados_Planteles]    Script Date: 18/11/2022 09:27:51 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados_Planteles](
	[IdRelacionEmpleadoPlantel] [int] IDENTITY(1,1) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdPlantel] [int] NOT NULL,
 CONSTRAINT [PK_Empleados_Planteles] PRIMARY KEY CLUSTERED 
(
	[IdRelacionEmpleadoPlantel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPersonas]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  Table [dbo].[tblEmpleados]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEmpleados](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
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
/****** Object:  Table [dbo].[tblPlanteles]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  View [dbo].[viewEmpleados]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewEmpleados]
AS
SELECT dbo.tblPersonas.Nombre, dbo.tblPersonas.PrimerApellido, dbo.tblPersonas.SegundoApellido, dbo.tblPersonas.FechaNacimiento, dbo.tblPersonas.Sexo, dbo.tblPersonas.Telefono, dbo.tblPersonas.Telefono2, dbo.tblPersonas.Correo, dbo.tblEmpleados.IdEmpleado, 
             dbo.tblEmpleados.IdPersona, dbo.tblEmpleados.Calle, dbo.tblEmpleados.Numero, dbo.tblEmpleados.Colonia, dbo.tblEmpleados.CodigoPostal, dbo.tblEmpleados.Ciudad, dbo.tblEmpleados.Estado, dbo.tblEmpleados.Curp, dbo.tblEmpleados.TipoEmpleado, dbo.tblEmpleados.Rfc, 
             dbo.tblEmpleados.Nss, dbo.tblEmpleados.Salario, dbo.tblEmpleados.Horario, dbo.tblEmpleados.Estatus, dbo.tblPlanteles.IdPlantel, dbo.tblPlanteles.Nombre AS NombrePlantel
FROM   dbo.Empleados_Planteles INNER JOIN
             dbo.tblEmpleados ON dbo.Empleados_Planteles.IdEmpleado = dbo.tblEmpleados.IdEmpleado INNER JOIN
             dbo.tblPersonas ON dbo.tblEmpleados.IdPersona = dbo.tblPersonas.IdPersona INNER JOIN
             dbo.tblPlanteles ON dbo.Empleados_Planteles.IdPlantel = dbo.tblPlanteles.IdPlantel
GO
/****** Object:  Table [dbo].[ctgCategorias]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgCategorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_ctgCategoria] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ctgTipoArbitros]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgTipoArbitros](
	[IdTipoArbitro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_ctgTipoArbitro] PRIMARY KEY CLUSTERED 
(
	[IdTipoArbitro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblArbitros]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  View [dbo].[viewArbitros]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[viewArbitros]
AS
SELECT        dbo.tblPersonas.Nombre, dbo.tblPersonas.PrimerApellido, dbo.tblPersonas.SegundoApellido, dbo.tblPersonas.IdPersona AS Expr2, dbo.tblPersonas.FechaNacimiento, dbo.tblPersonas.Sexo, dbo.tblPersonas.Telefono, 
                         dbo.tblPersonas.Correo, dbo.ctgCategorias.IdCategoria, dbo.ctgCategorias.Categoria AS Expr3, dbo.ctgTipoArbitros.IdTipoArbitro, dbo.ctgTipoArbitros.Nombre AS Expr1, dbo.tblArbitros.IdArbitro, dbo.tblArbitros.IdPersona, 
                         dbo.tblArbitros.CostoArbitraje, dbo.tblArbitros.Categoria, dbo.tblArbitros.TipoArbitro, dbo.tblArbitros.Estatus, dbo.tblPersonas.Telefono2
FROM            dbo.tblArbitros INNER JOIN
                         dbo.ctgTipoArbitros ON dbo.tblArbitros.TipoArbitro = dbo.ctgTipoArbitros.IdTipoArbitro INNER JOIN
                         dbo.ctgCategorias ON dbo.tblArbitros.Categoria = dbo.ctgCategorias.IdCategoria INNER JOIN
                         dbo.tblPersonas ON dbo.tblArbitros.IdPersona = dbo.tblPersonas.IdPersona
GO
/****** Object:  Table [dbo].[ctgTipoProveedores]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgTipoProveedores](
	[IdTipoProveedor] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_ctgTipoProveedor] PRIMARY KEY CLUSTERED 
(
	[IdTipoProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProveedores]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  View [dbo].[viewProveedores]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewProveedores] AS
SELECT dbo.tblProveedores.IdProveedor, dbo.tblProveedores.Rfc, dbo.tblProveedores.Nombre, dbo.tblProveedores.RazonSocial, dbo.tblProveedores.Calle, dbo.tblProveedores.Numero, dbo.tblProveedores.Colonia, dbo.tblProveedores.CodigoPostal, dbo.tblProveedores.Ciudad, 
             dbo.tblProveedores.Estado, dbo.tblProveedores.TipoProveedor, dbo.tblProveedores.Correo, dbo.tblProveedores.Telefono, dbo.tblProveedores.IdPlantel, dbo.tblProveedores.Estatus, dbo.ctgTipoProveedores.Nombre AS NombreTipoProveedor, 
             dbo.tblPlanteles.Nombre AS NombrePlantel
FROM   dbo.tblProveedores INNER JOIN
             dbo.ctgTipoProveedores ON dbo.tblProveedores.TipoProveedor = dbo.ctgTipoProveedores.IdTipoProveedor INNER JOIN
             dbo.tblPlanteles ON dbo.tblProveedores.IdPlantel = dbo.tblPlanteles.IdPlantel
GO
/****** Object:  Table [dbo].[tblJugadores]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  Table [dbo].[Jugadores_Equipos]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  Table [dbo].[tblEquipos]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  View [dbo].[viewJugadores]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  Table [dbo].[ctgTipoEmpleados]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ctgTipoEmpleados](
	[IdTipoEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_ctgTipoEmpleado] PRIMARY KEY CLUSTERED 
(
	[IdTipoEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCanchas]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  Table [dbo].[tblPartidos]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
/****** Object:  Table [dbo].[tblTemporadas]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTemporadas](
	[IdTemporada] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[FechaInicio] [varchar](10) NOT NULL,
	[FechaFin] [varchar](10) NOT NULL,
	[Estatus] [int] NULL,
 CONSTRAINT [PK_tblTemporadas] PRIMARY KEY CLUSTERED 
(
	[IdTemporada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Empleados_Planteles]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Planteles_Empleados_Planteles] FOREIGN KEY([IdPlantel])
REFERENCES [dbo].[tblPlanteles] ([IdPlantel])
GO
ALTER TABLE [dbo].[Empleados_Planteles] CHECK CONSTRAINT [FK_Empleados_Planteles_Empleados_Planteles]
GO
ALTER TABLE [dbo].[Empleados_Planteles]  WITH CHECK ADD  CONSTRAINT [FK_Empleados_Planteles_tblEmpleados] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[tblEmpleados] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Empleados_Planteles] CHECK CONSTRAINT [FK_Empleados_Planteles_tblEmpleados]
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
/****** Object:  StoredProcedure [dbo].[ctgCategoriasActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica una categoria
-- =============================================
CREATE PROCEDURE [dbo].[ctgCategoriasActivar]
	@IdCategoria int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE ctgCategorias SET Estatus = 1 WHERE IdCategoria = @IdCategoria;
END
GO
/****** Object:  StoredProcedure [dbo].[ctgCategoriasEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica una categoria
-- =============================================
CREATE PROCEDURE [dbo].[ctgCategoriasEliminar]
	@IdCategoria int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE ctgCategorias SET Estatus = 0 WHERE IdCategoria = @IdCategoria;
END
GO
/****** Object:  StoredProcedure [dbo].[ctgTipoArbitroActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica un tipo de arbitro
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoArbitroActivar]
	@IdTipoArbitro int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE ctgTipoArbitros SET Estatus = 1 WHERE IdTipoArbitro = @IdTipoArbitro;
END
GO
/****** Object:  StoredProcedure [dbo].[ctgTipoArbitroEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica un tipo de arbitro
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoArbitroEliminar]
	@IdTipoArbitro int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE ctgTipoArbitros SET Estatus = 0 WHERE IdTipoArbitro = @IdTipoArbitro;
END
GO
/****** Object:  StoredProcedure [dbo].[ctgTipoEmpleadoActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica un tipo de empleado
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoEmpleadoActivar]
	@IdTipoEmpleado int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE ctgTipoEmpleados SET Estatus = 1 WHERE IdTipoEmpleado = @IdTipoEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[ctgTipoEmpleadoEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica un tipo de empleado
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoEmpleadoEliminar]
	@IdTipoEmpleado int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE ctgTipoEmpleados SET Estatus = 0 WHERE IdTipoEmpleado = @IdTipoEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[ctgTipoProveedoresActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para activar un tipo de proveedor
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoProveedoresActivar] 
	@IdTipoProveedor int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ctgTipoProveedores SET Estatus = 1 WHERE IdTipoProveedor = @IdTipoProveedor;
END

GO
/****** Object:  StoredProcedure [dbo].[ctgTipoProveedoresAgregar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para guardar un tipo de proveedor
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoProveedoresAgregar] 
	@Nombre varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO ctgTipoProveedores(Nombre, Estatus) VALUES (@Nombre, 1)
END

GO
/****** Object:  StoredProcedure [dbo].[ctgTipoProveedoresEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para eliminar un tipo de proveedor
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoProveedoresEliminar] 
	@IdTipoProveedor int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ctgTipoProveedores SET Estatus = 0 WHERE IdTipoProveedor = @IdTipoProveedor;
END

GO
/****** Object:  StoredProcedure [dbo].[ctgTipoProveedoresModificar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para modificar un tipo de proveedor
-- =============================================
CREATE PROCEDURE [dbo].[ctgTipoProveedoresModificar] 
	@IdTipoProveedor int,
	@Nombre varchar(100)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE ctgTipoProveedores SET Nombre = @Nombre WHERE IdTipoProveedor = @IdTipoProveedor;
END

GO
/****** Object:  StoredProcedure [dbo].[tblArbitrosActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Jose Fernando Juarez Chavez
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para activar un arbitro
-- =============================================
CREATE PROCEDURE [dbo].[tblArbitrosActivar]
	@IdArbitro int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE tblArbitros SET Estatus = 1 WHERE IdArbitro = @IdArbitro;
END
GO
/****** Object:  StoredProcedure [dbo].[tblArbitrosAgregar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Jose Fernando Juarez Chavez
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para agregar un arbitro
-- =============================================
CREATE PROCEDURE [dbo].[tblArbitrosAgregar]
	-- Datos de la persona
	@Nombre varchar(80),
	@PrimerApellido	varchar(80),
	@SegundoApellido varchar(80),
	@FechaNacimiento varchar(10),
	@Sexo varchar(30),
	@Telefono varchar(10),
	@Telefono2 varchar(10),
	@Correo varchar(100),

	-- Datos del Arbitro
	@CostoArbitraje decimal(18,2),
	@Categoria int,
	@TipoArbitro int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @ID_PERSONA INT;
	DECLARE @ID_ARBITRO INT;

    -- Registramos primero a la persona
	INSERT INTO tblPersonas (Nombre, PrimerApellido,SegundoApellido, FechaNacimiento, Sexo,Telefono, Telefono2, Correo)
		VALUES (@Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Sexo, @Telefono, @Telefono2, @Correo);

	SET @ID_PERSONA = (SELECT SCOPE_IDENTITY());
	INSERT INTO tblArbitros (IdPersona,CostoArbitraje,Categoria,TipoArbitro,Estatus)
		VALUES (@ID_PERSONA,@CostoArbitraje,@Categoria,@TipoArbitro,1);

END
GO
/****** Object:  StoredProcedure [dbo].[tblArbitrosEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[tblArbitrosEliminar]
	@IdArbitro int,
	@Eliminar int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if (@Eliminar = 1)
		UPDATE tblArbitros SET Estatus = 0 WHERE IdArbitro = @IdArbitro;
	else
		UPDATE  tblArbitros SET Estatus = 1 WHERE IdArbitro = @IdArbitro;
END
GO
/****** Object:  StoredProcedure [dbo].[tblArbitrosModificar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Jose Fernando Juarez Chavez
-- Create date: 02/11/2022
-- Description:	Procedimiento almacenado para actualizar a un arbitro
-- =============================================
CREATE PROCEDURE [dbo].[tblArbitrosModificar]
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

	-- Datos del Arbitro
	@IdArbitro int,
	@CostoArbitraje decimal(18,2),
	@Categoria int,
	@TipoArbitro int
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

	-- Modificamos los datos del arbitro
	UPDATE tblArbitros SET
		CostoArbitraje = @CostoArbitraje,
		Categoria = @Categoria,
		TipoArbitro = @TipoArbitro
		WHERE IdArbitro = @IdArbitro;

END
GO
/****** Object:  StoredProcedure [dbo].[tblCanchaActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica una cancha
-- =============================================
CREATE PROCEDURE [dbo].[tblCanchaActivar]
	@IdCancha int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblCanchas SET Estatus = 1 WHERE IdCancha = @IdCancha;
END
GO
/****** Object:  StoredProcedure [dbo].[tblCanchaEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica una cancha
-- =============================================
CREATE PROCEDURE [dbo].[tblCanchaEliminar]
	@IdCancha int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblCanchas SET Estatus = 0 WHERE IdCancha = @IdCancha;
END
GO
/****** Object:  StoredProcedure [dbo].[tblEmpleadosActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abel Mendoza Vera
-- Create date: 31/10/2022
-- Description:	Procedimiento almacenado para eliminar a un empleado
-- =============================================
CREATE PROCEDURE [dbo].[tblEmpleadosActivar]
	@IdEmpleado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE tblEmpleados SET Estatus = 1 WHERE IdEmpleado = @IdEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[tblEmpleadosAgregar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abel Mendoza Vera
-- Create date: 31/10/2022
-- Description:	Procedimiento almacenado para guardar a un empleado
-- =============================================
CREATE PROCEDURE [dbo].[tblEmpleadosAgregar] 
	-- Datos de la persona
	@Nombre varchar(80),
	@PrimerApellido	varchar(80),
	@SegundoApellido varchar(80),
	@FechaNacimiento varchar(10),
	@Sexo varchar(30),
	@Telefono varchar(10),
	@Telefono2 varchar(10),
	@Correo varchar(100),

	-- Datos del empleado
	@CalleE varchar(100),
	@NumeroE varchar(50),
	@ColoniaE varchar(100),
	@CodigoPostalE varchar(5),
	@CiudadE varchar(100),
	@EstadoE varchar(100),
	@Curpe varchar(18),
	@TipoEmpleado int,
	@RfcE varchar(13),
	@NssE varchar(11),
	@SalarioE decimal (18,2),
	@HorarioE varchar(50)
	-- @IdPlantel int

AS
BEGIN
	SET NOCOUNT ON;

	
	DECLARE @ID_PERSONA INT;
	DECLARE @ID_EMPLEADO INT;


    -- Registramos primero a la persona
	INSERT INTO tblPersonas (Nombre, PrimerApellido,SegundoApellido, FechaNacimiento, Sexo,Telefono, Telefono2, Correo)
		VALUES (@Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Sexo, @Telefono, @Telefono2, @Correo);
	
	SET @ID_PERSONA = (SELECT SCOPE_IDENTITY());


	INSERT INTO tblEmpleados(Calle,Numero, Colonia, CodigoPostal,Ciudad,Estado,Curp,TipoEmpleado,Rfc,Nss,Salario,Horario, IdPersona, Estatus)
		VALUES (@CalleE, @NumeroE, @ColoniaE, @CodigoPostalE, @CiudadE, @EstadoE, @CurpE, @TipoEmpleado,@RfcE,@NssE,@SalarioE, @HorarioE, @ID_PERSONA, 1);
	
	SET @ID_EMPLEADO = (SELECT SCOPE_IDENTITY());

	-- INSERT INTO Empleados_Planteles(IdEmpleado, IdPlantel) VALUES(@ID_EMPLEADO, @IdPlantel)

END
GO
/****** Object:  StoredProcedure [dbo].[tblEmpleadosEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abel Mendoza Vera
-- Create date: 31/10/2022
-- Description:	Procedimiento almacenado para eliminar a un empleado
-- =============================================
CREATE PROCEDURE [dbo].[tblEmpleadosEliminar]
	@IdEmpleado int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    UPDATE tblEmpleados SET Estatus = 0 WHERE IdEmpleado = @IdEmpleado;
END
GO
/****** Object:  StoredProcedure [dbo].[tblEmpleadosModificar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abel Mendoza Vera
-- Create date: 31/10/2022
-- Description:	Procedimiento almacenado para Modificar a un empleado
-- =============================================
CREATE PROCEDURE [dbo].[tblEmpleadosModificar]
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

 	-- Datos del empleado
	@IdEmpleado int,
	@CalleE varchar(100),
	@NumeroE varchar(50),
	@ColoniaE varchar(100),
	@CodigoPostalE varchar(5),
	@CiudadE varchar(100),
	@EstadoE varchar(100),
	@Curpe varchar(18),
	@TipoEmpleado int,
	@RfcE varchar(13),
	@NssE varchar(11),
	@SalarioE decimal (18,2),
	@HorarioE varchar(50)
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

	
	-- Modificamos los datos del empleado
	UPDATE tblEmpleados SET
		Calle= @CalleE,
		Numero = @NumeroE,
		Colonia = @ColoniaE,
		CodigoPostal=@CodigoPostalE,
		Ciudad=@CiudadE,
		Estado=@EstadoE,
		Curp=@CurpE,
		TipoEmpleado=@TipoEmpleado,
		Rfc=@RfcE,
		Nss=@NssE,
		Salario=@SalarioE,
		Horario=@HorarioE
		WHERE IdEmpleado = @IdEmpleado;

END
GO
/****** Object:  StoredProcedure [dbo].[tblEquiposActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 02/11/2022
-- Description:	Se cambia el estatus del equipo para que este activo
-- =============================================
CREATE PROCEDURE [dbo].[tblEquiposActivar]
	@ID_EQUIPO int
AS
BEGIN
	
	SET NOCOUNT ON;

    UPDATE tblEquipos SET Estatus = 1 WHERE IdEquipo = @ID_EQUIPO;
END
GO
/****** Object:  StoredProcedure [dbo].[tblEquiposEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 02/11/2022
-- Description:	Se cambia el estatus del equipo y se eliminan las relaciones que
--				se tengan en la tabla intermedia Jugadores_Equipos
-- =============================================
CREATE PROCEDURE [dbo].[tblEquiposEliminar]
	@ID_EQUIPO int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE tblEquipos SET Estatus = 0 WHERE IdEquipo = @ID_EQUIPO;
	DELETE FROM Jugadores_Equipos WHERE IdEquipo = @ID_EQUIPO;
	
END
GO
/****** Object:  StoredProcedure [dbo].[tblJugadoresActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Daniel Garcia Correa
-- Create date: 29/10/2022
-- Description:	Procedimiento almacenado para cambiar a 1 el estatus de un jugador 
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
/****** Object:  StoredProcedure [dbo].[tblJugadoresAgregar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
	@Capitan int
	-- @IdEquipo int
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @ID_PERSONA INT;
	-- DECLARE @ID_JUGADOR INT;

    -- Registramos primero a la persona
	INSERT INTO tblPersonas (Nombre, PrimerApellido,SegundoApellido, FechaNacimiento, Sexo,Telefono, Telefono2, Correo)
		VALUES (@Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @Sexo, @Telefono, @Telefono2, @Correo);

	SET @ID_PERSONA = (SELECT SCOPE_IDENTITY());

	INSERT INTO tblJugadores (NumDorsal, SobreNombre, Posicion, Capitan, IdPersona, Estatus)
		VALUES (@NumDorsal, @SobreNombre, @Posicion, @Capitan, @ID_PERSONA, 1);
	
	-- SET @ID_JUGADOR = (SELECT SCOPE_IDENTITY());

	-- INSERT INTO Jugadores_Equipos(IdJugador, IdEquipo) VALUES(@ID_JUGADOR, @IdEquipo)

END
GO
/****** Object:  StoredProcedure [dbo].[tblJugadoresEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Carlos Daniel Garcia Correa
-- Create date: 29/10/2022
-- Description:	Procedimiento almacenado para cambiar a 0 el estatus de un jugador 
-- =============================================
CREATE PROCEDURE [dbo].[tblJugadoresEliminar]
	@IdJugador int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
		UPDATE tblJugadores SET Estatus = 0 WHERE IdJugador = @IdJugador;
END
GO
/****** Object:  StoredProcedure [dbo].[tblJugadoresModificar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
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
	@Capitan int
	-- @IdEquipo int
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

	-- UPDATE Jugadores_Equipos SET
	--	IdEquipo = @IdEquipo
	--	WHERE IdJugador = @IdJugador;
END
GO
/****** Object:  StoredProcedure [dbo].[tblPartidoActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica un partido
-- =============================================
CREATE PROCEDURE [dbo].[tblPartidoActivar]
	@IdPartido int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblPartidos SET Estatus = 1 WHERE IdPartido = @IdPartido;
END
GO
/****** Object:  StoredProcedure [dbo].[tblPartidoEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica un partido
-- =============================================
CREATE PROCEDURE [dbo].[tblPartidoEliminar]
	@IdPartido int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblPartidos SET Estatus = 0 WHERE IdPartido = @IdPartido;
END
GO
/****** Object:  StoredProcedure [dbo].[tblPlantelActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica un plantel
-- =============================================
CREATE PROCEDURE [dbo].[tblPlantelActivar]
	@IdPlantel int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblPlanteles SET Estatus = 1 WHERE IdPlantel = @IdPlantel;
END
GO
/****** Object:  StoredProcedure [dbo].[tblPlantelEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica un plantel
-- =============================================
CREATE PROCEDURE [dbo].[tblPlantelEliminar]
	@IdPlantel int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblPlanteles SET Estatus = 0 WHERE IdPlantel = @IdPlantel;
END
GO
/****** Object:  StoredProcedure [dbo].[tblProveedoresActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 03/11/2022
-- Description:	Procedimiento almacenado para activar un proveedor
-- =============================================
CREATE PROCEDURE [dbo].[tblProveedoresActivar] 
	@IdProveedor int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tblProveedores SET Estatus = 1 WHERE IdProveedor = @IdProveedor;
END

GO
/****** Object:  StoredProcedure [dbo].[tblProveedoresAgregar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 03/11/2022
-- Description:	Procedimiento almacenado para guardar un proveedor
-- =============================================
CREATE PROCEDURE [dbo].[tblProveedoresAgregar] 
	@Rfc varchar(13),
	@Nombre varchar(100),
	@RazonSocial varchar(50),
	@Calle varchar(100),
	@Numero varchar(50),
	@Colonia varchar(100),
	@CodigoPostal varchar(5),
	@Ciudad varchar(100),
	@Estado varchar(100),
	@IdTipoProveedor int,
	@Correo varchar(100),
	@Telefono varchar(10),
	@IdPlantel int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO tblProveedores(Rfc, Nombre, RazonSocial, Calle, Numero, Colonia, CodigoPostal, Ciudad, Estado, TipoProveedor, Correo, Telefono, IdPlantel,Estatus)
		VALUES (@Rfc, @Nombre, @RazonSocial, @Calle, @Numero, @Colonia, @CodigoPostal, @Ciudad, @Estado, @IdTipoProveedor, @Correo, @Telefono, @IdPlantel,1)
END

GO
/****** Object:  StoredProcedure [dbo].[tblProveedoresEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 03/11/2022
-- Description:	Procedimiento almacenado para eliminar un proveedor
-- =============================================
CREATE PROCEDURE [dbo].[tblProveedoresEliminar] 
	@IdProveedor int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tblProveedores SET Estatus = 0 WHERE IdProveedor = @IdProveedor;
END

GO
/****** Object:  StoredProcedure [dbo].[tblProveedoresModificar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Josué Israel Durán Alberto
-- Create date: 03/11/2022
-- Description:	Procedimiento almacenado para modificar un proveedor
-- =============================================
CREATE PROCEDURE [dbo].[tblProveedoresModificar] 
	@IdProveedor int,
	@Rfc varchar(13),
	@Nombre varchar(100),
	@RazonSocial varchar(50),
	@Calle varchar(100),
	@Numero varchar(50),
	@Colonia varchar(100),
	@CodigoPostal varchar(5),
	@Ciudad varchar(100),
	@Estado varchar(100),
	@IdTipoProveedor int,
	@Correo varchar(100),
	@Telefono varchar(10),
	@IdPlantel int
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE tblProveedores SET
		Rfc = @Rfc, 
		Nombre = @Nombre,
		RazonSocial = @RazonSocial,
		Calle = @Calle,
		Numero = @Numero,
		Colonia = @Colonia,
		CodigoPostal = @CodigoPostal,
		Ciudad = @Ciudad,
		Estado = @Estado,
		TipoProveedor = @IdTipoProveedor,
		Correo = @Correo,
		Telefono = @Telefono,
		IdPlantel = @IdPlantel
	WHERE IdProveedor = @IdProveedor;
END
GO
/****** Object:  StoredProcedure [dbo].[tblTemporadaActivar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para activar de manera logica una temporada
-- =============================================
CREATE PROCEDURE [dbo].[tblTemporadaActivar]
	@IdTemporada int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblTemporadas SET Estatus = 1 WHERE IdTemporada = @IdTemporada;
END
GO
/****** Object:  StoredProcedure [dbo].[tblTemporadaEliminar]    Script Date: 18/11/2022 09:27:52 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Eduardo Rubén Solís Hernández
-- Create date: 18/11/2022
-- Description:	Procedimiento almacenado para eliminar de manera logica una temporada
-- =============================================
CREATE PROCEDURE [dbo].[tblTemporadaEliminar]
	@IdTemporada int
AS
BEGIN
	
	SET NOCOUNT ON;
	UPDATE tblTemporadas SET Estatus = 0 WHERE IdTemporada = @IdTemporada;
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
         Begin Table = "tblArbitros"
            Begin Extent = 
               Top = 0
               Left = 65
               Bottom = 126
               Right = 235
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "ctgTipoArbitros"
            Begin Extent = 
               Top = 139
               Left = 185
               Bottom = 235
               Right = 355
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ctgCategorias"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 102
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPersonas"
            Begin Extent = 
               Top = 8
               Left = 723
               Bottom = 138
               Right = 905
            End
            DisplayFlags = 280
            TopColumn = 5
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
         Column = 2745
         Alias = 900
         Table = 3135
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewArbitros'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewArbitros'
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
         Begin Table = "Empleados_Planteles"
            Begin Extent = 
               Top = 0
               Left = 548
               Bottom = 170
               Right = 866
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblEmpleados"
            Begin Extent = 
               Top = 77
               Left = 40
               Bottom = 274
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblPersonas"
            Begin Extent = 
               Top = 21
               Left = 321
               Bottom = 218
               Right = 563
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "tblPlanteles"
            Begin Extent = 
               Top = 9
               Left = 1010
               Bottom = 206
               Right = 1232
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewEmpleados'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewEmpleados'
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
