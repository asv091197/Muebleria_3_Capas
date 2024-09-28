<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarStock.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.StockVenta.ListarStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


          <div class="container">
    <div class="row">
        <h3>Lista de Stock</h3>
        <%--Botón de Agregar--%>
        <p>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click"/>
        </p>
    </div>
    <div class="row">
        <asp:GridView ID="GVStock" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="Id_Stock"
            OnRowDeleting="GVStock_RowDeleting"
            OnRowCommand="GVStock_RowCommand"
            OnRowEditing="GVStock_RowEditing"
            OnRowUpdating="GVStock_RowUpdating"
            OnRowCancelingEdit="GVStock_RowCancelingEdit" OnSelectedIndexChanged="GVStock_SelectedIndexChanged">

            <Columns>
                <asp:BoundField DataField="Id_Stock" HeaderText="#" ItemStyle-Width="50px" ReadOnly="true" />

                <asp:BoundField DataField="Producto_Id" HeaderText="Producto" ItemStyle-Width="85px" />

                <asp:BoundField DataField="Sucursal_Id" HeaderText="Descripcion" ItemStyle-Width="85px" />

               <asp:BoundField DataField="Cantidad" HeaderText="Precio" ItemStyle-Width="85px" />

              
               

                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
               

                <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
            </Columns>

        </asp:GridView>
    </div>
</div>

</asp:Content>
