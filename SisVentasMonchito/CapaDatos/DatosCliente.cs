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
    public class DatosCliente
    {

        //Declaracion de variables de los atributos de la tabla CLIENTE
        private int _Idcliente;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _Tipodocumento;
        private string _Numdocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;

        //Variable para buscar dentro la tabala
        private string _TextoBuscar;

        //Metodos set y get
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Tipodocumento { get => _Tipodocumento; set => _Tipodocumento = value; }
        public string Numdocumento { get => _Numdocumento; set => _Numdocumento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DatosCliente()
        {

        }

        //Constructor con parametros
        public DatosCliente(int idcliente, string nombre, string apellidos, string sexo, DateTime fechanacimiento,
                            string tipodocumento, string numdocumento, string direccion, string telefono,
                            string email, string textobuscar)
        {
            this.Idcliente = idcliente;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.FechaNacimiento = fechanacimiento;
            this.Tipodocumento = tipodocumento;
            this.Numdocumento = numdocumento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.TextoBuscar = textobuscar;
        }


        //Metodo INSERTAR
        public string Insertar(DatosCliente Cliente)
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
                SqlCmd.CommandText = "sp_InsertarCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de CLIENTE
                //IdCliente
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdCliente);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Apellidos
                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 60;
                ParApellidos.Value = Cliente.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                //Sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //FechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@FechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Size = 200;
                ParFechaNacimiento.Value = Cliente.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //TipoDocumento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@TipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Cliente.Tipodocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //NumDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@NumDocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 8;
                ParNumDocumento.Value = Cliente.Numdocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 9;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);


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
        public string Editar(DatosCliente Cliente)
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
                SqlCmd.CommandText = "sp_EditarCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de CLIENTE
                //IdCliente
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Cliente.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Apellidos
                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 60;
                ParApellidos.Value = Cliente.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                //Sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Cliente.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //FechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@FechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Size = 200;
                ParFechaNacimiento.Value = Cliente.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //TipoDocumento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@TipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Cliente.Tipodocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //NumDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@NumDocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 8;
                ParNumDocumento.Value = Cliente.Numdocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Cliente.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 9;
                ParTelefono.Value = Cliente.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Cliente.Email;
                SqlCmd.Parameters.Add(ParEmail);


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
        public string Eliminar(DatosCliente Cliente)
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
                SqlCmd.CommandText = "sp_EliminarCliente";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de CATEGORIA
                //IdCategoria
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Cliente.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);


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
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarCliente";
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


        //Metodo BUSCAR por Apellidos
        public DataTable BuscarApellidos(DatosCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarClientexApellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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

        //Metodo BUSCAR por NUMDOCUMENTO
        public DataTable BuscarNumDocumento(DatosCliente Cliente)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarClientexNumDocumento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Cliente.TextoBuscar;
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
