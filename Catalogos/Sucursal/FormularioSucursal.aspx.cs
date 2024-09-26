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
    public partial class FormularioSucursal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar si voy a insertar o a editar
                if (Request.QueryString["ID"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Sucursal";
                    Subtitulo.Text = "Registro de un nueva sucursal";

                }
                else
                {
                    //Voy a actualizar
                    //Recupero el ID que proviene de la URL/petíción
                    int _id = Convert.ToInt32(Request.QueryString["ID"]);
                    //Obtener el Objeto original de la BD y colocar los valores en sus campos coreespondientes
                    Sucursal_VO _sucursal_original = BLL_Sucursal.get_Sucursal("@Id_sucursal", _id)[0];
                    //valido que realmente obtenga un objeto, de lo contrario me regreso al lsitado
                    if (_sucursal_original.Id_Sucursal != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Camión";
                        Subtitulo.Text = $"Modificar los datos del Proveedor #{_id}";
                        lblnombre.Text = _sucursal_original.Nombre_sucursal;
                        lbldireccion.Text = _sucursal_original.Direccion;
                        lbltelefono.Text = _sucursal_original.Telefono;
                      

                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("listaSucursal.aspx");
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
                Sucursal_VO _sucursal_aux = new Sucursal_VO();
                _sucursal_aux.Nombre_sucursal = txtnombre.Text;
                _sucursal_aux.Direccion = txtdireccion.Text;
                _sucursal_aux.Telefono = txtnombre.Text;
                


                Sucursal_VO _sucursal_aux2 = new Sucursal_VO
                {
                    Nombre_sucursal = txtnombre.Text,
                    Direccion = txtdireccion.Text,
                    Telefono = txttelefono.Text
                    

                };

                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar
                    // _proveedor_aux.Disponibilidad = true;
                    salida = BLL_Sucursal.insertar_Sucursal(_sucursal_aux);
                }
                else
                {
                    //Actualizar
                    _sucursal_aux.Id_Sucursal = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Sucursal.update_Sucursal(_sucursal_aux);
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
