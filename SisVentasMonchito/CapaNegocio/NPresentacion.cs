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
    public class NPresentacion
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosPresentacion de la capaDatos
        public static string Insertar(string nombre, string descripcion)
        {
            DatosPresentacion Objeto = new DatosPresentacion();
            Objeto.Nombre = nombre;
            Objeto.Descripcion = descripcion;
            return Objeto.Insertar(Objeto);
        }


        //Metodo EDITAR que llama al metodo EDITAR de la clase DatosPresentacion de la capaDatos
        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DatosPresentacion Objeto = new DatosPresentacion();
            Objeto.Idpresentacion = idpresentacion;
            Objeto.Nombre = nombre;
            Objeto.Descripcion = descripcion;
            return Objeto.Editar(Objeto);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosPresentacion de la capaDatos
        public static string Eliminar(int idpresentacion)
        {
            DatosPresentacion Objeto = new DatosPresentacion();
            Objeto.Idpresentacion = idpresentacion;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosPresentacion de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosPresentacion().Mostrar();
        }

        //Metodo BUSCARNOMBRE que llama al metodo BUSCARNOMBRE de la clase DatosPresentacion de la capaDatos
        public static DataTable BuscarNombre(string textobuscar)
        {
            DatosPresentacion Objeto = new DatosPresentacion();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarNombre(Objeto);
        }

    }
}
