using appHPotter.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appHPotter.Formularios
{
    public partial class frmActualizaCliente : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmActualizaCliente(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void frmActualizaCliente_Load(object sender, EventArgs e)
        {
            lvClientes.Clear();
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "PostgreSQL")
            {
                operaciones.CargarEnListView(lvClientes, @"SELECT * FROM public.""Cliente""");
                return;
            }
            operaciones.CargarEnListView(lvClientes, "SELECT * FROM Cliente");
        }

        private void lvClientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvClientes.SelectedItems.Count > 0)
            {
                ListViewItem item = lvClientes.SelectedItems[0];
                textBox1.Text = item.SubItems[0].Text;
                txtNombre.Text = item.SubItems[1].Text;
                txtPaterno.Text = item.SubItems[2].Text;
                txtMaterno.Text = item.SubItems[3].Text;
                txtCuyrp.Text = item.SubItems[5].Text;
                txtTelefono.Text = item.SubItems[6].Text;
                txtCalle.Text = item.SubItems[7].Text;
                txtColonia.Text = item.SubItems[8].Text;
            }
            else
            {
                textBox1.Text = string.Empty;
                textBox1.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtPaterno.Text = string.Empty;
                txtMaterno.Text = string.Empty;
                txtCuyrp.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtCalle.Text = string.Empty;
                txtColonia.Text = string.Empty;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No puede dejar espacio vacios");
                return;
            }

            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.ActualizaCliente(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtFecha.Text, txtCuyrp.Text, txtTelefono.Text, txtCalle.Text, txtColonia.Text, textBox1.Text);
            string mensaje = result ? $"El cliente con ID: {textBox1.Text}, se ha actualizado" : "Error no se pudo asignar";
            MessageBox.Show(mensaje);

            lvClientes.Clear();
            if (BaseDatos == "PostgreSQL")
            {
                operaciones.CargarEnListView(lvClientes, @"SELECT * FROM public.""Cliente""");
                return;
            }
            operaciones.CargarEnListView(lvClientes, "SELECT * FROM Cliente");
        }
    }
}
