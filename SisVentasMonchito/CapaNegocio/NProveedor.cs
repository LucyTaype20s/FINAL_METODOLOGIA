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
    public class NProveedor
    {

        //Metodo INSERTAR que llama al metodo INSERTAR de la clase DatosProveedor de la capaDatos
        public static string Insertar(string razonsocial, string sectorcomercail, string tipodocumento,
                                      string numdocumento, string direccion, string telefono, string email,
                                      string paginaweb)
        {
            DatosProveedor Objeto = new DatosProveedor();
            Objeto.RazonSocial = razonsocial;
            Objeto.SectorComercial = sectorcomercail;
            Objeto.TipoDocumento = tipodocumento;
            Objeto.NumDocumento = numdocumento;
            Objeto.Direccion = direccion;
            Objeto.Telefono = telefono;
            Objeto.Email = email;
            Objeto.Paginaweb = paginaweb;
            return Objeto.Insertar(Objeto);
        }


        //Metodo EDITAR que llama al metodo EDITAR de la clase DatosProveedor de la capaDatos
        public static string Editar(int idproveedor, string razonsocial, string sectorcomercail, string tipodocumento,
                                      string numdocumento, string direccion, string telefono, string email,
                                      string paginaweb)
        {
            DatosProveedor Objeto = new DatosProveedor();
            Objeto.Idproveedor = idproveedor;
            Objeto.RazonSocial = razonsocial;
            Objeto.SectorComercial = sectorcomercail;
            Objeto.TipoDocumento = tipodocumento;
            Objeto.NumDocumento = numdocumento;
            Objeto.Direccion = direccion;
            Objeto.Telefono = telefono;
            Objeto.Email = email;
            Objeto.Paginaweb = paginaweb;
            return Objeto.Editar(Objeto);
        }

        //Metodo ELIMINAR que llama al metodo ELIMINAR de la clase DatosProveedor de la capaDatos
        public static string Eliminar(int idproveedor)
        {
            DatosProveedor Objeto = new DatosProveedor();
            Objeto.Idproveedor = idproveedor;
            return Objeto.Eliminar(Objeto);
        }

        //Metodo MOSTRAR que llama al metodo MOSTRAR de la clase DatosProveedor de la capaDatos
        public static DataTable Mostrar()
        {
            return new DatosProveedor().Mostrar();
        }

        //Metodo BUSCARRAZONSOCIAL que llama al metodo BUSCARRAZONSOCIAL de la clase DatosProveedor de la capaDatos
        public static DataTable BuscarRazonSocial(string textobuscar)
        {
            DatosProveedor Objeto = new DatosProveedor();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarRazonSocial(Objeto);
        }

        //Metodo BUSCARNUMDOCUMENTO que llama al metodo BUSCARNUMDOCUMENTO de la clase DatosProveedor de la capaDatos
        public static DataTable BuscarNumDocumento(string textobuscar)
        {
            DatosProveedor Objeto = new DatosProveedor();
            Objeto.TextoBuscar = textobuscar;
            return Objeto.BuscarNumDocumento(Objeto);
        }

    }
}
