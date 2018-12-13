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
    public partial class frmCrearCliente : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmCrearCliente(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            var c = BDO.InsertarCliente(txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtFecha.Text, txtCuyrp.Text, txtTelefono.Text, txtCalle.Text, txtColonia.Text) ?
                "Cliente creado." : "Error no se creo.";
            MessageBox.Show(c);
        }
    }
}
