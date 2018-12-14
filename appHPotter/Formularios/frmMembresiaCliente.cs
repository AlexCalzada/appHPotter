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
    public partial class frmMembresiaCliente : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmMembresiaCliente(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text) || string.IsNullOrEmpty(txtMembresia.Text))
            {
                MessageBox.Show("No puede dejar espacio vacios");
                return;
            }

            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.InsertarClienteMembresia(txtCliente.Text, txtMembresia.Text);
            string mensaje = result ? "Nuevo membresia asignada" : "Error no se pudo asignar";
            MessageBox.Show(mensaje);
        }

        private void lvClientes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvClientes.SelectedItems.Count > 0)
            {
                ListViewItem item = lvClientes.SelectedItems[0];
                txtCliente.Text = item.SubItems[0].Text;
            }
            else
            {
                txtCliente.Text = string.Empty;
            }
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem item = listView2.SelectedItems[0];
                txtMembresia.Text = item.SubItems[0].Text;
            }
            else
            {
                txtMembresia.Text = string.Empty;
            }
        }

        private void frmMembresiaCliente_Load(object sender, EventArgs e)
        {
            lvClientes.Clear();
            listView2.Clear();
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            operaciones.CargarEnListViewSql(lvClientes, "SELECT * FROM Cliente");
            operaciones.CargarEnListViewSql(listView2, "SELECT * FROM Membresia");
        }
    }
}
