using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;

namespace biuropodrozyprojekt
{
    public partial class profileUserControl : UserControl
    {
        public profileUserControl()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        DataGridView dataGridView = new DataGridView()
        {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            GridColor = Color.Gray,
            AllowUserToAddRows = false,
            RowHeadersVisible = false,
            ReadOnly = true,
            AllowUserToResizeColumns = false,
            AllowUserToResizeRows = false,
            Height = 150,
            Width = 310,
            Location = new Point(15, 279),
        };
        private void showProfileInformations(object sender, EventArgs e)
        {

            dataGridView.DataBindings.Clear();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;

            cancelReservationButton.Visible = true;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", Form1.idUser);
                adapter.SelectCommand = command;

                DataTable usersTable = new DataTable();
                adapter.Fill(usersTable);

                usernameLabel.Text = "username: " + usersTable.Rows[0]["UserName"];
                emailLabel.Text = "email: " + usersTable.Rows[0]["UserMail"];
                passwordLabel.Text = "password: " + usersTable.Rows[0]["UserPassword"];
                changeLoginTx.Text = usersTable.Rows[0]["UserName"].ToString();
                changePasswordTx.Text = usersTable.Rows[0]["UserPassword"].ToString();
                changeEmailTx.Text = usersTable.Rows[0]["UserMail"].ToString();

                command = new SqlCommand("SELECT * FROM UserVacation WHERE UserId = @UserId", connection);
                command.Parameters.AddWithValue("@UserId", Form1.idUser);
                adapter.SelectCommand = command;

                DataTable reservationsTable = new DataTable();
                adapter.Fill(reservationsTable);

                dataGridView.Columns.Add("Trip ID", "Trip ID");
                dataGridView.Columns.Add("Country", "Country");
                dataGridView.Columns.Add("Number of travelers", "Number of travelers");
                dataGridView.Columns.Add("Id Trip", "Id Trip");
                dataGridView.Columns[0].Width = 57;
                dataGridView.Columns[1].Width = 100;
                dataGridView.Columns[2].Width = 150;
                dataGridView.Columns[3].Visible = false;
                dataGridView.BackgroundColor = Color.LightGray;
                dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
                dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
                dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
                dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                this.Controls.Add(dataGridView);

                DataTable tripsTable = new DataTable();
                foreach (DataRow row in reservationsTable.Rows)
                {   
                    command = new SqlCommand("SELECT Country.Country, UserVacation.NumberOfPeople, UserVacation.Id, UserVacation.VacationId FROM Vacation INNER JOIN UserVacation ON UserVacation.VacationId = Vacation.VacationId INNER JOIN Country ON Country.CountryId = Vacation.CountryId WHERE Vacation.VacationId = @VacationId", connection);
                    command.Parameters.AddWithValue("@VacationId", (int)row["VacationId"]);
                    
                    adapter.SelectCommand = command;                   
                    adapter.Fill(tripsTable);
                }

                for (int i = 0; i < reservationsTable.Rows.Count; i++)
                {
                    DataRow tripRow = tripsTable.Rows[i];
                    dataGridView.Rows.Add(tripRow["Id"], tripRow["Country"], tripRow["NumberOfPeople"], tripRow["VacationId"]);
                    dataGridView.Update();
                }
            }
        }
        private void cancelReservationButton_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = dataGridView.SelectedRows[0];
            
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM UserVacation WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", (int)selectedRow.Cells[0].Value);
                    command.ExecuteNonQuery();

                    int reservedSeats = (int)selectedRow.Cells[2].Value;
                    int vacationId = (int)selectedRow.Cells[3].Value;

                    command = new SqlCommand("UPDATE Vacation SET MaxPeople = MaxPeople + @reservedSeats WHERE VacationId = @vacationId", connection);
                    command.Parameters.AddWithValue("@reservedSeats", reservedSeats);
                    command.Parameters.AddWithValue("@vacationId", vacationId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Reservation canceled!", "Info", MessageBoxButtons.OK);

                }
                showProfileInformations(sender, e);
            }
            catch(System.ArgumentOutOfRangeException)
            {
                MessageBox.Show("Choose reservation!", "Error 404", MessageBoxButtons.OK);
            }
        }
        #region Changes

        private void changeEmailBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (changeLoginTx.Text.Length < 6 || changePasswordTx.Text.Length < 6)
                {
                    MessageBox.Show("Username and password must have at least 6 characters!", "Error 666", MessageBoxButtons.OK);
                }
                else if (!Regex.IsMatch(changeEmailTx.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
                {
                    MessageBox.Show("Enter valid email!", "Error 666", MessageBoxButtons.OK);
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string sql = "UPDATE Users SET UserName=@UserName, UserPassword=@UserPassword, UserMail=@UserMail WHERE UserId=@UserId";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@UserName", changeLoginTx.Text);
                            command.Parameters.AddWithValue("@UserPassword", changePasswordTx.Text);
                            command.Parameters.AddWithValue("@UserMail", changeEmailTx.Text);
                            command.Parameters.AddWithValue("@UserId", Form1.idUser);
                            command.ExecuteNonQuery();
                            MessageBox.Show("User data has been updated successfully!", "Success", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Username or email already exists!", "Error 666", MessageBoxButtons.OK);
            }
        }
        #endregion Changes       
    }
}
