USE [master]
GO
/****** Object:  Database [academia]    Script Date: 31/10/2016 23:26:45 ******/
CREATE DATABASE [academia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'academia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\academia.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'academia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\academia_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [academia] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [academia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [academia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [academia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [academia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [academia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [academia] SET ARITHABORT OFF 
GO
ALTER DATABASE [academia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [academia] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [academia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [academia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [academia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [academia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [academia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [academia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [academia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [academia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [academia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [academia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [academia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [academia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [academia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [academia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [academia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [academia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [academia] SET RECOVERY FULL 
GO
ALTER DATABASE [academia] SET  MULTI_USER 
GO
ALTER DATABASE [academia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [academia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [academia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [academia] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [academia]
GO
/****** Object:  Table [dbo].[apoderado]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[apoderado](
	[apo_dni] [char](8) NOT NULL,
	[apo_apellidos] [nvarchar](50) NULL,
	[apo_nombres] [nvarchar](50) NULL,
	[apo_celular] [nchar](9) NULL,
	[estado] [char](1) NULL,
 CONSTRAINT [PK_apoderado] PRIMARY KEY CLUSTERED 
(
	[apo_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[asistencia]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[asistencia](
	[asi_codigo] [int] IDENTITY(1,1) NOT NULL,
	[asi_hora_marcada] [time](7) NOT NULL,
	[asi_retraso] [time](7) NOT NULL,
	[asi_fecha] [date] NOT NULL,
	[asi_tipo] [nvarchar](7) NOT NULL,
	[asi_falta] [char](1) NULL,
	[estado] [char](1) NOT NULL,
	[mat_codigo] [char](10) NOT NULL,
	[tur_codigo] [int] NOT NULL,
 CONSTRAINT [PK_asistencia] PRIMARY KEY CLUSTERED 
(
	[asi_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ciclo]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ciclo](
	[cic_codigo] [int] IDENTITY(1,1) NOT NULL,
	[cic_nombre] [nvarchar](20) NULL,
	[cic_inicio] [date] NOT NULL,
	[cic_fin] [date] NOT NULL,
	[cic_costo_prim] [float] NOT NULL,
	[cic_costo_sec_a] [float] NOT NULL,
	[cic_costo_sec_b] [float] NOT NULL,
	[cic_costo_pre] [float] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_ciclo] PRIMARY KEY CLUSTERED 
(
	[cic_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[colegio]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[colegio](
	[col_id] [int] IDENTITY(1,1) NOT NULL,
	[col_nombre] [nvarchar](50) NOT NULL,
	[col_direccion] [nvarchar](50) NULL,
	[col_distrito] [nvarchar](50) NULL,
	[col_provincia] [nvarchar](50) NULL,
	[col_departamento] [nvarchar](50) NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_colegio] PRIMARY KEY CLUSTERED 
(
	[col_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[estudiante]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[estudiante](
	[est_dni] [char](8) NOT NULL,
	[est_apellidos] [nvarchar](50) NOT NULL,
	[est_nombres] [nvarchar](50) NOT NULL,
	[est_sexo] [nchar](15) NOT NULL,
	[est_edad] [int] NULL,
	[est_nacimiento] [date] NULL,
	[est_celular] [nchar](9) NULL,
	[est_direccion] [nvarchar](50) NULL,
	[est_foto] [image] NULL,
	[est_excelencia] [char](1) NULL,
	[est_otro] [nvarchar](20) NULL,
	[estado] [char](1) NOT NULL,
	[apo_dni] [char](8) NOT NULL,
	[col_id] [int] NOT NULL,
 CONSTRAINT [PK_estudiante] PRIMARY KEY CLUSTERED 
(
	[est_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[examen]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[examen](
	[exa_codigo] [nvarchar](8) NOT NULL,
	[exa_fecha] [date] NULL,
	[exa_nivel] [nvarchar](20) NOT NULL,
	[exa_num_preguntas] [int] NOT NULL,
	[exa_rpta_correcta] [float] NOT NULL,
	[exa_rpta_erronea] [float] NOT NULL,
	[estado] [char](1) NOT NULL,
 CONSTRAINT [PK_examen] PRIMARY KEY CLUSTERED 
(
	[exa_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[matricula]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[matricula](
	[mat_codigo] [char](10) NOT NULL,
	[mat_nivel] [nvarchar](20) NOT NULL,
	[mat_grado] [int] NULL,
	[mat_costo] [float] NOT NULL,
	[mat_deuda] [float] NOT NULL,
	[mat_tipo_descuento] [nvarchar](15) NOT NULL,
	[mat_descuento] [float] NOT NULL,
	[estado] [char](1) NOT NULL,
	[est_dni] [char](8) NOT NULL,
	[cic_codigo] [int] NOT NULL,
 CONSTRAINT [PK_matricula] PRIMARY KEY CLUSTERED 
(
	[mat_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[nota]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[nota](
	[not_codigo] [int] IDENTITY(1,1) NOT NULL,
	[not_num_rpta_correctas] [int] NOT NULL,
	[not_num_rpta_erroneas] [int] NOT NULL,
	[not_num_rpta_blancas] [int] NOT NULL,
	[not_puntaje] [float] NOT NULL,
	[estado] [char](1) NOT NULL,
	[exa_codigo] [nvarchar](8) NOT NULL,
	[mat_codigo] [char](10) NOT NULL,
 CONSTRAINT [PK_nota] PRIMARY KEY CLUSTERED 
(
	[not_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pago]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pago](
	[pag_codigo] [char](12) NOT NULL,
	[pag_fecha] [date] NOT NULL,
	[pag_monto] [float] NOT NULL,
	[estado] [char](1) NOT NULL,
	[mat_codigo] [char](10) NOT NULL,
 CONSTRAINT [PK_pago] PRIMARY KEY CLUSTERED 
(
	[pag_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[turno]    Script Date: 31/10/2016 23:26:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[turno](
	[tur_codigo] [int] IDENTITY(1,1) NOT NULL,
	[tur_nombre] [nvarchar](20) NOT NULL,
	[tur_entrada] [time](7) NOT NULL,
	[tur_salida] [time](7) NOT NULL,
	[tur_nivel] [nvarchar](20) NOT NULL,
	[estado] [char](1) NOT NULL,
	[cic_codigo] [int] NOT NULL,
 CONSTRAINT [PK_turno] PRIMARY KEY CLUSTERED 
(
	[tur_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[asistencia]  WITH CHECK ADD  CONSTRAINT [FK_asistencia_matricula] FOREIGN KEY([mat_codigo])
REFERENCES [dbo].[matricula] ([mat_codigo])
GO
ALTER TABLE [dbo].[asistencia] CHECK CONSTRAINT [FK_asistencia_matricula]
GO
ALTER TABLE [dbo].[asistencia]  WITH CHECK ADD  CONSTRAINT [FK_asistencia_turno] FOREIGN KEY([tur_codigo])
REFERENCES [dbo].[turno] ([tur_codigo])
GO
ALTER TABLE [dbo].[asistencia] CHECK CONSTRAINT [FK_asistencia_turno]
GO
ALTER TABLE [dbo].[estudiante]  WITH CHECK ADD  CONSTRAINT [FK_estudiante_apoderado] FOREIGN KEY([apo_dni])
REFERENCES [dbo].[apoderado] ([apo_dni])
GO
ALTER TABLE [dbo].[estudiante] CHECK CONSTRAINT [FK_estudiante_apoderado]
GO
ALTER TABLE [dbo].[estudiante]  WITH CHECK ADD  CONSTRAINT [FK_estudiante_colegio] FOREIGN KEY([col_id])
REFERENCES [dbo].[colegio] ([col_id])
GO
ALTER TABLE [dbo].[estudiante] CHECK CONSTRAINT [FK_estudiante_colegio]
GO
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_ciclo] FOREIGN KEY([cic_codigo])
REFERENCES [dbo].[ciclo] ([cic_codigo])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_ciclo]
GO
ALTER TABLE [dbo].[matricula]  WITH CHECK ADD  CONSTRAINT [FK_matricula_estudiante] FOREIGN KEY([est_dni])
REFERENCES [dbo].[estudiante] ([est_dni])
GO
ALTER TABLE [dbo].[matricula] CHECK CONSTRAINT [FK_matricula_estudiante]
GO
ALTER TABLE [dbo].[nota]  WITH CHECK ADD  CONSTRAINT [FK_nota_examen] FOREIGN KEY([exa_codigo])
REFERENCES [dbo].[examen] ([exa_codigo])
GO
ALTER TABLE [dbo].[nota] CHECK CONSTRAINT [FK_nota_examen]
GO
ALTER TABLE [dbo].[nota]  WITH CHECK ADD  CONSTRAINT [FK_nota_matricula] FOREIGN KEY([mat_codigo])
REFERENCES [dbo].[matricula] ([mat_codigo])
GO
ALTER TABLE [dbo].[nota] CHECK CONSTRAINT [FK_nota_matricula]
GO
ALTER TABLE [dbo].[pago]  WITH CHECK ADD  CONSTRAINT [FK_pago_matricula] FOREIGN KEY([mat_codigo])
REFERENCES [dbo].[matricula] ([mat_codigo])
GO
ALTER TABLE [dbo].[pago] CHECK CONSTRAINT [FK_pago_matricula]
GO
ALTER TABLE [dbo].[turno]  WITH CHECK ADD  CONSTRAINT [FK_turno_ciclo] FOREIGN KEY([cic_codigo])
REFERENCES [dbo].[ciclo] ([cic_codigo])
GO
ALTER TABLE [dbo].[turno] CHECK CONSTRAINT [FK_turno_ciclo]
GO
USE [master]
GO
ALTER DATABASE [academia] SET  READ_WRITE 
GO
