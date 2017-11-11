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
    public partial class VentanaReservaciones : Form
    {

        
        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        

        public VentanaReservaciones()
        {
            InitializeComponent();
            mostrar_reservacion();
            radioButton1.Checked = true;
            fillcombo2();
            
            
        }
        string tipoh;

        void fillcombo2()
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "select idCliente from cliente    ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    comboBox2.Items.Add(myReader.GetValue(0).ToString());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void mostrar_reservacion()
        {
            try
            {
                da = new OdbcDataAdapter("select * from reservacion", Conexion.conexion());
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
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("No se ingresaron los datos");
                return;
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("No se ingresaron los datos");
                return;
            }
            try
            {
                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "insert into reservacion (fechaEntrada, fechaSalida, estadoReserva, nombreCliente, apellidoCliente, cliente_idCliente, tipo) values ('" +maskedTextBox1.Text+ "', '"+maskedTextBox2.Text+"', '"+textBox8.Text+"', '"+textBox1.Text+"', '"+textBox2.Text+"', '"+Convert.ToInt32(comboBox2.Text)+"', '"+tipoh+"') ; ";
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
                    comboBox1.SelectedIndex = -1;
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox8.Clear();
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();

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
                MessageBox.Show("Datos no ingresados");
            }

            mostrar_reservacion();
           
        }


        string var_id;
        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("No se eliminaron los datos");
                return;
            }
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "delete from reservacion where idReservacion = '" + textBox5.Text + "' ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                MessageBox.Show("Datos eliminados");
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                textBox4.Clear();
                textBox5.Clear();
                textBox8.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            mostrar_reservacion();


        }

        private void VentanaReservaciones_Load(object sender, EventArgs e)
        {

        }


        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = ("select * from habitacion where idHabitacion = '" + comboBox1.Text + "' ; ");
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

                    string des = myReader.GetString(2);
                    string cos = myReader.GetInt32(5).ToString();
                    string estado = myReader.GetString(1);

                    textBox6.Text = des;
                    textBox7.Text = cos;
                    textBox8.Text = estado;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


           
        }


       

        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            string tipohi;
            string disp;
            disp = "Si";
            tipohi = "Individual";
            tipoh = "Individual";
            if (radioButton1.Checked) {
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.SelectedIndex = -1;
                    comboBox1.Items.Clear();
                    string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                    string Query = "select * from habitacion where estatusHabitacion = '" + disp + "' and Tipo ='"+ tipohi +"'   ; ";
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
            tipoh = "Individual";

        }

  

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            

            string tipohd;
            string disp;
            disp = "Si";
            tipohd = "Doble";
                if (radioButton2.Checked)
                {
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox1.Items.Clear();
                    string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                    string Query = "select * from habitacion where estatusHabitacion = '" + disp + "' and Tipo ='" + tipohd + "'   ; ";
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

            tipoh = "Doble";


        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            string tipoht;
            string disp;
            disp = "Si";
            tipoht = "Triple";
      
            if (radioButton3.Checked)
            {
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox1.Items.Clear();
                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "select * from habitacion where estatusHabitacion = '" + disp + "' and Tipo ='" + tipoht + "'   ; ";
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
            
            tipoh = "Triple";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            string tipohs;
            string disp;
            disp = "Si";
            tipohs= "Suite";
            
            if (radioButton4.Checked)
            {
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox1.Items.Clear();
                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "select * from habitacion where estatusHabitacion = '" + disp + "' and Tipo ='" + tipohs + "'   ; ";
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
            
            tipoh = "Suite";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            string tipohp;
            string disp;
            disp = "Si";
            tipohp = "Presidencial";

            if (radioButton5.Checked)
            {
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox1.Items.Clear();
                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "select * from habitacion where estatusHabitacion = '" + disp + "' and Tipo ='" + tipohp + "'   ; ";
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
            tipoh = "Presidencial";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                textBox1.Text = row.Cells["nombreCliente"].Value.ToString();
                textBox2.Text = row.Cells["apellidoCliente"].Value.ToString();
                //comboBox1.Text = row.Cells["Habitacion"].Value.ToString();
                maskedTextBox1.Text = row.Cells["fechaEntrada"].Value.ToString();
                maskedTextBox2.Text = row.Cells["fechaSalida"].Value.ToString();
                textBox8.Text = row.Cells["estadoReserva"].Value.ToString();
                textBox5.Text = row.Cells["idReservacion"].Value.ToString();



            }
        }


        

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("No se actualizaron los datos. Llene todos los campos");
                return;
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                MessageBox.Show("No se actualizaron los datos. Llene todos los campos");
                return;
            }
            try
            {
                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "update reservacion set nombreCliente = '" + textBox1.Text + "',apellidoCliente='" + textBox2.Text + "',Tipo= '" + tipoh + "',fechaEntrada= '" + maskedTextBox1.Text + "',fechaSalida= '" + maskedTextBox2.Text + "',cliente_idCliente= '" + comboBox2.Text + "' where idReservacion = '" + textBox5.Text + "'   ; ";
                OdbcConnection conDataBase = new OdbcConnection(constring);
                OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
                OdbcDataReader myReader;
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox4.Clear();
                textBox8.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
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
            }
            catch
            {
                MessageBox.Show("Datos no actualizados");

            }
            mostrar_reservacion();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                da = new OdbcDataAdapter("select * from reservacion where nombreCliente like ('" + textBox1.Text + "%') and apellidoCliente like ('" + textBox2.Text + "%') and cliente_idCliente like('" +comboBox2+ "%') ; ", Conexion.conexion());
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
        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "select * from cliente where idCliente = '" + comboBox2.Text + "'    ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    string sNombre = myReader.GetString(2);
                    string sApellido = myReader.GetString(3);

                    textBox1.Text = sNombre;
                    textBox2.Text = sApellido;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
