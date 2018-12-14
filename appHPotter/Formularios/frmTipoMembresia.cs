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
            switch (BaseDatos)
            {
                case "SQL":
                    this.BaseDatos = BaseDatos;
                    this.BDConnection = BDConnection;
                    break;
            }

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMembresia.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                return;
            }
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.InsertarNuevaMembresia(txtMembresia.Text);
            string mensaje = result ? "Nuevo tipo de membresia creada" : "Error no se creo";
            MessageBox.Show(mensaje);

            listView1.Clear();
            operaciones.CargarEnListViewSql(listView1, "SELECT * FROM TipoMembresia");
        }

        private void btnInsertarMembresia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtPrecio.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
                return;
            }
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.InsertarMembresia(txtDescripcion.Text, txtFechaInicial.Text, txtFechaFinal.Text, txtPrecio.Text, txtIDMembresia.Text);
            string mensaje = result ? "Nuevo membresia creada" : "Error no se creo";
            MessageBox.Show(mensaje);
        }

        private void frmTipoMembresia_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            operaciones.CargarEnListViewSql(listView1, "SELECT * FROM TipoMembresia");
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
