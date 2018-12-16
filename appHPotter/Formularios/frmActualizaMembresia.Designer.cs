namespace appHPotter.Formularios
{
    partial class frmActualizaMembresia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvMembresia = new System.Windows.Forms.ListView();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvMembresia);
            this.groupBox1.Location = new System.Drawing.Point(263, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 198);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Suscripcion";
            // 
            // lvMembresia
            // 
            this.lvMembresia.FullRowSelect = true;
            this.lvMembresia.GridLines = true;
            this.lvMembresia.Location = new System.Drawing.Point(16, 30);
            this.lvMembresia.Name = "lvMembresia";
            this.lvMembresia.Size = new System.Drawing.Size(273, 143);
            this.lvMembresia.TabIndex = 37;
            this.lvMembresia.UseCompatibleStateImageBehavior = false;
            this.lvMembresia.View = System.Windows.Forms.View.Details;
            this.lvMembresia.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvMembresia_MouseDoubleClick);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(33, 207);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(30, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 56;
            this.label9.Text = "ID Suscripcion:";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(165, 205);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 55;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtFechaInicial
            // 
            this.txtFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaInicial.Location = new System.Drawing.Point(31, 91);
            this.txtFechaInicial.Name = "txtFechaInicial";
            this.txtFechaInicial.Size = new System.Drawing.Size(100, 20);
            this.txtFechaInicial.TabIndex = 54;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(137, 47);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecio.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 46;
            this.label5.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Fecha Inicial:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(31, 47);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtDescripcion.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Descripcion:";
            // 
            // txtFechaFinal
            // 
            this.txtFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFechaFinal.Location = new System.Drawing.Point(137, 91);
            this.txtFechaFinal.Name = "txtFechaFinal";
            this.txtFechaFinal.Size = new System.Drawing.Size(100, 20);
            this.txtFechaFinal.TabIndex = 60;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(134, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 59;
            this.label2.Text = "Fecha Final:";
            // 
            // frmActualizaMembresia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtFechaInicial);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Name = "frmActualizaMembresia";
            this.Text = "frmActualizaSuscripcion";
            this.Load += new System.EventHandler(this.frmActualizaMembresia_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvMembresia;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker txtFechaInicial;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFechaFinal;
        private System.Windows.Forms.Label label2;
    }
}