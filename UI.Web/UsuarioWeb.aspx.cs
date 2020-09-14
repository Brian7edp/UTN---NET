using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class UsuarioWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			if (Session["user"] == null || Session["pers"] == null)
			{
				Response.Redirect("~/Login.aspx");
			}
			else if (((Persona)Session["pers"]).TipoPersona != Persona.TipoPersonas.Administrador)
			{
				Response.Redirect("~/Home.aspx");
			}
			else
			{
				SiteMapDataSource m = (SiteMapDataSource)Master.FindControl("SiteMapDataSource");
				m.SiteMapProvider = "AdminSiteMap";
				m.DataBind();
				switch (Request.QueryString["Modo"])
				{
					case ("1"):
						editMode = false;
						break;

					case ("2"):
						editMode = true;
						if (!this.IsPostBack)
						{
							this.UsuarioActual = (Usuario)Session["Usuario"];
							this.MapearDeDatos();
						}
						break;

					default:
						Response.Redirect("~/Home.aspx");
						break;
				}
			}
		}

		public bool editMode { get; set; }

		public Usuario UsuarioActual { get; set; }

		public void MapearDeDatos()
		{
			this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
			txtClave.Text = UsuarioActual.Clave;
			txtUsuario.Text = UsuarioActual.NombreUsuario;
			if (UsuarioActual.Persona.TipoPersona == Persona.TipoPersonas.Administrador)
			{
				chkAdmin.Checked = true;
			}
			else
			{
				this.ddlistLegajo.SelectedValue = UsuarioActual.Persona.ID.ToString();
			}
		}

		public void MapearADatos()
		{
			UsuarioActual = new Usuario();
			if (!editMode)
			{
				UsuarioActual.Persona = new Persona();
				UsuarioActual.State = BusinessEntity.States.New;
				if (chkAdmin.Checked)
				{
					PersonaLogic pl = new PersonaLogic();
					UsuarioActual.Persona.Nombre = txtNombre.Text;
					UsuarioActual.Persona.Apellido = txtApellido.Text;
					UsuarioActual.Persona.Direccion = txtDireccion.Text;
					UsuarioActual.Persona.Email = txtEmail.Text;
					UsuarioActual.Persona.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
					UsuarioActual.Persona.Telefono = txtTelefono.Text;
					UsuarioActual.Persona.TipoPersona = Persona.TipoPersonas.Administrador;
					UsuarioActual.Persona.State = BusinessEntity.States.New;
					try
					{
						pl.Save(UsuarioActual.Persona);
					}
					catch (Exception e)
					{
						Response.Write(e.Message);
					}
				}
				else
				{
					UsuarioActual.Persona.ID = Convert.ToInt32(ddlistLegajo.SelectedValue);
				}
			}
			else
			{
				UsuarioActual.ID = ((Usuario)Session["Usuario"]).ID;
				UsuarioActual.State = BusinessEntity.States.Modified;
			}
			UsuarioActual.Habilitado = chkHabilitado.Checked;
			UsuarioActual.Clave = txtClave.Text;
			UsuarioActual.NombreUsuario = txtUsuario.Text;
			if (!this.chkAdmin.Checked)
			{
				UsuarioActual.Persona = new Persona();
				UsuarioActual.Persona.ID = Convert.ToInt32(ddlistLegajo.SelectedValue);
			}
		}

		public void GuardarCambios()
		{
			this.MapearADatos();
			UsuarioLogic ul = new UsuarioLogic();
			try
			{
				ul.Save(UsuarioActual);
			}
			catch (Exception e)
			{
				Response.Write(e.Message);
			}
		}

		public bool Validar()
		{
			if (Util.Validar.isEmpty(txtClave.Text) || Util.Validar.isEmpty(txtUsuario.Text))
			{
				Response.Write("Campos vacíos");
				return false;
			}
			else if (txtClave.Text.Length < 8)
			{
				Response.Write("La clave debe tener más de 8 caracteres");
				return false;
			}
			else if (txtClave.Text != txtConfirmarClave.Text)
			{
				Response.Write("La clave no coincide con su confirmación");
				return false;
			}
			else if (ddlistLegajo.SelectedItem == null && !chkAdmin.Checked)
			{
				Response.Write("Debe seleccionar un legajo");
				return false;
			}
			else return true;
		}

		protected void chkAdmin_CheckedChanged(object sender, EventArgs e)
		{
			if (!editMode)
			{
				if (this.chkAdmin.Checked)
				{
					this.txtApellido.Visible = true;
					this.txtDireccion.Visible = true;
					this.txtEmail.Visible = true;
					this.txtFechaNac.Visible = true;
					this.txtNombre.Visible = true;
					this.txtTelefono.Visible = true;
					this.labelApellido.Visible = true;
					this.labelDireccion.Visible = true;
					this.labelEmail.Visible = true;
					this.labelFecha.Visible = true;
					this.labelNombre.Visible = true;
					this.labelTelefono.Visible = true;
					this.ddlistLegajo.Visible = false;
					this.btnAlumnos.Visible = false;
					this.btnProfesores.Visible = false;
					this.labelLegajo.Visible = false;
				}
				else
				{
					this.txtApellido.Visible = false;
					this.txtDireccion.Visible = false;
					this.txtEmail.Visible = false;
					this.txtFechaNac.Visible = false;
					this.txtNombre.Visible = false;
					this.txtTelefono.Visible = false;
					this.labelApellido.Visible = false;
					this.labelDireccion.Visible = false;
					this.labelEmail.Visible = false;
					this.labelFecha.Visible = false;
					this.labelNombre.Visible = false;
					this.labelTelefono.Visible = false;
					this.ddlistLegajo.Visible = true;
					this.btnAlumnos.Visible = true;
					this.btnProfesores.Visible = true;
					this.labelLegajo.Visible = true;
				}
			}
		}

        protected void btnProfesores_Click(object sender, EventArgs e)
        {

        }

        protected void btnAlumnos_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
			if (Validar())
			{
				this.GuardarCambios();
				Response.Redirect("~/Usuarios.aspx");
			}
		}

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Usuarios.aspx");
		}
    }
}