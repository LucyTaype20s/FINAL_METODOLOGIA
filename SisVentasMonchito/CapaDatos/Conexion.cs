using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    class Conexion
    {

        //La base de datos e sql server se llama dbventas / por definir
        //La ubicación de la base de datos es local y la instancia que se llama Angel /por definir
        //Se conecta a la base de datos utilizando seguridad integrada

        public static string Cn = "Data Source=localhost; Initial Catalog=DbBodegaMonchito; Integrated Security=true";
    }
}
