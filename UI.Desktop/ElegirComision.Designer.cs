namespace UI.Desktop
{
    partial class ElegirComision
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
            this.dgvElegirComision = new System.Windows.Forms.DataGridView();
            this.colRadioButton = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AnioEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCuro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirComision)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel1.Controls.Add(this.dgvElegirComision, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnInscribirse, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.48991F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.510086F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(315, 347);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvElegirComision
            // 
            this.dgvElegirComision.AllowUserToAddRows = false;
            this.dgvElegirComision.AllowUserToDeleteRows = false;
            this.dgvElegirComision.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvElegirComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElegirComision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRadioButton,
            this.AnioEspecialidad,
            this.Comision,
            this.IDCuro});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvElegirComision, 2);
            this.dgvElegirComision.Location = new System.Drawing.Point(3, 3);
            this.dgvElegirComision.Name = "dgvElegirComision";
            this.dgvElegirComision.ReadOnly = true;
            this.dgvElegirComision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvElegirComision.Size = new System.Drawing.Size(309, 307);
            this.dgvElegirComision.TabIndex = 0;
            this.dgvElegirComision.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElegirComision_CellClick);
            this.dgvElegirComision.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvElegirComision_DataBindingComplete);
            // 
            // colRadioButton
            // 
            this.colRadioButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.colRadioButton.HeaderText = "";
            this.colRadioButton.Name = "colRadioButton";
            this.colRadioButton.ReadOnly = true;
            this.colRadioButton.Width = 5;
            // 
            // AnioEspecialidad
            // 
            this.AnioEspecialidad.HeaderText = "Año";
            this.AnioEspecialidad.Name = "AnioEspecialidad";
            this.AnioEspecialidad.ReadOnly = true;
            // 
            // Comision
            // 
            this.Comision.HeaderText = "Comisión";
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            // 
            // IDCuro
            // 
            this.IDCuro.HeaderText = "ID Curso";
            this.IDCuro.Name = "IDCuro";
            this.IDCuro.ReadOnly = true;
            this.IDCuro.Visible = false;
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInscribirse.Location = new System.Drawing.Point(152, 318);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(75, 23);
            this.btnInscribirse.TabIndex = 1;
            this.btnInscribirse.Text = "Inscribirse";
            this.btnInscribirse.UseVisualStyleBackColor = true;
            this.btnInscribirse.Click += new System.EventHandler(this.btnInscribirse_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.Location = new System.Drawing.Point(237, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ElegirComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 347);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ElegirComision";
            this.Text = "ElegirComision";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElegirComision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvElegirComision;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioEspecialidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCuro;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.Button btnCancelar;
    }
}