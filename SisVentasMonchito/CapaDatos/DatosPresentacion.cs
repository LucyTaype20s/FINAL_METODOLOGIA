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
    public class DatosPresentacion
    {

        //Declaracion de variables de los atributos de la tabla PRESENTACION
        private int _Idpresentacion;
        private string _Nombre;
        private string _Descripcion;

        //Variable para buscar dentro la tabala
        private string _TextoBuscar;

        //Metodos set y get
        public int Idpresentacion { get => _Idpresentacion; set => _Idpresentacion = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DatosPresentacion()
        {

        }

        //Constructor con parametros
        public DatosPresentacion(int idpresentacion, string nombre, string descripcion, string textobuscar)
        {
            this.Idpresentacion = idpresentacion;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TextoBuscar = textobuscar;
        }


        //Metodo INSERTAR
        public string Insertar(DatosPresentacion Presentacion)
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
                SqlCmd.CommandText = "sp_InsertarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Presentacion
                //IdPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@IdPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


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
        public string Editar(DatosPresentacion Presentacion)
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
                SqlCmd.CommandText = "sp_EditarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Presentacion
                //IdPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@IdPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Presentacion.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Descripcion
                SqlParameter ParDescripcion = new SqlParameter();
                ParDescripcion.ParameterName = "@Descripcion";
                ParDescripcion.SqlDbType = SqlDbType.VarChar;
                ParDescripcion.Size = 200;
                ParDescripcion.Value = Presentacion.Descripcion;
                SqlCmd.Parameters.Add(ParDescripcion);


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
        public string Eliminar(DatosPresentacion Presentacion)
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
                SqlCmd.CommandText = "sp_EliminarPresentacion";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de PRESENTACION
                //IdPresentacion
                SqlParameter ParIdPresentacion = new SqlParameter();
                ParIdPresentacion.ParameterName = "@IdPresentacion";
                ParIdPresentacion.SqlDbType = SqlDbType.Int;
                ParIdPresentacion.Value = Presentacion.Idpresentacion;
                SqlCmd.Parameters.Add(ParIdPresentacion);


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
            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarPresentacion";
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
        public DataTable BuscarNombre(DatosPresentacion Presentacion)
        {
            DataTable DtResultado = new DataTable("Presentacion");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarPresentacionxNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Presentacion.TextoBuscar;
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


    }
}
