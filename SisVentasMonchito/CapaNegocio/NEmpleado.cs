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
    public class NEmpleado
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosEmpleado de la capaDatos
        public static string Insertar(string nombre, string apellidos, string sexo, DateTime fechanacimiento,
                                      string numdocumento, string direccion, string telefono, string email,
                                      string acceso, string usuario, string contraseña)
        {
            DatosEmpleado Objeto = new DatosEmpleado();
            Objeto.Nombre = nombre;
            Objeto.Apellidos = apellidos;
            Objeto.Sexo = sexo;
            Objeto.FechaNacimiento = fechanacimiento;
            Objeto.Numdocumento = numdocumento;
            Objeto.Direccion = direccion;
            Objeto.Telefono = telefono;
            Objeto.Email = email;
            Objeto.Acceso = acceso;
            Objeto.Usuario = usuario;
            Objeto.Contraseña = contraseña;
            return Objeto.Insertar(Objeto);
        }


        //Metodo EDITAR que llama al metodo EDITAR de la clase DatosEmpleado de la capaDatos
        public static string Editar(int idempleado, string nombre, string apellidos, string sexo, DateTime fechanacimiento,
                                      string numdocumento, string direccion, string telefono, string email,
                                      string acceso, string usuario, string contraseña)
        {
            DatosEmpleado Objeto = new DatosEmpleado();
            Objeto.Idempleado = idempleado;
            Objeto.Nombre = nombre;
            Objeto.Apellidos = apellidos;
            Objeto.Sexo = sexo;
            Objeto.FechaNacimiento = fechanacimiento;
            Objeto.Numdocumento = numdocumento;
            Objeto.Direccion = direccion;
            Objeto.Telefono = telefono;
            Objeto.Email = email;
            Objeto.Acceso = acceso;
            Objeto.Usuario = usuario;
            Objeto.Contraseña = contraseña;
            return Objeto.Editar(Objeto);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosEmpleado de la capaDatos
        public static string Eliminar(int idempleado)
        {
            DatosEmpleado Objeto = new DatosEmpleado();
            Objeto.Idempleado = idempleado;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosEmpleado de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosEmpleado().Mostrar();
        }

        //Metodo BUSCAR POR APELLIDOS que llama al metodo BUSCARXAPELLIDOS de la clase DatosEmpleado de la capaDatos
        public static DataTable BuscarApellidos(string textobuscar)
        {
            DatosEmpleado Objeto = new DatosEmpleado();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarApellidos(Objeto);
        }

        //Metodo BUSCARNUMDOCUMENTO que llama al metodo BUSCARNUMDOCUMENTO de la clase DatosEmpleado de la capaDatos
        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DatosEmpleado Objeto = new DatosEmpleado();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarNumDocumento(Objeto);
        }

        //Metodo LOGIN que llama al metodo LOGIN  de la clase DatosEmpleado de la capaDatos
        public static DataTable Login(string usuario, string contraseña)
        {
            DatosEmpleado Objeto = new DatosEmpleado();
            Objeto.Usuario = usuario;
            Objeto.Contraseña = contraseña;
            return Objeto.Login(Objeto);
        }

    }
}
