using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Cliente
    {
        public static string insertar_Cliente(Cliente_VO cliente)
        {
            return DAL_Cliente.insertar_Cliente(cliente);
        }

        public static List<Cliente_VO> get_Cliente(params object[] parametros)
        {
            return DAL_Cliente.get_Cliente(parametros);
        }
        //UPDATE
        public static string update_Cliente(Cliente_VO cliente)
        {
            return DAL_Cliente.actualizar_Cliente(cliente);
        }
        //DELETE
        public static string delete_Cliente(int id)
        {
            return DAL_Cliente.eliminar_Cliente(id);
        }
    }
}
