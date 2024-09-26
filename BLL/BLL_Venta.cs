using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Venta
    {
        public static string insertar_Venta(Venta_VO Venta)
        {
            return DAL_Venta.insertar_Venta(Venta);
        }

        public static List<Venta_VO> get_Venta(params object[] parametros)
        {
            return DAL_Venta.get_Venta(parametros);
        }
        //UPDATE
        public static string update_Venta(Venta_VO Venta)
        {
            return DAL_Venta.actualizar_Venta(Venta);
        }
        //DELETE
        public static string delete_Venta(int id)
        {
            return DAL_Venta.eliminar_Venta(id);
        }
    }
}
