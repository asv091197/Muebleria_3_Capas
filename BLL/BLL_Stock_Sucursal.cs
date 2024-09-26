using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Stock_Sucursal
    {
        public static string insertar_Stock_Sucursal(Stock_Sucursal_VO stock_Sucursal)
        {
            return DAL_Stock_Sucursal.insertar_Stock_Sucursal(stock_Sucursal);
        }

        public static List<Stock_Sucursal_VO> get_Stock_Sucursal(params object[] parametros)
        {
            return DAL_Stock_Sucursal.get_Stock_Sucursal(parametros);
        }
        //UPDATE
        public static string update_Stock_Sucursal(Stock_Sucursal_VO stock_Sucursal)
        {
            return DAL_Stock_Sucursal.actualizar_Stock_Sucursal(stock_Sucursal);
        }
        //DELETE
        public static string delete_Stock_Sucursal(int id)
        {
            return DAL_Stock_Sucursal.eliminar_Stock_Sucursal(id);
        }
    }
}
