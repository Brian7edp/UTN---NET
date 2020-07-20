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
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            this.Adaptar(modo);
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            this.Adaptar(modo);
            MateriaLogic ml = new MateriaLogic();
            try
            {
                MateriaActual = ml.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MapearDeDatos();
        }

        public Business.Entities.Materia MateriaActual { get; set; }

        private void Adaptar(ModoForm modo)
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic();
            try
            {
                this.cmbPlan.DataSource = pl.GetAll();
                this.cmbPlan.DisplayMember = "Descripcion";
                this.cmbPlan.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbPlan.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            switch (Modo)
            {
                case ModoForm.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModoForm.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;

                case ModoForm.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearDeDatos()
        {
            this.txtHSSemanales.Text = MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = MateriaActual.HSTotales.ToString();
            this.txtDescripcion.Text = MateriaActual.Descripcion;
            this.txtID.Text = MateriaActual.ID.ToString();
            foreach (Plan p in ((List<Plan>)cmbPlan.DataSource))
            {
                if (p.ID == MateriaActual.Plan.ID)
                {
                    this.cmbPlan.SelectedItem = p;
                    break;
                }
            }
        }

        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta || Modo == ModoForm.Modificacion)
            {
                if (Modo == ModoForm.Alta)
                {
                    MateriaActual = new Business.Entities.Materia();
                    MateriaActual.State = BusinessEntity.States.New;
                }
                else
                {
                    MateriaActual.State = BusinessEntity.States.Modified;
                }
                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.HSSemanales = int.Parse(txtHSSemanales.Text);
                MateriaActual.HSTotales = int.Parse(txtHSTotales.Text);
                MateriaActual.Plan = (Business.Entities.Plan)cmbPlan.SelectedItem;
            }
            else if (Modo == ModoForm.Baja)
                MateriaActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic mate = new MateriaLogic();
            try
            {
                mate.Save(MateriaActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public override bool Validar()
        {
            if (Util.Validar.isEmpty(txtDescripcion.Text) || Util.Validar.isEmpty(txtHSSemanales.Text) || Util.Validar.isEmpty(txtHSTotales.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!int.TryParse(txtHSSemanales.Text, out int result) || !int.TryParse(txtHSTotales.Text, out int result2))
            {
                Notificar("Las horas deben estar expresadas como número", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbPlan.SelectedItem == null)
            {
                Notificar("Debe seleccionar una especialidad", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            this.Close();
        }
    }
}
