using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
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

        public static void EnsureGridViewFooter<Comision>(GridView gridView) where Comision : new()
        {
            if (gridView.DataSource != null && gridView.DataSource is IEnumerable<Comision> && (gridView.DataSource as IEnumerable<Comision>).Count() > 0)
                return;

            var emptySource = new List<Comision>();
            var blankItem = new Comision();
            emptySource.Add(blankItem);
            gridView.DataSource = emptySource;


            gridView.RowDataBound += delegate (object sender, GridViewRowEventArgs e)
            {
                if (e.Row.DataItem == (object)blankItem)
                    e.Row.Visible = false;
            };
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();
            this.grdUsuarios.DataSource = ul.GetAll();
            EnsureGridViewFooter<Usuario>(grdUsuarios);
            this.grdUsuarios.DataBind();
        }

        public int getRowID(int index)
        {
            Label labelID;
            labelID = (Label)this.grdUsuarios.Rows[index].FindControl("labelID");
            return Convert.ToInt32(labelID.Text);
        }

        protected void grdComisiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index;
            if (e.CommandName.ToLower() != "nuevo")
            {
                index = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName.ToLower() == "eliminar")
                {
                    UsuarioLogic ul = new UsuarioLogic();
                    ul.Delete(this.getRowID(index));
                }
                else if (e.CommandName.ToLower() == "editar")
                {
                    int IDUsuario = this.getRowID(index);
                    UsuarioLogic pl = new UsuarioLogic();
                    Session["Usuario"] = pl.GetOne(IDUsuario);
                    Response.Redirect("UsuarioWeb.aspx?Modo=2");
                }
            }
            else
            {
                Response.Redirect("~/UsuarioWeb.aspx?Modo=1");
            }
            this.Listar();
        }
    }
}