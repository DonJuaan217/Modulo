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
    public partial class TipoHabitacion : Form
    {
        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        public TipoHabitacion()
        {
            InitializeComponent();
            mostrar_tipohabitacion();
        }

        void mostrar_tipohabitacion()
        {
            try
            {
                da = new OdbcDataAdapter("select idTipohabitacion as Id_habitacion, nombreTipoHabitacion as Tipo_habitacion from tipohabitacion", Conexion.conexion());
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No se ingresaron los datos");
                return;
            }

            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "insert into tipohabitacion (nombreTipoHabitacion) values ('" + textBox1.Text + "' )  ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Datos ingresados");
                textBox1.Clear();

                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            mostrar_tipohabitacion();
        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("No se eliminaron los datos");
                return;
            }
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "delete from tipohabitacion where idTipoHabitacion = '" + textBox2.Text + "' ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            textBox1.Clear();
            textBox2.Clear();
            
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Datos eliminados");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            mostrar_tipohabitacion();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox2.Text = row.Cells["id_habitacion"].Value.ToString();
                textBox1.Text = row.Cells["tipo_habitacion"].Value.ToString();
                




            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("No se actualizaron los datos");
                return;
            }
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "update tipohabitacion set idTipoHabitacion = '" + textBox2.Text + "', nombreTipoHabitacion= '" + textBox1.Text + "' where idTipoHabitacion = '" + textBox2.Text + "'   ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Datos actualizados");
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            mostrar_tipohabitacion();
        }
    }
}
