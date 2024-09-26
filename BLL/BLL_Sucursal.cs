using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Sucursal
    {
        public static string insertar_Sucursal(Sucursal_VO Sucursal)
        {
            return DAL_Sucursal.insertar_Sucursal(Sucursal);
        }

        public static List<Sucursal_VO> get_Sucursal(params object[] parametros)
        {
            return DAL_Sucursal.get_Sucursal(parametros);
        }
        //UPDATE
        public static string update_Sucursal(Sucursal_VO Sucursal)
        {
            return DAL_Sucursal.actualizar_Sucursal(Sucursal);
        }
        //DELETE
        public static string delete_Sucursal(int id)
        {
            return DAL_Sucursal.eliminar_Sucursal(id);
        }
    }
}
