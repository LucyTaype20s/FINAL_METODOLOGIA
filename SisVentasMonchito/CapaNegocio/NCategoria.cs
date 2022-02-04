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
    public class NCategoria
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosCategoria de la capaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DatosCategoria Objeto = new DatosCategoria();
            Objeto.Nombre = nombre;
            Objeto.Descripcion = descripcion;
            return Objeto.Insertar(Objeto);
        }


        //Metodo EDITAR que llama al metodo EDITAR de la clase DatosCategoria de la capaDatos
        public static string Editar(int idcategoria, string nombre, string descripcion)
        {
            DatosCategoria Objeto = new DatosCategoria();
            Objeto.Idcategoria = idcategoria;
            Objeto.Nombre = nombre;
            Objeto.Descripcion = descripcion;
            return Objeto.Editar(Objeto);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosCategoria de la capaDatos
        public static string Eliminar(int idcategoria)
        {
            DatosCategoria Objeto = new DatosCategoria();
            Objeto.Idcategoria = idcategoria;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosCategoria de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosCategoria().Mostrar();
        }

        //Metodo BUSCARNOMBRE que llama al metodo BUSCARNOMBRE de la clase DatosCategoria de la capaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DatosCategoria Objeto = new DatosCategoria();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarNombre(Objeto);
        }

    }
}
