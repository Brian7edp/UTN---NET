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
    public partial class ElegirComision : Form
    {
        public ElegirComision()
        {
            InitializeComponent();
            this.dgvElegirComision.AutoGenerateColumns = false;
        }

        public Persona AlumnoActual { get; set; }

        public ElegirComision(Materia mat, Persona alu) : this()
        {
            this.AlumnoActual = alu;
            this.Text = "Comisiones - " + mat.Descripcion;
            CursoLogic cl = new CursoLogic();
            try
            {
                this.dgvElegirComision.DataSource = cl.GetPosibles(mat);
                if (this.dgvElegirComision.Rows.Count == 0)
                {
                    this.Close();
                    throw new Exception("No se encontaron comisiones con cupo disponible");
                }
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void radioButtonChanged()
        {
            foreach (DataGridViewRow row in dgvElegirComision.Rows)
            {
                // Asegurarse de no desmarcar el radio button q el user acaba de marcar     
                if (row.Index != dgvElegirComision.CurrentCell.RowIndex)
                {
                    row.Cells[colRadioButton.Index].Value = false;
                }
            }
        }

        private void dgvElegirComision_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dgvElegirComision.Rows[e.RowIndex].Cells[colRadioButton.Index];
                cell.Value = true;
                radioButtonChanged();
            }
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            try
            {
                AlumnoInscripcion nuevaInscripcion = new AlumnoInscripcion();
                foreach (DataGridViewRow row in dgvElegirComision.Rows)
                {
                  if ((bool)row.Cells[colRadioButton.Index].Value)
                   {
                       nuevaInscripcion.Curso = new Curso();
                       nuevaInscripcion.Curso.ID = int.Parse(row.Cells["IDCurso"].Value.ToString());
                       break;
                  } 

                }
                nuevaInscripcion.Alumno = new Persona();
                nuevaInscripcion.Alumno.ID = this.AlumnoActual.ID;
                nuevaInscripcion.State = BusinessEntity.States.New;
                AlumnoInscripcionLogic inscr = new AlumnoInscripcionLogic();
                try
                {
                    inscr.Save(nuevaInscripcion);
                }
                catch (Exception ExcepcionManejada)
                {
                    MessageBox.Show(ExcepcionManejada.Message);
                }
                finally
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar una comisión", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvElegirComision_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvElegirComision.Rows)
            {
                row.Cells["AnioEspecialidad"].Value = ((Curso)row.DataBoundItem).Comision.AnioEspecialidad;
                row.Cells["Comision"].Value = ((Curso)row.DataBoundItem).Comision.Descripcion;
            }
        }
    }
}
