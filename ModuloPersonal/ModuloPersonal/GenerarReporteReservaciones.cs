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
    public partial class GenerarReporteReservaciones : Form
    {
        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        public GenerarReporteReservaciones()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = Conexion.conexion().CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "alter view reporte_reservacion as select * from reservacion where idReservacion like ('" + textBox4.Text + "%') and tipo like ('" + textBox5.Text + "%') and nombreCliente like ('" + textBox1.Text + "%') and apellidoCliente like ('" + textBox2.Text + "%') and cliente_idCliente like('" + textBox6.Text + "%') and estadoReserva like('" + textBox3.Text + "%')  ";
            cmd.ExecuteNonQuery();

            Conexion.conexion().Close();

            ReporteReservacioncs rpt = new ReporteReservacioncs();
            rpt.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
