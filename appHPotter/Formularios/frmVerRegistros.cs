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
            BDO.CargarEnListView(listView1, "SELECT * FROM Cliente");
        }

        private void verClientesConUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListView(listView1, "SELECT U.Usuario,C.Nombre +  ' ' + C.ApellidoPaterno AS Nombre,C.CURP,c.Telefono,cu.FechaIngreso,cu.FechaBaja,cu.Estatus FROM Cliente C INNER JOIN ClienteUsuario CU ON C.idCliente = CU.idCliente INNER JOIN Usuario U  ON U.idUsuario = CU.idUsuario");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListView(listView1, "SELECT TM.Descripcion AS Suscripcion, c.Nombre + ' ' + c.ApellidoPaterno AS Cliente, c.Telefono, c.Calle + ', ' + c.Colonia AS Direccion,m.FechaInicial, m.FechaFinal, c.Estatus FROM Cliente C INNER JOIN ClienteSuscripcion CM ON C.idCliente = CM.idCliente INNER JOIN Suscripcion M ON M.idSuscripcion = CM.idSuscripcion INNER JOIN TipoSuscripcion TM ON TM.idTipoSuscripcion = M.idTipoSuscripcion");
        }

        private void frmVerRegistros_Load(object sender, EventArgs e)
        {

        }

        private void verClientesConCineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            BDO.CargarEnListView(listView1, "SELECT C.Nombre AS Cine, Cl.Nombre + ' ' + Cl.ApellidoPaterno + ' ' + Cl.ApellidoMaterno AS Cliente, Cl.Telefono, C.Ubicacion AS 'Ubicacion del cine', CC.FechaRegistro, CC.Estatus FROM CineCliente CC INNER JOIN Cine C ON C.idCine = CC.idCine INNER JOIN Cliente Cl ON Cl.idCliente = CC.idCliente");
        }
    }
}
