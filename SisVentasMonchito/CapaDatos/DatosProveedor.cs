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
    public class DatosProveedor
    {

        //Declaracion de variables de los atributos de la tabla PRODUCTO
        private int _Idproveedor;
        private string _RazonSocial;
        private string _SectorComercial;
        private string _TipoDocumento;
        private string _NumDocumento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Paginaweb;

        //Variable para buscar dentro la tabala
        private string _TextoBuscar;

        //Metodos set y get
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string RazonSocial { get => _RazonSocial; set => _RazonSocial = value; }
        public string SectorComercial { get => _SectorComercial; set => _SectorComercial = value; }
        public string TipoDocumento { get => _TipoDocumento; set => _TipoDocumento = value; }
        public string NumDocumento { get => _NumDocumento; set => _NumDocumento = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Paginaweb { get => _Paginaweb; set => _Paginaweb = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Constructor Vacio
        public DatosProveedor()
        {

        }


        //Constructor con parametros
        public DatosProveedor(int idproveedor, string razonsocial, string sectorcomercial, string tipodocumento,
                             string numdocumento, string direccion, string telefono, string email,
                             string paginaweb, string textobuscar)
        {
            this.Idproveedor = idproveedor;
            this.RazonSocial = razonsocial;
            this.SectorComercial = sectorcomercial;
            this.TipoDocumento = tipodocumento;
            this.NumDocumento = numdocumento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.Paginaweb = paginaweb;
            this.TextoBuscar = textobuscar;
        }


        //Metodo INSERTAR
        public string Insertar(DatosProveedor Proveedor)
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
                SqlCmd.CommandText = "sp_InsertarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Proveedor
                //IdProveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IdProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdProveedor);

                //RazonSocial
                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@RazonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 50;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                //SectorComercial
                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@SectorComercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                //TipoDocumento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@TipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //NumDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@NumDocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 9;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //PaginaWeb
                SqlParameter ParPaginaWeb = new SqlParameter();
                ParPaginaWeb.ParameterName = "@PaginaWeb";
                ParPaginaWeb.SqlDbType = SqlDbType.VarChar;
                ParPaginaWeb.Size = 100;
                ParPaginaWeb.Value = Proveedor.Paginaweb;
                SqlCmd.Parameters.Add(ParPaginaWeb);



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
        public string Editar(DatosProveedor Proveedor)
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
                SqlCmd.CommandText = "sp_EditarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Proveedor
                //IdProveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IdProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);

                //RazonSocial
                SqlParameter ParRazonSocial = new SqlParameter();
                ParRazonSocial.ParameterName = "@RazonSocial";
                ParRazonSocial.SqlDbType = SqlDbType.VarChar;
                ParRazonSocial.Size = 50;
                ParRazonSocial.Value = Proveedor.RazonSocial;
                SqlCmd.Parameters.Add(ParRazonSocial);

                //SectorComercial
                SqlParameter ParSectorComercial = new SqlParameter();
                ParSectorComercial.ParameterName = "@SectorComercial";
                ParSectorComercial.SqlDbType = SqlDbType.VarChar;
                ParSectorComercial.Size = 50;
                ParSectorComercial.Value = Proveedor.SectorComercial;
                SqlCmd.Parameters.Add(ParSectorComercial);

                //TipoDocumento
                SqlParameter ParTipoDocumento = new SqlParameter();
                ParTipoDocumento.ParameterName = "@TipoDocumento";
                ParTipoDocumento.SqlDbType = SqlDbType.VarChar;
                ParTipoDocumento.Size = 20;
                ParTipoDocumento.Value = Proveedor.TipoDocumento;
                SqlCmd.Parameters.Add(ParTipoDocumento);

                //NumDocumento
                SqlParameter ParNumDocumento = new SqlParameter();
                ParNumDocumento.ParameterName = "@NumDocumento";
                ParNumDocumento.SqlDbType = SqlDbType.VarChar;
                ParNumDocumento.Size = 11;
                ParNumDocumento.Value = Proveedor.NumDocumento;
                SqlCmd.Parameters.Add(ParNumDocumento);

                //Direccion
                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@Direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Proveedor.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                //Telefono
                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@Telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 9;
                ParTelefono.Value = Proveedor.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                //Email
                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@Email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Proveedor.Email;
                SqlCmd.Parameters.Add(ParEmail);

                //PaginaWeb
                SqlParameter ParPaginaWeb = new SqlParameter();
                ParPaginaWeb.ParameterName = "@PaginaWeb";
                ParPaginaWeb.SqlDbType = SqlDbType.VarChar;
                ParPaginaWeb.Size = 100;
                ParPaginaWeb.Value = Proveedor.Paginaweb;
                SqlCmd.Parameters.Add(ParPaginaWeb);
                

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
        public string Eliminar(DatosProveedor Proveedor)
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
                SqlCmd.CommandText = "sp_EliminarProveedor";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de Proveedor
                //IdProveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IdProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Proveedor.Idproveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);


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
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarProveedor";
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


        //Metodo BuscarRazonSocial
        public DataTable BuscarRazonSocial(DatosProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarProveedorxRazonSocial";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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


        //Metodo BuscarNumerodeDocumento
        public DataTable BuscarNumDocumento(DatosProveedor Proveedor)
        {
            DataTable DtResultado = new DataTable("Proveedor");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarProveedorxNumDocumento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Proveedor.TextoBuscar;
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
