<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdEspecialidades" runat="server" AutoGenerateColumns="False" OnRowCommand="grdEspecialidades_RowCommand" ShowFooter="True">
        <Columns>
            <asp:ButtonField CommandName="editar" Text="Editar" />
            <asp:ButtonField CommandName="eliminar" Text="Eliminar" />
            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                <EditItemTemplate>
                    <asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnAgregar" runat="server" CommandName="agregar" Text="Agregar" />
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="label1" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descripcion" SortExpression="Descripcion">
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescripcion" runat="server" Text='<%# Bind("Descripcion") %>'></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>