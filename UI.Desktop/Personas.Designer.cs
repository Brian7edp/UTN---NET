﻿namespace UI.Desktop
{
    partial class Personas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personas));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.tcPersonas = new System.Windows.Forms.ToolStripContainer();
            this.tlPersonas = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_nacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.tsPersonas = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.tcPersonas.ContentPanel.SuspendLayout();
            this.tcPersonas.TopToolStripPanel.SuspendLayout();
            this.tcPersonas.SuspendLayout();
            this.tlPersonas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            this.tsPersonas.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(634, 336);
            // 
            // tcPersonas
            // 
            // 
            // tcPersonas.ContentPanel
            // 
            this.tcPersonas.ContentPanel.Controls.Add(this.tlPersonas);
            this.tcPersonas.ContentPanel.Size = new System.Drawing.Size(949, 336);
            this.tcPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPersonas.Location = new System.Drawing.Point(0, 0);
            this.tcPersonas.Name = "tcPersonas";
            this.tcPersonas.Size = new System.Drawing.Size(949, 361);
            this.tcPersonas.TabIndex = 0;
            this.tcPersonas.Text = "toolStripContainer1";
            // 
            // tcPersonas.TopToolStripPanel
            // 
            this.tcPersonas.TopToolStripPanel.Controls.Add(this.tsPersonas);
            // 
            // tlPersonas
            // 
            this.tlPersonas.ColumnCount = 2;
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlPersonas.Controls.Add(this.dgvPersonas, 0, 0);
            this.tlPersonas.Controls.Add(this.btnSalir, 1, 1);
            this.tlPersonas.Controls.Add(this.btnActualizar, 0, 1);
            this.tlPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPersonas.Location = new System.Drawing.Point(0, 0);
            this.tlPersonas.Name = "tlPersonas";
            this.tlPersonas.RowCount = 2;
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPersonas.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlPersonas.Size = new System.Drawing.Size(949, 336);
            this.tlPersonas.TabIndex = 0;
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.AllowUserToAddRows = false;
            this.dgvPersonas.AllowUserToDeleteRows = false;
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.legajo,
            this.nombre,
            this.apellido,
            this.fecha_nacimiento,
            this.direccion,
            this.telefono,
            this.email,
            this.especialidad});
            this.tlPersonas.SetColumnSpan(this.dgvPersonas, 2);
            this.dgvPersonas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPersonas.Location = new System.Drawing.Point(3, 3);
            this.dgvPersonas.MultiSelect = false;
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.ReadOnly = true;
            this.dgvPersonas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonas.Size = new System.Drawing.Size(943, 301);
            this.dgvPersonas.TabIndex = 0;
            this.dgvPersonas.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPersonas_DataBindingComplete);
            // 
            // id
            // 
            this.id.DataPropertyName = "ID";
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // legajo
            // 
            this.legajo.DataPropertyName = "Legajo";
            this.legajo.HeaderText = "Legajo";
            this.legajo.Name = "legajo";
            this.legajo.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // apellido
            // 
            this.apellido.DataPropertyName = "Apellido";
            this.apellido.HeaderText = "Apellido";
            this.apellido.Name = "apellido";
            this.apellido.ReadOnly = true;
            // 
            // fecha_nacimiento
            // 
            this.fecha_nacimiento.DataPropertyName = "FechaNacimiento";
            this.fecha_nacimiento.HeaderText = "Fecha de Nacimiento";
            this.fecha_nacimiento.Name = "fecha_nacimiento";
            this.fecha_nacimiento.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "Direccion";
            this.direccion.HeaderText = "Dirección";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "Telefono";
            this.telefono.HeaderText = "Teléfono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // email
            // 
            this.email.DataPropertyName = "Email";
            this.email.HeaderText = "EMail";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            // 
            // especialidad
            // 
            this.especialidad.HeaderText = "Especialidad";
            this.especialidad.Name = "especialidad";
            this.especialidad.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(871, 310);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(790, 310);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // tsPersonas
            // 
            this.tsPersonas.Dock = System.Windows.Forms.DockStyle.None;
            this.tsPersonas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsPersonas.Location = new System.Drawing.Point(3, 0);
            this.tsPersonas.Name = "tsPersonas";
            this.tsPersonas.Size = new System.Drawing.Size(81, 25);
            this.tsPersonas.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(23, 22);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 22);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // Personas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 361);
            this.Controls.Add(this.tcPersonas);
            this.Name = "Personas";
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Personas_Load);
            this.tcPersonas.ContentPanel.ResumeLayout(false);
            this.tcPersonas.TopToolStripPanel.ResumeLayout(false);
            this.tcPersonas.TopToolStripPanel.PerformLayout();
            this.tcPersonas.ResumeLayout(false);
            this.tcPersonas.PerformLayout();
            this.tlPersonas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            this.tsPersonas.ResumeLayout(false);
            this.tsPersonas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripContainer tcPersonas;
        private System.Windows.Forms.TableLayoutPanel tlPersonas;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.ToolStrip tsPersonas;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_nacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn especialidad;
    }
}