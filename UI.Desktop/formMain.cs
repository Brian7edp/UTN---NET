using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private Usuario _User;
        public Usuario User
        {
            get { return _User; }
            set { _User = value; }
        }

        private Persona _Persona;
        public Persona Pers
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }

            else
            {
                User = appLogin.user;
                PersonaLogic pl = new PersonaLogic();
                Pers = pl.GetOne(User.Persona.ID);
                switch (Pers.TipoPersona)
                {
                    case Persona.TipoPersonas.Administrador:
                        this.mnuInscripcionCursado.Visible = false;
                        break;

                    case Persona.TipoPersonas.Alumno:
                        this.mnuABMC.Visible = false;
                        break;

                    case Persona.TipoPersonas.Profesor:
                        this.mnuABMC.Visible = false;
                        this.mnuInscripcionCursado.Visible = false;
                        break;
                }
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios appUsuarios = new Usuarios();
            appUsuarios.Show();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades appEspecialidades = new Especialidades();
            appEspecialidades.Show();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas appAlumnos = new Personas(Persona.TipoPersonas.Alumno);
            appAlumnos.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas appProfesores = new Personas(Persona.TipoPersonas.Profesor);
            appProfesores.Show();
        }

        private void planesYMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes appPlanes = new Planes();
            appPlanes.Show();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones appComisiones = new Comisiones();
            appComisiones.Show();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos appCursos = new Cursos();
            appCursos.Show();
        }

        private void mnuInscripcionCursado_Click(object sender, EventArgs e)
        {
            InscripcionAlumnos appInscripcioAlumnos = new InscripcionAlumnos(Pers);
            appInscripcioAlumnos.Show();

        }
    }
}
