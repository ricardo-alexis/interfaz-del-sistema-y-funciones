using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//TRABAJO EXCELENTE
namespace Interfaz_del_sistema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarUsuario();
            string connection = "datasource=localhost;port=3306;username=root;password=;database=materia";
            string query = "SELECT * FROM alumno";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;
            string datos;


            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3));
                        datos = reader.GetString(0) + " - " + reader.GetString(1) + " - " + reader.GetString(2) + " - " + reader.GetString(3);

                    }
                }
                else
                {
                    Console.WriteLine("No hay datos existentes.");
                }
                conectionDatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Eliminar()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=materia";
            string query = "DELETE FROM `alumno` WHERE ID = '" + textBox4.Text + "' ";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;

            try
            {
                conectionDatabase.Open();
                MySqlDataReader myeader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("El dato se ha borrado exitosamente.");
                MostrarUsuario();
                conectionDatabase.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Actualizar()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=materia;";
            string query = "UPDATE `alumno` SET `FIRST_NAME`='" + textBox1.Text + "',`LAST_NAME`='" + textBox2.Text + "',`ADDRESS`='" + textBox3.Text + "' WHERE ID = '" + textBox4.Text + "' ";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;

            try
            {
                conectionDatabase.Open();
                MySqlDataReader myreader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("Dato actualizado exitosamente.");
                conectionDatabase.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void Buscar()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=materia;";
            string query = "SELECT * FROM alumno where ID= '" + textBox4.Text + "' ";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };

                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];

                    }

                }
                else
                {
                    Console.WriteLine("No se encontron datos.");
                }
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void GuardarUsuario()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=materia";
            string query = "INSERT INTO alumno(`ID`, `FIRST_NAME`, `LAST_NAME`, `ADDRESS`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;

            try
            {
                conectionDatabase.Open();
                MySqlDataReader myreader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("Dato registrado exitosamente ¡Felicidades!");
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void MostrarUsuario()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=materia;";
            string query = "SELECT * FROM alumno";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        listView1.Items.Clear();
                        while (reader.Read())
                        {
                            string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                            var ListViewItems = new ListViewItem(row);
                            listView1.Items.Add(ListViewItems);
                        }
                    }

                }
                else
                {
                    Console.WriteLine("No se encontron datos.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No tienes nombre");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("No tienes apellido");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("No tienes direccion");
            }
            else
            {

                GuardarUsuario();
                MostrarUsuario();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Actualizar
            MostrarUsuario();
        }



        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GuardarUsuario();
        }
    }
}