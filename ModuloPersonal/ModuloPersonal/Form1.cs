using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloPersonal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.conexion();
            MessageBox.Show("Conectado");
        }

        private void reservacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void realizarReservacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaReservaciones ir = new VentanaReservaciones();
            ir.ShowDialog();

        }

        private void folioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VentanaFolio ir = new VentanaFolio();
            ir.ShowDialog();
        }

        private void detalleFolioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //VentanaDetalleFolio ir = new VentanaDetalleFolio();
            //ir.ShowDialog();
        }

        private void habitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "file:C:/Users/Carlos Reyes/Desktop/Seguridad/Folio/ModuloPersonalFinal/ModuloPersonal/AyudaFolioReservacion/Folio & reservacion manual.chm");
        }

        private void habitacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            VentanaHabitaciones ir = new VentanaHabitaciones();
            ir.ShowDialog();

        }

        private void tiposDeHabitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoHabitacion ir = new TipoHabitacion();
            ir.ShowDialog();
        }

        private void habitacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GenerarReporteHabitacion ir = new GenerarReporteHabitacion();
            ir.ShowDialog();

        }

        private void tiposDeHabitacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneraReporteTipoH ir = new GeneraReporteTipoH();
            ir.ShowDialog();
        }

        private void folioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GeneraReporteFolio ir = new GeneraReporteFolio();
            ir.ShowDialog();
        }

        private void reservacionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GenerarReporteReservaciones ir = new GenerarReporteReservaciones();
            ir.ShowDialog();
        }
    }
}
