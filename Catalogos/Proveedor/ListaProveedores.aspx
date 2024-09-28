<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaProveedores.aspx.cs" Inherits="Muebleria_3_Capas.Catalogos.Proveedor.ListaProveedores" %>
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
         <asp:GridView ID="GVProveedores" runat="server"
             CssClass="table table-bordered table-striped table-condensed"
             AutoGenerateColumns="false"
             DataKeyNames="Id_Proveedor"
             OnRowDeleting="GVProveedores_RowDeleting"
             OnRowCommand="GVProveedores_RowCommand"
             OnRowEditing="GVProveedores_RowEditing"
             OnRowUpdating="GVProveedores_RowUpdating"
             OnRowCancelingEdit="GVProveedores_RowCancelingEdit" OnSelectedIndexChanged="GVProveedores_SelectedIndexChanged">

             <Columns>
                 <asp:BoundField DataField="Id_Proveedor" HeaderText="#" ItemStyle-Width="50px" ReadOnly="true" />

                 <asp:BoundField DataField="Nombre_Proveedor" HeaderText="Proveedor" ItemStyle-Width="85px" />
         

                 <asp:BoundField DataField="Direccion" HeaderText="Direccion" ItemStyle-Width="85px" />

                <asp:BoundField DataField="Telefono" HeaderText="Direccion" ItemStyle-Width="85px" />

                 <asp:BoundField DataField="Email" HeaderText="Telefono" ItemStyle-Width="85px" />

                 <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Ver Detalles" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                
                 <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />
             </Columns>

         </asp:GridView>
     </div>
 </div>

</asp:Content>
