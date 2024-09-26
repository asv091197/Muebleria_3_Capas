using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Categoria
    {
        
        public static string insertar_Categoria(Categoria_VO categoria)
        {
                string salida = "";
                int respuesta = 0;


            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_InsertarCategoria",
                    "@Nombre_Categoria", categoria.Nombre_Categoria,
                    "@Descripcion", categoria.Descripcion);

                if (respuesta != 0)
                {
                    salida = "Categoria registrado con éxito";
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



        public static List<Categoria_VO> get_Categoria(params object[] parametros)
        {
            //creo una lsita de objetos a llenar
            List<Categoria_VO> list = new List<Categoria_VO>();
            try
            {
                //crear un Dataset el cual recibirá lo que devuelva la ejecución del método "execute_Dataset" proviniente de la clase "metodos_Datos"
                DataSet ds_categoria = metodos_datos.execute_DataSet("ListarCategorias", parametros);
                //recorremos cada renglón existente de nuestro ds crando objetos VO y añadiéndolo la lista
                foreach (DataRow dr in ds_categoria.Tables[0].Rows)
                {
                    list.Add(new Categoria_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //update
        public static string actualizar_Categoria(Categoria_VO categoria)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_ActualizarCategoria",
                    "@Id_Categoria", categoria.Id_Categoria,
                    "@Nombre_Categoria", categoria.Nombre_Categoria,
                    "@Descripcion", categoria.Descripcion
                
                    );

                if (respuesta != 0)
                {
                    salida = "Categoria actualizado con éxito";
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

        public static string delete_Categoria(int id)
        {
            string salida = "";
            int respuesta = 0;

            try
            {
                respuesta = metodos_datos.execute_nonQuery("sp_EliminarCategoria",
                    "@ID_Categoria", id
                    );

                if (respuesta != 0)
                {
                    salida = "Categoria eliminado con éxito";
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
