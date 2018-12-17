using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHPotter.Clases
{
    class OrigenDeDatos
    {
        //Windows
        public static string SQLServer = $"Data Source=localhost; Initial Catalog=HPotter_DB;Trusted_Connection=True;";

        public static string Access = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\alex_\Documents\Databases\Access\BDHPotter_Access.accdb;Persist Security Info=False;";

        //Ubuntu  
        public static string MySQL = @"Server=127.0.0.1;Database=bdhpotter_mysql;Uid=root;Pwd=;";
        
        public static string PostgreSQL = @"Server=127.0.0.1;Port=5432;Database=HPotter;User Id = postgres;Password=oceano;";
    }


}
