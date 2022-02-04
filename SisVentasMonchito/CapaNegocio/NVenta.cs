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
    public class NVenta
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosVenta de la capaDatos
        public static string Insertar(int idcliente, int idempleado, DateTime fecha, string tipocomprobante, 
                                      string serie, string correlativo, decimal igv, DataTable dtDetalles)
        {
            DatosVenta Objeto = new DatosVenta();
            Objeto.Idcliente = idcliente;
            Objeto.Idempleado = idempleado;
            Objeto.Fecha = fecha;
            Objeto.Tipocomprobante = tipocomprobante;
            Objeto.Serie = serie;
            Objeto.Correlativo = correlativo;
            Objeto.Igv = igv;
            List<DatosDetalleVenta> detalles = new List<DatosDetalleVenta>();
            foreach (DataRow row in dtDetalles.Rows)
            {
                DatosDetalleVenta detalle = new DatosDetalleVenta();
                detalle.Iddetalleingreso = Convert.ToInt32(row["IdDetalleIngreso"].ToString());
                detalle.Cantidad = Convert.ToInt32(row["Cantidad"].ToString());
                detalle.Precioventa = Convert.ToDecimal(row["PrecioVenta"].ToString());
                detalle.Descuento = Convert.ToDecimal(row["Descuento"].ToString());
                detalles.Add(detalle);
            }
            return Objeto.Insertar(Objeto, detalles);
        }


        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosVENTA de la capaDatos
        public static string Eliminar(int idventa)
        {
            DatosVenta Objeto = new DatosVenta();
            Objeto.Idventa = idventa;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosVENTA de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosVenta().Mostrar();
        }

        //Metodo BUSCAR POR FECHA que llama al metodo BUSCAR POR FECHA  de la clase DatosVENTA de la capaDatos
        public static DataTable BuscarFechas(string FechaInicial, string FechaFinal)
        {
            DatosVenta Objeto = new DatosVenta();
            return Objeto.BuscarFechas(FechaInicial, FechaFinal);
        }

        //Metodo MOSTRAR DETALLE que llama al metodo MOSTRAR DETALLE  de la clase DatosVENTA de la capaDatos
        public static DataTable MostrarDetalle(string TextoBuscar)
        {
            DatosVenta Objeto = new DatosVenta();
            return Objeto.MostrarDetalle(TextoBuscar);
        }


        //Metodo MostrarProductoVentaNombre que llama al metodo MostrarProductoVentaNombre  de la clase DatosVENTA de la capaDatos
        public static DataTable MostrarProductoVentaNombre(string TextoBuscar)
        {
            DatosVenta Objeto = new DatosVenta();
            return Objeto.MostrarProductoVentaxNombre(TextoBuscar);
        }

        //Metodo MostrarProductoVentaCodigo que llama al metodo MostrarProductoVentaCodigo  de la clase DatosVENTA de la capaDatos
        public static DataTable MostrarProductoVentaCodigo(string TextoBuscar)
        {
            DatosVenta Objeto = new DatosVenta();
            return Objeto.MostrarProductoVentaxCodigo(TextoBuscar);
        }

    }
}
