using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Muebleria_3_Capas.Catalogos.Cliente
{
    public partial class ListaClientes : System.Web.UI.Page
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
            GVClientes.DataSource = BLL_Cliente.get_Cliente();
            //Mostramos los resultado renderizando los información
            GVClientes.DataBind();
        }

        protected void GVClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idcliente = int.Parse(GVClientes.DataKeys[e.RowIndex].Values["Id_Cliente"].ToString());
            ////Invoco mi método para eliminar camiones desde la BLL
            //string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //Invoco mi método para eliminar camiones desde el servicio Web
            string respuesta = BLL_Cliente.delete_Cliente(idcliente);
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

        protected void GVClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVClientes.DataKeys[varIndex].Values["Id_cliente"].ToString();
                Response.Redirect("FormularioClientes.aspx?Id=" + id);
            }
        }

    

    protected void GVClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GVClientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVClientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void Insertar_Click(object sender, EventArgs e)
        {

        }
    }
}