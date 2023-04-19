using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Globalization;
using System.Diagnostics;

namespace biuropodrozyprojekt
{
    public partial class AdminControlCheckInformations : UserControl
    {
        public AdminControlCheckInformations()
        {
            InitializeComponent();
        }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private void button1_Click(object sender, EventArgs e)
        {
            UserClass user = new UserClass();

            Form form = new Form()
            {
                Width = 660,
                Text = "All users",
                Height = 550,
            };

            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "Users",
                Height = 400,
                Width = 623,
                Location = new Point(10,10),
            };

            dataGridView.DataBindings.Clear();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.Gray;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataSet dataSet = new DataSet();
            DataTable usersTable = new DataTable("Users");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT Users.UserId, Users.UserName, Users.UserPassword, Users.UserMail, Roles.RoleName AS Role FROM Users INNER JOIN Roles ON Roles.RoleId = Users.RoleId", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(usersTable);
            }

            dataSet.Tables.Add(usersTable);          
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;
            dataGridView.Columns[0].Width = 60;
            dataGridView.Columns[1].Width = 150;
            dataGridView.Columns[2].Width = 150;
            dataGridView.Columns[3].Width = 200;
            dataGridView.Columns[4].Width = 60;

            Button btnDelete = new Button
            {
                Text = "Delete user",
                Font = new Font("Century Gothic", 10, FontStyle.Regular),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(500, 450),
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete.Click += new EventHandler((senderDelete, eDelete) =>
            {
                var selectedRow = dataGridView.SelectedRows[0];
                int userId = (int)selectedRow.Cells[0].Value;
                user.DeleteUser(userId);
                form.Close();
            });

            form.Controls.Add(btnDelete);
            form.Show();

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                int rowIndex = e2.RowIndex;
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                int userId = (int)row.Cells["UserId"].Value;


                user = user.GetUser(userId);

                Form formUser = new Form()
                {
                    Text = "Edit user",
                    Width = 360,
                    Height = 400,
                    BackColor = SystemColors.ButtonHighlight,
                    MaximumSize = new Size(360, 400),
                    MinimumSize = new Size(360, 400),
                };

                FlowLayoutPanel flowLayoutPanelUser = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };
                formUser.Controls.Add(flowLayoutPanelUser);

                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 350
                };

                Label labelUserId = new Label()
                { 
                    Text = "               id: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                Label labelUserId2 = new Label()
                {
                    Text = user.UserIdGS.ToString(),
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelUserName = new Label()
                {
                    Text = "username: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 70),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                TextBox textBoxUserName = new TextBox()
                {
                    Text = user.UserNameGS,
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 70),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelPassword = new Label()
                {
                    Text = " password: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 120),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                TextBox textBoxPassword = new TextBox()
                {
                    Text = user.PasswordGS,
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 120),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelEmail = new Label()
                {
                    Text = "         email: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 170),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                TextBox textBoxEmail = new TextBox()
                {
                    Text = user.EmailGS,
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 170),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelRole = new Label()
                {
                    Text = "          role: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 220),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                ComboBox comboBoxRoleName = new ComboBox
                {
                    Width = 150,
                    Location = new Point(140, 220),
                };
                comboBoxRoleName.Items.AddRange(new[] { "admin", "user" });

                switch (user.RoleGS)
                {
                    case 1:
                        comboBoxRoleName.SelectedIndex = 0; 
                        break;
                    case 2:
                        comboBoxRoleName.SelectedIndex = 1; 
                        break;
                }

                Button btnApply = new Button
                {
                    Text = "Apply changes",
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(150, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(140, 270),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                btnApply.Click += new EventHandler((senderApply, eApply) =>
                {
                    if(comboBoxRoleName.SelectedIndex == 0) user.UpdateUser(int.Parse(labelUserId2.Text), textBoxUserName.Text.ToString(), textBoxPassword.Text.ToString(), textBoxEmail.Text.ToString(), 1);
                    if(comboBoxRoleName.SelectedIndex == 1) user.UpdateUser(int.Parse(labelUserId2.Text), textBoxUserName.Text.ToString(), textBoxPassword.Text.ToString(), textBoxEmail.Text.ToString(), 2);
                    formUser.Close();
                    form.Close();
                });


                Control[] controlsDetails = { btnApply, labelRole, comboBoxRoleName, labelUserId, labelUserId2, labelUserName, textBoxUserName, labelPassword, textBoxPassword, labelEmail, textBoxEmail };

                panel.Controls.AddRange(controlsDetails);
                flowLayoutPanelUser.Controls.Add(panel);
                formUser.Controls.Add(flowLayoutPanelUser);
                formUser.Show();
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "Countries",
                Width = 550,
                Height = 500,
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "Country",
                Height = 430,
                Width = 250,
                Location = new Point(10,10)
            };

            dataGridView.DataBindings.Clear();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.Gray;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataSet dataSet = new DataSet();
            DataTable countriesTable = new DataTable("Country");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM Country", connection);

                adapter.SelectCommand = command;
                adapter.Fill(countriesTable);
            }

            dataSet.Tables.Add(countriesTable);
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;
            dataGridView.Columns[1].Width = 130;

            Button btnDelete = new Button
            {
                Text = "Delete country",
                Font = new Font("Century Gothic", 10, FontStyle.Regular),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(385, 400),
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat
            };
            CountryClass country = new CountryClass();
            btnDelete.Click += new EventHandler((senderDelete, eDelete) =>
            {
                var selectedRow = dataGridView.SelectedRows[0];
                int countryId = (int)selectedRow.Cells[0].Value;
                country.DeleteCountry(countryId);
                form.Close();
            });

            form.Controls.Add(btnDelete);

            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            CityClass city = new CityClass();
            Form form = new Form()
            {
                Text = "Cities Datagrid",
                Width = 490,
                Height = 560,
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "CountryCity",
                Height = 400,
                Width = 420,
                Location = new Point(10, 10),
            };

            dataGridView.DataBindings.Clear();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.Gray;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            Button btnDelete = new Button
            {
                Text = "Delete city",
                Font = new Font("Century Gothic", 10, FontStyle.Regular),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(300, 440),
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete.Click += new EventHandler((senderDelete, eDelete) =>
            {
                var selectedRow = dataGridView.SelectedRows[0];
                int cityId = (int)selectedRow.Cells[0].Value;
                city.DeleteCity(cityId);
                form.Close();
            });

            form.Controls.Add(btnDelete);
            DataSet dataSet = new DataSet();
            DataTable citiesTable = new DataTable("CountryCity");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT CountryCity.CityId, CountryCity.City, Country.Country, Country.CountryId FROM CountryCity INNER JOIN Country ON Country.CountryId = CountryCity.CountryId", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(citiesTable);
            }

            dataSet.Tables.Add(citiesTable);
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;
            form.Show();

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                int rowIndex = e2.RowIndex;
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                int cityId = (int)row.Cells["CityId"].Value;
                city = city.GetCity(cityId);

                Form formCity = new Form()
                {
                    Text = "Edit city",
                    Width = 330,
                    Height = 300,
                    BackColor = SystemColors.ButtonHighlight,
                    MaximumSize = new Size(330, 300),
                    MinimumSize = new Size(330, 300),
                };

                FlowLayoutPanel flowLayoutPanelUser = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };
                formCity.Controls.Add(flowLayoutPanelUser);

                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 250
                };

                Label labelUserId = new Label()
                {
                    Text = "id: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
                };

                Label labelUserId2 = new Label()
                {
                    Text = city.CityIdGS.ToString(),
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelUserName = new Label()
                {
                    Text = "city: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 70),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
                };

                TextBox textBoxCityName = new TextBox()
                {
                    Text = city.CityNameGS,
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 70),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelCountryName = new Label()
                {
                    Text = "country: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 120),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight,
                };

                ComboBox comboBoxCountryName = new ComboBox()
                {
                    Width = 150,
                    Location = new Point(140, 120),
                    DisplayMember = "Country",
                    ValueMember = "CountryId",
                    Font = new Font("Century Gothic", 14),
                };

                DataTable countriesTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT CountryId, Country FROM Country", connection);

                    adapter.SelectCommand = command;
                    adapter.Fill(countriesTable);
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT CountryId, Country FROM Country", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    int selectedCountryIndex = -1;
                    while (reader.Read())
                    {
                        int id = (int)reader["CountryId"];
                        string name = reader["Country"].ToString();

                        CountryClass item = new CountryClass { CountryIdGS = id, CountryNameGS = name };
                        comboBoxCountryName.Items.Add(item.CountryNameGS);

                        if (city.CountryIdGS == item.CountryIdGS)
                        {
                            selectedCountryIndex = comboBoxCountryName.Items.Count - 1;
                        }
                    }
                    comboBoxCountryName.SelectedIndex = selectedCountryIndex;
                }

                Button btnApply = new Button
                {
                    Text = "Apply changes",
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(150, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(140, 200),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                btnApply.Click += new EventHandler((senderApply, eApply) =>
                {
                    city.UpdateCity(cityId, textBoxCityName.Text.ToString(), comboBoxCountryName.SelectedIndex + 1);
                    formCity.Close();
                    form.Close();
                });

                Control[] controlsDetails = { labelUserId, labelUserId2, labelUserName, textBoxCityName, comboBoxCountryName, labelCountryName, btnApply };
                panel.Controls.AddRange(controlsDetails);
                flowLayoutPanelUser.Controls.Add(panel);
                formCity.Controls.Add(flowLayoutPanelUser);
                formCity.Show();
            };
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "Travel DataGrid",
                Width = 1150,
                Height = 500,
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "Vacation",
                Width = 1150,
                Height = 350,
                Location = new Point(10, 10),
            };

            dataGridView.DataBindings.Clear();
            dataGridView.Columns.Clear();
            dataGridView.DataSource = null;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.GridColor = Color.Gray;
            dataGridView.BackgroundColor = Color.LightGray;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            DataSet dataSet = new DataSet();
            DataTable travelTable = new DataTable("Vacation");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, TypeOfVacation.TypeName, Country.Country, CountryCity.City, Vacation.MaxPeople, Vacation.HotelName, Vacation.HotelRating, Vacation.Price, VehicleType.VehicleName as Vehicle, DateVacation.DepartureDate, DateVacation.ArrivalDate  FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationId = Vacation.VacationId INNER JOIN Country ON Country.CountryId = Vacation.CountryId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN TypeOfVacation ON Vacation.TypeId = TypeOfVacation.TypeId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId", connection);

                adapter.SelectCommand = command;
                adapter.Fill(travelTable);
            }

            dataSet.Tables.Add(travelTable);
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;

            dataGridView.Columns[5].Width = 130;
            dataGridView.Columns[9].Width = 110;
            dataGridView.Columns[10].Width = 100;

            Button btnDelete = new Button
            {
                Text = "Delete trip",
                Font = new Font("Century Gothic", 10, FontStyle.Regular),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(985, 400),
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat
            };

            Control[] controlsDetails = { btnDelete };
            form.Controls.AddRange(controlsDetails);

            form.Show();

            HolidaysClass holiday = new HolidaysClass();

            btnDelete.Click += new EventHandler((senderDelete, eDelete) =>
            {
                var selectedRow = dataGridView.SelectedRows[0];
                int tripId = (int)selectedRow.Cells[0].Value;
                holiday.DeleteTrip(tripId);
                form.Close();
            });

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                int rowIndex = e2.RowIndex;
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                int tripId = (int)row.Cells["VacationId"].Value;

                holiday = holiday.GetHolidays(tripId);

                Form formTrip = new Form()
                {
                    Text = "Edit holiday",
                    Width = 800,
                    Height = 700,
                    BackColor = SystemColors.ButtonHighlight,
                    MaximumSize = new Size(800, 600),
                    MinimumSize = new Size(800, 600),
                };

                FlowLayoutPanel flowLayoutPanelTrip = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };
                formTrip.Controls.Add(flowLayoutPanelTrip);

                Panel panel = new Panel
                {
                    Width = 750,
                    Height = 550
                };

                Label labelTripId = new Label()
                {
                    Text = "id: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                Label labelTripId2 = new Label()
                {
                    Text = holiday.VacationIdGS.ToString(),
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelType = new Label()
                {
                    Text = "type: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 60),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                ComboBox comboBoxTypeName = new ComboBox
                {
                    Width = 150,
                    Location = new Point(140, 60),
                    Font = new Font("Century Gothic", 10)
                };
                comboBoxTypeName.Items.AddRange(new[] { "National", "International" });

                switch (holiday.TypeIdGS)
                {
                    case 1:
                        comboBoxTypeName.SelectedIndex = 0;
                        break;
                    case 2:
                        comboBoxTypeName.SelectedIndex = 1;
                        break;
                }

                Label labelCountry = new Label()
                {
                    Text = "country: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 100),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                ComboBox comboBoxCountries = new ComboBox
                {
                    Width = 150,
                    Location = new Point(140, 100),
                    Font = new Font("Century Gothic", 10)
                };

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT CountryId, Country FROM Country", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    int selectedCountryIndex = -1;
                    while (reader.Read())
                    {
                        int id = (int)reader["CountryId"];
                        string name = reader["Country"].ToString();

                        CountryClass item = new CountryClass { CountryIdGS = id, CountryNameGS = name };
                        comboBoxCountries.Items.Add(item.CountryNameGS);

                        if (holiday.CountryIdGS == item.CountryIdGS)
                        {
                            selectedCountryIndex = comboBoxCountries.Items.Count - 1;
                        }
                    }
                    comboBoxCountries.SelectedIndex = selectedCountryIndex;
                }

                Label labelCity = new Label()
                {
                    Text = "city: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 140),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                ComboBox comboBoxCities = new ComboBox
                {
                    Width = 150,
                    Location = new Point(140, 140),
                    Font = new Font("Century Gothic", 10)
                };

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT CityId, City, CountryId FROM CountryCity WHERE CountryId=@CountryId", connection);
                    command.Parameters.AddWithValue("@CountryId", holiday.CountryIdGS);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int id = (int)reader["CityId"];
                        string name = reader["City"].ToString();
                        int countryId = (int)reader["CountryId"];
                        CityClass item = new CityClass { CityIdGS = id, CityNameGS = name, CountryIdGS = countryId };
                        comboBoxCities.Items.Add(item.CityNameGS);

                        if (holiday.CityIdGS == item.CityIdGS)
                        {
                            comboBoxCities.SelectedItem = item.CityNameGS;
                        }
                    }
                }

                comboBoxCountries.SelectedIndexChanged += (senderCity, eCity) =>
                {
                    string selectedCountry = comboBoxCountries.SelectedItem.ToString();

                    comboBoxCities.Items.Clear();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("SELECT City FROM CountryCity WHERE CountryId = (SELECT CountryId FROM Country WHERE Country = @SelectedCountry)", connection);
                        command.Parameters.AddWithValue("@SelectedCountry", selectedCountry);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            comboBoxCities.Items.Add(reader["City"].ToString());
                        }

                        if (comboBoxCities.Items.Count > 0)
                        {
                            comboBoxCities.SelectedIndex = 0;
                        }
                        else
                        {
                            comboBoxCities.Text = null;
                        }

                    }
                };

                Label labelPeople = new Label()
                {
                    Text = "people limit: ",
                    Height = 25,
                    Width = 130,
                    Location = new Point(10, 180),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                NumericUpDown numericPeople = new NumericUpDown()
                {
                    Value = holiday.MaxPeopleGS,
                    Maximum = 1000,
                    Height = 25,
                    Width = 120,
                    Location = new Point(140, 180),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                Label labelPrice = new Label()
                {
                    Text = "price: ",
                    Height = 25,
                    Width = 130,
                    Location = new Point(10, 220),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                NumericUpDown numericPrice = new NumericUpDown()
                {
                    Maximum = 1000000,
                    Value = holiday.PriceGS,
                    Height = 25,
                    Width = 120,
                    Location = new Point(140, 220),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                Label labelHotelName = new Label()
                {
                    Text = "hotel name: ",
                    Height = 25,
                    Width = 130,
                    Location = new Point(10, 260),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                TextBox textBoxHotelName = new TextBox()
                {
                    Text = holiday.HotelNameGS,
                    Height = 25,
                    Width = 200,
                    Location = new Point(140, 260),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelHotelRating = new Label()
                {
                    Text = "hotel rating: ",
                    Height = 25,
                    Width = 130,
                    Location = new Point(10, 300),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                NumericUpDown numericHotelRating = new NumericUpDown()
                {
                    Maximum = 10,
                    Value = holiday.HotelRatingGS,
                    Height = 25,
                    Width = 120,
                    Location = new Point(140, 300),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14)
                };

                Label labelVehicleType = new Label()
                {
                    Text = "vehicle: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 340),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                ComboBox comboBoxVehicleType = new ComboBox
                {
                    Width = 150,
                    Location = new Point(140, 340),
                    Font = new Font("Century Gothic", 10)
                };
                comboBoxVehicleType.Items.AddRange(new[] { "Plane", "Bus", "Train", "Cruise ship" });

                switch (holiday.VehicleIdGS)
                {
                    case 1:
                        comboBoxVehicleType.SelectedIndex = 0;
                        break;
                    case 2:
                        comboBoxVehicleType.SelectedIndex = 1;
                        break;
                    case 3:
                        comboBoxVehicleType.SelectedIndex = 2;
                        break;
                    case 4:
                        comboBoxVehicleType.SelectedIndex = 3;
                        break;
                }

                Label labelShortDescription = new Label()
                {
                    Text = "Short Desctipton",
                    Height = 25,
                    Width = 180,
                    Location = new Point(500, 10),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                TextBox textBoxShortDescription = new TextBox()
                {
                    Text = holiday.ShortDescriptionGS,
                    Height = 110,
                    Width = 300,
                    Location = new Point(450, 40),
                    Multiline = true,
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12),
                    MaxLength = 100,
                };

                textBoxShortDescription.TextChanged += (senderSD, eSD) =>
                {
                    if (textBoxShortDescription.Text.Length > 90 && textBoxShortDescription.Text.Length <100)
                    {
                        textBoxShortDescription.BackColor = Color.LightCoral;
                    }
                    else if(textBoxShortDescription.Text.Length == 100)
                    {
                        textBoxShortDescription.BackColor = Color.Red;
                    }
                    else
                    {
                        textBoxShortDescription.BackColor = SystemColors.ButtonHighlight;
                    }
                };

                Label labelDepartureDate = new Label()
                {
                    Text = "departure: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 380),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                HolidayDateClass dateTrip = new HolidayDateClass();

                dateTrip = dateTrip.GetVacationDate(holiday.VacationIdGS);

                DateTimePicker dateTimePicker = new DateTimePicker()
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dd.MM.yyyy",
                    Location = new Point(140,380),
                    Width = 120,
                    Font = new Font("Century Gothic", 12),
                    Height = 25
                };


                DateTime date;
                if (DateTime.TryParseExact(dateTrip.DepartureDateGS, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    dateTimePicker.Value = date;
                }

                Label labelArrivalDate = new Label()
                {
                    Text = "arrival: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 420),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.MiddleRight
                };

                DateTimePicker dateTimePickerArrival = new DateTimePicker()
                {
                    Format = DateTimePickerFormat.Custom,
                    CustomFormat = "dd.MM.yyyy",
                    Location = new Point(140, 420),
                    Width = 120,
                    Font = new Font("Century Gothic", 12),
                    Height = 25
                };

                if (DateTime.TryParseExact(dateTrip.ArrivalDateGS, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    dateTimePickerArrival.Value = date;
                }

                Button btnUpdate = new Button
                {
                    Text = "Update trip",
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(130, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(620, 480),
                    BackColor = Color.LightGreen,
                    FlatStyle = FlatStyle.Flat
                };

                Control[] controlsDetailsTrip = { btnUpdate, dateTimePickerArrival, labelArrivalDate, labelDepartureDate, dateTimePicker, labelShortDescription, textBoxShortDescription, comboBoxVehicleType, labelVehicleType, labelHotelRating, numericHotelRating, textBoxHotelName, labelHotelName, labelPrice, numericPrice, labelPeople, numericPeople, labelCity, comboBoxCities, labelTripId, labelTripId2, labelType, comboBoxTypeName, labelCountry, comboBoxCountries };

                panel.Controls.AddRange(controlsDetailsTrip);
                flowLayoutPanelTrip.Controls.Add(panel);
                formTrip.Controls.Add(flowLayoutPanelTrip);
                formTrip.Show();


                btnUpdate.Click += new EventHandler((senderApply, eApply) =>
                {
                    labelCountry.Text = comboBoxCountries.Text.ToString();
                    holiday.updateVacation(holiday.VacationIdGS, comboBoxTypeName.SelectedIndex+1, comboBoxCountries.Text.ToString() , comboBoxCities.Text.ToString(), numericPrice.Value, dateTimePicker.Value.ToString("dd.MM.yyyy"), dateTimePickerArrival.Value.ToString("dd.MM.yyyy"), (int)numericPeople.Value, textBoxHotelName.Text.ToString(), (int)numericHotelRating.Value, comboBoxVehicleType.SelectedIndex + 1, textBoxShortDescription.Text.ToString());
                    formTrip.Close();
                    form.Close();
                });

            };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "UserVacations DataGrid",
                Width = 500,
                Height = 600,
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "UserVacation",
                Height = 600,
                Width = 500,
            };

            DataSet dataSet = new DataSet();
            DataTable UserVacationTable = new DataTable("UserVacation");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM UserVacation", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(UserVacationTable);
            }

            dataSet.Tables.Add(UserVacationTable);           
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;

            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "Roles DataGrid",
                Width = 200,
                Height = 250,
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "Roles",
                Height = 200,
                Width = 250,
            };

            DataSet dataSet = new DataSet();
            DataTable RolesTable = new DataTable("Roles");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT * FROM Roles", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(RolesTable);
            }

            dataSet.Tables.Add(RolesTable);         
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;

            form.Show();
        }      

        private void button9_Click(object sender2, EventArgs ee)
        {
            Form form = new Form()
            {
                Text = "Add Country",
                Width = 350,
                Height = 200,
            };

            Label labelCountryName = new Label()
            {
                Text = "Country Name:",
                Width = 100,
                Location = new Point(20, 20),
                Font = new Font("Century Gothic", 12),
            };
            form.Controls.Add(labelCountryName);

            TextBox textBoxCountryName = new TextBox()
            {
                Width = 200,
                Location = new Point(120, 20),
            };
            form.Controls.Add(textBoxCountryName);

            Button buttonAddCountry = new Button()
            {
                Text = "Add Country",
                Width = 100,
                Height = 70,
                Location = new Point(100, 60),
                Font = new Font("Century Gothic", 12),
                BackColor = SystemColors.ButtonHighlight,
            };

            form.Controls.Add(buttonAddCountry);
            form.Show();

            buttonAddCountry.Click += (sender, e) =>
            {
                if (textBoxCountryName.Text.ToString() != "")
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("INSERT INTO Country (Country) VALUES (@Country)", connection);
                        command.Parameters.AddWithValue("@Country", textBoxCountryName.Text);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Country added succesfully", "AdminPanel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    form.Close();
                }
                else MessageBox.Show("Country name cannot be empty!", "AdminPanel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "Add City",
                Width = 350,
                Height = 200,
            };

            Label labelCityName = new Label()
            {
                Text = "City Name:",
                Width = 100,
                Location = new Point(20, 20),
                Font = new Font("Century Gothic", 12),
            };
            form.Controls.Add(labelCityName);

            TextBox textBoxCityName = new TextBox()
            {
                Width = 200,
                Location = new Point(120, 20),
            };
            form.Controls.Add(textBoxCityName);

            Label labelCountryName = new Label()
            {
                Text = "Country:",
                Width = 100,
                Location = new Point(20, 60),
                Font = new Font("Century Gothic", 12),
                };
            form.Controls.Add(labelCountryName);

            ComboBox comboBoxCountryName = new ComboBox()
            {
                Width = 200,
                Location = new Point(120, 60),
                DisplayMember = "Country",
                ValueMember = "CountryId",
            };
            form.Controls.Add(comboBoxCountryName);

            DataTable countriesTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT CountryId, Country FROM Country", connection);
                
                adapter.SelectCommand = command;          
                adapter.Fill(countriesTable);
                comboBoxCountryName.DataSource = countriesTable;
            }

            Button buttonAddCity = new Button
            {
                Text = "Add City",
                Width = 100,
                Height = 50,
                Location = new Point(100, 100),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12),
            };
            form.Controls.Add(buttonAddCity);

            buttonAddCity.Click += (sender2, e2) =>
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO CountryCity (City, CountryId) VALUES (@City, @CountryId)", connection);
                    command.Parameters.AddWithValue("City", textBoxCityName.Text);
                    command.Parameters.AddWithValue("CountryId", comboBoxCountryName.SelectedValue);
                    command.ExecuteNonQuery();
                    MessageBox.Show("City added succesfully", "AdminPanel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                form.Close();
            };        
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Add User",
                Width = 360,
                Height = 300,
            };

            Label labelUserName = new Label
            {
                Text = "UserName:",
                Width = 100,
                Location = new Point(20, 20),
                Font = new Font("Century Gothic", 12),
            };
            form.Controls.Add(labelUserName);

            TextBox textBoxUserName = new TextBox
            {
                Width = 200,
                Location = new Point(140, 20),
            };
            form.Controls.Add(textBoxUserName);

            Label labelUserPassword = new Label
            {
                Text = "Password:",
                Width = 100,
                Location = new Point(20, 60),
                Font = new Font("Century Gothic", 12),
            };
            form.Controls.Add(labelUserPassword);

            TextBox textBoxUserPassword = new TextBox
            {
                Width = 200,
                Location = new Point(140, 60),
            };
            form.Controls.Add(textBoxUserPassword);

            Label labelUserMail = new Label
            {
                Text = "User Mail:",
                Width = 100,
                Location = new Point(20, 100),
                Font = new Font("Century Gothic", 12)
            };
            form.Controls.Add(labelUserMail);

            TextBox textBoxUserMail = new TextBox
            {
                Width = 200,
                Location = new Point(140, 100)
            };
            form.Controls.Add(textBoxUserMail);

            Label labelRoleName = new Label
            {
                Text = "Role:",
                Width = 100,
                Location = new Point(20, 140),
                Font = new Font("Century Gothic", 12)
            };
            form.Controls.Add(labelRoleName);

            ComboBox comboBoxRoleName = new ComboBox
            {
                Width = 200,
                Location = new Point(140, 140),
                ValueMember = "RoleId",
                DisplayMember = "RoleName",
            };
            form.Controls.Add(comboBoxRoleName);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT RoleId, RoleName FROM Roles", connection);
                adapter.SelectCommand = command;

                DataTable rolesTable = new DataTable();
                adapter.Fill(rolesTable);

                comboBoxRoleName.DataSource = rolesTable;
            }
            
            Button buttonAdd = new Button
            {
                Text = "Add",
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12),
                Location = new Point(140, 200),
                Height = 50,
            };      
            form.Controls.Add(buttonAdd);
            buttonAdd.Click += new EventHandler(buttonAdd_Click);

            form.Show();

            void buttonAdd_Click(object sender3, EventArgs e3)
            {
                string userName = textBoxUserName.Text;
                string userPassword = textBoxUserPassword.Text;
                string userMail = textBoxUserMail.Text;
                int roleId = (int)comboBoxRoleName.SelectedValue;

                try
                {
                    MailAddress m = new MailAddress(userMail);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (System.ArgumentException)
                {
                    MessageBox.Show("Invalid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, UserPassword, UserMail, RoleId) VALUES (@UserName, @UserPassword, @UserMail, @RoleId)", connection);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@UserPassword", userPassword);
                    command.Parameters.AddWithValue("@UserMail", userMail);
                    command.Parameters.AddWithValue("@RoleId", roleId);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error while adding user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Travel DataGrid",
                Width = 1108,
                Height = 450,
                BackColor = SystemColors.ButtonHighlight
            };
            DataGridView dataGridView = new DataGridView
            {
                DataMember = "Vacation",
                Height = 300,
                Width = 1108,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                GridColor = Color.Gray,
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                ReadOnly = true,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false
            };
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            form.Controls.Add(dataGridView);

            DataSet dataSet = new DataSet();
            DataTable travelTable = new DataTable("Vacation");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, TypeOfVacation.TypeName, Country.Country, CountryCity.City, Vacation.MaxPeople, Vacation.HotelName, Vacation.HotelRating, Vacation.Price, VehicleType.VehicleName as Vehicle, DateVacation.DepartureDate, DateVacation.ArrivalDate  FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationId = Vacation.VacationId INNER JOIN Country ON Country.CountryId = Vacation.CountryId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN TypeOfVacation ON Vacation.TypeId = TypeOfVacation.TypeId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(travelTable);
            }

            dataSet.Tables.Add(travelTable);
            dataGridView.DataSource = dataSet;

            Button addPhotoButton = new Button()
            {
                Text = "Select photo",
                Location = new Point(form.Width - 150, dataGridView.Height + 10),
                Width = 125,
                Height = 40,
                Font = new Font("Century Gothic", 12),
                BackColor = SystemColors.ButtonHighlight,
            };
            form.Controls.Add(addPhotoButton);

            Button sendButton = new Button()
            {
                Text = "Send photo",
                Location = new Point(form.Width - 150, dataGridView.Height + 60),
                Width = 125,
                Height = 40,
                Font = new Font("Century Gothic", 12),
                BackColor = SystemColors.ButtonHighlight,
            };
            form.Controls.Add(sendButton);
            form.Show();

            byte[] photoPath = null;
            
            addPhotoButton.Click += (sender2, e2) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    photoPath = File.ReadAllBytes(openFileDialog.FileName);
                }
            };

            sendButton.Click += (sender2, e2) =>
            {
                int vacationId = (int)dataGridView.SelectedRows[0].Cells["VacationId"].Value;
                AddPhoto(vacationId, photoPath);
            };

            void AddPhoto(int vacationId, byte[] photo)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string query = "INSERT INTO Photos (VacationId, Photo) VALUES (@vacationId, @photo)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@vacationId", vacationId);

                        SqlParameter photoParam = new SqlParameter("@photo", SqlDbType.Image)
                        {
                            Value = photo
                        };
                        
                        command.Parameters.Add(photoParam);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Photo added succesfully", "AdminPanel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    MessageBox.Show("Check the photo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }               
            }
        }
    }
}