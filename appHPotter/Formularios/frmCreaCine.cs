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
    public partial class frmCreaCine : Form
    {
        private object BDConnection { get; set; }
        private string BaseDatos { get; set; }
        private string Accion { get; set; }
        private string ID { get; set; }

        public frmCreaCine(string BaseDatos, object BDConnection, string Accion)
        {
            InitializeComponent();
            this.BaseDatos = BaseDatos;
            this.BDConnection = BDConnection;
            this.Accion = Accion;
            this.HabilitarBotones();
        }

        private void HabilitarBotones()
        {
            btnInsertar.Enabled = (Accion == "Insertar") ? true : false;
            btnActualizar.Enabled = (Accion == "Actualizar") ? true : false;
            btnEliminar.Enabled = (Accion == "Eliminar") ? true : false;
        }

        private void frmCreaCine_Load(object sender, EventArgs e)
        {
            MostrarRegistros();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            var mensaje = BDO.InsertarCine(txtNombre.Text, txtDescripcion.Text, txtUbicacion.Text, dateTimePicker1.Text) ?
                "Cine creado." : "Error no se creo.";
            MessageBox.Show(mensaje);
            MostrarRegistros();
        }

        private void MostrarRegistros()
        {
            lvCine.Clear();
            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            if (BaseDatos == "PostgreSQL")
            {
                BDO.CargarEnListView(lvCine, @"SELECT * FROM public.""Cine""");
                return;
            }
            BDO.CargarEnListView(lvCine, "SELECT * FROM Cine");
        }

        private void lvCine_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvCine.SelectedItems.Count > 0)
            {
                ListViewItem item = lvCine.SelectedItems[0];
                ID = item.SubItems[0].Text;
                txtNombre.Text = item.SubItems[1].Text;
                txtDescripcion.Text = item.SubItems[2].Text;
                txtUbicacion.Text = item.SubItems[3].Text;
                dateTimePicker1.Text = item.SubItems[4].Text;
            }
            else
            {
                ID = string.Empty;
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtUbicacion.Text = string.Empty;
                dateTimePicker1.Text = string.Empty;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID))
            {
                MessageBox.Show("Debe seleccionar un registro para continuar");
                return;
            }

            BDOperaciones BDO = new BDOperaciones(BaseDatos, BDConnection);
            var mensaje = BDO.ActualizaCine(txtNombre.Text, txtDescripcion.Text, txtUbicacion.Text, dateTimePicker1.Text, ID) ?
                "Datos del Cine actualizado." : "Error no se actualizo.";
            MessageBox.Show(mensaje);
            MostrarRegistros();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmEliminaRegistro f = new frmEliminaRegistro(BaseDatos, BDConnection, "Cine");
            f.Show();
        }
    }
}
