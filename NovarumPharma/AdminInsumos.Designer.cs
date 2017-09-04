namespace NovarumPharma
{
    partial class AdminInsumos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminInsumos));
            this.grupNewEdit = new System.Windows.Forms.GroupBox();
            this.cboUN = new System.Windows.Forms.ComboBox();
            this.dt = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCod_insumo = new System.Windows.Forms.TextBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.Error_Insumo = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgInsumos = new System.Windows.Forms.DataGridView();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtEdit1 = new System.Windows.Forms.Button();
            this.grupNewEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Insumo)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInsumos)).BeginInit();
            this.SuspendLayout();
            // 
            // grupNewEdit
            // 
            this.grupNewEdit.Controls.Add(this.label5);
            this.grupNewEdit.Controls.Add(this.label2);
            this.grupNewEdit.Controls.Add(this.label1);
            this.grupNewEdit.Controls.Add(this.label3);
            this.grupNewEdit.Controls.Add(this.cboUN);
            this.grupNewEdit.Controls.Add(this.dt);
            this.grupNewEdit.Controls.Add(this.txtNombre);
            this.grupNewEdit.Controls.Add(this.txtCod_insumo);
            this.grupNewEdit.Location = new System.Drawing.Point(12, 347);
            this.grupNewEdit.Name = "grupNewEdit";
            this.grupNewEdit.Size = new System.Drawing.Size(1080, 81);
            this.grupNewEdit.TabIndex = 1;
            this.grupNewEdit.TabStop = false;
            // 
            // cboUN
            // 
            this.cboUN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUN.FormattingEnabled = true;
            this.cboUN.Items.AddRange(new object[] {
            "Kg",
            "Gr",
            "Ltr",
            "Unidad"});
            this.cboUN.Location = new System.Drawing.Point(329, 49);
            this.cboUN.Name = "cboUN";
            this.cboUN.Size = new System.Drawing.Size(78, 26);
            this.cboUN.TabIndex = 28;
            // 
            // dt
            // 
            this.dt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dt.Location = new System.Drawing.Point(418, 49);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(105, 24);
            this.dt.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(415, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 16);
            this.label5.TabIndex = 27;
            this.label5.Text = "Actualizacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(326, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "UN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(77, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(80, 49);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 24);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(6, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Codigo";
            // 
            // txtCod_insumo
            // 
            this.txtCod_insumo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod_insumo.Location = new System.Drawing.Point(9, 49);
            this.txtCod_insumo.Name = "txtCod_insumo";
            this.txtCod_insumo.Size = new System.Drawing.Size(54, 24);
            this.txtCod_insumo.TabIndex = 0;
            this.txtCod_insumo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCod_insumo_KeyPress);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(8, 13);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(266, 24);
            this.txtBuscar.TabIndex = 1;
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // Error_Insumo
            // 
            this.Error_Insumo.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(830, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "Dolar U$S =";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 42);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Perpetua Titling MT", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(5, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "buscar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Perpetua Titling MT", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 32);
            this.label7.TabIndex = 5;
            this.label7.Text = "Pista de Insumos";
            // 
            // dgInsumos
            // 
            this.dgInsumos.AllowUserToAddRows = false;
            this.dgInsumos.AllowUserToDeleteRows = false;
            this.dgInsumos.AllowUserToResizeColumns = false;
            this.dgInsumos.AllowUserToResizeRows = false;
            this.dgInsumos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInsumos.Location = new System.Drawing.Point(12, 94);
            this.dgInsumos.Name = "dgInsumos";
            this.dgInsumos.RowHeadersVisible = false;
            this.dgInsumos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgInsumos.Size = new System.Drawing.Size(1080, 178);
            this.dgInsumos.TabIndex = 4;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::NovarumPharma.Properties.Resources.new_icon;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(886, 278);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(56, 55);
            this.btnNew.TabIndex = 34;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::NovarumPharma.Properties.Resources.Save_icon;
            this.btnSave.Location = new System.Drawing.Point(1010, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 55);
            this.btnSave.TabIndex = 1;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtEdit1
            // 
            this.txtEdit1.Image = global::NovarumPharma.Properties.Resources.editar_icon;
            this.txtEdit1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtEdit1.Location = new System.Drawing.Point(948, 278);
            this.txtEdit1.Name = "txtEdit1";
            this.txtEdit1.Size = new System.Drawing.Size(56, 55);
            this.txtEdit1.TabIndex = 2;
            this.txtEdit1.UseVisualStyleBackColor = true;
            // 
            // AdminInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 507);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgInsumos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grupNewEdit);
            this.Controls.Add(this.txtEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminInsumos";
            this.Text = "ovarumPharma";
            this.Load += new System.EventHandler(this.FormAdminInsumos_Load);
            this.grupNewEdit.ResumeLayout(false);
            this.grupNewEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Error_Insumo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInsumos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grupNewEdit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCod_insumo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button txtEdit1;
        private System.Windows.Forms.DateTimePicker dt;
        private System.Windows.Forms.ErrorProvider Error_Insumo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgInsumos;
        private System.Windows.Forms.ComboBox cboUN;
        private System.Windows.Forms.Button btnNew;
    }
}