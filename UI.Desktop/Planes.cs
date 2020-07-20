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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
            this.dgvPlanes.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            PlanLogic pl = new PlanLogic();
            try
            {
                this.dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }


        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formPlan.ShowDialog();
            Listar();
        }

        private void tsbModificar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formPlan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPlan.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPlanes.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formPlan = new PlanDesktop(ID, PlanDesktop.ModoForm.Baja);
                formPlan.ShowDialog();
                Listar();
            }
        }

        private void dgvPlanes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanes.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
           e.RowIndex >= 0)
            {
                Materias appMaterias = new Materias((Plan)dgvPlanes.Rows[e.RowIndex].DataBoundItem);
                appMaterias.Show();
            }
        }

        private void dgvPlanes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvPlanes.Rows)
            {
                row.Cells["especialidad"].Value = ((Plan)row.DataBoundItem).Especialidad.Descripcion;
            }
        }
    }
}
