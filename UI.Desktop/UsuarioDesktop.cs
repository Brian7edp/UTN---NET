using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using Business.Logic;
using Business.Entities;
using Util;

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
            PersonaLogic pl = new PersonaLogic();
            try
            {
                this.cmbPersona.DataSource = pl.GetAll();
                this.cmbPersona.DisplayMember = "Legajo";
                this.cmbPersona.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbPersona.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Modo = modo;
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    chkHabilitado.Hide();
                    btnVerAlumnos.Hide();
                    btnVerProfesores.Hide();
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    chkHabilitado.Hide();
                    btnVerAlumnos.Hide();
                    btnVerProfesores.Hide();
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    btnVerAlumnos.Hide();
                    btnVerProfesores.Hide();
                    if (UsuarioActual.Persona.TipoPersona != Persona.TipoPersonas.Administrador)
                    {
                        checkAdmin.Hide();
                    }
                    else
                    {
                        cmbPersona.Hide();
                        label2.Hide();
                    }
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
            txtClave.Text = UsuarioActual.Clave;
            txtUsuario.Text = UsuarioActual.NombreUsuario;
            if (UsuarioActual.Persona.TipoPersona == Persona.TipoPersonas.Administrador)
            {
                checkAdmin.Checked = true;
            }
            else
            {
                foreach (Persona p in ((List<Persona>)cmbPersona.DataSource))
                {
                    if (p.ID == UsuarioActual.Persona.ID)
                    {
                        this.cmbPersona.SelectedItem = p;
                        break;
                    }
                }
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    UsuarioActual = new Usuario();
                    UsuarioActual.State = BusinessEntity.States.New;
                    if (checkAdmin.Checked)
                    {
                        PersonaDesktop form = new PersonaDesktop(ModoForm.Alta, Persona.TipoPersonas.Administrador);
                        form.ShowDialog();
                        if (!form.salidaPorCancelar)
                        {
                            UsuarioActual.Persona = form.PersonaActual;
                        }
                        else throw new Exception ("Registro cancelado");

                    }
                    else UsuarioActual.Persona = (Business.Entities.Persona)cmbPersona.SelectedItem;
                }
                else
                {
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Clave = txtClave.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                if (UsuarioActual.Persona.TipoPersona != Persona.TipoPersonas.Administrador)
                {
                    UsuarioActual.Persona = (Business.Entities.Persona)cmbPersona.SelectedItem;
                }
 
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
            else if (cmbPersona.SelectedItem == null && !checkAdmin.Checked)
            {
                Notificar("Debe seleccionar un legajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool salidaPorCancelar { get; set; }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnVerAlumnos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personas form = new Personas(Persona.TipoPersonas.Alumno);
            form.ShowDialog();
        }

        private void btnVerProfesores_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personas form = new Personas(Persona.TipoPersonas.Profesor);
            form.ShowDialog();
        }

        private void checkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkAdmin.Checked)
            {
                this.cmbPersona.Hide();
                this.label2.Hide();
            }
        }
    }
}
