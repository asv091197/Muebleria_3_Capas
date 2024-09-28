<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarEmpleados.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Empleados.ListarEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container">
    <div class="row">
        <h3>Clientes</h3>
        <%--Botón de Agregar--%>
        <p>
            <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
        </p>
    </div>
    <div class="row">
        <asp:GridView ID="GVEmpleados" runat="server"
            CssClass="table table-bordered table-striped table-condensed"
            AutoGenerateColumns="false"
            DataKeyNames="Id_Empleado"
            OnRowDeleting="GVEmpleados_RowDeleting"
            OnRowCommand="GVEmpleados_RowCommand"
            OnRowEditing="GVEmpleados_RowEditing"
            OnRowUpdating="GVEmpleados_RowUpdating"
            OnRowCancelingEdit="GVEmpleados_RowCancelingEdit">

            <Columns>
                <asp:BoundField DataField="Id_Empleado" HeaderText="#" ItemStyle-Width="50px" ReadOnly="true" />

                <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-Width="85px" />

                <asp:BoundField DataField="Apellido_paterno" HeaderText="A.Paterno" ItemStyle-Width="85px" />

                <asp:BoundField DataField="Apellido_materno" HeaderText="A.Materno" ItemStyle-Width="50px" ReadOnly="true" />

                <asp:BoundField DataField="Fecha_nacimiento" HeaderText="Fecha Nacimiento" ItemStyle-Width="50px" ReadOnly="true" />

                <asp:BoundField DataField="Direccion" HeaderText="Dirección" ItemStyle-Width="85px" />

                <asp:BoundField DataField="Telefono" HeaderText="Telefono" ItemStyle-Width="85px" />
                   
                <asp:BoundField DataField="Telefono" HeaderText="Email" ItemStyle-Width="85px" />

                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                

                <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
            </Columns>

        </asp:GridView>
    </div>
</div>

</asp:Content>
