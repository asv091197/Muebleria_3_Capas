using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.Sucursal
{
    public partial class ListaSucursal : System.Web.UI.Page
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
            GVSucursales.DataSource = BLL_Sucursal.get_Sucursal();
            //Mostramos los resultado renderizando los información
            GVSucursales.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioSucursal.aspx");
        }

        protected void GVSucursales_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idsucursal = int.Parse(GVSucursales.DataKeys[e.RowIndex].Values["Id_sucursal"].ToString());
            ////Invoco mi método para eliminar camiones desde la BLL
            //string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //Invoco mi método para eliminar camiones desde el servicio Web
            string respuesta = BLL_Sucursal.delete_Sucursal(idsucursal);
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

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //defino si el comando (el click que se detecta) tiene la propiedad "Select")
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recuperamos
                string id = GVSucursales.DataKeys[varIndex].Values["Id_sucursal"].ToString();
                //redirecciono al formulario de edición, pasando como parámetro el ID
                Response.Redirect("formulariocamiones.aspx?Id=" + id);
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Careamos un nuevo índice de Edición
            GVSucursales.EditIndex = e.NewEditIndex;
            cargarGrid();
        }

        protected void GVSucursales_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recuperamos
                string id = GVSucursales.DataKeys[varIndex].Values["ID_Camion"].ToString();
                //redirecciono al formulario de edición, pasando como parámetro el ID
                Response.Redirect("FormularioSucursal.aspx?Id=" + id);
            }
        }

        protected void GVSucursales_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVSucursales.EditIndex = e.NewEditIndex;
            cargarGrid();
        }

        protected void GVSucursales_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idsucursal = int.Parse(GVSucursales.DataKeys[e.RowIndex].Values["Id_sucursal"].ToString());
            //Recupero y creo nuevos índices de edición en función de los campos que serán editables (las columnas existentes)
            string nombresucursal = e.NewValues["Nombre_sucursal"].ToString();
            string direccion = e.NewValues["Direccion"].ToString();
            string telefono = e.NewValues["telefono"].ToString();
           
            //Recupero el Objeto Original
            Sucursal_VO _sucursal = BLL_Sucursal.get_Sucursal("@Id_sucursal", idsucursal)[0];
            //creo un nuevo objeto para enviar con los datos modificados
            Sucursal_VO _sucursalAux = new Sucursal_VO();
            //asignamos los valores que vamos a actualizar
            _sucursalAux.Id_Sucursal = idsucursal;
            _sucursalAux.Nombre_sucursal = nombresucursal;
            _sucursalAux.Direccion = direccion;
            _sucursalAux.Telefono = telefono;
           

            //Configurar el Sweet Alert
            string respuesta = "";
            string titulo, msg, tipo;

            try
            {
                //invoco mi método de actualizar desde la capa BLL pasándole el nuevo objeto
                respuesta = BLL_Sucursal.update_Sucursal(_sucursalAux);
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
            GVSucursales.EditIndex = -1;
            //recargar el Grid
            cargarGrid();
        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reinicio los ínidices de Edición
            GVSucursales.EditIndex = -1;
            //Recargo el Grid
            cargarGrid();
        }

        protected void GVSucursales_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVSucursales.EditIndex = -1;
            //Recargo el Grid
            cargarGrid();
        }
    }
}