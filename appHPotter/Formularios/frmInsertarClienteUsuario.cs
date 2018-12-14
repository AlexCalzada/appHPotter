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
    public partial class frmInsertarClienteUsuario : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmInsertarClienteUsuario(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            var mensaje = BDO.InsertarClienteUsuario(txtCliente.Text, txtUsuario.Text, txtFechaAlta.Text, txtFechaBaja.Text) ?
                "Cliente creado." : "Error no se creo.";
            MessageBox.Show(mensaje);
        }

        private void frmInsertarClienteUsuario_Load(object sender, EventArgs e)
        {
            lvClientes.Clear();
            lvUsuario.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListViewSql(lvClientes, "SELECT idCliente AS ID, Nombre + ' ' + ApellidoPaterno + ' ' + ApellidoMaterno AS Cliente FROM Cliente");
            BDO.CargarEnListViewSql(lvUsuario, "SELECT idUsuario AS ID, Usuario FROM Usuario");
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

        private void lvUsuario_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvUsuario.SelectedItems.Count > 0)
            {
                ListViewItem item = lvUsuario.SelectedItems[0];
                txtUsuario.Text = item.SubItems[0].Text;
            }
            else
            {
                txtUsuario.Text = string.Empty;
            }
        }
    }
}
