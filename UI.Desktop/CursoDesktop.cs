﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Util;

namespace UI.Desktop
{
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public Curso CursoActual { get; set; }

        public CursoDesktop(ModoForm modo) : this()
        {
            this.Adaptar(modo);
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Adaptar(modo);
            CursoLogic cl = new CursoLogic();
            try
            {
                CursoActual = cl.GetOne(ID);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.MapearDeDatos();
        }

        private void Adaptar(ModoForm modo)
        {
            Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            try
            {
                this.cmbComision.DataSource = cl.GetAll();
                this.cmbComision.DisplayMember = "Descripcion";
                this.cmbComision.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbComision.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            this.txtCupo.Text = CursoActual.Cupo.ToString();
            this.txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            this.txtID.Text = CursoActual.ID.ToString();
            foreach (Comision c in ((List<Comision>)cmbComision.DataSource))
            {
                if (c.ID == CursoActual.Comision.ID)
                {
                    this.cmbComision.SelectedItem = c;
                    break;
                }
            }
            foreach (Materia m in ((List<Materia>)cmbMateria.DataSource))
            {
                if (m.ID == CursoActual.Materia.ID)
                {
                    this.cmbMateria.SelectedItem = m;
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
                    CursoActual = new Business.Entities.Curso();
                    CursoActual.State = BusinessEntity.States.New;
                }
                else
                {
                    CursoActual.State = BusinessEntity.States.Modified;
                }
                CursoActual.Cupo = int.Parse(txtCupo.Text);
                CursoActual.AnioCalendario = int.Parse(txtAnioCalendario.Text);
                CursoActual.Materia = (Business.Entities.Materia)cmbMateria.SelectedItem;
                CursoActual.Comision = (Business.Entities.Comision)cmbComision.SelectedItem;
            }
            else if (Modo == ModoForm.Baja)
                CursoActual.State = BusinessEntity.States.Deleted;
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cur = new CursoLogic();
            try
            {
                cur.Save(CursoActual);
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public override bool Validar()
        {
            if (Util.Validar.isEmpty(txtAnioCalendario.Text) || Util.Validar.isEmpty(txtCupo.Text))
            {
                Notificar("Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (!int.TryParse(txtAnioCalendario.Text, out int result) || !int.TryParse(txtCupo.Text, out int result2))
            {
                Notificar("El cupo y el año deben estar expresados como número", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbComision.SelectedItem == null)
            {
                Notificar("Debe seleccionar una comisión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (cmbMateria.SelectedItem == null)
            {
                Notificar("Debe seleccionar una materia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void cmbComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            MateriaLogic ml = new MateriaLogic();
            try
            {
                this.cmbMateria.DataSource = ml.GetMateriasPlan(((Business.Entities.Comision)cmbComision.SelectedItem).Plan);
                this.cmbMateria.DisplayMember = "Descripcion";
                this.cmbMateria.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.cmbMateria.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
            catch (Exception ExcepcionManejada)
            {
                Notificar(ExcepcionManejada.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
