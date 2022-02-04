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
    public class NProducto
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosProducto de la capaDatos
        public static string Insertar(string codigo, string nombre, string descripcion, byte[] imagen, 
                                int idcategoria, int idpresentacion)
        {
            DatosProducto Objeto = new DatosProducto();
            Objeto.Codigo = codigo;
            Objeto.Nombre = nombre;
            Objeto.Descripcion = descripcion;
            Objeto.Imagen = imagen;
            Objeto.Idcategoria = idcategoria;
            Objeto.Idpresentacion = idpresentacion;
            return Objeto.Insertar(Objeto);
        }


        //Metodo EDITAR que llama al metodo EDITAR de la clase DatosProducto de la capaDatos
        public static string Editar(int idproducto, string codigo, string nombre, string descripcion, byte[] imagen,
                                int idcategoria, int idpresentacion)
        {
            DatosProducto Objeto = new DatosProducto();
            Objeto.Idprodcuto = idproducto;
            Objeto.Codigo = codigo;
            Objeto.Nombre = nombre;
            Objeto.Descripcion = descripcion;
            Objeto.Imagen = imagen;
            Objeto.Idcategoria = idcategoria;
            Objeto.Idpresentacion = idpresentacion;
            return Objeto.Editar(Objeto);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosProducto de la capaDatos
        public static string Eliminar(int idproducto)
        {
            DatosProducto Objeto = new DatosProducto();
            Objeto.Idprodcuto = idproducto;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosProducto de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosProducto().Mostrar();
        }

        //Metodo BUSCARNOMBRE que llama al metodo BUSCARNOMBRE de la clase DatosProducto de la capaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DatosProducto Objeto = new DatosProducto();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarNombre(Objeto);
        }

        //Metodo STOCKPRODUCTO que llama al metodo STOCKPRODUCTO de la clase DatosProducto de la capaDatos
        public static DataTable StockProducto()
        {
            return new DatosProducto().StockProductos();
        }


    }
}
