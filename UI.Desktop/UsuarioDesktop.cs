using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public Usuario UsuarioActual { get; set; }

        private void Adaptar(ModoForm modo)
        {
            Modo = modo;
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    chkHabilitado.Hide();
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    chkHabilitado.Hide();
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Adaptar(modo);
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this() 
        {
            UsuarioLogic usuarioLog = new UsuarioLogic();
            try
            {
                UsuarioActual = usuarioLog.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.Adaptar(modo);
            MapearDeDatos();
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = UsuarioActual.Clave;
            this.txtUsuario.Text = UsuarioActual.NombreUsuario;
            this.txtConfirmarClave.Text = UsuarioActual.Clave;           
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();
                    UsuarioActual.State = BusinessEntity.States.New;
                }
                else
                {
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.Email = txtEmail.Text;
            }
            else if (Modo == ModoForm.Baja)
                UsuarioActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic user = new UsuarioLogic();
            try
            {
                user.Save(UsuarioActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public override bool Validar()
        {
            if (Util.Validar.isEmpty(txtClave.Text) || Util.Validar.isEmpty(txtUsuario.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtClave.Text.Length < 8)
            {
                Notificar("La clave debe tener más de 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtClave.Text != txtConfirmarClave.Text)
            {
                Notificar("La clave no coincide con su confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            
            else return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Modo == ModoForm.Baja)
            {
                GuardarCambios();
                Close();
            }
            else if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
