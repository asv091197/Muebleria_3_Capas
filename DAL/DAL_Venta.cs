using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Venta
    {
        public static string insertar_Venta(Venta_VO venta)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarVenta",
                    "@Fecha_Venta", venta.Fecha_Venta,
                    "@Cliente_Id", venta.Cliente_Id,
                    "@Empleado_Id", venta.Empleado_Id,
                    "@Total", venta.Total);

                if (respuesta != 0)
                {
                    salida = "Venta registrado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }



        public static List<Venta_VO> get_Venta(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Venta_VO> list = new List<Venta_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_venta = metodos_datos.execute_DataSet("sp_ListarVentas", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_venta.Tables[0].Rows)
                {
                    list.Add(new Venta_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Venta(Venta_VO venta)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarVenta",
                    "@Id_Venta", venta.Id_Venta,
                    "@Fecha_Venta", venta.Fecha_Venta,
                    "@Cliente_Id", venta.Cliente_Id,
                    "@Empleado_Id", venta.Empleado_Id,
                    "@Total", venta.Total
                    );

                if (respuesta != 0)
                {
                    salida = "Venta actualizado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }


        //Eliminar Categoria

        public static string eliminar_Venta(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarVenta",
                    "@Id_Venta", id
                    );

                if (respuesta != 0)
                {
                    salida = "Stock eliminado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = "Error: " + e.Message;
            }
            return salida;
        }
    }
}
