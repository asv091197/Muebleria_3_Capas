<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaSucursal.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Sucursal.ListaSucursal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <h3>Lista de Sucursales</h3>

            <p>
               <asp:Button ID="Insertar" runat="server" Text="Agregar" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insertar_Click" />
            </p>

        </div>

        <div class="row">
            <asp:GridView ID="GVSucursales" runat="server"
                CssClass="table table-bordered table-striped table-condensed"
                AutoGenerateColumns="false"
                DataKeyNames="Id_sucursal"
                OnRowDeleting="GVSucursales_RowDeleting"
                OnRowCommand="GVSucursales_RowCommand"
                OnRowEditing="GVSucursales_RowEditing"
                OnRowUpdating="GVSucursales_RowUpdating"
                OnRowCancelingEdit="GVSucursales_RowCancelingEdit">


                <Columns>
                    <asp:BoundField DataField="Id_sucursal" HeaderText="#" ItemStyle-Width="50px" ReadOnly="true" />

                    <asp:BoundField DataField="Nombre_sucursal" HeaderText="Nombre_sucursal" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="telefono" HeaderText="Telefono" ItemStyle-Width="85px" />

                     <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
                </Columns>

                
            </asp:GridView>
        </div>
    </div>

</asp:Content>
