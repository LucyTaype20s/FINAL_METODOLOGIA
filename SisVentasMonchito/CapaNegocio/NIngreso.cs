using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Importamos los tipis de datos de sql
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NIngreso
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosIngreso de la capaDatos
        public static string Insertar(DateTime fecha, string tipocomprobante, string serie, string correlativo, 
                                      decimal igv, int idempleado, int idproveedor, string estado, DataTable dtDetalles)
        {
            DatosIngreso Objeto = new DatosIngreso();
            Objeto.Fecha = fecha;
            Objeto.Tipocomprobante = tipocomprobante;
            Objeto.Serie = serie;
            Objeto.Correlativo = correlativo;
            Objeto.Igv = igv;
            Objeto.Idempleado = idempleado;
            Objeto.Idproveedor = idproveedor;
            Objeto.Estado = estado;
            List<DatosDetalleIngreso> detalles = new List<DatosDetalleIngreso>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DatosDetalleIngreso detalle = new DatosDetalleIngreso();
                detalle.Idproducto = Convert.ToInt32(row["IdProducto"].ToString());
                detalle.Preciocompra = Convert.ToDecimal(row["PrecioCompra"].ToString());
                detalle.Precioventa = Convert.ToDecimal(row["PrecioVenta"].ToString());
                detalle.Stockinicial = Convert.ToInt32(row["StockInicial"].ToString());
                detalle.Stockactual = Convert.ToInt32(row["StockInicial"].ToString());
                detalle.Fechaproduccion1 = Convert.ToDateTime(row["FechaProduccion"].ToString());
                detalle.Fechavencimiento1 = Convert.ToDateTime(row["FechaVencimiento"].ToString());
                detalles.Add(detalle);
            }
            return Objeto.Insertar(Objeto, detalles);
        }


        //Metodo ANULAR que llama al metodo ANULAR de la clase DatosiNGRESO de la capaDatos
        public static string Anular(int idingreso)
        {
            DatosIngreso Objeto = new DatosIngreso();
            Objeto.Idingreso  = idingreso;
            return Objeto.Anular(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosIngreso de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosIngreso().Mostrar();
        }

        //Metodo BUSCAR POR FECHA que llama al metodo BUSCAR POR FECHA  de la clase DatosIngreso de la capaDatos
        public static DataTable BuscarFechas(string FechaInicial, string FechaFinal)
        {
            DatosIngreso Objeto = new DatosIngreso();
            return Objeto.BuscarFechas(FechaInicial, FechaFinal);
        }

        //Metodo MOSTRAR DETALLE que llama al metodo MOSTRAR DETALLE  de la clase DatosIngreso de la capaDatos
        public static DataTable MostrarDetalle(string TextoBuscar)
        {
            DatosIngreso Objeto = new DatosIngreso();
            return Objeto.MostrarDetalle(TextoBuscar);
        }

    }
}
