using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Cliente
    {
        public static string insertar_Cliente(Cliente_VO cliente)
        {
            string salida = "";
            int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarCliente",
                    "@Nombre",cliente.Nombre,
                    "@Apellido_paterno", cliente.Apellido_paterno,
                    "@Apellido_materno", cliente.Apellido_materno,
                    "@Fecha_nacimiento", cliente.Fecha_nacimiento,
                    "@Direccion",cliente.Direccion,
                    "@Telefono",cliente.Telefono,
                    "@Email",cliente.Email);

                if (respuesta != 0)
                {
                    salida = "Cliente registrado con éxito";
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



        public static List<Cliente_VO> get_Cliente(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Cliente_VO> list = new List<Cliente_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_cliente = metodos_datos.execute_DataSet("ListarClientes", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_cliente.Tables[0].Rows)
                {
                    list.Add(new Cliente_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Cliente(Cliente_VO cliente)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarCliente",
                    "@Id_Cliente", cliente.Id_Cliente,
                    "@Nombre",cliente.Nombre,
                   "@Apellido_paterno", cliente.Apellido_paterno,
                    "@Apellido_materno", cliente.Apellido_materno,
                    "@Fecha_nacimiento", cliente.Fecha_nacimiento,
                    "@Direccion", cliente.Direccion,
                    "@Telefono", cliente.Telefono,
                    "@Email", cliente.Email

                    );

                if (respuesta != 0)
                {
                    salida = "Cliente actualizado con éxito";
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

        public static string eliminar_Cliente(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarCliente",
                    "@Id_Cliente", id
                    );

                if (respuesta != 0)
                {
                    salida = "Cliente eliminado con éxito";
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
