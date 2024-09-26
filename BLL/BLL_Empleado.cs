using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Empleado
    {
        public static string insertar_Empleado(Empleado_VO Empleado)
        {
            return DAL_Empleado.insertar_Empleado(Empleado);
        }

        public static List<Empleado_VO> get_Empleado(params object[] parametros)
        {
            return DAL_Empleado.get_Empleado(parametros);
        }
        //UPDATE
        public static string update_Empleado(Empleado_VO Empleado)
        {
            return DAL_Empleado.actualizar_Empleado(Empleado);
        }
        //DELETE
        public static string delete_Empleado(int id)
        {
            return DAL_Empleado.eliminar_Empleado(id);
        }
    }
}
