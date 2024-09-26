using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAL;

namespace BLL
{
    public class BLL_Proveedor
    {
        public static string insertar_Proveedor(Proveedor_VO proveedor)
        {
            return DAL_Proveedor.insertar_Proveedor(proveedor);
        }

        public static List<Proveedor_VO> get_Proveedor(params object[] parametros)
        {
            return DAL_Proveedor.get_Proveedor(parametros);
        }
        //UPDATE
        public static string update_Proveedor(Proveedor_VO proveedor)
        {
            return DAL_Proveedor.actualizar_Proveedor(proveedor);
        }
        //DELETE
        public static string delete_Proveedor(int id)
        {
            return DAL_Proveedor.eliminar_Proveedor(id);
        }
    }
}
