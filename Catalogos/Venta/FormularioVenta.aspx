<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioVenta.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Venta.FormularioVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
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
       
        <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
<asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>

       
        <%--DLL - Drop Down List--%>
       <asp:Label ID="lblcliente" runat="server" Text="Cliente"></asp:Label>
        <asp:DropDownList ID="ddlcliente" runat="server" CssClass="form-control"></asp:DropDownList>

        <asp:Label ID="lblEmpleado" runat="server" Text="Empleado"></asp:Label>
        <asp:DropDownList ID="ddlempleado" runat="server" CssClass="form-control"></asp:DropDownList>

        <asp:Label ID="lblproducto" runat="server" Text="Producto"></asp:Label>
<asp:DropDownList ID="ddlproducto" runat="server" CssClass="form-control"></asp:DropDownList>
 
        <asp:Label ID="lblcantidad" runat="server" Text="Cantidad"></asp:Label>
<asp:TextBox ID="txtcantidad" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:Label ID="lblprecio" runat="server" Text="Precio Unitario"></asp:Label>
<asp:TextBox ID="txtprecio" runat="server" CssClass="form-control"></asp:TextBox>

            </div>
    <br />
    <br />

    <br />
    <asp:Button ID="btnGuardar" CssClass="btn btn-primary btn-sm" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
</div>

</asp:Content>
