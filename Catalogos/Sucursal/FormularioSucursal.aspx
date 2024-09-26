<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioSucursal.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Sucursal.FormularioSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
        <div class="row">
            <asp:Label ID="Titulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <asp:Label ID="Subtitulo" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        </div>

        <div class="row">
            <div class="col-md-12">
                <%--Formulario--%>
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="lblnombre" runat="server" Text="">Nombre</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lbldireccion" runat="server" Text="">Direccion</asp:Label>
                    <asp:TextBox ID="txtdireccion" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lbltelefono" runat="server" Text="">Telefono</asp:Label>
                    <asp:TextBox ID="txttelefono" runat="server" CssClass="form-control"></asp:TextBox>


                    

                    <asp:Button ID="btnguardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnguardar_Click"></asp:Button>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
