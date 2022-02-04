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
    public class DatosDetalleIngreso
    {

        //Declaracion de variables de los atributos de la tabla DetalleIngreso
        private int _Iddetalleingreso;
        private decimal _Preciocompra;
        private decimal _Precioventa;
        private int _Stockinicial;
        private int _Stockactual;
        private DateTime Fechaproduccion;
        private DateTime Fechavencimiento;
        private int _Idingreso;
        private int _Idproducto;

        //Metodos set y get
        public int Iddetalleingreso { get => _Iddetalleingreso; set => _Iddetalleingreso = value; }
        public decimal Preciocompra { get => _Preciocompra; set => _Preciocompra = value; }
        public decimal Precioventa { get => _Precioventa; set => _Precioventa = value; }
        public int Stockinicial { get => _Stockinicial; set => _Stockinicial = value; }
        public int Stockactual { get => _Stockactual; set => _Stockactual = value; }
        public DateTime Fechaproduccion1 { get => Fechaproduccion; set => Fechaproduccion = value; }
        public DateTime Fechavencimiento1 { get => Fechavencimiento; set => Fechavencimiento = value; }
        public int Idingreso { get => _Idingreso; set => _Idingreso = value; }
        public int Idproducto { get => _Idproducto; set => _Idproducto = value; }

        //Constructor Vacio
        public DatosDetalleIngreso()
        {

        }

        //Constructor con parametros
        public DatosDetalleIngreso(int iddetalleingreso, decimal preciocompra, decimal precioventa, int stockinicial,
                                   int stockactual, DateTime fechaproduccion, DateTime fechavencimiento, int idingreso,
                                   int idproducto)
        {
            this.Iddetalleingreso = iddetalleingreso;
            this.Preciocompra = preciocompra;
            this.Precioventa = precioventa;
            this.Stockinicial = stockinicial;
            this.Stockactual = stockactual;
            this.Fechaproduccion = fechaproduccion;
            this.Fechavencimiento = fechavencimiento;
            this.Idingreso = idingreso;
            this.Idproducto = idproducto;
        }

        //Metodo INSERTAR
        public string Insertar(DatosDetalleIngreso DetalleIngreso, ref SqlConnection SqlCon, ref SqlTransaction SqlTra)
        {
            string Respuesta = "";            
            try
            {
                //Establecer comando para ejecutar sentencia en sql
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.Transaction = SqlTra;
                SqlCmd.CommandText = "sp_InsertarDetalleIngreso";
                SqlCmd.CommandType = CommandType.StoredProcedure;


                //Capturando los parametros de DetalleIngreso
                //IdDetalleIngreso
                SqlParameter ParIdDetalleIngreso = new SqlParameter();
                ParIdDetalleIngreso.ParameterName = "@IdDetalleIngreso";
                ParIdDetalleIngreso.SqlDbType = SqlDbType.Int;
                ParIdDetalleIngreso.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdDetalleIngreso);

                //IdIngreso
                SqlParameter PaIdIngreso = new SqlParameter();
                PaIdIngreso.ParameterName = "@IdIngreso";
                PaIdIngreso.SqlDbType = SqlDbType.Int;
                PaIdIngreso.Value = DetalleIngreso.Idingreso;
                SqlCmd.Parameters.Add(PaIdIngreso);

                //IdProducto
                SqlParameter ParIdProducto = new SqlParameter();
                ParIdProducto.ParameterName = "@IdProducto";
                ParIdProducto.SqlDbType = SqlDbType.Int;
                ParIdProducto.Value = DetalleIngreso.Idproducto;
                SqlCmd.Parameters.Add(ParIdProducto);

                //PrecioCompra
                SqlParameter ParPrecioCompra = new SqlParameter();
                ParPrecioCompra.ParameterName = "@PrecioCompra";
                ParPrecioCompra.SqlDbType = SqlDbType.Money;
                ParPrecioCompra.Value = DetalleIngreso.Preciocompra;
                SqlCmd.Parameters.Add(ParPrecioCompra);

                //PrecioVenta
                SqlParameter ParPrecioVenta = new SqlParameter();
                ParPrecioVenta.ParameterName = "@PrecioVenta";
                ParPrecioVenta.SqlDbType = SqlDbType.Money;
                ParPrecioVenta.Value = DetalleIngreso.Precioventa;
                SqlCmd.Parameters.Add(ParPrecioVenta);

                //StockInicial
                SqlParameter ParStockInicial = new SqlParameter();
                ParStockInicial.ParameterName = "@StockInicial";
                ParStockInicial.SqlDbType = SqlDbType.Int;
                ParStockInicial.Value = DetalleIngreso.Stockinicial;
                SqlCmd.Parameters.Add(ParStockInicial);

                //StockActual
                SqlParameter ParStockActual = new SqlParameter();
                ParStockActual.ParameterName = "@StockActual";
                ParStockActual.SqlDbType = SqlDbType.Int;
                ParStockActual.Value = DetalleIngreso.Stockactual;
                SqlCmd.Parameters.Add(ParStockActual);

                //FechaProduccion
                SqlParameter ParFechaProduccion = new SqlParameter();
                ParFechaProduccion.ParameterName = "@FechaProduccion";
                ParFechaProduccion.SqlDbType = SqlDbType.Date;
                ParFechaProduccion.Value = DetalleIngreso.Fechaproduccion;
                SqlCmd.Parameters.Add(ParFechaProduccion);

                //FechaVencimiento
                SqlParameter ParFechaVencimiento = new SqlParameter();
                ParFechaVencimiento.ParameterName = "@FechaVencimiento";
                ParFechaVencimiento.SqlDbType = SqlDbType.Date;
                ParFechaVencimiento.Value = DetalleIngreso.Fechavencimiento;
                SqlCmd.Parameters.Add(ParFechaVencimiento);
                

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
