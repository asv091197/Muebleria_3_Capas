using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using DAL;

namespace BLL
{
    public class BLL_Categoria
    {
        public static string insertar_Categoria(Categoria_VO Categoria)
        {
            return DAL_Categoria.insertar_Categoria(Categoria);
        }

        public static List<Categoria_VO> get_Categoria(params object[] parametros)
        {
            return DAL_Categoria.get_Categoria(parametros);
        }
        //UPDATE
        public static string update_Categoria(Categoria_VO Categoria)
        {
            return DAL_Categoria.actualizar_Categoria(Categoria);
        }
        //DELETE
        public static string delete_Categoria(int id)
        {
            return DAL_Categoria.delete_Categoria(id);
        }



    }
}
