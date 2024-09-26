using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Producto
    {
        public static string insertar_Producto(Producto_VO producto)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarProducto",
                    "@Nombre_Producto",producto.Nombre_Producto,
                    "@Descripcion", producto.Descripcion,
                    "@Precio", producto.Precio,
                    "@Categoria_Id", producto.Categoia_Id,
                    "@Proveedor_Id", producto.Proveedor_Id
                 );

                if (respuesta != 0)
                {
                    salida = "Empleado registrado con éxito";
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

        public static List<Producto_VO> get_Producto(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Producto_VO> list = new List<Producto_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_producto = metodos_datos.execute_DataSet("sp_ListarProductos", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_producto.Tables[0].Rows)
                {
                    list.Add(new Producto_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Producto(Producto_VO producto)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarProducto",
                    "@Id_Producto", producto.Id_Producto,
                 "@Nombre_Producto", producto.Nombre_Producto,
                    "@Descripcion", producto.Descripcion,
                    "@Precio", producto.Precio,
                    "@Categoria_Id", producto.Categoia_Id,
                    "@Proveedor_Id", producto.Proveedor_Id

                    );

                if (respuesta != 0)
                {
                    salida = "Producto actualizado con éxito";
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

        public static string eliminar_Producto(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarProducto",
                    "@Id_Producto", id
                    );

                if (respuesta != 0)
                {
                    salida = "Producto eliminado con éxito";
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
