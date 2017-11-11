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
    public partial class GeneraReporteFolio : Form
    {
        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        public GeneraReporteFolio()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcCommand cmd = Conexion.conexion().CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "alter view reporte_folio as select * from folio where habitacion like ('" + textBox7.Text + "%') and Id_reservacion like ('" + textBox1.Text + "%') and Descripcion like ('" + textBox6.Text + "%') and monto like ('" + textBox5.Text + "%') and Nombre like('" + textBox2.Text + "%') and Apellido like('" + textBox3.Text + "%') and Servicio like('" + textBox4.Text + "%') and id_gasto like ('" + textBox8.Text + "%')   ";
            cmd.ExecuteNonQuery();

            Conexion.conexion().Close();

            ReporteFolio rpt = new ReporteFolio();
            rpt.ShowDialog();


        }
    }
}
