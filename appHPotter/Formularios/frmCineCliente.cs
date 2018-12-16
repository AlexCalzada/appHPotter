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
    public partial class frmCineCliente : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmCineCliente(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void frmCineCliente_Load(object sender, EventArgs e)
        {
            lvClientes.Clear();
            lvCines.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListView(lvClientes, "SELECT idCliente AS ID, Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno AS Cliente FROM Cliente");
            BDO.CargarEnListView(lvCines, "SELECT * FROM Cine");
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCliente.Text) || string.IsNullOrEmpty(txtCine.Text))
            {
                MessageBox.Show("No puede dejar campos vacios.");
                return;
            }

            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            var mensaje = BDO.InsertarCineCliente(txtCliente.Text, txtCine.Text, dateTimePicker1.Text) ?
                "Cliente asignado." : "Error no se creo.";
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

        private void lvCines_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCines.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCines.SelectedItems[0];
                txtCine.Text = item.SubItems[0].Text;
            }
            else
            {
                txtCine.Text = string.Empty;
            }
        }
    }
}
