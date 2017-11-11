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
    public partial class GenerarReporteHabitacion : Form
    {
        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        public GenerarReporteHabitacion()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = Conexion.conexion().CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "alter view reporte_habitacion as select * from habitacion where idHabitacion like ('" + textBox1.Text + "%') and tipo like ('" + textBox4.Text + "%') and Descripcion like ('" + textBox2.Text + "%') and costo like ('" + textBox3.Text + "%') and estatusHabitacion like('" + textBox5.Text+ "%')   ";
            cmd.ExecuteNonQuery();

            Conexion.conexion().Close();

            ReporteHabitacion rpt = new ReporteHabitacion();
            rpt.ShowDialog();
        }
    }
}
