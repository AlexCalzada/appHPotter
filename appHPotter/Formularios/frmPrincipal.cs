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
    public partial class frmPrincipal : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmPrincipal(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerRegistros f = new frmVerRegistros(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearCliente f = new frmCrearCliente(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void clienteConUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsertarClienteUsuario f = new frmInsertarClienteUsuario(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tipoMembresiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoMembresia f = new frmTipoMembresia(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void membresiaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMembresiaCliente f = new frmMembresiaCliente(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void verMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerRegistros f = new frmVerRegistros(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmActualizaCliente f = new frmActualizaCliente(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEliminaRegistro f = new frmEliminaRegistro(BaseDatos, BDConnection, "Cliente");
            f.MdiParent = this;
            f.Show();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmActualizaMembresia f = new frmActualizaMembresia(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmEliminaRegistro f = new frmEliminaRegistro(BaseDatos, BDConnection, "Suscripcion");
            f.MdiParent = this;
            f.Show();
        }

        private void insertarUnNuevoCineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreaCine f = new frmCreaCine(BaseDatos, BDConnection, "Insertar");
            f.MdiParent = this;
            f.Show();
        }

        private void asignarCineAClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCineCliente f = new frmCineCliente(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void actualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCreaCine f = new frmCreaCine(BaseDatos, BDConnection, "Actualizar");
            f.MdiParent = this;
            f.Show();
        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmCreaCine f = new frmCreaCine(BaseDatos, BDConnection, "Eliminar");
            f.MdiParent = this;
            f.Show();
        }

        private void verCinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerRegistros f = new frmVerRegistros(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }
    }
}
