using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Especialidades : System.Web.UI.Page
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
				if (!this.IsPostBack)
				{
					this.Listar();
				}
			}
		}

		public static void EnsureGridViewFooter<Especialidad>(GridView gridView) where Especialidad : new()
		{
			if (gridView.DataSource != null && gridView.DataSource is IEnumerable<Especialidad> && (gridView.DataSource as IEnumerable<Especialidad>).Count() > 0)
				return;

			// Si no se asignó nada a la grilla o no se generó ninguna fila, agregamos una vacía.
			var emptySource = new List<Especialidad>();
			var blankItem = new Especialidad();
			emptySource.Add(blankItem);
			gridView.DataSource = emptySource;

			// En databinding asegurarse de que la fila vacia sea invisible para ocultarla en pantalla 
			gridView.RowDataBound += delegate (object sender, GridViewRowEventArgs e)
			{
				if (e.Row.DataItem == (object)blankItem)
					e.Row.Visible = false;
			};
		}
	

		public void Listar()
		{
			EspecialidadLogic el = new EspecialidadLogic();
			try
			{
				this.grdEspecialidades.DataSource = el.GetAll();
				EnsureGridViewFooter<Especialidad>(grdEspecialidades);
				this.grdEspecialidades.DataBind();
			}
			catch (Exception e)
			{
				Response.Write(e.Message);
			}
		}

        protected void grdEspecialidades_RowCommand(object sender, GridViewCommandEventArgs e)
        {
			int index;
			if (e.CommandName.ToLower() != "agregar")
			{
				index = Convert.ToInt32(e.CommandArgument);
			}
			else index = 0;
			if (e.CommandName.ToLower() == "agregar" || e.CommandName.ToLower() == "eliminar" || e.CommandName.ToLower() == "actualizar")
			{
				Especialidad esp = new Especialidad();
				EspecialidadLogic el = new EspecialidadLogic();
				if (e.CommandName.ToLower() == "eliminar")
				{
					this.Eliminar(index, esp, el);
				}
				else if (e.CommandName.ToLower() == "actualizar")
				{
					this.Actualizar(index, esp, el);
				}
				else
				{
					this.AgregarNuevo(esp, el);
				}
				this.Listar();
			}
			else if (e.CommandName.ToLower() == "editar")
			{
				this.changeRowToEditMode(index);
			}
			else if (e.CommandName.ToLower() == "cancelar")
			{
				this.changeRowToTemplate(index);
			}
		}

		public void Eliminar(int index, Especialidad esp, EspecialidadLogic el)
		{
			esp.ID = this.getRowID(index);
			esp.State = BusinessEntity.States.Deleted;
			try
			{
				el.Save(esp);
			}
			catch (Exception ex)
			{
				Response.Write(ex.Message);
			}
		}

		public void Actualizar(int index, Especialidad esp, EspecialidadLogic el)
		{
			TextBox cajaTexto;

			cajaTexto = (TextBox)this.grdEspecialidades.Rows[index].FindControl("txtDescripcion");
			string txtDescripcion = cajaTexto.Text;
			if (Validar(txtDescripcion))
			{
				esp.ID = this.getRowID(index);
				esp.Descripcion = txtDescripcion;
				esp.State = BusinessEntity.States.Modified;
				this.changeRowToTemplate(index);
				try
				{
					el.Save(esp);
				}
				catch (Exception ex)
				{
					Response.Write(ex.Message);
				}
			}
			else this.grdEspecialidades.EditIndex = -1;
		}

		public void AgregarNuevo(Especialidad esp, EspecialidadLogic el)
		{
			TextBox cajaTexto;
			cajaTexto = (TextBox)this.grdEspecialidades.FooterRow.FindControl("txtDescripcion");
			string txtDescripcion = cajaTexto.Text;
			if (Validar(txtDescripcion))
			{
				esp.Descripcion = txtDescripcion;
				esp.State = BusinessEntity.States.New;
				try
				{
					el.Save(esp);
				}
				catch (Exception ex)
				{
					Response.Write(ex.Message);
				}
			}
		}

		public void changeRowToEditMode(int index)
		{
			this.grdEspecialidades.EditIndex = index;
			this.Listar();
			LinkButton btn;
			btn = this.grdEspecialidades.Rows[index].Cells[0].Controls[0] as LinkButton;
			btn.Text = "Actualizar";
			btn.CommandName = "Actualizar";
			btn = this.grdEspecialidades.Rows[index].Cells[1].Controls[0] as LinkButton;
			btn.Text = "Cancelar";
			btn.CommandName = "Cancelar";
		}

		public void changeRowToTemplate(int index)
		{
			this.grdEspecialidades.EditIndex = -1;
			this.Listar();
			LinkButton btn;
			btn = this.grdEspecialidades.Rows[index].Cells[0].Controls[0] as LinkButton;
			btn.Text = "Editar";
			btn.CommandName = "Editar";
			btn = this.grdEspecialidades.Rows[index].Cells[1].Controls[0] as LinkButton;
			btn.Text = "Eliminar";
			btn.CommandName = "Eliminar";
		}

		public int getRowID(int index)
		{
			Label labelID;
			labelID = (Label)this.grdEspecialidades.Rows[index].FindControl("labelID");
			return Convert.ToInt32(labelID.Text);
		}

		public bool Validar(string txtDescripcion)
		{
			if (Util.Validar.isEmpty(txtDescripcion))
			{
				Response.Write("Cambios no guardados: Campos vacíos");
				return false;
			}
			else return true;
		}


	}
}