using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Muebleria_3_Capas.Catalogos.StockVenta
{
    public partial class ListarStock : System.Web.UI.Page
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
            GVStock.DataSource = BLL_Stock_Sucursal.get_Stock_Sucursal();
            //Mostramos los resultado renderizando los información
            GVStock.DataBind();
        }

        protected void GVStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int idproducto = int.Parse(GVStock.DataKeys[e.RowIndex].Values["Id_Stock"].ToString());
            ////Invoco mi método para eliminar camiones desde la BLL
            //string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //Invoco mi método para eliminar camiones desde el servicio Web
            string respuesta = BLL_Producto.delete_Producto(idproducto);

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

        protected void GVStock_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recuperamos
                string id = GVStock.DataKeys[varIndex].Values["Id_Stock"].ToString();
                //redirecciono al formulario de edición, pasando como parámetro el ID
                Response.Redirect("FormularioStock.aspx?Id=" + id);
            }
        }
        protected void GVStock_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVStock_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVStock_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GVStock_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioStock.aspx");
        }
    }
}