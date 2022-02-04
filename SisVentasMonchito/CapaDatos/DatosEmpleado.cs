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
    public class DatosEmpleado
    {
        //Declaracion de variables de los atributos de la tabla EMPLEADO
        private int _Idempleado;
        private string _Nombre;
        private string _Apellidos;
        private string _Sexo;
        private DateTime _FechaNacimiento;
        private string _Numdocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Acceso;
        private string _Usuario;
        private string _Contraseña;

        //Variable para buscar dentro la tabala
        private string _TextoBuscar;

        //Metodos set y get
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Sexo { get => _Sexo; set => _Sexo = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Numdocumento { get => _Numdocumento; set => _Numdocumento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Acceso { get => _Acceso; set => _Acceso = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Contraseña { get => _Contraseña; set => _Contraseña = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DatosEmpleado()
        {

        }


        //Constructor con parametros
        public DatosEmpleado(int idempleado, string nombre, string apellidos, string sexo, DateTime fechanacimiento,
                            string numdocumento, string direccion, string telefono, string email,
                            string acceso, string usuario, string contraseña, string textobuscar)
        {
            this.Idempleado = idempleado;
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.Sexo = sexo;
            this.FechaNacimiento = fechanacimiento;
            this.Numdocumento = numdocumento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.TextoBuscar = textobuscar;
        }


        //Metodo INSERTAR
        public string Insertar(DatosEmpleado Empleado)
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
                SqlCmd.CommandText = "sp_InsertarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Empleado
                //IdEmpleado
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@IdEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Empleado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Apellidos
                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 60;
                ParApellidos.Value = Empleado.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                //Sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empleado.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //FechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@FechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Size = 200;
                ParFechaNacimiento.Value = Empleado.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //NumDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@NumDocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 8;
                ParNumDocumento.Value = Empleado.Numdocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Empleado.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 9;
                ParTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Empleado.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Acceso
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@Acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Empleado.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                //Usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                //Contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@Contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 20;
                ParContraseña.Value = Empleado.Contraseña;
                SqlCmd.Parameters.Add(ParContraseña);



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
        public string Editar(DatosEmpleado Empleado)
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
                SqlCmd.CommandText = "sp_EditarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Empleado
                //IdEmpleado
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@IdEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.Idempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                //Nombre
                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@Nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 30;
                ParNombre.Value = Empleado.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                //Apellidos
                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@Apellidos";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 60;
                ParApellidos.Value = Empleado.Apellidos;
                SqlCmd.Parameters.Add(ParApellidos);

                //Sexo
                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@Sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Empleado.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                //FechaNacimiento
                SqlParameter ParFechaNacimiento = new SqlParameter();
                ParFechaNacimiento.ParameterName = "@FechaNacimiento";
                ParFechaNacimiento.SqlDbType = SqlDbType.DateTime;
                ParFechaNacimiento.Size = 200;
                ParFechaNacimiento.Value = Empleado.FechaNacimiento;
                SqlCmd.Parameters.Add(ParFechaNacimiento);

                //NumDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@NumDocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 8;
                ParNumDocumento.Value = Empleado.Numdocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Empleado.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 9;
                ParTelefono.Value = Empleado.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Empleado.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //Acceso
                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@Acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 20;
                ParAcceso.Value = Empleado.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                //Usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                //Contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@Contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 20;
                ParContraseña.Value = Empleado.Contraseña;
                SqlCmd.Parameters.Add(ParContraseña);


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
        public string Eliminar(DatosEmpleado Empleado)
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
                SqlCmd.CommandText = "sp_EliminarEmpleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de CATEGORIA
                //IdCategoria
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@IdEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Empleado.Idempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);


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
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarEmpleado";
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
        public DataTable BuscarApellidos(DatosEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarEmpleadoxApellidos";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleado.TextoBuscar;
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
        public DataTable BuscarNumDocumento(DatosEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarEmpleadoxNumDocumento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Empleado.TextoBuscar;
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




        //Metodo Login
        public DataTable Login(DatosEmpleado Empleado)
        {
            DataTable DtResultado = new DataTable("Empleado");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_Login";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Usuario
                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Empleado.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                //Contraseña
                SqlParameter ParContraseña = new SqlParameter();
                ParContraseña.ParameterName = "@Contraseña";
                ParContraseña.SqlDbType = SqlDbType.VarChar;
                ParContraseña.Size = 20;
                ParContraseña.Value = Empleado.Contraseña;
                SqlCmd.Parameters.Add(ParContraseña);

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
