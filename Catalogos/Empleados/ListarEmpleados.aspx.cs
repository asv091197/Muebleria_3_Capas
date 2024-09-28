using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Muebleria_3_Capas.Catalogos.Empleados
{
    public partial class ListarEmpleados : System.Web.UI.Page
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
            GVEmpleados.DataSource = BLL_Empleado.get_Empleado();
            //Mostramos los resultado renderizando los información
            GVEmpleados.DataBind();
        }



        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioEmpleado.aspx");
        }

        protected void GVEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idempleado = int.Parse(GVEmpleados.DataKeys[e.RowIndex].Values["Id_Empleados"].ToString());
            ////Invoco mi método para eliminar camiones desde la BLL
            //string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //Invoco mi método para eliminar camiones desde el servicio Web
            string respuesta =  BLL_Empleado.delete_Empleado(idempleado);
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

        protected void GVEmpleados_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVEmpleados.DataKeys[varIndex].Values["Id_Empleado"].ToString();
                Response.Redirect("FormularioEmpleado.aspx?Id=" + id);
            }
        }

        protected void GVEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

      

        protected void GVEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void GVEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
         
        }
    }
}