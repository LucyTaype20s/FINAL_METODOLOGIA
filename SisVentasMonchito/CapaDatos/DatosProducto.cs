using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importar tipo de datos de sql server
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DatosProducto
    {

        //Declaracion de variables de los atributos de la tabla PRODUCTO
        private int _Idprodcuto;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private byte[] _Imagen;
        private int _Idcategoria;
        private int _Idpresentacion;

        //Variable para buscar dentro la tabala
        private string _TextoBuscar;

        //Metodos set y get
        public int Idprodcuto { get => _Idprodcuto; set => _Idprodcuto = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DatosProducto()
        {

        }


        //Constructor con parametros
        public DatosProducto(int idproducto, string codigo, string nombre, string descripcion,
                             byte[] imagen, int idcategoria, int idpresentacion, string textobuscar)
        {
            this.Idprodcuto = idproducto;
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Imagen = imagen;
            this.Idcategoria = idcategoria;
            this.Idpresentacion = idpresentacion;
            this.TextoBuscar = textobuscar;
        }


        //Metodo INSERTAR
        public string Insertar(DatosProducto Producto)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecemos la conexion
                SqlCon.ConnectionString = Conexion.Cn;

                // Abrimos la conexion con SqlServer
                SqlCon.Open();

                //Establecer comando para ejecutar sentencia en sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_InsertarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de PRODUCTO
                //IdProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@IdProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProducto);

                //Codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@Codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Producto.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1000;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Imagen
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@Imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Producto.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //IdCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@IdCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.VarChar;
                ParIdCategoria.Value = Producto.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                //IdPresentacion
                SqlParameter IdPresentacion = new SqlParameter();
                IdPresentacion.ParameterName = "@IdPresentacion";
                IdPresentacion.SqlDbType = SqlDbType.VarChar;
                IdPresentacion.Value = Producto.Idpresentacion;
                SqlCmd.Parameters.Add(IdPresentacion);



                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }

            //Cerramos la conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Respuesta;
        }


        //Metodo EDITAR
        public string Editar(DatosProducto Producto)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecemos la conexion
                SqlCon.ConnectionString = Conexion.Cn;

                // Abrimos la conexion con SqlServer
                SqlCon.Open();

                //Establecer comando para ejecutar sentencia en sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_EditarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Presentacion
                //IdProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@IdProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.Idprodcuto;
                SqlCmd.Parameters.Add(ParIdProducto);

                //Codigo
                SqlParameter ParCodigo = new SqlParameter();
                ParCodigo.ParameterName = "@Codigo";
                ParCodigo.SqlDbType = SqlDbType.VarChar;
                ParCodigo.Size = 50;
                ParCodigo.Value = Producto.Codigo;
                SqlCmd.Parameters.Add(ParCodigo);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Producto.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 1000;
                ParDescripcion.Value = Producto.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);

                //Imagen
                SqlParameter ParImagen = new SqlParameter();
                ParImagen.ParameterName = "@Imagen";
                ParImagen.SqlDbType = SqlDbType.Image;
                ParImagen.Value = Producto.Imagen;
                SqlCmd.Parameters.Add(ParImagen);

                //IdCategoria
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@IdCategoria";
                ParIdCategoria.SqlDbType = SqlDbType.VarChar;
                ParIdCategoria.Value = Producto.Idcategoria;
                SqlCmd.Parameters.Add(ParIdCategoria);

                //IdPresentacion
                SqlParameter IdPresentacion = new SqlParameter();
                IdPresentacion.ParameterName = "@IdPresentacion";
                IdPresentacion.SqlDbType = SqlDbType.VarChar;
                IdPresentacion.Value = Producto.Idpresentacion;
                SqlCmd.Parameters.Add(IdPresentacion);


                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se actualizo el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }

            //Cerramos la conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Respuesta;
        }


        //Metodo ELIMINAR
        public string Eliminar(DatosProducto Producto)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecemos la conexion
                SqlCon.ConnectionString = Conexion.Cn;

                // Abrimos la conexion con SqlServer
                SqlCon.Open();

                //Establecer comando para ejecutar sentencia en sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_EliminarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de PRODUCTO
                //IdProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@IdProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = Producto.Idprodcuto;
                SqlCmd.Parameters.Add(ParIdProducto);


                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se elimino el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }

            //Cerramos la conexion
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

            return Respuesta;
        }


        //Metodo MOSTRAR
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarProducto";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //Metodo BUSCARNOMBRE
        public DataTable BuscarNombre(DatosProducto Producto)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarProductoxNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Producto.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }



        //Metodo StockProductos
        public DataTable StockProductos()
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_StockProductos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

    }
}
