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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null && Session["pers"] != null)
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        public Usuario user { get; set; }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            UsuarioLogic ul = new UsuarioLogic();
            user = ul.GetOne(this.Login1.UserName, this.Login1.Password);
            if (user.NombreUsuario == this.Login1.UserName && this.Login1.Password == user.Clave)
            {
                Session["user"] = user;
                Session["pers"] = user.Persona;
                Page.Response.Redirect("~/Home.aspx");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Usted es un usuario muy olvidadizo, haga memoria");
        }

        
    }
}