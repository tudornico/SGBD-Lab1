using System.Data.SqlClient;
using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BookNameBox.Hide();
            PriceBox.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            RegionBox.Hide();
            PagesBox.Hide();
            AuthorBox.Hide();
            BuchNummerBox.Hide();
        }


        public void GetData(string command)
        {
            String con = "Data Source = DESKTOP-PBGUL9N\\MY_SQL_SERVICE;Initial Catalog=Library;Integrated Security=true";

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData("Select * From Author");

            String con = "Data Source = DESKTOP-PBGUL9N\\MY_SQL_SERVICE;Initial Catalog=Library;Integrated Security=true";
            String command = "Select * From Author";
            using (
                SqlConnection connection = new SqlConnection(con)
            )
            {
                
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command, con);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    DataTable table = new DataTable
                    {
                        Locale = CultureInfo.InvariantCulture
                    };

                    dataAdapter.Fill(table);
                    BindingSource binding = new BindingSource();
                    binding.DataSource = table;

                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridView1.DataSource = binding;
                    connection.Close();

                }
                catch(Exception ex)
                {   
                    Console.Write(ex.Message);
                    Console.Write("AAAAAAAAAAAA");
                }
            }
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs    e)
        {
            String con = "Data Source = DESKTOP-PBGUL9N\\MY_SQL_SERVICE;Initial Catalog=Library;Integrated Security=true";

            using (SqlConnection connection = 
                new SqlConnection(con))
            {
                try
                {
                    connection.Open();
                    var AuthorId = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                   // MessageBox.Show(AuthorId.ToString());
                    String query = "Select * From Buecher Where AuthorId = ' " + AuthorId.ToString() + "'";
                    SqlCommand command = new SqlCommand(query);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                    SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                    DataTable table = new DataTable
                    {
                        Locale = CultureInfo.InvariantCulture
                    };

                    dataAdapter.Fill(table);
                    BindingSource binding = new BindingSource();
                    binding.DataSource = table;

                    dataGridView2.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    dataGridView2.DataSource = binding;
                    connection.Close();
                }
                catch
                {
                    Console.Write("An Error has occured");
                }

                if(comboBox1.SelectedItem.ToString() == "Insert")
                {
                    AuthorBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                }
            }
               

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String command = comboBox1.SelectedItem.ToString();
            if(command == "Update")
            {
                
                BookNameBox.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                BuchNummerBox.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                RegionBox.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                PagesBox.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                PriceBox.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();
                AuthorBox.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            }

            if(command == "Delete")
            {
                BuchNummerBox.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            BuchNummerBox.Hide();
            BuchNummerBox.Clear();
            PriceBox.Hide();
            PriceBox.Clear();
            BookNameBox.Hide();
            BookNameBox.Clear();
            RegionBox.Hide();
            RegionBox.Clear();
            PagesBox.Hide();
            PagesBox.Clear();
            AuthorBox.Hide();
            String command = comboBox1.SelectedItem.ToString();



            if(command == "Delete")
            {
                label1.Show();
                BuchNummerBox.Show();

            }

            if(command == "Insert")
            {
                label1.Show();
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                label6.Show();
                BuchNummerBox.Show();
                PriceBox.Show();
                BookNameBox.Show();
                RegionBox.Show();
                PagesBox.Show();
                AuthorBox.Show();
            }

            if(command == "Update")
            {
                label2.Show();
                label3.Show();
                label4.Show();
                label5.Show();
                PriceBox.Show();
                BookNameBox.Show();
                RegionBox.Show();
                PagesBox.Show();
               
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String command = comboBox1.SelectedItem.ToString();
            String con = "Data Source = DESKTOP-PBGUL9N\\MY_SQL_SERVICE;Initial Catalog=Library;Integrated Security=true";
            if (command == "Delete")
            {
                String Query = "Delete From Buecher Where Buchnummer = '" + BuchNummerBox.Text + "'";
                using (SqlConnection connection = 
                    new SqlConnection(con))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(Query, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Sorry there isn't a book with that ID");
                    }
                }
            }

            if(command == "Insert")
            {
                String Query = "Insert into Buecher Values ('" + BookNameBox.Text + "' , '" + BuchNummerBox.Text + "' , '" +
                    RegionBox.Text + "' , '" + PagesBox.Text + "' , '" + PriceBox.Text + "' , '" + AuthorBox.Text + "')";
                using (SqlConnection connection =
                    new SqlConnection(con))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(Query, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Sorry a problem has occured !!");
                    }
                }
            }

            if(command == "Update")
            {
                String Query = "Update Buecher " +
                    "set BookName = '" + BookNameBox.Text + "' , " +
                    " Region_nummer = " + RegionBox.Text + " , " +
                    " Number_of_pages = " + PagesBox.Text + " , " +
                    " Preis = " + PriceBox.Text +
                    " Where AuthorId = " + AuthorBox.Text +";" ;
                // TODO: make this work idk why update keeps crashing smh
                MessageBox.Show(Query);
                using(SqlConnection connection = 
                    new SqlConnection(con))
                {
                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(Query, connection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Sorry an error has occured !");
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}