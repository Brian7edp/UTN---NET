<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">


<asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False"
    SelectedRowStyle-BlackColor="Black"
    SelectedRowStyle-ForeColor="White"
    DataKeyNames="ID" OnSelectedIndexChanged="GridView_SelectedIndexChanged">
    <Columns>
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Email" DataField="Email" />
        <asp:BoundField HeaderText="Usuario" DataField="Usuario" />
        <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
        <asp:BoundField HeaderText="Seleccionar" DataField="Seleccionar" />
    </Columns>
        </asp:GridView>
</asp:Panel>

    <asp:Panel ID="formPanel" Visible="false" runat="server">
        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: " ></asp:Label>
        <asp:TextBox ID="nombreTextBox" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
        <asp:TextBox ID="apellidoTextBox" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="EmailLabel" runat="server" Text="Email: "></asp:Label>
        <asp:TextBox ID="EmailTextBox" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="HabilitadoLabel" runat="server" Text="Habilitida: "></asp:Label>
        <asp:CheckBox ID="HabilitadoCheckBox" runat="server" ></asp:CheckBox>
        <br />
        <asp:Label ID="NombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
        <asp:TextBox ID="NombreUsuarioTextBox" runat="server" ></asp:TextBox>
        <br />
        <asp:Label ID="ClaveLabel" runat="server" Text="Clave: "></asp:Label>
        <asp:TextBox ID="ClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="RepetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
        <asp:TextBox ID="RepetirClaveTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="CancelarLinkButton" runat="server" OnClick="CancelarLinkButton_Click">Cancelar</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>

    
    <asp:Panel ID="gridActionsPanel" runat="server">
        <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click" > Editar</asp:LinkButton> 
        <asp:LinkButton ID="EliminarLinkButton" runat="server" OnClick="EliminarLinkButton_Click" > Eliminar</asp:LinkButton>
        <asp:LinkButton ID="NuevoLinkButton" runat="server" OnClick="NuevoLinkButton_Click" > Nuevo</asp:LinkButton>
    </asp:Panel>

 </asp:Content>
   
