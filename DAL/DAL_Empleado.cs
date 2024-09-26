using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Empleado
    {
        public static string insertar_Empleado(Empleado_VO empleado)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarEmpleado",
                    "@Nombre", empleado.Nombre,
                    "@Apellido_paterno", empleado.Apellido_paterno,
                    "@Apellido_materno", empleado.Apellido_materno,
                    "@Fecha_Naciminto", empleado.Fecha_nacimiento,
                    "@Direccion", empleado.Direccion,
                    "@Telono", empleado.Telefono,
                    "@Email", empleado.Email);

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



        public static List<Empleado_VO> get_Empleado(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Empleado_VO> list = new List<Empleado_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_empleado = metodos_datos.execute_DataSet("sp_ListarEmpleados", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_empleado.Tables[0].Rows)
                {
                    list.Add(new Empleado_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Empleado(Empleado_VO  empleado)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarCliente",
                    "@Id_Empleado", empleado.Id_Empleado,
                   "@Apellido_paterno", empleado.Apellido_paterno,
                    "@Apellido_materno", empleado.Apellido_materno,
                    "@Fecha_Naciminto", empleado.Fecha_nacimiento,
                    "@Direccion", empleado.Direccion,
                    "@Telono", empleado.Telefono,
                    "@Email", empleado.Email

                    );

                if (respuesta != 0)
                {
                    salida = "Empleado actualizado con éxito";
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

        public static string eliminar_Empleado(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarEmpleado",
                    "@Id_Empleado", id
                    );

                if (respuesta != 0)
                {
                    salida = "Empleado eliminado con éxito";
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
