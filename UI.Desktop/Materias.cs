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
    public partial class Materias : Form
    {
        public Materias(Plan p)
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
            planActual = p;
            this.Text = "Materias del plan: " + p.Descripcion;
        }

        public Plan planActual { get; set; }

        public void Listar()
        {
            MateriaLogic cl = new MateriaLogic();
            try
            {
                this.dgvMaterias.DataSource = cl.GetMateriasPlan(planActual);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void Materias_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActulizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMats = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formMats.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMats = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formMats.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formMats = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formMats.ShowDialog();
                Listar();
            }
        }
    }
}
