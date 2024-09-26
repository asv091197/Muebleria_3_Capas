<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCategorias.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Categorias.FormularioCategorias" %>
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
                    <asp:Label ID="lblnombrecategoria" runat="server" Text="">Categoria</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtnombrecategoria" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lbldescripcion" runat="server" Text="">Descripcion</asp:Label>
                    <asp:TextBox ID="txtdescripcion" runat="server" CssClass="form-control"></asp:TextBox>

                    <br />
                    <br />
                    <asp:Button ID="btnguardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnguardar_Click"></asp:Button>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
