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
    public partial class frmActualizaMembresia : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmActualizaMembresia(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void lvMembresia_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvMembresia.SelectedItems.Count > 0)
            {
                ListViewItem item = lvMembresia.SelectedItems[0];
                txtID.Text = item.SubItems[0].Text;
                txtDescripcion.Text = item.SubItems[1].Text;
                txtPrecio.Text = item.SubItems[4].Text;
            }
            else
            {
                txtID.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtPrecio.Text = string.Empty;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("No puede dejar espacio vacios");
                return;
            }

            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.ActualizaSuscripcion(txtDescripcion.Text, txtFechaInicial.Text, txtFechaFinal.Text, txtPrecio.Text, txtID.Text);
            string mensaje = result ? $"La Suscripcion con ID: {txtID.Text}, se ha actualizado" : "Error no se pudo asignar";
            MessageBox.Show(mensaje);

            lvMembresia.Clear();
            operaciones.CargarEnListView(lvMembresia, "SELECT * FROM Suscripcion");
        }

        private void frmActualizaMembresia_Load(object sender, EventArgs e)
        {
            lvMembresia.Clear();
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            operaciones.CargarEnListView(lvMembresia, "SELECT * FROM Suscripcion");
        }
    }
}
