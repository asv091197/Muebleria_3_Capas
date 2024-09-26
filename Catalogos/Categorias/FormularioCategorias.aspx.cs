using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.Categorias
{
    public partial class FormularioCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar si voy a insertar o a editar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Categoria";
                    Subtitulo.Text = "Registro de una nueva categoria";

                }
                else
                {
                    //Voy a actualizar
                    //Recupero el ID que proviene de la URL/petíción
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Obtener el Objeto original de la BD y colocar los valores en sus campos coreespondientes
                    Categoria_VO _categoria_original = BLL_Categoria.get_Categoria("@Id_Categoria", _id)[0];
                    //valido que realmente obtenga un objeto, de lo contrario me regreso al lsitado
                    if (_categoria_original.Id_Categoria != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Categoria";
                        Subtitulo.Text = $"Modificar los datos del Categoria #{_id}";
                        txtnombrecategoria.Text = _categoria_original.Nombre_Categoria;
                        txtdescripcion.Text = _categoria_original.Descripcion;

                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListarCategorias.aspx");
                    }
                    }
                }
            } 
        

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";

            try
            {
                //Creamos el objeto que enviaremos para actualiza o insertar
                Categoria_VO _categoria_aux = new Categoria_VO();
                _categoria_aux.Nombre_Categoria = txtnombrecategoria.Text;
                _categoria_aux.Descripcion = txtdescripcion.Text;
                

                Categoria_VO _categoria_aux2 = new Categoria_VO()
                {
                    Nombre_Categoria = txtnombrecategoria.Text,
                    Descripcion = txtdescripcion.Text,
                
                };

                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar
                  
                    salida = BLL_Categoria.insertar_Categoria(_categoria_aux);
                }
                else
                {
                    //Actualizar
                    _categoria_aux.Id_Categoria = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Categoria.update_Categoria(_categoria_aux);
                }

                //preparamos la salida para cachar un error y mostrar un Sweet Alert
                if (salida.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    respuesta = salida;
                    tipo = "error";
                }
                else
                {
                    titulo = "Correcto";
                    respuesta = salida;
                    tipo = "success";
                }

            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            //sweet alert
        
    }
    }
}