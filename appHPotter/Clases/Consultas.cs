using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appHPotter.Clases
{
    class Consultas
    {
        //Consulta Clientes con usuario
        public static string sqlClienteUsuario = "SELECT U.Usuario,C.Nombre AS Nombre, C.ApellidoPaterno,C.CURP,c.Telefono,cu.FechaIngreso,cu.FechaBaja,cu.Estatus FROM Cliente C INNER JOIN ClienteUsuario CU ON C.idCliente = CU.idCliente INNER JOIN Usuario U  ON U.idUsuario = CU.idUsuario";
        public static string mysqlClienteUsuario = "SELECT U.Usuario,C.Nombre AS Nombre, C.ApellidoPaterno,C.CURP,c.Telefono,cu.FechaIngreso,cu.FechaBaja,cu.Estatus FROM Cliente C INNER JOIN ClienteUsuario CU ON C.idCliente = CU.idCliente INNER JOIN Usuario U  ON U.idUsuario = CU.idUsuario";
        public static string accessClienteUsuario = "SELECT U.Usuario,C.Nombre +  ' ' + C.ApellidoPaterno AS Nombre,C.CURP,c.Telefono,cu.FechaIngreso,cu.FechaBaja,cu.Estatus FROM ((Cliente C INNER JOIN ClienteUsuario CU ON C.idCliente = CU.idCliente) INNER JOIN Usuario U  ON U.idUsuario = CU.idUsuario)";
        public static string postqClienteUsuario = @"SELECT ""Usuario"".""Usuario"", ""Cliente"".""Nombre"",""Cliente"".""ApellidoPaterno"",""Cliente"".""CURP"",""Cliente"".""Telefono"",""ClienteUsuario"".""FechaIngreso"",""ClienteUsuario"".""FechaBaja"",""ClienteUsuario"".""Estatus"" FROM public.""ClienteUsuario"", public.""Cliente"",public.""Usuario"" WHERE ""ClienteUsuario"".""idCliente"" = ""Cliente"".""idCliente"" AND ""ClienteUsuario"".""idUsuario"" = ""Usuario"".""idUsuario""";

        //Consulta Clientes con sucripcion
        public static string sqlClienteSuscripcion = "SELECT TM.Descripcion AS Suscripcion, c.Nombre + ' ' + c.ApellidoPaterno AS Cliente, c.Telefono, c.Calle + ', ' + c.Colonia AS Direccion,m.FechaInicial, m.FechaFinal, c.Estatus FROM Cliente C INNER JOIN ClienteSuscripcion CM ON C.idCliente = CM.idCliente INNER JOIN Suscripcion M ON M.idSuscripcion = CM.idSuscripcion INNER JOIN TipoSuscripcion TM ON TM.idTipoSuscripcion = M.idTipoSuscripcion";
        public static string mysqlClienteSuscripcion = "SELECT TM.Descripcion AS Suscripcion, c.Nombre + ' ' + c.ApellidoPaterno AS Cliente, c.Telefono, c.Calle + ', ' + c.Colonia AS Direccion,m.FechaInicial, m.FechaFinal, c.Estatus FROM Cliente C INNER JOIN ClienteSuscripcion CM ON C.idCliente = CM.idCliente INNER JOIN Suscripcion M ON M.idSuscripcion = CM.idSuscripcion INNER JOIN TipoSuscripcion TM ON TM.idTipoSuscripcion = M.idTipoSuscripcion";
        public static string accessClienteSuscripcion = "SELECT TM.Descripcion AS Suscripcion, c.Nombre + ' ' + c.ApellidoPaterno AS Cliente, c.Telefono, c.Calle + ', ' + c.Colonia AS Direccion,m.FechaInicial, m.FechaFinal, c.Estatus FROM (((Cliente C INNER JOIN ClienteSuscripcion CM ON C.idCliente = CM.idCliente) INNER JOIN Suscripcion M ON M.idSuscripcion = CM.idSuscripcion) INNER JOIN TipoSuscripcion TM ON TM.idTipoSuscripcion = M.idTipoSuscripcion)";
        public static string postqClienteSuscripcion = @"SELECT ""TipoSuscripcion"".""Descripcion"", ""Cliente"".""Nombre"",""Cliente"".""ApellidoPaterno"",""Cliente"".""Telefono"",""Cliente"".""Calle"",""Cliente"".""Colonia"", ""Suscripcion"".""FechaInicial"",""Suscripcion"".""FechaFinal"",""Cliente"".""Estatus"" FROM public.""ClienteSuscripcion"", public.""Cliente"", public.""Suscripcion"", public.""TipoSuscripcion"" WHERE ""ClienteSuscripcion"".""idCliente"" = ""Cliente"".""idCliente"" AND ""ClienteSuscripcion"".""idSuscripcion"" = ""Suscripcion"".""idSuscripcion"" AND ""TipoSuscripcion"".""idTipoSuscripcion"" = ""Suscripcion"".""idTipoSuscripcion""";

        //Consulta Clientes con cine
        public static string sqlClienteCine = "SELECT C.Nombre AS Cine, Cl.Nombre + ' ' + Cl.ApellidoPaterno + ' ' + Cl.ApellidoMaterno AS Cliente, Cl.Telefono, C.Ubicacion AS 'Ubicacion del cine', CC.FechaRegistro, CC.Estatus FROM CineCliente CC INNER JOIN Cine C ON C.idCine = CC.idCine INNER JOIN Cliente Cl ON Cl.idCliente = CC.idCliente";
        public static string mysqlClienteCine = "SELECT C.Nombre AS Cine, Cl.Nombre + ' ' + Cl.ApellidoPaterno + ' ' + Cl.ApellidoMaterno AS Cliente, Cl.Telefono, C.Ubicacion AS 'Ubicacion del cine', CC.FechaRegistro, CC.Estatus FROM CineCliente CC INNER JOIN Cine C ON C.idCine = CC.idCine INNER JOIN Cliente Cl ON Cl.idCliente = CC.idCliente";
        public static string accessClienteCine = "SELECT C.Nombre AS Cine, Cl.Nombre + ' ' + Cl.ApellidoPaterno + ' ' + Cl.ApellidoMaterno AS Cliente, Cl.Telefono, C.Ubicacion AS 'Ubicacion del cine', CC.FechaRegistro, CC.Estatus FROM ((CineCliente CC INNER JOIN Cine C ON C.idCine = CC.idCine) INNER JOIN Cliente Cl ON Cl.idCliente = CC.idCliente)";
        public static string postqClienteCine = @"SELECT ""Cine"".""Nombre"",""Cliente"".""Nombre"",""Cliente"".""ApellidoPaterno"",""Cliente"".""ApellidoMaterno"",""Cliente"".""Telefono"",""Cine"".""Ubicacion"",""CineCliente"".""FechaRegistro"",""CineCliente"".""Estatus"" FROM public.""CineCliente"",public.""Cine"",public.""Cliente"" WHERE ""CineCliente"".""idCliente"" = ""Cliente"".""idCliente"" AND ""CineCliente"".""idCine"" = ""Cine"".""idCine""";


        
    }
}
