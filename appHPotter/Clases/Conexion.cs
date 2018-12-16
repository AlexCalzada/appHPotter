using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
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
        private string MensajeConexion { get; set; }
        private bool CreandoUsuario { get; set; }

        public Conexion(string Usuario, string Clave, string BaseDatos, bool CreandoUsuario)
        {
            this.Usuario = Usuario;
            this.Clave = Clave;
            this.BaseDatos = BaseDatos;
            this.CreandoUsuario = CreandoUsuario;
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
                        SqlConnection ConnectionSql = new SqlConnection($"Data Source=localhost; Initial Catalog=HPotter_DB;Trusted_Connection=True;");
                        {
                            ConnectionSql.Open();
                            if (ConnectionSql.State == ConnectionState.Open)
                            {
                                this.BDConnection = ConnectionSql;
                                MensajeConexion = (CreandoUsuario) ? $"La conexion a {BaseDatos}, se establecio correctamente.\nVerificando credenciales de acceso... " : $"La conexion a {BaseDatos}, se establecio correctamente.\nAhora puede crear un usuario.";
                                System.Windows.Forms.MessageBox.Show(MensajeConexion);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show($"No se pudo establecer conexion a {BaseDatos}");
                            }
                        }
                        break;
                    case "Access":
                        OleDbConnection ConnectionAccess = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\alex_\Documents\Databases\Access\BDHPotter_Access.accdb;Persist Security Info=False;");
                        {
                            ConnectionAccess.Open();
                            if (ConnectionAccess.State == ConnectionState.Open)
                            {
                                this.BDConnection = ConnectionAccess;
                                MensajeConexion = (CreandoUsuario) ? $"La conexion a {BaseDatos}, se establecio correctamente.\nVerificando credenciales de acceso... " : $"La conexion a {BaseDatos}, se establecio correctamente.\nAhora puede crear un usuario.";
                                System.Windows.Forms.MessageBox.Show(MensajeConexion);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show($"No se pudo establecer conexion a {BaseDatos}");
                            }
                        }
                        break;
                    case "MySQL":
                        MySqlConnection ConnectionMySql = new MySqlConnection(@"Server=localhost;Database=bdhpotter_mysql;Uid=root;Pwd=;");
                        {
                            ConnectionMySql.Open();
                            if (ConnectionMySql.State == ConnectionState.Open)
                            {
                                this.BDConnection = ConnectionMySql;
                                MensajeConexion = (CreandoUsuario) ? $"La conexion a {BaseDatos}, se establecio correctamente.\nVerificando credenciales de acceso... " : $"La conexion a {BaseDatos}, se establecio correctamente.\nAhora puede crear un usuario.";
                                System.Windows.Forms.MessageBox.Show(MensajeConexion);
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show($"No se pudo establecer conexion a {BaseDatos}");
                            }
                        }
                        break;
                    case "SQLite":
                        SQLiteConnection ConnectionSQLite = new SQLiteConnection(@"Data Source=C:\Users\alex_\Documents\Databases\SQLite\HPotter.db;Version = 3");
                        {
                            ConnectionSQLite.Open();
                            if (ConnectionSQLite.State == ConnectionState.Open)
                            {
                                this.BDConnection = ConnectionSQLite;
                                MensajeConexion = (CreandoUsuario) ? $"La conexion a {BaseDatos}, se establecio correctamente.\nVerificando credenciales de acceso... " : $"La conexion a {BaseDatos}, se establecio correctamente.\nAhora puede crear un usuario.";
                                System.Windows.Forms.MessageBox.Show(MensajeConexion);
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
