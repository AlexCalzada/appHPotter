using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHPotter.Clases
{
    class Conexion
    {
        private string Usuario { get; set; }
        private string Clave { get; set; }
        private string BaseDatos { get; set; }
        private object BDConnection { get; set; } 

        public Conexion(string Usuario, string Clave, string BaseDatos)
        {
            this.Usuario = Usuario;
            this.Clave = Clave;
            this.BaseDatos = BaseDatos;
            VerificarConexion();
        }

        public object ObtenerConexion()
        {
            return BDConnection;
        }

        private void VerificarConexion()
        {
            try
            {
                switch (BaseDatos)
                {
                    case "SQL":
                        SqlConnection Connection = new SqlConnection($"Data Source=localhost; Initial Catalog=HPotter_DB;Trusted_Connection=True;");
                        {
                            Connection.Open();
                            if (Connection.State == ConnectionState.Open)
                            {
                                this.BDConnection = Connection;
                                System.Windows.Forms.MessageBox.Show($"Conectado a {BaseDatos}");
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show($"No se pudo establecer conexion a {BaseDatos}");
                            }
                        }
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show($"No se especifico ninguna base de datos");
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Se produjo una excepcion\n {ex}");
            }
        }
    }
}
