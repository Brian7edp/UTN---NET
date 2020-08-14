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
    public partial class InscripcionAlumnos : Form
    {
        public InscripcionAlumnos()
        {
            InitializeComponent();
            this.dgvMaterias.AutoGenerateColumns = false;
        }

        public Persona AlumnoActual { get; set; }

        public InscripcionAlumnos(Persona alumno) : this()
        {
            AlumnoActual = alumno;
            this.rdbPosibles.Checked = true;
        }

        public void ListarPosibles()
        {
            MateriaLogic ml = new MateriaLogic();
            try
            {
                this.dgvMaterias.DataSource = ml.GetPosibles(AlumnoActual);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        public void ListarInscripciones()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            try
            {
                this.dgvMaterias.DataSource = ail.GetInscripcionesAlumno(AlumnoActual);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void rdbPosibles_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbPosibles.Checked)
            {
                this.dgvMaterias.Columns["HorasOcomision"].HeaderText = "Horas Semanales";
                this.dgvMaterias.Columns["HorasOcomision"].DataPropertyName = "HSSemanales";
                this.dgvMaterias.Columns["Materia"].DataPropertyName = "Descripcion";
                this.ListarPosibles();
                this.btnInscripciones.Text = "Inscribirse";
            }
            else if (this.rdbInscriptas.Checked)
            {
                this.dgvMaterias.Columns["HorasOcomision"].HeaderText = "Comision";
                this.dgvMaterias.Columns["HorasOcomision"].DataPropertyName = null;
                this.dgvMaterias.Columns["Materia"].DataPropertyName = null;
                this.ListarInscripciones();
                this.btnInscripciones.Text = "Eliminar Inscripción";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMaterias.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
            e.RowIndex >= 0)
            {
                if (this.rdbPosibles.Checked)
                {
                    try
                    {
                        ElegirComision elegir = new ElegirComision((Business.Entities.Materia)dgvMaterias.Rows[e.RowIndex].DataBoundItem, AlumnoActual);
                        elegir.ShowDialog();
                        this.ListarPosibles();
                    }
                    catch (Exception ExcepcionManejada)
                    {
                        MessageBox.Show(ExcepcionManejada.Message);
                    }
                }
                else if (this.rdbInscriptas.Checked)
                {
                    AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
                    try
                    {
                        int ID_Inscripcion = int.Parse((((AlumnoInscripcion)dgvMaterias.Rows[e.RowIndex].DataBoundItem).ID).ToString());
                        ail.Delete(ID_Inscripcion);
                        this.ListarInscripciones();
                    }
                    catch (Exception ExcepcionManejada)
                    {
                        MessageBox.Show(ExcepcionManejada.Message);
                    }
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionLogic insc = new AlumnoInscripcionLogic();
            try
            {
                insc.confirmarInscripciones(AlumnoActual);
                if (this.rdbPosibles.Checked)
                {
                    this.ListarPosibles();
                }
                else this.ListarInscripciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar inscripciones");
            }
        }

        private void dgvMaterias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.rdbInscriptas.Checked)
            {
                foreach (DataGridViewRow row in this.dgvMaterias.Rows)
                {
                    row.Cells["HorasOcomision"].Value = ((AlumnoInscripcion)row.DataBoundItem).Curso.Comision.Descripcion;
                    row.Cells["Materia"].Value = ((AlumnoInscripcion)row.DataBoundItem).Curso.Materia.Descripcion;
                }
            }
        }
    }
}
