using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Muebleria_3_Capas.Utilidades;
using VO;

namespace Muebleria_3_Capas.Catalogos.Cliente
{
    public partial class FormularioClientes : System.Web.UI.Page
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
                    Titulo.Text = "Agregar Cliente";
                    Subtitulo.Text = "Registro de un nuevo cliente";

                }
                else
                {
                    //Voy a actualizar
                    //Recupero el ID que proviene de la URL/petíción
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //Obtener el Objeto original de la BD y colocar los valores en sus campos coreespondientes
                    Cliente_VO _cliente_original = BLL_Cliente.get_Cliente("@Id_Cliente", _id)[0];
                    //valido que realmente obtenga un objeto, de lo contrario me regreso al lsitado
                    if (_cliente_original.Id_Cliente != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Categoria";
                        Subtitulo.Text = $"Modificar los datos del Categoria #{_id}";
                        txtnombre.Text = _cliente_original.Nombre;
                        txtapepat.Text = _cliente_original.Apellido_paterno;
                        txtapemat.Text = _cliente_original.Apellido_materno;


                        calnacimiento.SelectedDate = DateTime.Parse(_cliente_original.Fecha_nacimiento);



                        txtdireccion.Text = _cliente_original.Direccion;
                        txttelefono.Text = _cliente_original.Telefono;
                        txtemail.Text = _cliente_original.Email;

                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListarCategorias.aspx");
                    }
                }
            }
        }

        protected void calnacimiento_SelectionChanged(object sender, EventArgs e)
        {
            fecha_salida_global = calnacimiento.SelectedDate;
             

         
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {

            Cliente_VO _cliente = new Cliente_VO();
            string titulo, msg, tipo, respuesta;

            try
            {
                // Asigno mis valores del formulario al objeto
                _cliente.Nombre = txtnombre.Text;
                _cliente.Apellido_paterno = txtapepat.Text;
                _cliente.Apellido_materno = txtapemat.Text;
                _cliente.Fecha_nacimiento = calnacimiento.SelectedDate.ToString("yyyy/MM/dd");


                _cliente.Direccion = txtdireccion.Text;
                _cliente.Telefono = txttelefono.Text;
                _cliente.Email = txtemail.Text;
              

                //valido si voy a insertar o a actualizar
                if (Request.QueryString["Id"] != null)
                {
                    //Voy a actualziar
                    _cliente.Id_Cliente = int.Parse(Request.QueryString["Id"]);
                    respuesta = BLL_Cliente.update_Cliente( _cliente );
                    
                }
                else
                {
                    //Voy a Insertar
                    respuesta = BLL_Cliente.insertar_Cliente(_cliente);
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
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Cliente/ListaClientes.aspx");
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
    }
    }
