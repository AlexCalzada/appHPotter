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
using System.Windows.Forms;

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

        public void CargarEnListViewSql(ListView Lista, string consulta)
        {
            SqlConnection sqlCnx = null;
            OleDbConnection accCnx = null;
            MySqlConnection mysqlCnx = null;
            SQLiteConnection sqliteCnx = null;
            switch (BaseDatos)
            {
                case "SQL":
                    sqlCnx = (SqlConnection)BDConnection;
                    break;
                case "MySQL":
                    mysqlCnx = (MySqlConnection)BDConnection;
                    break;
                case "Access":
                    accCnx = (OleDbConnection)BDConnection;
                    break;
                case "SQLite":
                    sqliteCnx = (SQLiteConnection)BDConnection;
                    break;
            }
            try
            {
                //ccn.Close();
                //ccn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: \n" + ex, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlCnx.Close();
            }

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, sqlCnx);

                DataSet ds = new DataSet();
                da.Fill(ds);

                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    Lista.Columns.Add(ds.Tables[0].Columns[i].ColumnName);
                    Lista.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    for (int j = 1; j < ds.Tables[0].Columns.Count; j++)
                    {
                        item.SubItems.Add(row[j].ToString());
                    }
                    Lista.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: \n" + ex, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ccn.Close();
            }
            //ccn.Close();
        }

        public bool CrearUsuario(string Usuario, string Clave)
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrEmpty(Clave))
            {
                MessageBox.Show("No puede dejar espacio vacios");
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

        public bool VerificarExistencia(string Usuario, string Clave = null)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = string.IsNullOrEmpty(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
                var cnx = (SqlConnection)BDConnection;
                SqlCommand command = new SqlCommand(consulta, cnx);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (BaseDatos == "Access")
            {
                string consulta = string.IsNullOrEmpty(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
                var cnx = (OleDbConnection)BDConnection;
                OleDbCommand command = new OleDbCommand(consulta, cnx);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (BaseDatos == "MySQL")
            {
                string consulta = string.IsNullOrEmpty(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
                var cnx = (MySqlConnection)BDConnection;
                MySqlCommand command = new MySqlCommand(consulta, cnx);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else if (BaseDatos == "SQLite")
            {
                string consulta = string.IsNullOrEmpty(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
                var cnx = (SQLiteConnection)BDConnection;
                SQLiteCommand command = new SQLiteCommand(consulta, cnx);
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return Result;
        }

        public bool InsertarCliente(string Nombre, string Paterno, string Materno, string Fecha, string CURP, string Telefono, string Calle, string Colonia)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO Cliente VALUES('{Nombre}','{Paterno}','{Materno}','{Fecha}','{CURP}','{Telefono}','{Calle}','{Colonia}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarClienteUsuario(string ClienteID, string UsuarioID, string FechaAlta, string FechaBaja)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO ClienteUsuario VALUES({ClienteID},{UsuarioID},'{FechaAlta}','{FechaBaja}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarNuevaSuscripcion(string Suscripcion)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO TipoSuscripcion VALUES('{Suscripcion}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarSuscripcion(string Descripcion, string FechaInicial, string FechaFinal, string Precio, string IDSuscripcion)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO Suscripcion VALUES('{Descripcion}','{FechaInicial}','{FechaFinal}',{Precio},{IDSuscripcion},1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarClienteSuscripcion(string IDCliente, string IDSuscripcion)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO ClienteSuscripcion VALUES('{IDCliente}','{IDSuscripcion}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool ActualizaCliente(string Nombre, string Paterno, string Materno, string Fecha, string CURP, string Telefono, string Calle, string Colonia, string IDCliente)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"UPDATE Cliente SET Nombre = '{Nombre}', ApellidoPaterno = '{Paterno}', ApellidoMaterno = '{Materno}', FechaNacimiento = '{Fecha}', CURP = '{CURP}', Telefono = '{Telefono}', Calle = '{Calle}', Colonia = '{Colonia}' WHERE idCliente = {IDCliente}";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool ActualizaSuscripcion(string Descripcion, string FechaInicial, string FechaFinal, string Precio, string ID)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"UPDATE Suscripcion SET Descripcion = '{Descripcion}', FechaInicial = '{FechaInicial}', FechaFinal = '{FechaFinal}', Precio = {Precio} WHERE idSuscripcion = {ID}";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarCine(string Nombre, string Descripcion, string Ubicacion, string Fecha)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO Cine VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarCineCliente(string IDCliente, string IDCine, string Fecha)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO CineCliente VALUES('{Fecha}',{IDCine},{IDCliente},1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool ActualizaCine(string Nombre, string Descripcion, string Ubicacion, string Fecha, string ID)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"UPDATE Cine SET Nombre = '{Nombre}', Descripcion = '{Descripcion}', Ubicacion = '{Ubicacion}', FechaInaugurada = '{Fecha}' WHERE idCine = {ID}";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool EliminaRegistro(string ID, string Tabla)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"DELETE FROM {Tabla} WHERE id{Tabla} = {ID}";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    try
                    {
                        Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    }
                    catch (Exception)
                    {
                        Result = false;
                    }
                    return Result;
                }
            }
            return false;
        }
    }
}
