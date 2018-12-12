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

namespace appHPotter
{
    public partial class frmIniciarSesion : Form
    {
        private object BDConnection { get; set; }

        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion(txtUsuario.Text, txtClave.Text, cmbDB.Text);
            switch (cmbDB.Text)
            {
                case "SQL":
                    this.BDConnection = conexion.ObtenerConexion();
                    break;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Formularios.frmCreaUsuario frm = null;
            if (BDConnection is null)
            {
                if (string.IsNullOrEmpty(cmbDB.Text))
                {
                    MessageBox.Show("Especifica una base datos");
                    return;
                }
                else
                {
                    Conexion conexion = new Conexion("Sin valor", "Sin valor", cmbDB.Text);
                    switch (cmbDB.Text)
                    {
                        case "SQL":
                            this.BDConnection = conexion.ObtenerConexion();
                            frm = new Formularios.frmCreaUsuario(cmbDB.Text, BDConnection);
                            break;
                        default:
                            break;
                    }
                }
            }
            frm.Show();
        }
    }
}
