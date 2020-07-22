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
    }
}
