<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProductos.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Producto.FormularioProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="row">
   
    <div class="container">
        <div class="row">
            <h3>
                <asp:Label ID="Titulo" runat="server" Text=""></asp:Label>
            </h3>
            <h4>
                <asp:Label ID="Subtitulo" runat="server" Text=""></asp:Label>
            </h4>
        </div>

        <div class="row col-md-5">
            <asp:Label ID="lblNombreProducto" runat="server" Text="Producto"></asp:Label>
            <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control"></asp:TextBox>

             <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
             <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"></asp:TextBox>

            <%--DLL - Drop Down List--%>
           <asp:Label ID="lblcategoria" runat="server" Text="Categoria"></asp:Label>
            <asp:DropDownList ID="ddlcategoria" runat="server" CssClass="form-control"></asp:DropDownList>

            <asp:Label ID="lblproveedor" runat="server" Text="Proveedor"></asp:Label>
            <asp:DropDownList ID="ddlproveedor" runat="server" CssClass="form-control"></asp:DropDownList>

                </div>
        <br />
        <br />
    
        <br />
        <asp:Button ID="btnGuardar" CssClass="btn btn-primary btn-sm" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>

</asp:Content>
