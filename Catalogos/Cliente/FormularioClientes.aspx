<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioClientes.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Cliente.FormularioClientes" %>
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
                    <asp:Label ID="lblnombre" runat="server" Text=""></asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtnombre" runat="server" CssClass="form-control">Nombre</asp:TextBox>

                    <asp:Label ID="lblapepat" runat="server" Text="">A.Paterno</asp:Label>
                    <asp:TextBox ID="txtapepat" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lblapemat" runat="server" Text="">A.Materno</asp:Label>
                    <asp:TextBox ID="txtapemat" runat="server" CssClass="form-control"></asp:TextBox>
 <br />
                     <br />
                    
                    

                    <div class="col-md-4">
                <h5>
                 <asp:Label ID="lblnacimiento" runat="server" Text="Fecha Nacimiento"></asp:Label>
                </h5>
                <asp:Calendar ID="calnacimiento" runat="server" OnSelectionChanged="calnacimiento_SelectionChanged"
                    
                    ></asp:Calendar>

                       </div>   



                    <asp:Label ID="lbldireccion" runat="server" Text="">Direccion</asp:Label>
                    <asp:TextBox ID="txtdireccion" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:Label ID="lbltelefono" runat="server" Text="">Telefono</asp:Label>
                    <asp:TextBox ID="txttelefono" runat="server" CssClass="form-control"></asp:TextBox>

                    

                    <asp:Label ID="lblemail" runat="server" Text="">Email</asp:Label>
                    <asp:TextBox ID="txtemail" runat="server" CssClass="form-control"></asp:TextBox>

                    

                    <asp:Button ID="btnguardar" CssClass="btn btn-primary" runat="server" Text="Guardar" OnClick="btnguardar_Click"></asp:Button>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
