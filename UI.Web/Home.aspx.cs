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
	public partial class Home : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (Session["user"] == null && Session["pers"] == null)
			{
				Response.Redirect("~/Login.aspx");
			}
			else
			{
				Persona p = (Persona)Session["pers"];
				SiteMapDataSource m = (SiteMapDataSource)Master.FindControl("SiteMapDataSource");
				switch (p.TipoPersona)
				{
					case (Persona.TipoPersonas.Administrador):
						m.SiteMapProvider = "AdminSiteMap";
						break;

					case (Persona.TipoPersonas.Alumno):
						m.SiteMapProvider = "AluSiteMap";
						break;

					case (Persona.TipoPersonas.Profesor):
						m.SiteMapProvider = "DocenteSiteMap";
						break;
				}
				m.DataBind();
			}
		}
	}
}