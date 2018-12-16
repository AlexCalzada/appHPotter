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
        public bool Existe { get; set; }

        public frmIniciarSesion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion(txtUsuario.Text, txtClave.Text, cmbDB.Text, true);
            if (string.IsNullOrEmpty(cmbDB.Text))
            {
                MessageBox.Show("Error.\nNo puede dejar campos vacios.");
                return;
            }
            Formularios.frmPrincipal frmPrincipal = null;
            this.BDConnection = conexion.ObtenerConexion();
            BDOperaciones BDO = new BDOperaciones(cmbDB.Text, BDConnection);
            Existe = BDO.VerificarExistencia(txtUsuario.Text, txtClave.Text);
            if (!Existe)
            {
                MessageBox.Show("Error.\nUsuario o Clave incorrectos.");
                return;
            }
            else
            {
                MessageBox.Show($"Acceso autorizado.\nBienvenido(a), {txtUsuario.Text}.");
            }
            frmPrincipal = new Formularios.frmPrincipal(cmbDB.Text, BDConnection);
            frmPrincipal.Show();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            BDConnection = null;
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
                    Conexion conexion = new Conexion("Sin valor", "Sin valor", cmbDB.Text, false);
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
