namespace UI.Desktop
{
    partial class InscripcionAlumnos
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rdbPosibles = new System.Windows.Forms.RadioButton();
            this.rdbInscriptas = new System.Windows.Forms.RadioButton();
            this.dgvMaterias = new System.Windows.Forms.DataGridView();
            this.btnInscripciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorasOcomision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.48742F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.51258F));
            this.tableLayoutPanel1.Controls.Add(this.rdbPosibles, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rdbInscriptas, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvMaterias, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirmar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.14286F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.85714F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(437, 370);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rdbPosibles
            // 
            this.rdbPosibles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbPosibles.AutoSize = true;
            this.rdbPosibles.Location = new System.Drawing.Point(3, 3);
            this.rdbPosibles.Name = "rdbPosibles";
            this.rdbPosibles.Size = new System.Drawing.Size(219, 34);
            this.rdbPosibles.TabIndex = 0;
            this.rdbPosibles.TabStop = true;
            this.rdbPosibles.Text = "Nueva Inscripción";
            this.rdbPosibles.UseVisualStyleBackColor = true;
            this.rdbPosibles.CheckedChanged += new System.EventHandler(this.rdbPosibles_CheckedChanged);
            // 
            // rdbInscriptas
            // 
            this.rdbInscriptas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbInscriptas.AutoSize = true;
            this.rdbInscriptas.Location = new System.Drawing.Point(228, 3);
            this.rdbInscriptas.Name = "rdbInscriptas";
            this.rdbInscriptas.Size = new System.Drawing.Size(206, 34);
            this.rdbInscriptas.TabIndex = 1;
            this.rdbInscriptas.TabStop = true;
            this.rdbInscriptas.Text = "Inscripción realizadas";
            this.rdbInscriptas.UseVisualStyleBackColor = true;
            // 
            // dgvMaterias
            // 
            this.dgvMaterias.AllowUserToAddRows = false;
            this.dgvMaterias.AllowUserToDeleteRows = false;
            this.dgvMaterias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterias.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnInscripciones,
            this.Materia,
            this.HorasOcomision,
            this.ID});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvMaterias, 2);
            this.dgvMaterias.Location = new System.Drawing.Point(3, 43);
            this.dgvMaterias.Name = "dgvMaterias";
            this.dgvMaterias.ReadOnly = true;
            this.dgvMaterias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterias.Size = new System.Drawing.Size(431, 290);
            this.dgvMaterias.TabIndex = 2;
            this.dgvMaterias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterias_CellContentClick);
            this.dgvMaterias.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMaterias_DataBindingComplete);
            // 
            // btnInscripciones
            // 
            this.btnInscripciones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.btnInscripciones.HeaderText = "";
            this.btnInscripciones.Name = "btnInscripciones";
            this.btnInscripciones.ReadOnly = true;
            this.btnInscripciones.UseColumnTextForButtonValue = true;
            this.btnInscripciones.Width = 5;
            // 
            // Materia
            // 
            this.Materia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Materia.DataPropertyName = "Descripcion";
            this.Materia.HeaderText = "Materia";
            this.Materia.Name = "Materia";
            this.Materia.ReadOnly = true;
            // 
            // HorasOcomision
            // 
            this.HorasOcomision.DataPropertyName = "HSSemanales";
            this.HorasOcomision.HeaderText = "Horas Semanales";
            this.HorasOcomision.Name = "HorasOcomision";
            this.HorasOcomision.ReadOnly = true;
            this.HorasOcomision.Width = 105;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConfirmar.AutoSize = true;
            this.btnConfirmar.Location = new System.Drawing.Point(50, 341);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(125, 23);
            this.btnConfirmar.TabIndex = 3;
            this.btnConfirmar.Text = "Confirmar inscripciones";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAceptar.Location = new System.Drawing.Point(359, 341);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // InscripcionAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 370);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InscripcionAlumnos";
            this.Text = "InscripcionAlumnos";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterias)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton rdbPosibles;
        private System.Windows.Forms.RadioButton rdbInscriptas;
        private System.Windows.Forms.DataGridView dgvMaterias;
        private System.Windows.Forms.DataGridViewButtonColumn btnInscripciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorasOcomision;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnAceptar;
    }
}