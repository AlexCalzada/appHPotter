using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Npgsql;
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

        public void CargarEnListView(ListView Lista, string consulta)
        {
            SqlConnection sqlCnx = null;
            OleDbConnection accCnx = null;
            MySqlConnection mysqlCnx = null;
            //SQLiteConnection sqliteCnx = null;
            NpgsqlConnection posCnx = null;


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
                case "PostgreSQL":
                    posCnx = (NpgsqlConnection)BDConnection;
                    break;
            }

            try
            {
                SqlDataAdapter daSql = null;
                OleDbDataAdapter daAccess = null;
                MySqlDataAdapter daMySql = null;
                NpgsqlDataAdapter daPos = null;

                DataSet ds = new DataSet();
                switch (BaseDatos)
                {
                    case "SQL":
                        daSql = new SqlDataAdapter(consulta, sqlCnx);
                        daSql.Fill(ds);
                        break;
                    case "MySQL":
                        daMySql = new MySqlDataAdapter(consulta, mysqlCnx);
                        daMySql.Fill(ds);
                        break;
                    case "Access":
                        daAccess = new OleDbDataAdapter(consulta, accCnx);
                        daAccess.Fill(ds);
                        break;
                    case "SQLite":
                        daPos = new NpgsqlDataAdapter(consulta, posCnx);
                        daPos.Fill(ds);
                        break;
                    default:
                        break;
                }
                

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
            }
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
            string consulta = $"INSERT INTO Usuario(Usuario,Clave,idTipoUsuario,Estatus) VALUES('{Usuario}','{Clave}',2,1)";
            if (BaseDatos == "SQL")
            {
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "MySQL")
            {
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "PostgreSQL")
            {
                string query = string.Format(@"INSERT INTO public.""Usuario""(""Usuario"",""Clave"",""idTipoUsuario"",""Estatus"") VALUES('{0}','{1}',4,b'1')",Usuario,Clave);
                var cnx = (NpgsqlConnection)BDConnection;
                using (NpgsqlCommand command = new NpgsqlCommand(query, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool VerificarExistencia(string Usuario, string Clave = "")
        {
            if (BaseDatos == "SQL")
            {
                string consulta = string.IsNullOrWhiteSpace(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
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
                string consulta = string.IsNullOrWhiteSpace(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
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
                string consulta = string.IsNullOrWhiteSpace(Clave) ? $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'" : $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}' AND Clave = '{Clave}'";
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
            else if (BaseDatos == "PostgreSQL")
            {
                string consulta = null ;

                if (string.IsNullOrWhiteSpace(Clave))
                {
                    consulta = @"SELECT * FROM public.""Usuario"" WHERE ""Usuario"".""Usuario"" = '" + Usuario + "'";
                }
                else
                {
                    consulta = string.Format(@"SELECT * FROM public.""Usuario"" WHERE ""Usuario"".""Usuario"" = '{0}' AND ""Usuario"".""Clave"" = '{1}'", Usuario, Clave);
                }

                var cnx = (NpgsqlConnection)BDConnection;
                NpgsqlCommand command = new NpgsqlCommand(consulta, cnx);
                using (NpgsqlDataReader reader = command.ExecuteReader())
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"INSERT INTO Cliente(Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CURP,Telefono,Calle,Colonia,Estatus) VALUES('{Nombre}','{Paterno}','{Materno}','{Fecha}','{CURP}','{Telefono}','{Calle}','{Colonia}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"INSERT INTO Cliente(Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CURP,Telefono,Calle,Colonia,Estatus) VALUES('{Nombre}','{Paterno}','{Materno}','{Fecha}','{CURP}','{Telefono}','{Calle}','{Colonia}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"INSERT INTO Cliente(Nombre,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CURP,Telefono,Calle,Colonia,Estatus) VALUES('{Nombre}','{Paterno}','{Materno}','{Fecha}','{CURP}','{Telefono}','{Calle}','{Colonia}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"INSERT INTO ClienteUsuario(idCliente,idUsuario,FechaIngreso,FechaBaja,Estatus) VALUES({ClienteID},{UsuarioID},'{FechaAlta}','{FechaBaja}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"INSERT INTO ClienteUsuario(idCliente,idUsuario,FechaIngreso,FechaBaja,Estatus) VALUES({ClienteID},{UsuarioID},'{FechaAlta}','{FechaBaja}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"INSERT INTO ClienteUsuario(idCliente,idUsuario,FechaIngreso,FechaBaja,Estatus) VALUES({ClienteID},{UsuarioID},'{FechaAlta}','{FechaBaja}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"INSERT INTO TipoSuscripcion(Descripcion,Estatus) VALUES('{Suscripcion}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"INSERT INTO TipoSuscripcion(Descripcion,Estatus) VALUES('{Suscripcion}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"INSERT INTO TipoSuscripcion(Descripcion,Estatus) VALUES('{Suscripcion}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"INSERT INTO Suscripcion(Descripcion,FechaInicial,FechaFinal,Precio,idTipoSuscripcion,Estatus) VALUES('{Descripcion}','{FechaInicial}','{FechaFinal}',{Precio},{IDSuscripcion},1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"INSERT INTO Suscripcion(Descripcion,FechaInicial,FechaFinal,Precio,idTipoSuscripcion,Estatus) VALUES('{Descripcion}','{FechaInicial}','{FechaFinal}',{Precio},{IDSuscripcion},1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"INSERT INTO Suscripcion(Descripcion,FechaInicial,FechaFinal,Precio,idTipoSuscripcion,Estatus) VALUES('{Descripcion}','{FechaInicial}','{FechaFinal}',{Precio},{IDSuscripcion},1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"INSERT INTO ClienteSuscripcion(idCliente,idSuscripcion,Estatus) VALUES('{IDCliente}','{IDSuscripcion}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"INSERT INTO ClienteSuscripcion(idCliente,idSuscripcion,Estatus) VALUES('{IDCliente}','{IDSuscripcion}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"INSERT INTO ClienteSuscripcion(idCliente,idSuscripcion,Estatus) VALUES('{IDCliente}','{IDSuscripcion}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"UPDATE Cliente SET Nombre = '{Nombre}', ApellidoPaterno = '{Paterno}', ApellidoMaterno = '{Materno}', FechaNacimiento = '{Fecha}', CURP = '{CURP}', Telefono = '{Telefono}', Calle = '{Calle}', Colonia = '{Colonia}' WHERE idCliente = {IDCliente}";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"UPDATE Cliente SET Nombre = '{Nombre}', ApellidoPaterno = '{Paterno}', ApellidoMaterno = '{Materno}', FechaNacimiento = '{Fecha}', CURP = '{CURP}', Telefono = '{Telefono}', Calle = '{Calle}', Colonia = '{Colonia}' WHERE idCliente = {IDCliente}";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"UPDATE Cliente SET Nombre = '{Nombre}', ApellidoPaterno = '{Paterno}', ApellidoMaterno = '{Materno}', FechaNacimiento = '{Fecha}', CURP = '{CURP}', Telefono = '{Telefono}', Calle = '{Calle}', Colonia = '{Colonia}' WHERE idCliente = {IDCliente}";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"UPDATE Suscripcion SET Descripcion = '{Descripcion}', FechaInicial = '{FechaInicial}', FechaFinal = '{FechaFinal}', Precio = {Precio} WHERE idSuscripcion = {ID}";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"UPDATE Suscripcion SET Descripcion = '{Descripcion}', FechaInicial = '{FechaInicial}', FechaFinal = '{FechaFinal}', Precio = {Precio} WHERE idSuscripcion = {ID}";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"UPDATE Suscripcion SET Descripcion = '{Descripcion}', FechaInicial = '{FechaInicial}', FechaFinal = '{FechaFinal}', Precio = {Precio} WHERE idSuscripcion = {ID}";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
                string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada,Estatus) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "MySQL")
            {
                string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada,Estatus) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada,Estatus) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada,Estatus) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarCineCliente(string IDCliente, string IDCine, string Fecha)
        {
            string consulta = $"INSERT INTO CineCliente(FechaRegistro,idCine,idCliente,Estatus) VALUES('{Fecha}',{IDCine},{IDCliente},1)";
            if (BaseDatos == "SQL")
            {
                
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "MySQL")
            {
                //string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                //string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                //string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool ActualizaCine(string Nombre, string Descripcion, string Ubicacion, string Fecha, string ID)
        {
            string consulta = $"UPDATE Cine SET Nombre = '{Nombre}', Descripcion = '{Descripcion}', Ubicacion = '{Ubicacion}', FechaInaugurada = '{Fecha}' WHERE idCine = {ID}";
            if (BaseDatos == "SQL")
            {
               
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "MySQL")
            {
                //string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "Access")
            {
                //string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            if (BaseDatos == "SQLite")
            {
                //string consulta = $"INSERT INTO Cine(Nombre,Descripcion,Ubicacion,FechaInaugurada) VALUES('{Nombre}','{Descripcion}','{Ubicacion}','{Fecha}',1)";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
            if (BaseDatos == "MySQL")
            {
                string consulta = $"DELETE FROM {Tabla} WHERE id{Tabla} = {ID}";
                var cnx = (MySqlConnection)BDConnection;
                using (MySqlCommand command = new MySqlCommand(consulta, cnx))
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
            if (BaseDatos == "Access")
            {
                string consulta = $"DELETE FROM {Tabla} WHERE id{Tabla} = {ID}";
                var cnx = (OleDbConnection)BDConnection;
                using (OleDbCommand command = new OleDbCommand(consulta, cnx))
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
            if (BaseDatos == "SQLite")
            {
                string consulta = $"DELETE FROM {Tabla} WHERE id{Tabla} = {ID}";
                var cnx = (SQLiteConnection)BDConnection;
                using (SQLiteCommand command = new SQLiteCommand(consulta, cnx))
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
