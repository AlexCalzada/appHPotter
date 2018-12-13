﻿using System;
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
            switch (BaseDatos)
            {
                case "SQL":
                    this.BaseDatos = BaseDatos;
                    this.BDConnection = BDConnection;
                    break;
            }

        }

        private void verClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerRegistros f = new frmVerRegistros(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();
        }

        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearCliente f = new frmCrearCliente(BaseDatos, BDConnection);
            f.MdiParent = this;
            f.Show();

        }
    }
}
