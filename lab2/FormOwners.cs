using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace lab2
{
    public partial class FormOwners : Form
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder builder;
        string queryString = "SELECT * FROM Owners";
        string connectionString = ConfigurationManager.ConnectionStrings["WorkshopConnectionString"].ConnectionString;


        public FormOwners()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Owners", conn);
                dataAdapter.Fill(dataSet, "Owners");
            }
            DisplayOwners("");
        }

        private void DisplayOwners(string FindFioOwner)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string commandText = $"SELECT ownerID, driverLicense, fioOwner, adress, phone " +
                    $"FROM Owners WHERE fioOwner LIKE '%" + FindFioOwner + "%'";
                SqlCommand command = new SqlCommand(commandText, conn);
                var res = command.ExecuteReader();
                dataGridView_Owners.Rows.Clear();
                int i = 0;
                while (res.Read())
                {
                    dataGridView_Owners.Rows.Add();
                    dataGridView_Owners.Rows[i].Cells[0].Value = res[0];
                    dataGridView_Owners.Rows[i].Cells[1].Value = res[1];
                    dataGridView_Owners.Rows[i].Cells[2].Value = res[2];
                    dataGridView_Owners.Rows[i].Cells[3].Value = res[3];
                    dataGridView_Owners.Rows[i].Cells[4].Value = res[4];
                    i++;
                }
            }
        }

        //добавить
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.CommandText = "INSERT INTO Owners " +
                        "(driverLicense, fioOwner, adress, phone) " +
                        "VALUES (@driverLicense, @fioOwner, @adress, @phone)";
                    insertCommand.Connection = conn;
                    
                    insertCommand.Parameters.Add("@driverLicense", SqlDbType.Int);
                    insertCommand.Parameters["@driverLicense"].Value = textBox2.Text;
                    insertCommand.Parameters.Add("@fioOwner", SqlDbType.VarChar);
                    insertCommand.Parameters["@fioOwner"].Value = textBox3.Text;
                    insertCommand.Parameters.Add("@adress", SqlDbType.VarChar);
                    insertCommand.Parameters["@adress"].Value = textBox4.Text;
                    insertCommand.Parameters.Add("@phone", SqlDbType.Int);
                    insertCommand.Parameters["@phone"].Value = textBox5.Text;
                    
                    conn.Open();
                    insertCommand.ExecuteNonQuery();
                }

                DisplayOwners("");
                MessageBox.Show("Запись добавлена.");

                dataGridView_Owners.CurrentCell = dataGridView_Owners[0, dataGridView_Owners.Rows.Count - 1];
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка." + exeption);
            }
        }

        //обновить
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView_Owners.CurrentRow == null)
            {
                MessageBox.Show("Запись не обновлена.");
                return;

            }
            int idCurrentRow = 1;
            if (textBox1.Text != "")
            {
                idCurrentRow = Convert.ToInt32(textBox1.Text);
            }
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.CommandText = "UPDATE Owners " +
                        "SET driverLicense=@driverLicense, fioOwner=@fioOwner, adress=@adress, phone=@phone " +
                        "WHERE ownerID=@ownerID";
                    updateCommand.Connection = conn;
                    
                    updateCommand.Parameters.Add("@ownerID", SqlDbType.Int);
                    updateCommand.Parameters["@ownerID"].Value = idCurrentRow;
                    updateCommand.Parameters.Add("@driverLicense", SqlDbType.Int);
                    updateCommand.Parameters["@driverLicense"].Value = textBox2.Text;
                    updateCommand.Parameters.Add("@fioOwner", SqlDbType.VarChar);
                    updateCommand.Parameters["@fioOwner"].Value = textBox3.Text;
                    updateCommand.Parameters.Add("@adress", SqlDbType.VarChar);
                    updateCommand.Parameters["@adress"].Value = textBox4.Text;
                    updateCommand.Parameters.Add("@phone", SqlDbType.Int);
                    updateCommand.Parameters["@phone"].Value = textBox5.Text;
                    
                    conn.Open();
                    updateCommand.ExecuteNonQuery();
                }

                var currentCell = dataGridView_Owners.CurrentCell;
                DisplayOwners("");
                
                MessageBox.Show("Запись обновлена.");
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка." + exeption);
            }
        }
        
        //удалить
        private void buttonDel_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView_Owners.CurrentRow.Cells[0].Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = queryString;
                    command.Connection = conn;
                    
                    dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = command;
                    
                    builder = new SqlCommandBuilder();
                    builder.DataAdapter = dataAdapter;
                    dataAdapter.DeleteCommand = builder.GetDeleteCommand();

                    DataTable table = dataSet.Tables["Owners"];
                    
                    DataRow[] deleteRow = table.Select("ownerID = " + id);
                    foreach (DataRow row in deleteRow)
                    {
                        row.Delete();
                    }
                    dataAdapter.Update(table);
                    table.AcceptChanges();
                }

                MessageBox.Show("Запись удалена.");

            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка." + exeption);
            }
        }
                
        private void dataGridView_Owners_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Owners.Rows[e.RowIndex];

                textBox1.Text = row.Cells["ownerID"].Value.ToString();
                textBox2.Text = row.Cells["driverLicense"].Value.ToString();
                textBox3.Text = row.Cells["fioOwner"].Value.ToString();
                textBox4.Text = row.Cells["adress"].Value.ToString();
                textBox5.Text = row.Cells["phone"].Value.ToString();
            }   
        }
    }
}
