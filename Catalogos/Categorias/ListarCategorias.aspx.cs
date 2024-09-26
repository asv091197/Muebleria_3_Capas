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
    public partial class ListarCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }


        public void cargarGrid()
        {
            //carga la información desde la BLL al GV
            GVCategorias.DataSource = BLL_Categoria.get_Categoria();
            //Mostramos los resultado renderizando los información
            GVCategorias.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioCategorias.aspx");
        }

        protected void GVCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idcategoria = int.Parse(GVCategorias.DataKeys[e.RowIndex].Values["Id_Categoria"].ToString());
            ////Invoco mi método para eliminar camiones desde la BLL
            //string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //Invoco mi método para eliminar camiones desde el servicio Web
            string respuesta = BLL_Categoria.delete_Categoria(idcategoria);
            //Preparamos el Sweet Alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";
            }
            //Sweet alert
            //Recargamos el Grid
            cargarGrid();
        }

        protected void GVCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recuperamos
                string id = GVCategorias.DataKeys[varIndex].Values["Id_Categoria"].ToString();
                //redirecciono al formulario de edición, pasando como parámetro el ID
                Response.Redirect("FormularioCategorias.aspx?Id=" + id);
            }
        }

        protected void GVCategorias_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVCategorias.EditIndex = e.NewEditIndex;
            cargarGrid();
        }

        protected void GVCategorias_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idcategoria = int.Parse(GVCategorias.DataKeys[e.RowIndex].Values["Id_Categoria"].ToString());
            //Recupero y creo nuevos índices de edición en función de los campos que serán editables (las columnas existentes)
            string nombre = e.NewValues["Nombre_Categoria"].ToString();
            string descripcion = e.NewValues["Descripcion"].ToString();
         
            //Recupero el Objeto Original
            Categoria_VO _categoria = BLL_Categoria.get_Categoria("@Id_Categoria", idcategoria)[0];
            //creo un nuevo objeto para enviar con los datos modificados
            Categoria_VO _categoriaAux = new Categoria_VO();
            //asignamos los valores que vamos a actualizar
            _categoriaAux.Id_Categoria = idcategoria;
            _categoriaAux.Nombre_Categoria = nombre;
            _categoriaAux.Descripcion = descripcion;


            _categoriaAux.Nombre_Categoria = _categoria.Nombre_Categoria;
            _categoriaAux.Descripcion = _categoria.Descripcion;
          

            //Configurar el Sweet Alert
            string respuesta = "";
            string titulo, msg, tipo;

            try
            {
                //invoco mi método de actualizar desde la capa BLL pasándole el nuevo objeto
                respuesta = BLL_Categoria.update_Categoria(_categoriaAux);
                //Configuración para el Sweet Alert
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    msg = respuesta;
                    tipo = "error";
                }
                else
                {
                    titulo = "Correcto!";
                    msg = respuesta;
                    tipo = "success";
                }
            }
            catch (Exception ex)
            {
                titulo = "Ops...";
                msg = ex.Message;
                tipo = "error";
            }
            //Sweet Alert
            //Reiniciar los ínidces de Edición
            GVCategorias.EditIndex = -1;
            //recargar el Grid
            cargarGrid();
        }

        protected void GVCategorias_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reinicio los ínidices de Edición
            GVCategorias.EditIndex = -1;
            //Recargo el Grid
            cargarGrid();
        }

        protected void GVCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}