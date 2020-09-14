<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuarioWeb.aspx.cs" Inherits="UI.Web.UsuarioWeb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="labelLegajo" runat="server" Text="Legajo: "></asp:Label>
<asp:DropDownList ID="ddlistLegajo" runat="server" DataSourceID="ObjectDataSource1" DataTextField="Legajo" DataValueField="ID">
</asp:DropDownList>
<asp:LinkButton ID="btnProfesores" runat="server" OnClick="btnProfesores_Click">Ver Profesores</asp:LinkButton>
&nbsp;
<asp:LinkButton ID="btnAlumnos" runat="server" OnClick="btnAlumnos_Click">Ver Alumnos</asp:LinkButton>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="Business.Logic.PersonaLogic"></asp:ObjectDataSource>
<br />
<asp:Label ID="Label2" runat="server" Text="Usuario: "></asp:Label>
<asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label3" runat="server" Text="Clave: "></asp:Label>
<asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Confirmar Clave: "></asp:Label>
<asp:TextBox ID="txtConfirmarClave" runat="server"></asp:TextBox>
<br />
<asp:CheckBox ID="chkHabilitado" runat="server" Text="Habilitado" />
<br />
<asp:CheckBox ID="chkAdmin" runat="server" AutoPostBack="True" OnCheckedChanged="chkAdmin_CheckedChanged" Text="Conceder permisos de administrador" />
<br />
<asp:Label ID="labelNombre" runat="server" Text="Nombre: " Visible="False"></asp:Label>
<asp:TextBox ID="txtNombre" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Label ID="labelApellido" runat="server" Text="Apellido: " Visible="False"></asp:Label>
<asp:TextBox ID="txtApellido" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Label ID="labelFecha" runat="server" Text="Fecha de Nacimiento: " Visible="False"></asp:Label>
<asp:TextBox ID="txtFechaNac" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Label ID="labelDireccion" runat="server" Text="Dirección: " Visible="False"></asp:Label>
<asp:TextBox ID="txtDireccion" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Label ID="labelTelefono" runat="server" Text="Teléfono: " Visible="False"></asp:Label>
<asp:TextBox ID="txtTelefono" runat="server" style="margin-top: 0px" Visible="False"></asp:TextBox>
<br />
<asp:Label ID="labelEmail" runat="server" Text="Email: " Visible="False"></asp:Label>
<asp:TextBox ID="txtEmail" runat="server" Visible="False"></asp:TextBox>
<br />
<asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
&nbsp;
<asp:Button ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" Text="Cancelar" />
</asp:Content>