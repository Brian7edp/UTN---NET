<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanel" runat="server" Height="139px">
        <asp:GridView ID="grdUsuarios" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="grdComisiones_RowCommand" ShowFooter="True">
            <Columns>
                <asp:ButtonField CommandName="editar" Text="Editar" />
                <asp:ButtonField CommandName="eliminar" Text="Eliminar" />
                <asp:TemplateField HeaderText="ID" SortExpression="ID">
                    <FooterTemplate>
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Usuario" CommandName="nuevo" />
                    </FooterTemplate>
                    <ItemTemplate>
                        <asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("Persona.TipoPersona") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Legajo">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Persona.Legajo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre" SortExpression="IDPersona">
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Persona.Apellido") %>'></asp:Label>
                        <asp:Label ID="Label6" runat="server" Text=", "></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Persona.Nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Usuario" SortExpression="NombreUsuario">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("NombreUsuario") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Habilitado">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Habilitado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>

</asp:Content>
