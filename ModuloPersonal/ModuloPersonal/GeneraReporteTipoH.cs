using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ModuloPersonal
{
    public partial class GeneraReporteTipoH : Form
    {
        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        public GeneraReporteTipoH()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = Conexion.conexion().CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "alter view reporte_tipohabitacion as select * from tipohabitacion where idTipoHabitacion like ('" + textBox2.Text + "%') and NombreTipoHabitacion like ('" + textBox1.Text + "%')   ";
            cmd.ExecuteNonQuery();

            Conexion.conexion().Close();

            GenerarReporteTipoH ir = new GenerarReporteTipoH();
            ir.ShowDialog();

        }
    }
}
