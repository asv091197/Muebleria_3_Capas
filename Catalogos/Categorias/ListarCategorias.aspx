<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarCategorias.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Categorias.ListarCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h3>Lista de Categorias</h3>
            <%--Botón de Agregar--%>
            <p>
                <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click"/>
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVCategorias" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="Id_Categoria"
                OnRowDeleting="GVCategorias_RowDeleting"
                OnRowCommand="GVCategorias_RowCommand"
                OnRowEditing="GVCategorias_RowEditing"
                OnRowUpdating="GVCategorias_RowUpdating"
                OnRowCancelingEdit="GVCategorias_RowCancelingEdit" OnSelectedIndexChanged="GVCategorias_SelectedIndexChanged">

                <Columns>
                    <asp:BoundField DataField="Id_Categoria" HeaderText="Número de Categoria" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:BoundField DataField="Nombre_Categoria" HeaderText="Categoria" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" ItemStyle-Width="85px" />

                   


                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>

            </asp:GridView>
        </div>
    </div>

</asp:Content>
