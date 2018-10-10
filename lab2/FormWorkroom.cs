using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;

namespace lab2
{
    public partial class FormWorkroom : Form
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder builder;
        string queryString = "SELECT * FROM Workroom";
        string connectionString = ConfigurationManager.ConnectionStrings["WorkshopConnectionString"].ConnectionString;

        public FormWorkroom()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string commandText1 = "SELECT carID, model FROM Cars";
                SqlCommand command1 = new SqlCommand(commandText1, con);
                var reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox1.Items.Add(new ComboBoxItem() { Value = Convert.ToInt32(reader1[0]), Text = reader1[1].ToString() });
                }
                reader1.Close();
                string commandText2 = "SELECT mechanicID, fioMechanic FROM Mechanics";
                SqlCommand command2 = new SqlCommand(commandText2, con);
                var reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    comboBox2.Items.Add(new ComboBoxItem() { Value = Convert.ToInt32(reader2[0]), Text = reader2[1].ToString() });
                }
                reader2.Close();
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Workroom", con);
                dataAdapter.Fill(dataSet, "Workroom");
            }
            
            DisplayWorkroom("", "");
        }

        private void DisplayWorkroom(string FindCar, string FindFioMechanic)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string commandText = $"SELECT workroomID, Workroom.carID, Workroom.mechanicID, receiptDate, cost, model,  fioMechanic " +
                    "FROM Workroom INNER JOIN Cars on Workroom.carID = Cars.carID INNER " +
                    "JOIN Mechanics on Workroom.mechanicID = Mechanics.mechanicID " +
                    "WHERE model LIKE '%" + FindCar + "%' " +
                    "AND fioMechanic LIKE '%" + FindFioMechanic + "%' ORDER BY workroomID";
                SqlCommand command = new SqlCommand(commandText, conn);
                var res = command.ExecuteReader();
                dataGridView_Workroom.Rows.Clear();
                int i = 0;
                while(res.Read())
                {
                    dataGridView_Workroom.Rows.Add();
                    dataGridView_Workroom.Rows[i].Cells[0].Value = res[0];
                    dataGridView_Workroom.Rows[i].Cells[1].Value = res[5];
                    dataGridView_Workroom.Rows[i].Cells[2].Value = res[6];
                    dataGridView_Workroom.Rows[i].Cells[3].Value = Convert.ToDateTime(res[3]).ToString("dd.MM.yyyy");
                    dataGridView_Workroom.Rows[i].Cells[4].Value = res[4];
                    i++;
                }
            }
        }

        private void dataGridView_Workroom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Workroom.Rows[e.RowIndex];

                textBox1.Text = row.Cells["workroomID"].Value.ToString();
                var arr1 = comboBox1.Items.Cast<ComboBoxItem>().Select(item => item).ToArray();
                comboBox1.SelectedItem = arr1.First(p => p.Text == row.Cells["carID"].Value.ToString());
                var arr2 = comboBox2.Items.Cast<ComboBoxItem>().Select(item => item).ToArray();
                comboBox2.SelectedItem = arr2.First(p => p.Text == row.Cells["mechanicID"].Value.ToString());
                dateTimePicker1.Text = row.Cells["receiptDate"].Value.ToString();
                textBox2.Text = row.Cells["cost"].Value.ToString();
            }
        }

        //добавить
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand insertCommand = new SqlCommand();
                    insertCommand.CommandText = "INSERT INTO Workroom" +
                        "(carID, mechanicID, receiptDate, cost)" +
                        "VALUES (@carID, @mechanicID, @receiptDate, @cost)";
                    insertCommand.Connection = conn;
                    
                    insertCommand.Parameters.Add("@carID", SqlDbType.Int);
                    insertCommand.Parameters["@carID"].Value = comboBox1.SelectedValue;
                    insertCommand.Parameters.Add("@mechanicID", SqlDbType.Int);
                    insertCommand.Parameters["@mechanicID"].Value = comboBox2.SelectedValue;
                    insertCommand.Parameters.Add("@receiptDate", SqlDbType.Date);
                    insertCommand.Parameters["@receiptDate"].Value = dateTimePicker1.Text;
                    insertCommand.Parameters.Add("@cost", SqlDbType.Decimal);
                    insertCommand.Parameters["@cost"].Value = textBox2.Text;

                    conn.Open();
                    insertCommand.ExecuteNonQuery();
                }

                DisplayWorkroom("", "");
                MessageBox.Show("Запись добавлена.");

                dataGridView_Workroom.CurrentCell = dataGridView_Workroom[0, dataGridView_Workroom.Rows.Count - 1];
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка." + exeption);
            }
        }

        //обновить
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView_Workroom.CurrentRow == null)
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
                    updateCommand.CommandText = "UPDATE Workroom " +
                        "SET carID=@carID, mechanicID=@mechanicID, receiptDate=@receiptDate, cost=@cost " +
                        "WHERE workroomID=@workroomID";
                    updateCommand.Connection = conn;
                    
                    updateCommand.Parameters.Add("@workroomID", SqlDbType.Int);
                    updateCommand.Parameters["@workroomID"].Value = idCurrentRow;
                    updateCommand.Parameters.Add("@carID", SqlDbType.Int);
                    updateCommand.Parameters["@carID"].Value = ((ComboBoxItem)comboBox1.SelectedItem).Value;
                    updateCommand.Parameters.Add("@mechanicID", SqlDbType.Int);
                    updateCommand.Parameters["@mechanicID"].Value = ((ComboBoxItem)comboBox2.SelectedItem).Value;
                    updateCommand.Parameters.Add("@receiptDate", SqlDbType.Date);
                    updateCommand.Parameters["@receiptDate"].Value = dateTimePicker1.Text;
                    updateCommand.Parameters.Add("@cost", SqlDbType.Decimal);
                    updateCommand.Parameters["@cost"].Value = textBox2.Text;
                    
                    conn.Open();
                    updateCommand.ExecuteNonQuery();
                }

                var currentCell = dataGridView_Workroom.CurrentCell;
                DisplayWorkroom("", "");
                
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
            int id = (int)dataGridView_Workroom.CurrentRow.Cells[0].Value;

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

                    DataTable table = dataSet.Tables["Workroom"];
                    
                    DataRow[] deleteRow = table.Select("workroomID = " + id);
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

        //переход к таблице Владельцы
        private void toolStripButton_Owners_Click(object sender, EventArgs e)
        {
            FormOwners formOwners = new FormOwners();
            formOwners.Show();
        }

        //перехад к таблице Автомобили
        private void toolStripButton__Cars_Click(object sender, EventArgs e)
        {
            FormCars formCars = new FormCars();
            formCars.Show();
        }

        //переход к таблице Механики
        private void toolStripButton_Mechanics_Click(object sender, EventArgs e)
        {
            FormMechanics formMechanics = new FormMechanics();
            formMechanics.Show();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            DisplayWorkroom(textBox_model.Text, textBox_mechanic.Text);
        }
    }
}
