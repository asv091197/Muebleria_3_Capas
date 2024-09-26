using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class configuracion
    {
        static string _cadenaConexion = @"Data Source = DESKTOP-6QIV74C;
                                         Initial Catalog = MuebleriaDB;
                                         Integrated Security = true";

        public static string CadenaConexion //Encapsulamiento
        {
            get { return _cadenaConexion; }
        }
    }
}
