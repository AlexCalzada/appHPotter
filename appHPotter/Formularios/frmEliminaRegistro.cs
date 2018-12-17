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
    public partial class frmEliminaRegistro : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }
        private string Tabla { get; set; }

        public frmEliminaRegistro(string BaseDatos, object BDConnection , string Tabla)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
            this.Tabla = Tabla;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                textBox1.Text = item.SubItems[0].Text;
            }
            else
            {
                textBox1.Text = string.Empty;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No puede dejar espacio vacios");
                return;
            }

            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.EliminaRegistro(textBox1.Text, Tabla);
            string mensaje = result ? $"El registro con ID: {textBox1.Text}, se ha eliminado" : "Error no se pudo eliminar.\nEl ID que desea eliminar ya se encuentra asignado a otro registro";
            MessageBox.Show(mensaje);

            listView1.Clear();
            if (BaseDatos == "PostgreSQL")
            {
                operaciones.CargarEnListView(listView1, @"SELECT * FROM public.""" + Tabla + "");
                return;
            }
            operaciones.CargarEnListView(listView1, $"SELECT * FROM {Tabla}");
        }

        private void frmEliminaRegistro_Load(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "PostgreSQL")
            {
                operaciones.CargarEnListView(listView1, @"SELECT * FROM public.""" + Tabla + "");
                return;
            }
            operaciones.CargarEnListView(listView1, $"SELECT * FROM {Tabla}");
        }
    }
}
