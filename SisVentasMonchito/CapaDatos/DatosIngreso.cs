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
    public class DatosIngreso
    {

        //Declaracion de variables de los atributos de la tabla INGRESO
        private int _Idingreso;
        private DateTime _Fecha;
        private string _Tipocomprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;
        private int _Idempleado;
        private int _Idproveedor;
        private string _Estado;

        //Metodos set y get
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipocomprobante { get => _Tipocomprobante; set => _Tipocomprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public int Idproveedor { get => _Idproveedor; set => _Idproveedor = value; }
        public string Estado { get => _Estado; set => _Estado = value; }

        //Constructor Vacio
        public DatosIngreso()
        {

        }

        //Constructor con parametros
        public DatosIngreso(int idingreso, DateTime fecha, string tipocomprobante, string serie, string correlativo,
                            decimal igv, int idempleado, int idproveedor, string estado)
        {
            this.Idingreso = idingreso;
            this.Fecha = fecha;
            this.Tipocomprobante = tipocomprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
            this.Idempleado = idempleado;
            this.Idproveedor = idproveedor;
            this.Estado = estado;
        }

        //Metodo INSERTAR
        public string Insertar(DatosIngreso Ingreso, List<DatosDetalleIngreso> Detalle)
        {
            string Respuesta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Establecemos la conexion
                SqlCon.ConnectionString = Conexion.Cn;

                // Abrimos la conexion con SqlServer
                SqlCon.Open();

                //Establecer transaccion
                SqlTransaction SqlTra = SqlCon.BeginTransaction();


                //Establecer comando para ejecutar sentencia en sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "sp_InsertarIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de INGRESO
                //IdIngreso
                SqlParameter ParIdIdIngreso = new SqlParameter();
                ParIdIdIngreso.ParameterName = "@IdIngreso";
                ParIdIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIdIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdIdIngreso);



                //Fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Ingreso.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //TipoComprobante
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@TipoComprabante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Ingreso.Tipocomprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                //Serie
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Ingreso.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                //Correlativo
                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@Correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Ingreso.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                //Igv
                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@Igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Ingreso.Igv;
                SqlCmd.Parameters.Add(ParIgv);

                //Estado
                SqlParameter ParEstado = new SqlParameter();
                ParEstado.ParameterName = "@Estado";
                ParEstado.SqlDbType = SqlDbType.VarChar;
                ParEstado.Size = 7;
                ParEstado.Value = Ingreso.Estado;
                SqlCmd.Parameters.Add(ParEstado);


                //IdEmpleado
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@IdEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Ingreso.Idempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                //IdProveedor
                SqlParameter ParIdProveedor = new SqlParameter();
                ParIdProveedor.ParameterName = "@IdProveedor";
                ParIdProveedor.SqlDbType = SqlDbType.Int;
                ParIdProveedor.Value = Ingreso.Idproveedor;
                SqlCmd.Parameters.Add(ParIdProveedor);


                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

                if (Respuesta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.Idingreso = Convert.ToInt32(SqlCmd.Parameters["@IdIngreso"].Value);
                    foreach (DatosDetalleIngreso det in Detalle)
                    {
                        det.Idingreso = this.Idingreso;
                        //llamar al metodo insertar de la clase DatosDettaleIngreso
                        Respuesta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!Respuesta.Equals("OK"))
                        {
                            break;
                        }
                    }
                }

                if (Respuesta.Equals("OK"))
                {
                    SqlTra.Commit();
                }
                else
                {
                    SqlTra.Rollback();
                }

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


        //Metodo ANULAR
        public string Anular(DatosIngreso Ingreso)
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
                SqlCmd.CommandText = "sp_AnularIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de INGRESO
                //IdIngreso
                SqlParameter ParIdIngreso = new SqlParameter();
                ParIdIngreso.ParameterName = "@IdIngreso";
                ParIdIngreso.SqlDbType = SqlDbType.Int;
                ParIdIngreso.Value = Ingreso.Idingreso;
                SqlCmd.Parameters.Add(ParIdIngreso);


                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se anulo el registro";

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
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarIngreso";
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


        //Metodo BUSCAR POR FECHAS
        public DataTable BuscarFechas(string FechaInicial, string FechaFinal)
        {
            DataTable DtResultado = new DataTable("Ingreso");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarIngresoxFecha";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParFechaInicial = new SqlParameter();
                ParFechaInicial.ParameterName = "@FechaInicial";
                ParFechaInicial.SqlDbType = SqlDbType.VarChar;
                ParFechaInicial.Size = 20;
                ParFechaInicial.Value = FechaInicial;
                SqlCmd.Parameters.Add(ParFechaInicial);

                SqlParameter ParFechaFinal = new SqlParameter();
                ParFechaFinal.ParameterName = "@FechaFinal";
                ParFechaFinal.SqlDbType = SqlDbType.VarChar;
                ParFechaFinal.Size = 20;
                ParFechaFinal.Value = FechaFinal;
                SqlCmd.Parameters.Add(ParFechaFinal);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);
            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;
        }


        //Metodo Mostrar Detalles de ingreso
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("DetalleIngreso");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarDetalleIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 20;
                ParTextoBuscar.Value = TextoBuscar;
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
