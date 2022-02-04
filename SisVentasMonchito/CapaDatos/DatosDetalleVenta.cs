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
    public class DatosDetalleVenta
    {

        //Declaracion de variables de los atributos de la tabla DETALLE VENTA
        private int _Iddetalleventa;
        private int _Idventa;
        private int _Iddetalleingreso;
        private int _Cantidad;
        private decimal _Precioventa;
        private decimal _Descuento;

        //Metodos set y get
        public int Iddetalleventa { get => _Iddetalleventa; set => _Iddetalleventa = value; }
        public int Idventa { get => _Idventa; set => _Idventa = value; }
        public int Iddetalleingreso { get => _Iddetalleingreso; set => _Iddetalleingreso = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precioventa { get => _Precioventa; set => _Precioventa = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }

        //Constructor Vacio
        public DatosDetalleVenta()
        {

        }

        //Constructor con parametros
        public DatosDetalleVenta(int iddetalleventa, int idventa, int iddetalleingreso, int cantidad,
                                 decimal precioventa, decimal descuento)
        {
            this.Iddetalleventa = iddetalleventa;
            this.Idventa = idventa;
            this.Iddetalleingreso = iddetalleingreso;
            this.Cantidad = cantidad;
            this.Precioventa = precioventa;
            this.Descuento = descuento;
        }



        //Metodo INSERTAR
        public string Insertar(DatosDetalleVenta DetalleVenta, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string Respuesta = "";
            try
            {
                //Establecer comando para ejecutar sentencia en sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "sp_InsertarDetalleVenta";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de DetalleVenta
                //IdDetalleIngreso
                SqlParameter ParIdDetalleVenta = new SqlParameter();
                ParIdDetalleVenta.ParameterName = "@IdDetalleVenta";
                ParIdDetalleVenta.SqlDbType = SqlDbType.Int;
                ParIdDetalleVenta.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalleVenta);

                //IdVenta
                SqlParameter ParIdVenta = new SqlParameter();
                ParIdVenta.ParameterName = "@IdVenta";
                ParIdVenta.SqlDbType = SqlDbType.Int;
                ParIdVenta.Value = DetalleVenta.Idventa;
                SqlCmd.Parameters.Add(ParIdVenta);

                //IdDetalleIngreso
                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@IdDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Value = DetalleVenta.Iddetalleingreso;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                //IdDetalleIngreso
                SqlParameter ParCantidad = new SqlParameter();
                ParCantidad.ParameterName = "@Cantidad";
                ParCantidad.SqlDbType = SqlDbType.Int;
                ParCantidad.Value = DetalleVenta.Cantidad;
                SqlCmd.Parameters.Add(ParCantidad);

                //PrecioVenta
                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@PrecioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleVenta.Precioventa;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                //Descuento
                SqlParameter ParDescuento = new SqlParameter();
                ParDescuento.ParameterName = "@Descuento";
                ParDescuento.SqlDbType = SqlDbType.Money;
                ParDescuento.Value = DetalleVenta.Descuento;
                SqlCmd.Parameters.Add(ParDescuento);



                //Ejecutamos el comando
                Respuesta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "No se ingreso el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }

            return Respuesta;
        }


    }
}
