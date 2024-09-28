using BLL;
using Muebleria_3_Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.Empleados
{
    public partial class FormularioEmpleado : System.Web.UI.Page
    {
        public DateTime fecha_salida_global;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Validar si voy a insertar o a editar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Empleado";
                    Subtitulo.Text = "Registro de un nuevo empleado";

                }
                else
                {
                    //Voy a actualizar
                    //Recupero el ID que proviene de la URL/petíción
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Obtener el Objeto original de la BD y colocar los valores en sus campos coreespondientes
                    Empleado_VO _empleado_original = BLL_Empleado.get_Empleado("@Id_Empleado", _id)[0];
                    //valido que realmente obtenga un objeto, de lo contrario me regreso al lsitado
                    if (_empleado_original.Id_Empleado != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Empleado";
                        Subtitulo.Text = $"Modificar los datos del Empleado #{_id}";
                        txtnombre.Text = _empleado_original.Nombre;
                        txtapepat.Text = _empleado_original.Apellido_paterno;
                        txtapemat.Text = _empleado_original.Apellido_materno;


                        calnacimiento.SelectedDate = DateTime.Parse(_empleado_original.Fecha_nacimiento);



                        txtdireccion.Text = _empleado_original.Direccion;
                        txttelefono.Text = _empleado_original.Telefono;
                        txtemail.Text = _empleado_original.Email;

                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListarEmpleados.aspx");
                    }
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            Empleado_VO _empleado = new Empleado_VO();
            string titulo, msg, tipo, respuesta;

            try
            {
                // Asigno mis valores del formulario al objeto
                _empleado.Nombre = txtnombre.Text;
                _empleado.Apellido_paterno = txtapepat.Text;
                _empleado.Apellido_materno = txtapemat.Text;
                _empleado.Fecha_nacimiento = calnacimiento.SelectedDate.ToString("yyyy/MM/dd");


                _empleado.Direccion = txtdireccion.Text;
                _empleado.Telefono = txttelefono.Text;
                _empleado.Email = txtemail.Text;


                //valido si voy a insertar o a actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //Voy a actualziar
                    _empleado.Id_Empleado = int.Parse(Request.QueryString["Id"]);
                    respuesta = BLL_Empleado.update_Empleado(_empleado);

                }
                else
                {
                    //Voy a Insertar
                    respuesta = BLL_Empleado.insertar_Empleado(_empleado);
                }

                //Preaparo mi Sweet Alert
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Error";
                    msg = respuesta;
                    tipo = "error";
                    // sweet alert
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
                }
                else
                {
                    titulo = "Ok!";
                    msg = respuesta;
                    tipo = "success";
                    //sweet alert
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Empleados/ListarEmpleados.aspx");
                }
            }
            catch (Exception ex)
            {
                titulo = "Error";
                msg = ex.Message;
                tipo = "error";
                //sweet alert
               sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            }
        }

        protected void calnacimiento_SelectionChanged(object sender, EventArgs e)
        {
            fecha_salida_global = calnacimiento.SelectedDate;
        }
    }
}