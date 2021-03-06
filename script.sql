USE [master]
GO
/****** Object:  Database [DbBodegaMonchito]    Script Date: 2/02/2022 23:10:17 ******/
CREATE DATABASE [DbBodegaMonchito]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DbBodegaMonchito', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DbBodegaMonchito.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DbBodegaMonchito_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DbBodegaMonchito_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DbBodegaMonchito] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DbBodegaMonchito].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DbBodegaMonchito] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET ARITHABORT OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DbBodegaMonchito] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DbBodegaMonchito] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DbBodegaMonchito] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DbBodegaMonchito] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET RECOVERY FULL 
GO
ALTER DATABASE [DbBodegaMonchito] SET  MULTI_USER 
GO
ALTER DATABASE [DbBodegaMonchito] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DbBodegaMonchito] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DbBodegaMonchito] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DbBodegaMonchito] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DbBodegaMonchito] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DbBodegaMonchito] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DbBodegaMonchito', N'ON'
GO
ALTER DATABASE [DbBodegaMonchito] SET QUERY_STORE = OFF
GO
USE [DbBodegaMonchito]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellidos] [varchar](60) NOT NULL,
	[Sexo] [varchar](1) NULL,
	[FechaNacimiento] [date] NULL,
	[TipoDocumento] [varchar](20) NOT NULL,
	[NumDocumento] [varchar](8) NOT NULL,
	[Direccion] [varchar](100) NULL,
	[Telefono] [varchar](9) NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleIngreso]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleIngreso](
	[IdDetalleIngreso] [int] IDENTITY(1,1) NOT NULL,
	[PrecioCompra] [money] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
	[StockInicial] [int] NOT NULL,
	[StockActual] [int] NOT NULL,
	[FechaProduccion] [date] NOT NULL,
	[FechaVencimiento] [date] NOT NULL,
	[IdIngreso] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetalleVenta]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetalleVenta](
	[IdDetalleVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdDetalleIngreso] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
	[Descuento] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDetalleVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[IdEmpleado] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](30) NOT NULL,
	[Apellidos] [varchar](60) NOT NULL,
	[Sexo] [varchar](1) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[NumDocumento] [varchar](8) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](9) NOT NULL,
	[Email] [varchar](50) NULL,
	[Acceso] [varchar](20) NOT NULL,
	[Usuario] [varchar](20) NOT NULL,
	[Contraseña] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingreso]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingreso](
	[IdIngreso] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [date] NOT NULL,
	[TipoComprobante] [varchar](20) NOT NULL,
	[Serie] [varchar](4) NOT NULL,
	[Correlativo] [varchar](7) NOT NULL,
	[Igv] [decimal](4, 2) NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[IdProveedor] [int] NOT NULL,
	[Estado] [varchar](7) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdIngreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentacion]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentacion](
	[IdPresentacion] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdPresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](1000) NULL,
	[Imagen] [image] NULL,
	[IdCategoria] [int] NOT NULL,
	[IdPresentacion] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IdProveedor] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [varchar](50) NOT NULL,
	[SectorComercial] [varchar](50) NOT NULL,
	[TipoDocumento] [varchar](20) NOT NULL,
	[NumDocumento] [varchar](11) NOT NULL,
	[Direccion] [varchar](100) NOT NULL,
	[Telefono] [varchar](9) NOT NULL,
	[Email] [varchar](50) NULL,
	[PaginaWeb] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[IdVenta] [int] IDENTITY(1,1) NOT NULL,
	[IdCliente] [int] NOT NULL,
	[IdEmpleado] [int] NOT NULL,
	[Fecha] [date] NOT NULL,
	[TipoComprobante] [varchar](20) NULL,
	[Serie] [varchar](4) NOT NULL,
	[Correlativo] [varchar](7) NOT NULL,
	[Igv] [decimal](4, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IdVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DetalleIngreso]  WITH CHECK ADD  CONSTRAINT [fk_IdIngreso] FOREIGN KEY([IdIngreso])
REFERENCES [dbo].[Ingreso] ([IdIngreso])
GO
ALTER TABLE [dbo].[DetalleIngreso] CHECK CONSTRAINT [fk_IdIngreso]
GO
ALTER TABLE [dbo].[DetalleIngreso]  WITH CHECK ADD  CONSTRAINT [fk_IdProducto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([IdProducto])
GO
ALTER TABLE [dbo].[DetalleIngreso] CHECK CONSTRAINT [fk_IdProducto]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [fk_IdDetalleIngreso] FOREIGN KEY([IdDetalleIngreso])
REFERENCES [dbo].[DetalleIngreso] ([IdDetalleIngreso])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [fk_IdDetalleIngreso]
GO
ALTER TABLE [dbo].[DetalleVenta]  WITH CHECK ADD  CONSTRAINT [fk_IdVenta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([IdVenta])
GO
ALTER TABLE [dbo].[DetalleVenta] CHECK CONSTRAINT [fk_IdVenta]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [fk_IdEmpleado] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [fk_IdEmpleado]
GO
ALTER TABLE [dbo].[Ingreso]  WITH CHECK ADD  CONSTRAINT [fk_IdProveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([IdProveedor])
GO
ALTER TABLE [dbo].[Ingreso] CHECK CONSTRAINT [fk_IdProveedor]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [fk_IdCategoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([IdCategoria])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [fk_IdCategoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [fk_IdPresentacion] FOREIGN KEY([IdPresentacion])
REFERENCES [dbo].[Presentacion] ([IdPresentacion])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [fk_IdPresentacion]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [fk_IdCliente] FOREIGN KEY([IdCliente])
REFERENCES [dbo].[Cliente] ([IdCliente])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [fk_IdCliente]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [fk_IdEmpleadoV] FOREIGN KEY([IdEmpleado])
REFERENCES [dbo].[Empleado] ([IdEmpleado])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [fk_IdEmpleadoV]
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarCategoria]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar por nombre
Create proc [dbo].[sp_BuscarCategoria]
@TextoBuscar varchar(50)
as
Select * from Categoria
where Nombre like @TextoBuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarPresentacionxNombre]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar por nombre
Create proc [dbo].[sp_BuscarPresentacionxNombre]
@TextoBuscar varchar(50)
as
Select * from Presentacion
where Nombre like @TextoBuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarProductoxNombre]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar por nombre
Create proc [dbo].[sp_BuscarProductoxNombre]
@TextoBuscar varchar(50)
as
Select p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, p.Imagen, p.IdCategoria, 
c.Nombre Categoria, p.IdPresentacion, pres.Nombre Presentacion
from Producto p inner join Categoria c on p.IdCategoria = c.IdCategoria
inner join Presentacion pres on p.IdPresentacion = pres.IdPresentacion
where p.Nombre like @TextoBuscar + '%'
order by p.IdProducto desc
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarProveedorxNumDocumento]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar por Numero de Documento
Create proc [dbo].[sp_BuscarProveedorxNumDocumento]
@TextoBuscar varchar(11)
as
Select * from Proveedor
where NumDocumento like @TextoBuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarProveedorxRazonSocial]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar por RazonSocial
Create proc [dbo].[sp_BuscarProveedorxRazonSocial]
@TextoBuscar varchar(50)
as
Select * from Proveedor
where RazonSocial like @TextoBuscar + '%'
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarCategoria]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Editar Categoria
Create proc [dbo].[sp_EditarCategoria]
@IdCategoria int,
@Nombre varchar(50),
@Descripcion varchar(200)
as
update Categoria set Nombre=@Nombre, Descripcion=@Descripcion
where IdCategoria = @IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarPresentacion]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Editar PRESENTACION
Create proc [dbo].[sp_EditarPresentacion]
@IdPresentacion int,
@Nombre varchar(50),
@Descripcion varchar(200)
as
update Presentacion set Nombre=@Nombre, Descripcion=@Descripcion
where IdPresentacion = @IdPresentacion
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProducto]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Editar PRODUCTO
Create proc [dbo].[sp_EditarProducto]
@IdProducto int,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(1000),
@Imagen image,
@IdCategoria int,
@IdPresentacion int
as
update Producto set Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, 
Imagen=@Imagen, IdCategoria=@IdCategoria, IdPresentacion=@IdPresentacion
where IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProveedor]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Editar PROVEEDOR
Create proc [dbo].[sp_EditarProveedor]
@IdProveedor int,
@RazonSocial varchar(50),
@SectorComercial varchar(50),
@TipoDocumento varchar(20),
@NumDocumento varchar(11),
@Direccion varchar(100),
@Telefono varchar(9),
@Email varchar(50),
@PaginaWeb varchar(100)
as
update Proveedor set RazonSocial=@RazonSocial, SectorComercial=@SectorComercial, TipoDocumento=@TipoDocumento, NumDocumento=@NumDocumento,
Direccion=@Direccion, Telefono=@Telefono, Email=@Email, PaginaWeb=@PaginaWeb
where IdProveedor = @IdProveedor
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarCategoria]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar Categoria
Create proc [dbo].[sp_EliminarCategoria]
@IdCategoria int
as
delete from Categoria
where IdCategoria = @IdCategoria
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarPresentacion]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar PRESENTACION
Create proc [dbo].[sp_EliminarPresentacion]
@IdPresentacion int
as
delete from Presentacion
where IdPresentacion = @IdPresentacion
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProducto]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar PRODUCTO
Create proc [dbo].[sp_EliminarProducto]
@IdProducto int
as
delete from Producto
where IdProducto = @IdProducto
GO
/****** Object:  StoredProcedure [dbo].[sp_EliminarProveedor]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Eliminar PROVEEDOR
Create proc [dbo].[sp_EliminarProveedor]
@IdProveedor int
as
delete from Proveedor
where IdProveedor = @IdProveedor
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarCategoria]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insertar Categoria
Create proc [dbo].[sp_InsertarCategoria]
@IdCategoria int output,
@Nombre varchar(50),
@Descripcion varchar(200)
as
insert into Categoria (Nombre, Descripcion)
Values (@Nombre, @Descripcion)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarPresentacion]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insertar PRESENTACION
Create proc [dbo].[sp_InsertarPresentacion]
@IdPresentacion int output,
@Nombre varchar(50),
@Descripcion varchar(200)
as
insert into Presentacion (Nombre, Descripcion)
Values (@Nombre, @Descripcion)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarProducto]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insertar PRODUCTO
Create proc [dbo].[sp_InsertarProducto]
@IdProducto int output,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(1000),
@Imagen image,
@IdCategoria int,
@IdPresentacion int
as
insert into Producto(Codigo, Nombre, Descripcion, Imagen, IdCategoria, IdPresentacion)
Values (@Codigo, @Nombre, @Descripcion, @Imagen, @IdCategoria, @IdPresentacion)
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertarProveedor]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Insertar PROVEEDOR
Create proc [dbo].[sp_InsertarProveedor]
@IdProveedor int output,
@RazonSocial varchar(50),
@SectorComercial varchar(50),
@TipoDocumento varchar(20),
@NumDocumento varchar(11),
@Direccion varchar(100),
@Telefono varchar(9),
@Email varchar(50),
@PaginaWeb varchar(100)
as
insert into Proveedor (RazonSocial , SectorComercial, TipoDocumento, NumDocumento, Direccion, Telefono, Email, PaginaWeb)
Values (@RazonSocial, @SectorComercial, @TipoDocumento, @NumDocumento, @Direccion, @Telefono, @Email, @PaginaWeb)
GO
/****** Object:  StoredProcedure [dbo].[sp_MostrarCategoria]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------------------------- PROCEDIMIENTOS ALMACENADOS DE LA TABLA CATEGORIA--------------------------------
-- Mostrar Categoria
Create proc [dbo].[sp_MostrarCategoria]
as
Select top 200 * from Categoria
order by IdCategoria desc
GO
/****** Object:  StoredProcedure [dbo].[sp_MostrarPresentacion]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 





-------------------------------- PROCEDIMIENTOS ALMACENADOS DE LA TABLA PRESENTACION--------------------------------
-- Mostrar PRESENTACION
Create proc [dbo].[sp_MostrarPresentacion]
as
Select top 200 * from Presentacion
order by IdPresentacion desc
GO
/****** Object:  StoredProcedure [dbo].[sp_MostrarProducto]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-------------------------------- PROCEDIMIENTOS ALMACENADOS DE LA TABLA PRODUCTO--------------------------------
-- Mostrar PRODUCTO
Create proc [dbo].[sp_MostrarProducto]
as
Select p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, p.Imagen, p.IdCategoria, 
c.Nombre Categoria, p.IdPresentacion, pres.Nombre Presentacion
from Producto p inner join Categoria c on p.IdCategoria = c.IdCategoria
inner join Presentacion pres on p.IdPresentacion = pres.IdPresentacion
order by p.IdProducto desc
GO
/****** Object:  StoredProcedure [dbo].[sp_MostrarProveedor]    Script Date: 2/02/2022 23:10:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






-------------------------------- PROCEDIMIENTOS ALMACENADOS DE LA TABLA PROVEEDOR--------------------------------
-- Mostrar PROVEEDOR
Create proc [dbo].[sp_MostrarProveedor]
as
Select top 200 * from Proveedor
order by RazonSocial desc
GO
USE [master]
GO
ALTER DATABASE [DbBodegaMonchito] SET  READ_WRITE 
GO
