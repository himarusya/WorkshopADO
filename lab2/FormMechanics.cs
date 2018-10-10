using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace lab2
{
    public partial class FormMechanics : Form
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder builder;
        string queryString = "SELECT * FROM Mechanics";
        string connectionString = ConfigurationManager.ConnectionStrings["WorkshopConnectionString"].ConnectionString;

        public FormMechanics()
        {
            InitializeComponent();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Mechanics", conn);
                dataAdapter.Fill(dataSet, "Mechanics");
            }
            DisplayMechanics("");
        }

        private void DisplayMechanics(string FindFioMechanic)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string commandText = $"SELECT mechanicID, fioMechanic, qualification, experience, salary " +
                    $" FROM Mechanics WHERE fioMechanic LIKE '%" + FindFioMechanic + "%'";
                SqlCommand command = new SqlCommand(commandText, conn);
                var res = command.ExecuteReader();
                dataGridView_Mechanics.Rows.Clear();
                int i = 0;
                while (res.Read())
                {
                    dataGridView_Mechanics.Rows.Add();
                    dataGridView_Mechanics.Rows[i].Cells[0].Value = res[0];
                    dataGridView_Mechanics.Rows[i].Cells[1].Value = res[1];
                    dataGridView_Mechanics.Rows[i].Cells[2].Value = res[2];
                    dataGridView_Mechanics.Rows[i].Cells[3].Value = res[3];
                    dataGridView_Mechanics.Rows[i].Cells[4].Value = res[4];
                    i++;
                }
            }
        }

        private void dataGridView_Mechanics_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Mechanics.Rows[e.RowIndex];

                textBox1.Text = row.Cells["mechanicID"].Value.ToString();
                textBox2.Text = row.Cells["fioMechanic"].Value.ToString();
                textBox3.Text = row.Cells["qualification"].Value.ToString();
                textBox4.Text = row.Cells["experience"].Value.ToString();
                textBox5.Text = row.Cells["salary"].Value.ToString();
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
                    insertCommand.CommandText = "INSERT INTO Mechanics " +
                        "(fioMechanic, qualification, experience, salary) " +
                        "VALUES (@fioMechanic, @qualification, @experience, @salary)";
                    insertCommand.Connection = conn;
                    
                    insertCommand.Parameters.Add("@fioMechanic", SqlDbType.VarChar);
                    insertCommand.Parameters["@fioMechanic"].Value = textBox2.Text;
                    insertCommand.Parameters.Add("@qualification", SqlDbType.VarChar);
                    insertCommand.Parameters["@qualification"].Value = textBox3.Text;
                    insertCommand.Parameters.Add("@experience", SqlDbType.Int);
                    insertCommand.Parameters["@experience"].Value = textBox4.Text;
                    insertCommand.Parameters.Add("@salary", SqlDbType.Decimal);
                    insertCommand.Parameters["@salary"].Value = textBox5.Text;
                    
                    conn.Open();
                    insertCommand.ExecuteNonQuery();
                }

                DisplayMechanics("");

                MessageBox.Show("Запись добавлена.");

                dataGridView_Mechanics.CurrentCell = dataGridView_Mechanics[0, dataGridView_Mechanics.Rows.Count - 1];
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка." + exeption);
            }
        }

        //обновить
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView_Mechanics.CurrentRow == null)
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
                    updateCommand.CommandText = "UPDATE Mechanics " +
                        "SET fioMechanic=@fioMechanic, qualification=@qualification, experience=@experience, salary=@salary " +
                        "WHERE mechanicID=@mechanicID";
                    updateCommand.Connection = conn;
                    
                    updateCommand.Parameters.Add("@mechanicID", SqlDbType.Int);
                    updateCommand.Parameters["@mechanicID"].Value = idCurrentRow;
                    updateCommand.Parameters.Add("@fioMechanic", SqlDbType.VarChar);
                    updateCommand.Parameters["@fioMechanic"].Value = textBox2.Text;
                    updateCommand.Parameters.Add("@qualification", SqlDbType.VarChar);
                    updateCommand.Parameters["@qualification"].Value = textBox3.Text;
                    updateCommand.Parameters.Add("@experience", SqlDbType.Int);
                    updateCommand.Parameters["@experience"].Value = textBox4.Text;
                    updateCommand.Parameters.Add("@salary", SqlDbType.Int);
                    updateCommand.Parameters["@salary"].Value = textBox5.Text;
                    
                    conn.Open();
                    updateCommand.ExecuteNonQuery();
                }

                var currentCell = dataGridView_Mechanics.CurrentCell;
                DisplayMechanics("");

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
            int id = (int)dataGridView_Mechanics.CurrentRow.Cells[0].Value;

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

                    DataTable table = dataSet.Tables["Mechanics"];
                    
                    DataRow[] deleteRow = table.Select("mechanicID = " + id);
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
    }
}
