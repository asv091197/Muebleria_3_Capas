using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Muebleria_3_Capas.Catalogos.Venta
{
    public partial class ListarVenta : System.Web.UI.Page
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
            GVVenta.DataSource = BLL_Venta.get_Venta();
            //Mostramos los resultado renderizando los información
            GVVenta.DataBind();
        }

        protected void GVVenta_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GVVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GVVenta_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVVenta_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVVenta_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GVVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioVenta.aspx");
        }
    }
}