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
    public partial class Planes : System.Web.UI.Page
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

        public static void EnsureGridViewFooter<Plan>(GridView gridView) where Plan : new()
        {
            if (gridView.DataSource != null && gridView.DataSource is IEnumerable<Plan> && (gridView.DataSource as IEnumerable<Plan>).Count() > 0)
                return;

            // Si no se asignó nada a la grilla o no se generó ninguna fila, agregamos una vacía.
            var emptySource = new List<Plan>();
            var blankItem = new Plan();
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
            PlanLogic pl = new PlanLogic();
            this.grdPlanes.DataSource = pl.GetAll();
            EnsureGridViewFooter<Plan>(grdPlanes);
            this.grdPlanes.DataBind();
        }

        protected void grdPlanes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            if (e.CommandName.ToLower() != "agregar")
            {
                index = Convert.ToInt32(e.CommandArgument);
            }
            else index = 0;
            if (e.CommandName.ToLower() == "agregar" || e.CommandName.ToLower() == "eliminar" || e.CommandName.ToLower() == "actualizar")
            {
                Plan pla = new Plan();
                PlanLogic pl = new PlanLogic();
                if (e.CommandName.ToLower() == "eliminar")
                {
                    this.Eliminar(index, pla, pl);
                }
                else if (e.CommandName.ToLower() == "actualizar")
                {
                    this.Actualizar(index, pla, pl);
                }
                else
                {
                    this.AgregarNuevo(pla, pl);
                }
                this.Listar();
            }
            else if (e.CommandName.ToLower() == "editar")
            {
                this.changeRowToEditMode(index);
                ((DropDownList)this.grdPlanes.Rows[index].FindControl("ddlistEspecialidad")).SelectedValue =
                    ((Label)this.grdPlanes.Rows[index].FindControl("labelEspecialidad")).Text;
            }
            else if (e.CommandName.ToLower() == "cancelar")
            {
                this.changeRowToTemplate(index);
            }
            else if (e.CommandName.ToLower() == "materias")
            {
                int IDPlan = this.getRowID(index);
                PlanLogic pl = new PlanLogic();
                Session["Plan"] = pl.GetOne(IDPlan);
                Response.Write("<script> window.open('Materias.aspx'); </script>");
            }
        }

        public void Eliminar(int index, Plan pla, PlanLogic pl)
        {
            pla.ID = this.getRowID(index);
            pla.State = BusinessEntity.States.Deleted;
            try
            {
                pl.Save(pla);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        public void Actualizar(int index, Plan pla, PlanLogic pl)
        {
            TextBox cajaTexto;

            cajaTexto = (TextBox)this.grdPlanes.Rows[index].FindControl("txtDescripcion");
            string txtDescripcion = cajaTexto.Text;
            if (Validar(txtDescripcion))
            {
                pla.ID = this.getRowID(index);
                pla.Descripcion = txtDescripcion;
                DropDownList ddl = (DropDownList)this.grdPlanes.Rows[index].FindControl("ddlistEspecialidad");
                pla.Especialidad = new Especialidad();
                pla.Especialidad.ID = int.Parse(ddl.SelectedValue);
                pla.State = BusinessEntity.States.Modified;
                this.changeRowToTemplate(index);
                try
                {
                    pl.Save(pla);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else this.grdPlanes.EditIndex = -1;
        }

        public void AgregarNuevo(Plan pla, PlanLogic pl)
        {
            TextBox cajaTexto;
            cajaTexto = (TextBox)this.grdPlanes.FooterRow.FindControl("txtDescripcion");
            string txtDescripcion = cajaTexto.Text;
            if (Validar(txtDescripcion))
            {
                pla.Descripcion = txtDescripcion;
                DropDownList ddl = (DropDownList)this.grdPlanes.FooterRow.FindControl("ddlistEspecialidad");
                pla.Especialidad = new Especialidad();
                pla.Especialidad.ID = int.Parse(ddl.SelectedValue);
                pla.State = BusinessEntity.States.New;
                try
                {
                    pl.Save(pla);
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }

        public void changeRowToEditMode(int index)
        {
            this.grdPlanes.EditIndex = index;
            this.Listar();
            LinkButton btn;
            btn = this.grdPlanes.Rows[index].Cells[0].Controls[0] as LinkButton;
            btn.Text = "Actualizar";
            btn.CommandName = "Actualizar";
            btn = this.grdPlanes.Rows[index].Cells[1].Controls[0] as LinkButton;
            btn.Text = "Cancelar";
            btn.CommandName = "Cancelar";
        }

        public void changeRowToTemplate(int index)
        {
            this.grdPlanes.EditIndex = -1;
            this.Listar();
            LinkButton btn;
            btn = this.grdPlanes.Rows[index].Cells[0].Controls[0] as LinkButton;
            btn.Text = "Editar";
            btn.CommandName = "Editar";
            btn = this.grdPlanes.Rows[index].Cells[1].Controls[0] as LinkButton;
            btn.Text = "Eliminar";
            btn.CommandName = "Eliminar";
        }

        public int getRowID(int index)
        {
            Label labelID;
            labelID = (Label)this.grdPlanes.Rows[index].FindControl("labelID");
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