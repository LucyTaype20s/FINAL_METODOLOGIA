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
    public class DatosVenta
    {

        //Declaracion de variables de los atributos de la tabla VENTA
        private int _Idventa;
        private int _Idcliente;
        private int _Idempleado;
        private DateTime _Fecha;
        private string _Tipocomprobante;
        private string _Serie;
        private string _Correlativo;
        private decimal _Igv;

        //Metodos set y get
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Idcliente { get => _Idcliente; set => _Idcliente = value; }
        public int Idempleado { get => _Idempleado; set => _Idempleado = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Tipocomprobante { get => _Tipocomprobante; set => _Tipocomprobante = value; }
        public string Serie { get => _Serie; set => _Serie = value; }
        public string Correlativo { get => _Correlativo; set => _Correlativo = value; }
        public decimal Igv { get => _Igv; set => _Igv = value; }

        //Constructor Vacio
        public DatosVenta()
        {

        }


        //Constructor con paramentros
        public DatosVenta(int idventa, int idcliente, int idempleado, DateTime fecha,
                          string tipocomprobante, string serie, string correlativo, decimal igv)
        {
            this.Idventa = idventa;
            this.Idcliente = idcliente;
            this.Idempleado = idempleado;
            this.Fecha = fecha;
            this.Tipocomprobante = tipocomprobante;
            this.Serie = serie;
            this.Correlativo = correlativo;
            this.Igv = igv;
        }


        //Metodo DISMUNIR STOCK
        public string DisminuirSotck(int iddetalleingreso, int cantidad)
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
                SqlCmd.CommandText = "sp_DisminuirStock";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                
                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@IdDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Value = iddetalleingreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = cantidad;
                SqlCmd.Parameters.Add(ParCantidad);


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


        //Metodo INSERTAR
        public string Insertar(DatosVenta Venta, List<DatosDetalleVenta> Detalle)
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
                SqlCmd.CommandText = "sp_InsertarVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de VENTA
                //IdVenta
                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@IdVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdVenta);



                //IdCliente
                SqlParameter ParIdCliente = new SqlParameter();
                ParIdCliente.ParameterName = "@IdCliente";
                ParIdCliente.SqlDbType = SqlDbType.Int;
                ParIdCliente.Value = Venta.Idcliente;
                SqlCmd.Parameters.Add(ParIdCliente);

                //IdEmpleado
                SqlParameter ParIdEmpleado = new SqlParameter();
                ParIdEmpleado.ParameterName = "@IdEmpleado";
                ParIdEmpleado.SqlDbType = SqlDbType.Int;
                ParIdEmpleado.Value = Venta.Idempleado;
                SqlCmd.Parameters.Add(ParIdEmpleado);

                //Fecha
                SqlParameter ParFecha = new SqlParameter();
                ParFecha.ParameterName = "@Fecha";
                ParFecha.SqlDbType = SqlDbType.Date;
                ParFecha.Value = Venta.Fecha;
                SqlCmd.Parameters.Add(ParFecha);

                //TipoComprobante
                SqlParameter ParTipoComprobante = new SqlParameter();
                ParTipoComprobante.ParameterName = "@TipoComprobante";
                ParTipoComprobante.SqlDbType = SqlDbType.VarChar;
                ParTipoComprobante.Size = 20;
                ParTipoComprobante.Value = Venta.Tipocomprobante;
                SqlCmd.Parameters.Add(ParTipoComprobante);

                //Serie
                SqlParameter ParSerie = new SqlParameter();
                ParSerie.ParameterName = "@Serie";
                ParSerie.SqlDbType = SqlDbType.VarChar;
                ParSerie.Size = 4;
                ParSerie.Value = Venta.Serie;
                SqlCmd.Parameters.Add(ParSerie);

                //Correlativo
                SqlParameter ParCorrelativo = new SqlParameter();
                ParCorrelativo.ParameterName = "@Correlativo";
                ParCorrelativo.SqlDbType = SqlDbType.VarChar;
                ParCorrelativo.Size = 7;
                ParCorrelativo.Value = Venta.Correlativo;
                SqlCmd.Parameters.Add(ParCorrelativo);

                //Igv
                SqlParameter ParIgv = new SqlParameter();
                ParIgv.ParameterName = "@Igv";
                ParIgv.SqlDbType = SqlDbType.Decimal;
                ParIgv.Precision = 4;
                ParIgv.Scale = 2;
                ParIgv.Value = Venta.Igv;
                SqlCmd.Parameters.Add(ParIgv);


                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

                if (Respuesta.Equals("OK"))
                {
                    //Obtener el codigo del ingreso generado
                    this.Idventa = Convert.ToInt32(SqlCmd.Parameters["@IdVenta"].Value);
                    foreach (DatosDetalleVenta det in Detalle)
                    {
                        det.Idventa = this.Idventa;
                        //llamar al metodo insertar de la clase DatosDettaleIngreso
                        Respuesta = det.Insertar(det, ref SqlCon, ref SqlTra);
                        if (!Respuesta.Equals("OK"))
                        {
                            break;
                        }
                        else
                        {
                            //Actualizamos el stock
                            Respuesta = DisminuirSotck(det.Iddetalleingreso, det.Cantidad);
                            if (!Respuesta.Equals("OK"))
                            {
                                break;
                            }
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




        //Metodo Eliminar
        public string Eliminar(DatosVenta Venta)
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
                SqlCmd.CommandText = "sp_EliminarVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de INGRESO
                //IdIngreso
                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@IdVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = Venta.Idventa;
                SqlCmd.Parameters.Add(ParIdVenta);


                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "OK";

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
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarVenta";
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
            DataTable DtResultado = new DataTable("Venta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarVentaxFecha";
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


        //Metodo Mostrar Detalles de Ventas
        public DataTable MostrarDetalle(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("DetalleVenta");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_MostrarDetalleVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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


        //Mostrar productos por su nombre
        public DataTable MostrarProductoVentaxNombre(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarProductoVentaNombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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


        //Mostrar productos por su codigo
        public DataTable MostrarProductoVentaxCodigo(string TextoBuscar)
        {
            DataTable DtResultado = new DataTable("Producto");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_BuscarProductoVentaCodigo";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@TextoBuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
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
