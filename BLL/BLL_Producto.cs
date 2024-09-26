using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAL;

namespace BLL
{
    public class BLL_Producto
    {
        public static string insertar_Producto(Producto_VO producto)
        {
            return DAL_Producto.insertar_Producto(producto);
        }

        public static List<Producto_VO> get_Producto(params object[] parametros)
        {
            return DAL_Producto.get_Producto(parametros);
        }
        //UPDATE
        public static string update_Producto(Producto_VO producto)
        {
            return DAL_Producto.actualizar_Producto(producto);
        }
        //DELETE
        public static string delete_Producto(int id)
        {
            return DAL_Producto.eliminar_Producto(id);
        }

    }
}
