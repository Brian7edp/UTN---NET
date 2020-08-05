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
    public partial class DocentesCurso : Form
    {
        public DocentesCurso(Curso cur)
        {
            InitializeComponent();
            this.dgvDocentes.AutoGenerateColumns = false;
            cursoActual = cur;
            this.Listar();
        }

        public Curso cursoActual { get; set; }

        public void Listar()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            try
            {
                this.dgvDocentes.DataSource = dcl.GetAll(cursoActual);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDocentes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDocentes.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {
                DocenteCursoLogic dcl = new DocenteCursoLogic();
                try
                {
                    DocenteCurso dc = ((DocenteCurso)dgvDocentes.Rows[e.RowIndex].DataBoundItem);
                    dc.State = BusinessEntity.States.Deleted;
                    dcl.Save(dc);
                    this.Listar();
                }
                catch (Exception ExcepcionManejada)
                {
                    MessageBox.Show(ExcepcionManejada.Message);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ElegirDocente form = new ElegirDocente(cursoActual);
            form.ShowDialog();
            this.Listar();
        }

        private void dgvDocentes_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvDocentes.Rows)
            {
                row.Cells["Docente"].Value = ((DocenteCurso)row.DataBoundItem).Docente.Nombre + " " + ((DocenteCurso)row.DataBoundItem).Docente.Apellido;
            }
        }
    }
}
