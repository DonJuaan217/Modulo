using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.Odbc;


namespace ModuloPersonal
{
    public partial class VentanaHabitaciones : Form
    {

        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;

        public VentanaHabitaciones()
        {
            InitializeComponent();
            mostrar_habitaciones();
            Fillcombo();
        }


        public void mostrar_habitaciones()
        {
            try
            {
                da = new OdbcDataAdapter("select idHabitacion, estatusHabitacion, tipo, Descripcion, costo from habitacion", Conexion.conexion());
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


        string Tipoh;
        string idh;
        string disp;

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {

                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "insert into habitacion (idHabitacion, estatusHabitacion,tipohabitacion_idTipoHabitacion, tipo, Descripcion, costo) values ('" + Convert.ToInt32(textBox1.Text) + "', '" + comboBox2.Text + "', '" + Convert.ToString(textBox4.Text) + "' ,'" + comboBox1.Text + "', '" + textBox2.Text + "', '" + Convert.ToInt32(textBox3.Text) + "' )  ; ";
                OdbcConnection conDataBase = new OdbcConnection(constring);
                OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
                OdbcDataReader myReader;
                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    MessageBox.Show("Datos ingresados");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    while (myReader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch
            {
                MessageBox.Show("No se ingresaron los datos");
            }
            
            mostrar_habitaciones();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Tipoh = "Individual";
            idh = "1";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Tipoh = "Doble";
            idh = "2";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Tipoh = "Triple";
            idh = "3";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Tipoh = "Suite";
            idh = "4";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Tipoh = "Presidencial";
            idh = "5";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            disp = "Si";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            disp = "No";
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No se actualizaron los datos");
                return;
            }
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "update habitacion set IdHabitacion = '" + textBox1.Text + "',tipo='" + comboBox1.Text + "',Descripcion= '" + textBox2.Text + "',estatusHabitacion= '" + comboBox2.Text + "',costo='" + textBox3.Text + "' where IdHabitacion = '" + textBox1.Text + "'   ; ";
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
            mostrar_habitaciones();

        }

        string tipohi;
        string tipohd;
        string tipoht;
        string tipohs;
        string tipohp;

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tipohi = "Individual";
            tipohd = "Doble";
            tipoht = "Triple";
            tipohs = "Suite";
            tipohp = "Presidencial";

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["IdHabitacion"].Value.ToString();
                textBox2.Text = row.Cells["Descripcion"].Value.ToString();
                textBox3.Text = row.Cells["Costo"].Value.ToString();
                comboBox1.Text = row.Cells["Tipo"].Value.ToString();
                comboBox2.Text = row.Cells["estatusHabitacion"].Value.ToString();




            }
        }

        void Fillcombo()
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "select nombreTipoHabitacion from tipohabitacion    ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    comboBox1.Items.Add(myReader.GetValue(0).ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "select * from tipohabitacion where nombreTipoHabitacion = '"+comboBox1.Text+ "'    ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    

                    string sTipo = myReader.GetInt32(0).ToString();

                    textBox4.Text = sTipo;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No se eliminaron los datos");
                return;
            }
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "delete from habitacion where idHabitacion = '" + textBox1.Text + "' ; ";
                OdbcConnection conDataBase = new OdbcConnection(constring);
                OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
                OdbcDataReader myReader;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
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
            
            mostrar_habitaciones();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                da = new OdbcDataAdapter("select * from habitacion where estatusHabitacion like ('" + comboBox2.Text + "%') and tipo like ('" + comboBox1.Text + "%') and idHabitacion like ('" + textBox1.Text + "%') and Descripcion like ('" + textBox2.Text + "%') and Costo like ('" + textBox3.Text + "%') ", Conexion.conexion());
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Tipoh = "Individual";
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
