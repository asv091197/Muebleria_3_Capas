using BLL;
using DAL;
using Muebleria_3_Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.Venta
{
    public partial class FormularioVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
                cargar_ddl();
                cargar_ddl2();
                cargar_ddl3();
                //Validar si voy a insertar o a editar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Venta";
                    Subtitulo.Text = "Registro de una venta";

                }
                else
                {
                    //Voy a Actualizar
                    //recupero el ID de la URL
                    int
                        _id = int.Parse(Request.QueryString["Id"].ToString());
                    //recupero el objeto original
                    Venta_VO _venta = BLL_Venta.get_Venta("@Id_Venta", _id)[0];
                    //valido que realmente haya recuperado 
                    if (_venta.Id_Venta != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Venta";
                        Subtitulo.Text = $"Modificar los datos del la venta #{_id}";

                        ddlcliente.SelectedValue = _venta.Cliente_Id.ToString();
                        ddlempleado.SelectedValue = _venta.Empleado_Id.ToString();
                        ddlproducto.SelectedValue = _venta.Empleado_Id.ToString();
                        txtcantidad.Text = _venta.Cantidad.ToString();
                        txtprecio.Text = _venta.Precio_Unitario.ToString();
                       // txttotal.Text = _venta.Total.ToString();
                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListarVenta.aspx");
                    }
                }
            }
        }


        protected void cargar_ddl()
        {
            ListItem ddlcategorias_I = new ListItem("Seleccione un empleado", "0");
            ddlempleado.Items.Add(ddlcategorias_I);
            List<Empleado_VO> list_cat = BLL_Empleado.get_Empleado();
            if (list_cat.Count > 0)
            {
                foreach (var pro in list_cat)
                {
                    ListItem cate = new ListItem(
                        pro.Nombre + " | " + pro.Apellido_paterno + " | " + pro.Apellido_materno,
                        pro.Id_Empleado.ToString()
                        );
                    ddlempleado.Items.Add(cate);
                }
            }


        }

        protected void cargar_ddl2()
        {
            ListItem ddlcliente_I = new ListItem("Seleccione un cliente", "0");
            ddlcliente.Items.Add(ddlcliente_I);
            List<Cliente_VO> list_prov = BLL_Cliente.get_Cliente(); 
            if (list_prov.Count > 0)
            {
                foreach (var prov in list_prov)
                {
                    ListItem prove = new ListItem(
                        prov.Nombre + " | " + prov.Apellido_paterno + " | " + prov.Apellido_materno,
                        prov.Id_Cliente.ToString()
                        );
                    ddlcliente.Items.Add(prove);
                }
            }
        }


        protected void cargar_ddl3()
        {
            ListItem ddlproduto_I = new ListItem("Seleccione un producto", "0");
            ddlproducto.Items.Add(ddlproduto_I);
            List<Producto_VO> list_prov = BLL_Producto.get_Producto();
            if (list_prov.Count > 0)
            {
                foreach (var prov in list_prov)
                {
                    ListItem prove = new ListItem(
                        prov.Nombre_Producto,
                        prov.Id_Producto.ToString()
                        );
                    ddlproducto.Items.Add(prove);
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "", msg = " ";

            try
            {
                //Creamos el objeto que enviaremos para actualiza o insertar
                Venta_VO _venta_aux = new Venta_VO();
                _venta_aux.Fecha_Venta = txtFecha.Text;
                _venta_aux.Cliente_Id = int.Parse(ddlcliente.SelectedValue);
                _venta_aux.Empleado_Id = int.Parse(ddlempleado.SelectedValue);
                _venta_aux.Producto_Id = int.Parse(ddlproducto.SelectedValue);
                _venta_aux.Cantidad = int.Parse(txtcantidad.Text);
                _venta_aux.Precio_Unitario = float.Parse(txtprecio.Text);
              //  _venta_aux.Total= float.Parse(txttotal.Text);



                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar

                    salida = BLL_Venta.insertar_Venta(_venta_aux); 
                }
                else
                {
                    //Actualizar
                    _venta_aux.Id_Venta = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Venta.update_Venta(_venta_aux); 
                }

                //preparamos la salida para cachar un error y mostrar un Sweet Alert
                if (salida.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    respuesta = salida;
                    tipo = "error";
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
                }
                else
                {
                    titulo = "Correcto";
                    respuesta = salida;
                    tipo = "success";
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Venta/ListarVenta.aspx");
                }

            }
            catch (SqlException ex)
            {
                // Capturar errores SQL, incluyendo los del trigger
                if (ex.Number == 50000) // RAISERROR en SQL Server tiene código de error 50000
                {
                    titulo = "Error en stock";
                    respuesta = "No hay suficiente stock disponible.";
                }
                else
                {
                    titulo = "Error SQL";
                    respuesta = ex.Message;
                }
                tipo = "error";
                sweet_Alert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType());
            }
            catch (Exception ex)
            {
                // Manejar otros errores
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
                sweet_Alert.Sweet_Alert(titulo, respuesta, tipo, this.Page, this.GetType());
            }
        }
        //sweet alert

    }

    }
    
