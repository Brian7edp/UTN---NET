<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grdPlanes" runat="server" AutoGenerateColumns="False" OnRowCommand="grdPlanes_RowCommand" ShowFooter="True">
        <Columns>
            <asp:ButtonField CommandName="Editar" Text="Editar" />
            <asp:ButtonField CommandName="Eliminar" Text="Eliminar" />
            <asp:TemplateField HeaderText="ID" SortExpression="ID">
                <EditItemTemplate>
                    <asp:Label ID="labelID" runat="server" Text='<%# Bind("ID") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnAgregar" runat="server" CommandName="Agregar" Text="Agregar" />
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
            <asp:TemplateField HeaderText="Especialidad" SortExpression="DescEspecialidad">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlistEspecialidad" runat="server" DataSourceID="ObjectDataSource2" DataTextField="Descripcion" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.EspecialidadLogic"></asp:ObjectDataSource>
                    <asp:Label ID="labelEspecialidad" runat="server" Text='<%# Bind("Especialidad.ID") %>' Visible="False"></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Descripcion" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.EspecialidadLogic"></asp:ObjectDataSource>
                </FooterTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Especialidad.Descripcion") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:ButtonField CommandName="Materias" HeaderText="Materias del Plan" Text="Ver Materias" />
        </Columns>
    </asp:GridView>
</asp:Content>
