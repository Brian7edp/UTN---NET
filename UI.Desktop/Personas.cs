﻿using System;
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
    public partial class Personas : Form
    {
        public Personas(Persona.TipoPersonas tipo)
        {
            InitializeComponent();
            tipoPersona = tipo;
            this.dgvPersonas.AutoGenerateColumns = false;
            if (tipo == Persona.TipoPersonas.Profesor)
            {
                this.Text = "Profesores";
            }
            else this.Text = "Alumnos";
        }

        protected Persona.TipoPersonas tipoPersona;

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            try
            {
                this.dgvPersonas.DataSource = pl.GetAll(tipoPersona);
            }
            catch (Exception ExcepcionManejada)
            {
                MessageBox.Show(ExcepcionManejada.Message);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop formPers = new PersonaDesktop(ApplicationForm.ModoForm.Alta, tipoPersona);
            formPers.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop formPers = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPers.ShowDialog();
                Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop formPers = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPers.ShowDialog();
                Listar();
            }
        }

        private void dgvPersonas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvPersonas.Rows)
            {
                row.Cells["especialidad"].Value = ((Persona)row.DataBoundItem).Plan.Especialidad.Descripcion;
            }
        }
    }
}

