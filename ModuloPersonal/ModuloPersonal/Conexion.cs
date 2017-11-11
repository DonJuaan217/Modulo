using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data.Odbc;
using MySql.Data.MySqlClient;



namespace ModuloPersonal
{
    public class Conexion
    {
        public static OdbcConnection conexion()
        {
            OdbcConnection con = new OdbcConnection();
            con = new OdbcConnection("Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;");
            con.Open();
            return con;
        }
    }
}
