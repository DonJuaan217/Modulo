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
using System.Data.Odbc;


namespace ModuloPersonal
{
    public partial class VentanaFolio : Form
    {

        Conexion con = new Conexion();
        OdbcCommand com;
        OdbcDataAdapter da;
        DataTable dt;
        OdbcDataReader dr;
        public VentanaFolio()
        {
            InitializeComponent();
            Fillcombo();
            mostrar_folio();
            radioButton1.Checked = true;
            radioButton4.Checked = true;
        }

        void Fillcombo()
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "select idCheckin from checkin    ; ";
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

        private void VentanaFolio_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "select * from checkin where idCheckin = '" + comboBox1.Text +"'   ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read())
                {
                    //comboBox1.Items.Add(myReader.GetValue(0).ToString());

                    string sId_reservacion = myReader.GetInt32(0).ToString();
                   

                    textBox1.Text = sId_reservacion;
                    


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void mostrar_folio()
        {
            try
            {
                da = new OdbcDataAdapter("select * from folio", Conexion.conexion());
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

        public void calculo_folio()
        {
            try
            {
                da = new OdbcDataAdapter("select SUM(Monto) as Total, Id_reservacion from folio group by Id_reservacion  ", Conexion.conexion());
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
           
            try
            {
                string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
                string Query = "insert into folio (habitacion, tipoCliente, Nombre, Apellido, Servicio, fecha, monto, descripcion, Id_reservacion) values ('" + Convert.ToInt32(comboBox1.Text) + "', '" + tipoc + "','" + textBox2.Text + "' ,'" + textBox3.Text + "', '" + textBox4.Text + "', '" + Convert.ToString(maskedTextBox1.Text) + "', '" + Convert.ToInt32(textBox5.Text) + "', '" + textBox6.Text + "', '" + textBox1.Text + "' ) ; ";
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
                    comboBox1.SelectedIndex = -1;
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox8.Clear();
                    maskedTextBox1.Clear();
                    

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

            mostrar_folio();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            calculo_folio();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                comboBox1.Text = row.Cells["Habitacion"].Value.ToString();
                textBox1.Text = row.Cells["Id_reservacion"].Value.ToString();
                textBox2.Text = row.Cells["Nombre"].Value.ToString();
                textBox3.Text = row.Cells["Apellido"].Value.ToString();
                textBox4.Text = row.Cells["Servicio"].Value.ToString();
                maskedTextBox1.Text = row.Cells["Fecha"].Value.ToString();
                textBox5.Text = row.Cells["Monto"].Value.ToString();
                textBox6.Text = row.Cells["Descripcion"].Value.ToString();
                textBox7.Text = row.Cells["Id_gasto"].Value.ToString();
                textBox8.Text = row.Cells["TipoCliente"].Value.ToString();

            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "update folio set Servicio = '" + textBox4.Text + "',Fecha='" + maskedTextBox1.Text + "',Monto= '" + textBox5.Text + "',Descripcion= '" + textBox6.Text + "',Nombre= '" + textBox2.Text + "',Apellido= '" + textBox3.Text + "' where Id_gasto = '" + textBox7.Text + "'   ; ";
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
            mostrar_folio();
        }

        string tipoc;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                comboBox1.Text ="";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;


            }


            tipoc = "Huesped";
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Text = "0";
                textBox1.Text = "0";
            }

            tipoc = "Consumidor";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Contains("Huesped"))
            {
                

            }
            if (textBox8.Text.Contains("Consumidor"))
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Enabled = false;

            }


        }

        private void btn_borrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                MessageBox.Show("No se eliminaron los datos");
                return;
            }
            string constring = "Driver ={ MySQL ODBC 3.51 Driver }; Dsn=Servidor_hotelsancarlos; UID=root; PWD = ; Database=hotelfase2;";
            string Query = "delete from folio where id_gasto = '" + textBox7.Text + "' ; ";
            OdbcConnection conDataBase = new OdbcConnection(constring);
            OdbcCommand cmdDataBase = new OdbcCommand(Query, conDataBase);
            OdbcDataReader myReader;
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
            mostrar_folio();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (radioButton3.Checked)
            {
                
                try
                {
                    da = new OdbcDataAdapter("select * from folio where Id_reservacion like ('" + textBox1.Text + "%') and TipoCliente like ('" + textBox10.Text + "%') and Habitacion like ('"+ comboBox1.Text + "%') and Id_reservacion like ('"+ textBox1.Text + "%') and Nombre like ('" + textBox2.Text + "%') and Apellido like ('" + textBox3.Text + "%') and Servicio like ('" + textBox4.Text + "%') and Monto like ('" + textBox5.Text + "%') and Descripcion like ('" + textBox6.Text + "%') ", Conexion.conexion());
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




            if (radioButton4.Checked)
            {
                
                try
                {
                    da = new OdbcDataAdapter("select * from folio where Id_reservacion like ('" + textBox1.Text + "%') and TipoCliente like ('" + textBox9.Text + "%') and Habitacion like ('" + comboBox1.Text + "%') and Id_reservacion like ('" + textBox1.Text + "%') and Nombre like ('" + textBox2.Text + "%') and Apellido like ('" + textBox3.Text + "%') and Servicio like ('" + textBox4.Text + "%') and Monto like ('" + textBox5.Text + "%') and Descripcion like ('" + textBox6.Text + "%') ", Conexion.conexion());
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR");
                }
            }//fin if

            if (radioButton5.Checked)
            {
                
                try
                {
                    da = new OdbcDataAdapter("select * from folio where Id_reservacion like ('" + textBox1.Text + "%') and Habitacion like ('" + comboBox1.Text + "%') and Id_reservacion like ('" + textBox1.Text + "%') and Nombre like ('" + textBox2.Text + "%') and Apellido like ('" + textBox3.Text + "%') and Servicio like ('" + textBox4.Text + "%') and Monto like ('" + textBox5.Text + "%') and Descripcion like ('" + textBox6.Text + "%') ", Conexion.conexion());
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR");
                }
            }//fin if
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                comboBox1.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                comboBox1.Enabled = true;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                comboBox1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Text = "0";
                textBox1.Text = "0";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                comboBox1.Text = "";
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                da = new OdbcDataAdapter("select SUM(monto) as Total from folio where Habitacion = '" + comboBox1.Text + "' group by habitacion  ", Conexion.conexion());
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
    }
}
