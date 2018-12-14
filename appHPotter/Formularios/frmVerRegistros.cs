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
            switch (BaseDatos)
            {
                case "SQL":
                    this.BaseDatos = BaseDatos;
                    this.BDConnection = BDConnection;
                    break;
            }

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListViewSql(listView1, "SELECT * FROM Cliente");
        }

        private void verClientesConUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListViewSql(listView1, "SELECT U.Usuario,C.Nombre +  ' ' + C.ApellidoPaterno AS Nombre,C.CURP,c.Telefono,cu.FechaIngreso,cu.FechaBaja,cu.Estatus FROM Cliente C INNER JOIN ClienteUsuario CU ON C.idCliente = CU.idCliente INNER JOIN Usuario U  ON U.idUsuario = CU.idUsuario");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListViewSql(listView1, "SELECT TM.Descripcion AS Membresia, c.Nombre + ' ' + c.ApellidoPaterno AS Cliente, c.Telefono, c.Calle + ', ' + c.Colonia AS Direccion,m.FechaInicial, m.FechaFinal, c.Estatus FROM Cliente C INNER JOIN ClienteMembresia CM ON C.idCliente = CM.idCliente INNER JOIN Membresia M ON M.idMembresia = CM.idMembresia INNER JOIN TipoMembresia TM ON TM.idTipoMembresia = M.idTipoMembresia");
        }
    }
}
