using BLL;
using Muebleria_3_Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.Producto
{
    public partial class FormularioProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_ddl();
                cargar_ddl2();
                //Validar si voy a insertar o a editar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    Titulo.Text = "Agregar Producto";
                    Subtitulo.Text = "Registro de un nuevo producto";

                }
                else
                {
                    //Voy a Actualizar
                    //recupero el ID de la URL
                    int 
                        _id = int.Parse(Request.QueryString["Id"].ToString());
                    //recupero el objeto original
                    Producto_VO _producto = BLL_Producto.get_Producto("@Id_Producto", _id)[0];
                    //valido que realmente haya recuperado 
                    if (_producto.Id_Producto != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Categoria";
                        Subtitulo.Text = $"Modificar los datos del Categoria #{_id}";
                        txtNombreProducto.Text = _producto.Nombre_Producto;
                        txtDescripcion.Text = _producto.Descripcion;
                        txtPrecio.Text = _producto.Precio.ToString();
                        ddlcategoria.SelectedValue = _producto.Categoria_Id.ToString();
                        ddlproveedor.SelectedValue = _producto.Proveedor_Id.ToString();

                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListarProductos.aspx");
                    }
                }
            }
        }


        protected void cargar_ddl()
        {
            ListItem ddlcategorias_I = new ListItem("Seleccione una categoria", "0");
            ddlcategoria.Items.Add(ddlcategorias_I);
            List<Categoria_VO> list_cat = BLL_Categoria.get_Categoria();
            if (list_cat.Count > 0)
            {
                foreach (var pro in list_cat)
                {
                    ListItem cate = new ListItem(
                        pro.Nombre_Categoria,
                        pro.Id_Categoria.ToString()
                        );
                    ddlcategoria.Items.Add(cate);
                }
            }


        }

        protected void cargar_ddl2()
        {
            ListItem ddlproveedor_I = new ListItem("Seleccione un proveedor", "0");
            ddlproveedor.Items.Add(ddlproveedor_I);
            List<Proveedor_VO> list_prov = BLL_Proveedor.get_Proveedor();
            if (list_prov.Count > 0)
            {
                foreach (var prov in list_prov)
                {
                    ListItem prove = new ListItem(
                        prov.Nombre_Proveedor,
                        prov.Id_Proveedor.ToString()
                        );
                    ddlproveedor.Items.Add(prove);
                }
            }
        }
    


            protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "", msg = " ";

            try
            {
                //Creamos el objeto que enviaremos para actualiza o insertar
                Producto_VO _producto_aux = new Producto_VO();
                _producto_aux.Nombre_Producto = txtNombreProducto.Text;
                _producto_aux.Descripcion = txtDescripcion.Text;
                _producto_aux.Precio = float.Parse(txtPrecio.Text);
                _producto_aux.Categoria_Id = int.Parse(ddlcategoria.SelectedValue);
                _producto_aux.Proveedor_Id = int.Parse(ddlproveedor.SelectedValue);



                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar

                    salida = BLL_Producto.insertar_Producto(_producto_aux);
                }
                else
                {
                    //Actualizar
                    _producto_aux.Id_Producto = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Producto.update_Producto(_producto_aux);
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
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/Categorias/ListarCategorias.aspx");
                }

            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
                sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            }
            //sweet alert

        }
    }
    }
