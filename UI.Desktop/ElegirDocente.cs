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
    public partial class ElegirDocente : ApplicationForm
    {
        public ElegirDocente(Curso cur)
        {
            InitializeComponent();
            cursoActual = cur;
            this.cmbCargo.Items.Add("Profesor");
            this.cmbCargo.Items.Add("Auxiliar");
            PersonaLogic pl = new PersonaLogic();
            try
            {
                this.cmbLegajo.DataSource = pl.GetAll(Persona.TipoPersonas.Profesor);
                this.cmbLegajo.DisplayMember = "Legajo";
                this.cmbLegajo.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbLegajo.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public Curso cursoActual { get; set; }

        public DocenteCurso docenteCursoActual { get; set; }

        private void btnLegajos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Personas form = new Personas(Persona.TipoPersonas.Profesor);
            form.ShowDialog();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void MapearADatos()
        {
            docenteCursoActual = new DocenteCurso();
            switch ((string)cmbCargo.SelectedItem)
            {
                case ("Profesor"):
                    docenteCursoActual.Cargo = DocenteCurso.TipoCargos.Profesor;
                    break;

                case ("Auxiliar"):
                    docenteCursoActual.Cargo = DocenteCurso.TipoCargos.Auxiliar;
                    break;
            }
            docenteCursoActual.Curso = cursoActual;
            docenteCursoActual.Docente = (Persona)cmbLegajo.SelectedItem;
            docenteCursoActual.State = BusinessEntity.States.New;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            try
            {
                dcl.Save(docenteCursoActual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override bool Validar()
        {
            if (cmbLegajo.SelectedItem == null || cmbLegajo.Text == "")
            {
                Notificar("Debe seleccionar un legajo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbCargo.SelectedItem == null || cmbCargo.Text == "")
            {
                Notificar("Debe seleccionar un cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else return true;
        }
    }
}
