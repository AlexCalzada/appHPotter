namespace appHPotter.Formularios
{
    partial class frmCineCliente
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
            this.btnAsignar = new System.Windows.Forms.Button();
            this.txtCine = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvCines = new System.Windows.Forms.ListView();
            this.lvClientes = new System.Windows.Forms.ListView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btnAsignar);
            this.groupBox1.Controls.Add(this.txtCine);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lvCines);
            this.groupBox1.Controls.Add(this.lvClientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(602, 399);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignar clientes a cine";
            // 
            // btnAsignar
            // 
            this.btnAsignar.Location = new System.Drawing.Point(369, 44);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(75, 23);
            this.btnAsignar.TabIndex = 6;
            this.btnAsignar.Text = "Asignar";
            this.btnAsignar.UseVisualStyleBackColor = true;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // txtCine
            // 
            this.txtCine.Location = new System.Drawing.Point(116, 46);
            this.txtCine.Name = "txtCine";
            this.txtCine.ReadOnly = true;
            this.txtCine.Size = new System.Drawing.Size(100, 20);
            this.txtCine.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID Cine:";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(10, 46);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCliente.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID Cliente:";
            // 
            // lvCines
            // 
            this.lvCines.FullRowSelect = true;
            this.lvCines.GridLines = true;
            this.lvCines.Location = new System.Drawing.Point(6, 238);
            this.lvCines.Name = "lvCines";
            this.lvCines.Size = new System.Drawing.Size(588, 148);
            this.lvCines.TabIndex = 1;
            this.lvCines.UseCompatibleStateImageBehavior = false;
            this.lvCines.View = System.Windows.Forms.View.Details;
            this.lvCines.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvCines_MouseDoubleClick);
            // 
            // lvClientes
            // 
            this.lvClientes.FullRowSelect = true;
            this.lvClientes.GridLines = true;
            this.lvClientes.Location = new System.Drawing.Point(6, 84);
            this.lvClientes.Name = "lvClientes";
            this.lvClientes.Size = new System.Drawing.Size(588, 148);
            this.lvClientes.TabIndex = 0;
            this.lvClientes.UseCompatibleStateImageBehavior = false;
            this.lvClientes.View = System.Windows.Forms.View.Details;
            this.lvClientes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvClientes_MouseDoubleClick);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(223, 46);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(124, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fecha:";
            // 
            // frmCineCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCineCliente";
            this.Text = "frmCineCliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCineCliente_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.TextBox txtCine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvCines;
        private System.Windows.Forms.ListView lvClientes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}