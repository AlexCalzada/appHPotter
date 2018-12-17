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
    public partial class frmTipoMembresia : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmTipoMembresia(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMembresia.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                return;
            }
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.InsertarNuevaSuscripcion(txtMembresia.Text);
            string mensaje = result ? "Nuevo tipo de Suscripcion creada" : "Error no se creo";
            MessageBox.Show(mensaje);

            listView1.Clear();
            if (BaseDatos == "PostgreSQL")
            {
                operaciones.CargarEnListView(listView1, @"SELECT * FROM public.""TipoSuscripcion""");
                return;
            }
            operaciones.CargarEnListView(listView1, "SELECT * FROM TipoSuscripcion");
        }

        private void btnInsertarMembresia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                return;
            }
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.InsertarSuscripcion(txtDescripcion.Text, txtFechaInicial.Text, txtFechaFinal.Text, txtPrecio.Text, txtIDMembresia.Text);
            string mensaje = result ? "Nueva Suscripcion creada" : "Error no se creo";
            MessageBox.Show(mensaje);
        }

        private void frmTipoMembresia_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "PostgreSQL")
            {
                operaciones.CargarEnListView(listView1, @"SELECT * FROM public.""TipoSuscripcion""");
                return;
            }
            operaciones.CargarEnListView(listView1, "SELECT * FROM TipoSuscripcion");
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                txtIDMembresia.Text = item.SubItems[0].Text;
            }
            else
            {
                txtIDMembresia.Text = string.Empty;
            }
        }
    }
}
