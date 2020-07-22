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
    public partial class ComisionDesktop : ApplicationForm
    {
        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            this.Adaptar(modo);
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {

            this.Adaptar(modo);
            ComisionLogic cl = new ComisionLogic();
            try
            {
                ComisionActual = cl.GetOne(ID);
            }
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MapearDeDatos();
        }

        public Business.Entities.Comision ComisionActual { get; set; }

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
            catch (Exception e)
            {
                Notificar(e.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            this.txtAnioEspecialidad.Text = ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = ComisionActual.Descripcion;
            this.txtID.Text = ComisionActual.ID.ToString();
            foreach (Plan p in ((List<Plan>)cmbPlan.DataSource))
            {
                if (p.ID == ComisionActual.Plan.ID)
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
                    ComisionActual = new Business.Entities.Comision();
                    ComisionActual.State = BusinessEntity.States.New;
                }
                else
                {
                    ComisionActual.State = BusinessEntity.States.Modified;
                }
                ComisionActual.Descripcion = txtDescripcion.Text;
                ComisionActual.AnioEspecialidad = int.Parse(txtAnioEspecialidad.Text);
                ComisionActual.Plan = (Business.Entities.Plan)cmbPlan.SelectedItem;
            }
            else if (Modo == ModoForm.Baja)
                ComisionActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic comi = new ComisionLogic();
            try
            {
                comi.Save(ComisionActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public override bool Validar()
        {
            if (Util.Validar.isEmpty(txtDescripcion.Text) || Util.Validar.isEmpty(txtAnioEspecialidad.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!int.TryParse(txtAnioEspecialidad.Text, out int result))
            {
                Notificar("El año debe estar expresado como número", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
