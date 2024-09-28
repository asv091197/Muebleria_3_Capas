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
    public partial class FormularioProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar si voy a insertar o a editar
                if (Request.QueryString["ID"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Camión";
                    Subtitulo.Text = "Registro de un nuevo camión";
                  
                }
                else
                {
                    //Voy a actualizar
                    //Recupero el ID que proviene de la URL/petíción
                    int _id = Convert.ToInt32(Request.QueryString["ID"]);
                    //Obtener el Objeto original de la BD y colocar los valores en sus campos coreespondientes
                    Proveedor_VO _proveedor_original = BLL_Proveedor.get_Proveedor("@Id_Proveedor",_id)[0];
                    //valido que realmente obtenga un objeto, de lo contrario me regreso al lsitado
                    if (_proveedor_original.Id_Proveedor != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Proveedor";
                        Subtitulo.Text = $"Modificar los datos del Proveedor #{_id}";
                        txtnombre.Text = _proveedor_original.Nombre_Proveedor;
                        txtdireccion.Text = _proveedor_original.Direccion;
                        txttelefono.Text = _proveedor_original.Telefono;
                        txtemail.Text = _proveedor_original.Email;
                     
                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListaProveedores.aspx");
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
                Proveedor_VO _proveedor_aux = new Proveedor_VO();
                _proveedor_aux.Nombre_Proveedor = txtnombre.Text;
                _proveedor_aux.Direccion = txtdireccion.Text;
                _proveedor_aux.Telefono = txtnombre.Text;
                _proveedor_aux.Email = txtemail.Text;
               

                Proveedor_VO _proveedor_aux2 = new Proveedor_VO
                {
                    Nombre_Proveedor = txtnombre.Text,
                    Direccion = txtdireccion.Text,
                    Telefono = txttelefono.Text,
                    Email = txtemail.Text
                   
                };

                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar
                    // _proveedor_aux.Disponibilidad = true;
                    salida = BLL_Proveedor.insertar_Proveedor(_proveedor_aux);
                }
                else
                {
                    //Actualizar
                    _proveedor_aux.Id_Proveedor = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Proveedor.update_Proveedor(_proveedor_aux);
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
