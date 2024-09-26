using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Detalle_Venta
    {
        public static string insertar_Detalle_Venta(Detalle_Venta_VO detalle_Venta)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarDetalleVenta",
                    "@Venta_Id", detalle_Venta.Venta_Id,
                    "@Producto_Id", detalle_Venta.Producto_Id,
                    "@Cantidad", detalle_Venta.Cantidad,
                    "@Precion_Unitario", detalle_Venta.Precio_Unitario

                 );

                if (respuesta != 0)
                {
                    salida = "DetalleVenta registrado con éxito";
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

        public static List<Detalle_Venta_VO> get_Detalle_Venta(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Detalle_Venta_VO> list = new List<Detalle_Venta_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_detalle = metodos_datos.execute_DataSet("sp_ListarDetalleVenta", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_detalle.Tables[0].Rows)
                {
                    list.Add(new Detalle_Venta_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Detalle_Venta(Detalle_Venta_VO detalle_Venta)
    
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarDetalleVenta",
                    "@Id_Detalle", detalle_Venta.Id_Detalle,
                  "@Venta_Id", detalle_Venta.Venta_Id,
                    "@Producto_Id", detalle_Venta.Producto_Id,
                    "@Cantidad", detalle_Venta.Cantidad,
                    "@Precion_Unitario", detalle_Venta.Precio_Unitario

                    );

                if (respuesta != 0)
                {
                    salida = "Detlle Venta actualizado con éxito";
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

        public static string eliminar_DetalleVenta(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarDetalleVenta",
                    "@Id_Detalle", id
                    );

                if (respuesta != 0)
                {
                    salida = "DetalleVenta eliminado con éxito";
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
