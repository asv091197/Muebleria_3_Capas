<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarVenta.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Venta.ListarVenta" %>
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
        <asp:GridView ID="GVVenta" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="Id_Venta"
            OnRowDeleting="GVVenta_RowDeleting"
            OnRowCommand="GVVenta_RowCommand"
            OnRowEditing="GVVenta_RowEditing"
            OnRowUpdating="GVVenta_RowUpdating"
            OnRowCancelingEdit="GVVenta_RowCancelingEdit" OnSelectedIndexChanged="GVVenta_SelectedIndexChanged">

            <Columns>
                <asp:BoundField DataField="Id_Venta" HeaderText="#" ItemStyle-Width="50px" ReadOnly="true" />

                <asp:BoundField DataField="Fecha_Venta" HeaderText="Fecha Venta" ItemStyle-Width="85px" />

                <asp:BoundField DataField="Cliente_Id" HeaderText="Cliente" ItemStyle-Width="85px" />

               <asp:BoundField DataField="Empleado_Id" HeaderText="Empleado" ItemStyle-Width="85px" />

              <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-Width="85px" />   
               

               
               

                <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
            </Columns>

        </asp:GridView>
    </div>
</div>


</asp:Content>
