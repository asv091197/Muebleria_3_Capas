using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.Proveedor
{
    public partial class ListaProveedores : System.Web.UI.Page
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
            GVProveedores.DataSource = BLL_Proveedor.get_Proveedor();
            //Mostramos los resultado renderizando los información
            GVProveedores.DataBind();
        }
        protected void GVProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //recupero el ID del renglón efectao
            int idproveedor = int.Parse(GVProveedores.DataKeys[e.RowIndex].Values["Id_Proveedor"].ToString());
            ////Invoco mi método para eliminar camiones desde la BLL
            //string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //Invoco mi método para eliminar camiones desde el servicio Web
            string respuesta = BLL_Proveedor.delete_Proveedor(idproveedor);
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



        protected void GVProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recuperamos
                string id = GVProveedores.DataKeys[varIndex].Values["Id_Proveedor"].ToString();
                //redirecciono al formulario de edición, pasando como parámetro el ID
                Response.Redirect("FormularioProveedores.aspx?Id=" + id);
            }
        }

        protected void GVProveedores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVProveedores.EditIndex = e.NewEditIndex;
            cargarGrid();
        }

        protected void GVProveedores_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int idproveedor = int.Parse(GVProveedores.DataKeys[e.RowIndex].Values["Id_Proveedor"].ToString());
            //Recupero y creo nuevos índices de edición en función de los campos que serán editables (las columnas existentes)
            string nombre = e.NewValues["Nombre_Proveedor"].ToString();
            string direccion = e.NewValues["Direccion"].ToString();
            string telefono = e.NewValues["Telefono"].ToString();
            string email = e.NewValues["Email"].ToString();

         
            //Recupero el Objeto Original
            Proveedor_VO _proveedor = BLL_Proveedor.get_Proveedor("@Id_Proveedor", idproveedor)[0];
            //creo un nuevo objeto para enviar con los datos modificados
            Proveedor_VO _proveedorAux = new Proveedor_VO();
            //asignamos los valores que vamos a actualizar
            _proveedorAux.Id_Proveedor = idproveedor;
            _proveedorAux.Nombre_Proveedor = nombre;
            _proveedorAux.Direccion = direccion;
            _proveedorAux.Telefono = telefono;
            _proveedorAux.Email = email;
            //Asignamos los valores anteriores
         

            //Configurar el Sweet Alert
            string respuesta = "";
            string titulo, msg, tipo;

            try
            {
                //invoco mi método de actualizar desde la capa BLL pasándole el nuevo objeto
                respuesta = BLL_Proveedor.update_Proveedor(_proveedorAux);
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
            GVProveedores.EditIndex = -1;
            //recargar el Grid
            cargarGrid();
        }

        protected void GVProveedores_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVProveedores.EditIndex = -1;
            //Recargo el Grid
            cargarGrid();
        }

        protected void GVProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioProveedores.aspx");
        }
    }
}