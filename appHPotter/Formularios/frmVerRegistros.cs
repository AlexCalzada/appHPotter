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
    public partial class frmVerRegistros : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }

        public frmVerRegistros(string BaseDatos, object BDConnection)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "PostgreSQL")
            {
                BDO.CargarEnListView(listView1, @"SELECT * FROM public.""Cliente");
                return;
            }
            BDO.CargarEnListView(listView1, "SELECT * FROM Cliente");
        }

        private void verClientesConUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "Access")
            {
                BDO.CargarEnListView(listView1, Consultas.accessClienteUsuario);
                return;
            }
            if (BaseDatos == "PostgreSQL")
            {
                BDO.CargarEnListView(listView1, Consultas.postqClienteUsuario);
                return;
            }
            BDO.CargarEnListView(listView1, Consultas.sqlClienteUsuario);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "Access")
            {
                BDO.CargarEnListView(listView1, Consultas.accessClienteSuscripcion);
                return;
            }
            if (BaseDatos == "PostgreSQL")
            {
                BDO.CargarEnListView(listView1, Consultas.postqClienteSuscripcion);
                return;
            }
            BDO.CargarEnListView(listView1, Consultas.sqlClienteSuscripcion);
        }

        private void frmVerRegistros_Load(object sender, EventArgs e)
        {

        }

        private void verClientesConCineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "Access")
            {
                BDO.CargarEnListView(listView1, Consultas.accessClienteCine);
                return;
            }
            if (BaseDatos == "PostgreSQL")
            {
                BDO.CargarEnListView(listView1, Consultas.postqClienteCine);
                return;
            }
            BDO.CargarEnListView(listView1, Consultas.sqlClienteCine);
        }
    }
}
