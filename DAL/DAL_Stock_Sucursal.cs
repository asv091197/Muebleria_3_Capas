using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Stock_Sucursal
    {
        public static string insertar_Stock_Sucursal(Stock_Sucursal_VO stock_Sucursal)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("spInsertarStockSucursal",
                    "@Producto_Id", stock_Sucursal.Producto_Id,
                    "@Sucursal_Id", stock_Sucursal.Sucursal_Id,
                    "@Cantidad",stock_Sucursal.Cantidad );

                if (respuesta != 0)
                {
                    salida = "Stock registrado con éxito";
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



        public static List<Stock_Sucursal_VO> get_Stock_Sucursal(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Stock_Sucursal_VO> list = new List<Stock_Sucursal_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_stock = metodos_datos.execute_DataSet("sp_ListarStockSucursal", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_stock.Tables[0].Rows)
                {
                    list.Add(new Stock_Sucursal_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Stock_Sucursal(Stock_Sucursal_VO stock_Sucursal)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarStockSucursal",
                    "@Id_Stock", stock_Sucursal.Id_Stock,
                    "@Producto_Id", stock_Sucursal.Producto_Id,
                    "@Sucursal_Id", stock_Sucursal.Sucursal_Id,
                    "@Cantidad", stock_Sucursal.Cantidad
                    );

                if (respuesta != 0)
                {
                    salida = "Stock actualizado con éxito";
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

        public static string eliminar_Stock_Sucursal(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarStockSucursal",
                    "@Id_Stock", id
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
