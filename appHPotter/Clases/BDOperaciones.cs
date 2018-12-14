using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            SqlConnection ccn = null;
            switch (BaseDatos)
            {
                case "SQL":
                    ccn = (SqlConnection)BDConnection;
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
                ccn.Close();
            }

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(consulta, ccn);

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

        public bool VerificarExistencia(string Usuario)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"SELECT * FROM Usuario WHERE Usuario = '{Usuario}'";
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

        public bool InsertarNuevaMembresia(string Membresia)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO TipoMembresia VALUES('{Membresia}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarMembresia(string Descripcion, string FechaInicial, string FechaFinal, string Precio, string IDMembresia)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO Membresia VALUES('{Descripcion}','{FechaInicial}','{FechaFinal}',{Precio},{IDMembresia},1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }

        public bool InsertarClienteMembresia(string IDCliente, string IDMembresia)
        {
            if (BaseDatos == "SQL")
            {
                string consulta = $"INSERT INTO ClienteMembresia VALUES('{IDCliente}','{IDMembresia}',1)";
                var cnx = (SqlConnection)BDConnection;
                using (SqlCommand command = new SqlCommand(consulta, cnx))
                {
                    Result = (command.ExecuteNonQuery() > 0) ? true : false;
                    return Result;
                }
            }
            return false;
        }
    }
}
