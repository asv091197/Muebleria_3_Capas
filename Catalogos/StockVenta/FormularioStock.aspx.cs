using BLL;
using DAL;
using Muebleria_3_Capas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VO;

namespace Muebleria_3_Capas.Catalogos.StockVenta
{
    public partial class FormularioStock : System.Web.UI.Page
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
                    Titulo.Text = "Agregar Stock";
                    Subtitulo.Text = "Registro de un nuevo stock";

                }
                else
                {
                    //Voy a Actualizar
                    //recupero el ID de la URL
                    int
                        _id = int.Parse(Request.QueryString["Id"].ToString());
                    //recupero el objeto original
                    Stock_Sucursal_VO _stock = BLL_Stock_Sucursal.get_Stock_Sucursal("@Id_Stock", _id)[0];
                    //valido que realmente haya recuperado 
                    if (_stock.Id_Stock != 0)
                    {
                        //quiere decir que si recuperé el objeto y procedo a colocar los valores
                        Titulo.Text = "Actualizar Stock";
                        Subtitulo.Text = $"Modificar los datos del Stock #{_id}";

                        ddlproducto.SelectedValue = _stock.Producto_Id.ToString();
                        ddlsucursal.SelectedValue = _stock.Sucursal_Id.ToString();
                        txttotal.Text = _stock.Cantidad.ToString();
                    }
                    else
                    {
                        ////Voy pa' tras
                        Response.Redirect("ListarStock.aspx");
                    }
                }
            }
        }

        protected void cargar_ddl()
        {
            ListItem ddlsucursal_I = new ListItem("Seleccione un sucursal", "0");
            ddlsucursal.Items.Add(ddlsucursal_I);
            List<Sucursal_VO> list_st = BLL_Sucursal.get_Sucursal();
            if (list_st.Count > 0)
            {
                foreach (var pro in list_st)
                {
                    ListItem stk = new ListItem(
                        pro.Nombre_sucursal,
                        pro.Id_Sucursal.ToString()
                        );
                    ddlsucursal.Items.Add(stk);
                }
            }


        }

        protected void cargar_ddl2()
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
                Stock_Sucursal_VO _stock_aux = new Stock_Sucursal_VO();
                
                _stock_aux.Producto_Id = int.Parse(ddlproducto.SelectedValue);
                _stock_aux.Sucursal_Id = int.Parse(ddlsucursal.SelectedValue);
                _stock_aux.Cantidad = int.Parse(txttotal.Text);



                //decido si voy a actualizar o insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Insertar

                    salida = BLL_Stock_Sucursal.insertar_Stock_Sucursal(_stock_aux);
                }
                else
                {
                    //Actualizar
                    _stock_aux.Id_Stock = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Stock_Sucursal.update_Stock_Sucursal(_stock_aux);
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
                    sweet_Alert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType(), "/Catalogos/StockVenta/ListarStock.aspx");
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