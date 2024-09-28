<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioStock.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.StockVenta.FormularioStock" %>
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
       

       
        <%--DLL - Drop Down List--%>
       <asp:Label ID="lblproducto" runat="server" Text="Producto"></asp:Label>
        <asp:DropDownList ID="ddlproducto" runat="server" CssClass="form-control"></asp:DropDownList>

        <asp:Label ID="lblsucursal" runat="server" Text="Sucursal"></asp:Label>
        <asp:DropDownList ID="ddlsucursal" runat="server" CssClass="form-control"></asp:DropDownList>
 
        <asp:Label ID="lbltotal" runat="server" Text="Total"></asp:Label>
        <asp:TextBox ID="txttotal" runat="server" CssClass="form-control"></asp:TextBox>

            </div>
    <br />
    <br />

    <br />
    <asp:Button ID="btnGuardar" CssClass="btn btn-primary btn-sm" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
</div>

</asp:Content>
