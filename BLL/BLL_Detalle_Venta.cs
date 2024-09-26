using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Detalle_Venta
    {
        public static string insertar_Detalle_Venta(Detalle_Venta_VO Detalle_Venta)
        {
            return DAL_Detalle_Venta.insertar_Detalle_Venta(Detalle_Venta);
        }

        public static List<Detalle_Venta_VO> get_Categoria(params object[] parametros)
        {
            return DAL_Detalle_Venta.get_Detalle_Venta(parametros);
        }
        //UPDATE
        public static string update_Detalle_Venta(Detalle_Venta_VO Detalle_Venta)
        {
            return DAL_Detalle_Venta.actualizar_Detalle_Venta(Detalle_Venta);
        }
        //DELETE
        public static string delete_Detalle_Venta(int id)
        {
            return DAL_Detalle_Venta.eliminar_DetalleVenta(id);
        }
    }
}
