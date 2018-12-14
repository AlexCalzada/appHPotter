using appHPotter.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appHPotter.Formularios
{
    public partial class frmCreaUsuario : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmCreaUsuario(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (txtClave.Text != txtRepiteClave.Text)
            {
                MessageBox.Show("Las claves no coinciden");
                return;
            }
            BDOperaciones operaciones = new BDOperaciones(BaseDatos, BDConnection);
            bool result = operaciones.CrearUsuario(txtUsuario.Text, txtClave.Text);
            string mensaje = result ? "Usuario creado" : "Error no se creo";
            MessageBox.Show(mensaje);
        }

        private void frmCreaUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}
