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
    public class NCliente
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosCliente de la capaDatos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fechanacimiento,
                                      string tipodocumento, string numdocumento, string direccion, string telefono,
                                      string email)
        {
            DatosCliente Objeto = new DatosCliente();
            Objeto.Nombre = nombre;
            Objeto.Apellidos = apellidos;
            Objeto.Sexo = sexo;
            Objeto.FechaNacimiento = fechanacimiento;
            Objeto.Tipodocumento = tipodocumento;
            Objeto.Numdocumento = numdocumento;
            Objeto.Direccion = direccion;
            Objeto.Telefono = telefono;
            Objeto.Email = email;
            return Objeto.Insertar(Objeto);
        }


        //Metodo EDITAR que llama al metodo EDITAR de la clase DatosCliente de la capaDatos
        public static string Editar(int idcliente, string nombre, string apellidos, string sexo, DateTime fechanacimiento,
                                      string tipodocumento, string numdocumento, string direccion, string telefono,
                                      string email)
        {
            DatosCliente Objeto = new DatosCliente();
            Objeto.Idcliente = idcliente;
            Objeto.Nombre = nombre;
            Objeto.Apellidos = apellidos;
            Objeto.Sexo = sexo;
            Objeto.FechaNacimiento = fechanacimiento;
            Objeto.Tipodocumento = tipodocumento;
            Objeto.Numdocumento = numdocumento;
            Objeto.Direccion = direccion;
            Objeto.Telefono = telefono;
            Objeto.Email = email;
            return Objeto.Editar(Objeto);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosCliente de la capaDatos
        public static string Eliminar(int idcliente)
        {
            DatosCliente Objeto = new DatosCliente();
            Objeto.Idcliente = idcliente;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosCliente de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosCliente().Mostrar();
        }

        //Metodo BUSCAR POR APELLDISO que llama al metodo BUSCARXAPELLIDOS de la clase DatosCliente de la capaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DatosCliente Objeto = new DatosCliente();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarApellidos(Objeto);
        }

        //Metodo BUSCARNUMDOCUMENTO que llama al metodo BUSCARNUMDOCUMENTO de la clase DatosCliente de la capaDatos
        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DatosCliente Objeto = new DatosCliente();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarNumDocumento(Objeto);
        }

    }
}
