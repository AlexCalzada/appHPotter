using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHPotter.Clases
{
    class BDOperaciones
    {
        private object BDConnection { get; set; }
        public string BaseDatos { get; set; }
        public bool Result { get; set; }

        public BDOperaciones(string BaseDatos, object BDConnection)
        {
            this.BDConnection = BDConnection;
            this.BaseDatos = BaseDatos;
        }
        
        public bool CrearUsuario(string Usuario, string Clave)
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Clave))
            {
                System.Windows.Forms.MessageBox.Show("No puede dejar espacio vacios");
                return false;
            }

            bool ExisteUsuario = VerificarExistencia(Usuario);
            if (ExisteUsuario) return false; 

            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO Usuario VALUES('{Usuario}','{Clave}',2,1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool VerificarExistencia(string Usuario)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"SELECT COUNT(*) FROM Usuario WHERE Usuario = '{Usuario}'";
                var cnx = (SqlConnection)BDConnection;
                SqlCommand command = new SqlCommand(consulta, cnx);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Result = (reader.FieldCount > 0) ? true : false;
                        return Result;
                    }
                }
            }
            return Result;
        }
    }
}
