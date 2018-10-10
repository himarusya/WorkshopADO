using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using System.Linq;


namespace lab2
{
    public partial class FormCars : Form
    {
        DataSet dataSet = new DataSet();
        SqlDataAdapter dataAdapter;
        SqlCommandBuilder builder;
        string queryString = "SELECT * FROM Cars";
        string connectionString = ConfigurationManager.ConnectionStrings["WorkshopConnectionString"].ConnectionString;

        public FormCars()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string commandText = "SELECT ownerID, fioOwner FROM Owners";
                SqlCommand command = new SqlCommand(commandText, con);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(new ComboBoxItem() { Value = Convert.ToInt32(reader[0]), Text = reader[1].ToString() });
                }
                reader.Close();
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = new SqlCommand("SELECT * FROM Cars", con);
                dataAdapter.Fill(dataSet, "Cars");
            }
            DisplayCars("");
        }

        private void DisplayCars(string FindFioOwner)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string commandText = $"SELECT carID, Cars.ownerID, model, vis, colour, yearOfIssue, bodyNumber, engineNumber, fioOwner " +
                    "FROM Cars INNER JOIN Owners ON Cars.ownerID = Owners.ownerID " +
                    "WHERE fioOwner LIKE '%" + FindFioOwner + "%'";
                SqlCommand command = new SqlCommand(commandText, conn);
                var res = command.ExecuteReader();
                dataGridView_Cars.Rows.Clear();
                int i = 0;
                while (res.Read())
                {
                    dataGridView_Cars.Rows.Add();
                    dataGridView_Cars.Rows[i].Cells[0].Value = res[0];
                    dataGridView_Cars.Rows[i].Cells[1].Value = res[8];
                    dataGridView_Cars.Rows[i].Cells[2].Value = res[2];
                    dataGridView_Cars.Rows[i].Cells[3].Value = res[3];
                    dataGridView_Cars.Rows[i].Cells[4].Value = res[4];
                    dataGridView_Cars.Rows[i].Cells[5].Value = Convert.ToDateTime(res[5]).ToString("dd.MM.yyyy");
                    dataGridView_Cars.Rows[i].Cells[6].Value = res[6];
                    dataGridView_Cars.Rows[i].Cells[7].Value = res[7];
                    i++;
                }
            }
        }

        private void dataGridView_Cars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Cars.Rows[e.RowIndex];

                textBox1.Text = row.Cells["carID"].Value.ToString();
                var arr = comboBox1.Items.Cast<ComboBoxItem>().Select(item => item).ToArray();
                comboBox1.SelectedItem = arr.First(p => p.Text == row.Cells["ownerID"].Value.ToString());
                textBox2.Text = row.Cells["model"].Value.ToString();
                textBox3.Text = row.Cells["vis"].Value.ToString();
                textBox4.Text = row.Cells["colour"].Value.ToString();
                dateTimePicker1.Text = row.Cells["yearOfIssue"].Value.ToString();
                textBox5.Text = row.Cells["bodyNumber"].Value.ToString();
                textBox6.Text = row.Cells["engineNumber"].Value.ToString();
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
                    insertCommand.CommandText = "INSERT INTO Cars " +
                        "(ownerID, model, vis, colour, yearOfIssue, bodyNumber, engineNumber) " +
                        "VALUES (@ownerID, @model, @vis, @colour, @yearOfIssue, @bodyNumber, @engineNumber)";
                    insertCommand.Connection = conn;

                    insertCommand.Parameters.Add("@ownerID", SqlDbType.Int);
                    insertCommand.Parameters["@ownerID"].Value = comboBox1.SelectedValue;
                    insertCommand.Parameters.Add("@model", SqlDbType.VarChar);
                    insertCommand.Parameters["@model"].Value = textBox2.Text;
                    insertCommand.Parameters.Add("@vis", SqlDbType.Int);
                    insertCommand.Parameters["@vis"].Value = textBox3.Text;
                    insertCommand.Parameters.Add("@colour", SqlDbType.VarChar);
                    insertCommand.Parameters["@colour"].Value = textBox4.Text;
                    insertCommand.Parameters.Add("@yearOfIssue", SqlDbType.Date);
                    insertCommand.Parameters["@yearOfIssue"].Value = dateTimePicker1.Text;
                    insertCommand.Parameters.Add("@bodyNumber", SqlDbType.Int);
                    insertCommand.Parameters["@bodyNumber"].Value = textBox5.Text;
                    insertCommand.Parameters.Add("@engineNumber", SqlDbType.Int);
                    insertCommand.Parameters["@engineNumber"].Value = textBox6.Text;

                    conn.Open();
                    insertCommand.ExecuteNonQuery();
                }

                DisplayCars("");
                MessageBox.Show("Запись добавлена.");

                dataGridView_Cars.CurrentCell = dataGridView_Cars[0, dataGridView_Cars.Rows.Count - 1];
            }
            catch (Exception exeption)
            {
                MessageBox.Show("Ошибка." + exeption);
            }
        }

        //обновить
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView_Cars.CurrentRow == null)
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
                    updateCommand.CommandText = "UPDATE Cars " +
                        "SET ownerID=@ownerID, model=@model, vis=@vis, colour=@colour, yearOfIssue=@yearOfIssue, bodyNumber=@bodyNumber, engineNumber=@engineNumber " +
                        "WHERE carID=@carID";
                    updateCommand.Connection = conn;

                    updateCommand.Parameters.AddWithValue("@carID", idCurrentRow);
                    updateCommand.Parameters.Add("@ownerID", SqlDbType.Int);
                    updateCommand.Parameters["@ownerID"].Value = ((ComboBoxItem)comboBox1.SelectedItem).Value;
                    updateCommand.Parameters.Add("@model", SqlDbType.VarChar);
                    updateCommand.Parameters["@model"].Value = textBox2.Text;
                    updateCommand.Parameters.Add("@vis", SqlDbType.Int);
                    updateCommand.Parameters["@vis"].Value = textBox3.Text;
                    updateCommand.Parameters.Add("@colour", SqlDbType.VarChar);
                    updateCommand.Parameters["@colour"].Value = textBox4.Text;
                    updateCommand.Parameters.Add("@yearOfIssue", SqlDbType.Date);
                    updateCommand.Parameters["@yearOfIssue"].Value = dateTimePicker1.Text;
                    updateCommand.Parameters.Add("@bodyNumber", SqlDbType.Int);
                    updateCommand.Parameters["@bodyNumber"].Value = textBox5.Text;
                    updateCommand.Parameters.Add("@engineNumber", SqlDbType.Int);
                    updateCommand.Parameters["@engineNumber"].Value = textBox6.Text;

                    conn.Open();
                    updateCommand.ExecuteNonQuery();
                }

                var currentCell = dataGridView_Cars.CurrentCell;
                DisplayCars("");

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
            int id = (int)dataGridView_Cars.CurrentRow.Cells[0].Value;

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

                    DataTable table = dataSet.Tables["Cars"];

                    DataRow[] deleteRow = table.Select("carID = " + id);
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
