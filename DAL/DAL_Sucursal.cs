using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Sucursal
    {
        public static string insertar_Sucursal(Sucursal_VO sucursal)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarSucursal",
                    "@Nombre_sucusal", sucursal.Nombre_sucursal,
                    "@Direccion", sucursal.Direccion,
                    "@Telefono", sucursal.Telefono
                    );

                if (respuesta != 0)
                {
                    salida = "Sucursal registrado con éxito";
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



        public static List<Sucursal_VO> get_Sucursal(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Sucursal_VO> list = new List<Sucursal_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_sucursal = metodos_datos.execute_DataSet("ListarSucursales", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_sucursal.Tables[0].Rows)
                {
                    list.Add(new Sucursal_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Sucursal(Sucursal_VO sucursal)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarSucursal",
                    "@Id_sucursal", sucursal.Id_Sucursal,
                    "@Nombre_Sucursal", sucursal.Nombre_sucursal,
                    "@Direccion", sucursal.Direccion,
                    "@Telefono", sucursal.Telefono

                    );

                if (respuesta != 0)
                {
                   salida = "Sucursal actualizado con éxito";
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

        public static string eliminar_Sucursal(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("EliminarSucursal",
                    "@Id_sucursal", id
                    );

                if (respuesta != 0)
                {
                    salida = "Sucursal eliminado con éxito";
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
