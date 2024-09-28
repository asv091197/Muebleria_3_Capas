using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Proveedor
    {
        public static string insertar_Proveedor(Proveedor_VO proveedor)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarProveedor",
                    "@Nombre_Proveedor", proveedor.Nombre_Proveedor,
                    "@Direccion", proveedor.Direccion,
                    "@Telefono", proveedor.Telefono,
                    "@Email", proveedor.Email);

                if (respuesta != 0)
                {
                    salida = "Proveedor registrado con éxito";
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



        public static List<Proveedor_VO> get_Proveedor(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Proveedor_VO> list = new List<Proveedor_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_proveedor = metodos_datos.execute_DataSet("sp_ListarProveedores", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_proveedor.Tables[0].Rows)
                {
                    list.Add(new Proveedor_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Proveedor(Proveedor_VO proveedor)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarProveedor",
                    "@Id_Proveedor", proveedor.Id_Proveedor,
                    "@Nombre_Proveedor", proveedor.Nombre_Proveedor,
                    "@Direccion",proveedor.Direccion,
                    "@Telefono", proveedor.Telefono,
                    "@Email", proveedor.Email

                    );

                if (respuesta != 0)
                {
                    salida = "Proveedor actualizado con éxito";
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

        public static string eliminar_Proveedor(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarProveedor",
                    "@ID_Provedor", id
                    );

                if (respuesta != 0)
                {
                    salida = "Proveedor eliminado con éxito";
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
