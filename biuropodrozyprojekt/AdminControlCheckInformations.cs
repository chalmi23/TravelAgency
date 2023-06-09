﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Globalization;

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
                MaximumSize = new Size(660, 550),
                MinimumSize = new Size(660, 550),
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
                user.DeleteUser((int)selectedRow.Cells[0].Value);
                form.Close();
            });

            form.Controls.Add(btnDelete);
            form.Show();

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                DataGridViewRow row = dataGridView.Rows[e2.RowIndex];
                user = user.GetUser((int)row.Cells["UserId"].Value);

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
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
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
                    Text = "password: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 120),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
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
                    Text = "email: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 170),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
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
                    Text = "role: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 220),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
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
                MaximumSize = new Size(550, 500),
                MinimumSize = new Size(550, 500),
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
                country.DeleteCountry((int)selectedRow.Cells[0].Value);
                form.Close();
            });
            form.Controls.Add(btnDelete);

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                DataGridViewRow row = dataGridView.Rows[e2.RowIndex];

                country = country.GetCountry((int)row.Cells["CountryId"].Value);

                Form formCountry = new Form()
                {
                    Text = "Edit country",
                    Width = 360,
                    Height = 300,
                    BackColor = SystemColors.ButtonHighlight,
                    MaximumSize = new Size(360, 300),
                    MinimumSize = new Size(360, 300),
                };

                FlowLayoutPanel flowLayoutPanelUser = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };
                formCountry.Controls.Add(flowLayoutPanelUser);

                Panel panel = new Panel
                {
                    Width = 300,
                    Height = 250
                };

                Label labelCountryId = new Label()
                {
                    Text = "id: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
                };

                Label labelCountryId2 = new Label()
                {
                    Text = country.CountryIdGS.ToString(),
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 20),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Label labelCountryIName = new Label()
                {
                    Text = "country: ",
                    Height = 25,
                    Width = 120,
                    Location = new Point(20, 70),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 14),
                    TextAlign = ContentAlignment.TopRight
                };

                TextBox textBoxCountryName = new TextBox()
                {
                    Text = country.CountryNameGS,
                    Height = 20,
                    Width = 150,
                    Location = new Point(140, 70),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12)
                };

                Button btnApply = new Button
                {
                    Text = "Apply changes",
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(150, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(140, 170),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                btnApply.Click += new EventHandler((senderApply, eApply) =>
                {
                    country.UpdateCountry((int)row.Cells["CountryId"].Value, textBoxCountryName.Text.ToString());
                    formCountry.Close();
                    form.Close();
                });

                Control[] controlsDetails = { btnApply, labelCountryId, labelCountryId2, textBoxCountryName, labelCountryIName };
                panel.Controls.AddRange(controlsDetails);
                flowLayoutPanelUser.Controls.Add(panel);
                formCountry.Controls.Add(flowLayoutPanelUser);
                formCountry.Show();
            };
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
                MaximumSize = new Size(490, 560),
                MinimumSize = new Size(490, 560),
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
                city.DeleteCity((int)selectedRow.Cells[0].Value);
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
                DataGridViewRow row = dataGridView.Rows[e2.RowIndex];
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
                MaximumSize = new Size(1150, 500),
                MinimumSize = new Size(1150, 500),
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "Vacation",
                Width = 1110,
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
            dataGridView.Columns[7].Width = 80;
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
                holiday.DeleteTrip((int)selectedRow.Cells[0].Value);
                form.Close();
            });

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                DataGridViewRow row = dataGridView.Rows[e2.RowIndex];
                holiday = holiday.GetHolidays((int)row.Cells["VacationId"].Value);

                Form formTrip = new Form()
                {
                    Text = "Edit holiday",
                    Width = 800,
                    Height = 600,
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
                        CountryClass item = new CountryClass { CountryIdGS = (int)reader["CountryId"], CountryNameGS = reader["Country"].ToString() };
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
                        CityClass item = new CityClass { CityIdGS = (int)reader["CityId"], CityNameGS = reader["City"].ToString(), CountryIdGS = (int)reader["CountryId"] };
                        comboBoxCities.Items.Add(item.CityNameGS);

                        if (holiday.CityIdGS == item.CityIdGS)
                        {
                            comboBoxCities.SelectedItem = item.CityNameGS;
                        }
                    }
                }

                comboBoxCountries.SelectedIndexChanged += (senderCity, eCity) =>
                {
                    comboBoxCities.Items.Clear();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("SELECT City FROM CountryCity WHERE CountryId = (SELECT CountryId FROM Country WHERE Country = @SelectedCountry)", connection);
                        command.Parameters.AddWithValue("@SelectedCountry", comboBoxCountries.SelectedItem.ToString());

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
                    Maximum = 1000,
                    Value = holiday.MaxPeopleGS,        
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
                Width = 480,
                Height = 470,
                MaximumSize = new Size(480, 470),
                MinimumSize = new Size(480, 470),
            };
            DataGridView dataGridView = new DataGridView()
            {
                DataMember = "UserVacation",
                Height = 350,
                Width = 440,
                Location = new Point(10,10),
            };

            DataSet dataSet = new DataSet();
            DataTable UserVacationTable = new DataTable("UserVacation");

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


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT Users.UserId, Users.UserName, UserVacation.VacationId, UserVacation.NumberOfPeople FROM UserVacation INNER JOIN Users ON users.userid = uservacation.userid", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(UserVacationTable);
            }

            dataSet.Tables.Add(UserVacationTable);           
            form.Controls.Add(dataGridView);
            dataGridView.DataSource = dataSet;

            dataGridView.Columns[0].Width = 100;
            dataGridView.Columns[1].Width = 100;
            dataGridView.Columns[2].Width = 100;
            dataGridView.Columns[3].Width = 136;

            Button btnDelete = new Button
            {
                Text = "Delete record",
                Font = new Font("Century Gothic", 10, FontStyle.Regular),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(320, 370),
                BackColor = Color.Red,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete.Click += (sender2, e2) =>
            {
                try
                {
                    int reservationId = (int)dataGridView.SelectedRows[0].Cells["Id"].Value;
                    int reservedSeats = (int)dataGridView.SelectedRows[0].Cells["NumberOfPeople"].Value;
                    int vacationId = (int)dataGridView.SelectedRows[0].Cells["VacationId"].Value;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand("DELETE FROM UserVacation WHERE Id = @Id", connection);
                        command.Parameters.AddWithValue("@Id", reservationId);
                        command.ExecuteNonQuery();

                        command = new SqlCommand("UPDATE Vacation SET MaxPeople = MaxPeople + @reservedSeats WHERE VacationId = @vacationId", connection);
                        command.Parameters.AddWithValue("@reservedSeats", reservedSeats);
                        command.Parameters.AddWithValue("@vacationId", vacationId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Reservation canceled!", "Info", MessageBoxButtons.OK);

                    }
                    form.Close();
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Choose record!", "Info", MessageBoxButtons.OK);
                }
            };

            form.Controls.Add(btnDelete);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form form = new Form()
            {
                Text = "Roles DataGrid",
                Width = 200,
                Height = 250,
                MaximumSize = new Size(200, 250),
                MinimumSize = new Size(200, 250),
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
                MaximumSize = new Size(350, 200),
                MinimumSize = new Size(350, 200),
            };

            Label labelCountryName = new Label()
            {
                Text = "Country Name:",
                Width = 100,
                Location = new Point(20, 20),
                Font = new Font("Century Gothic", 12),
            };

            TextBox textBoxCountryName = new TextBox()
            {
                Width = 200,
                Location = new Point(120, 20),
            };

            Button buttonAddCountry = new Button()
            {
                Text = "Add Country",
                Width = 100,
                Height = 70,
                Location = new Point(100, 60),
                Font = new Font("Century Gothic", 12),
                BackColor = SystemColors.ButtonHighlight,
            };

            Control[] controlsDetails = { buttonAddCountry, textBoxCountryName, labelCountryName };
            form.Controls.AddRange(controlsDetails);
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
                MaximumSize = new Size(350, 200),
                MinimumSize = new Size(350, 200),
            };

            Label labelCityName = new Label()
            {
                Text = "City Name:",
                Width = 100,
                Location = new Point(20, 20),
                Font = new Font("Century Gothic", 12),
            };

            TextBox textBoxCityName = new TextBox()
            {
                Width = 200,
                Location = new Point(120, 20),
            };

            Label labelCountryName = new Label()
            {
            Text = "Country:",
            Width = 100,
            Location = new Point(20, 60),
            Font = new Font("Century Gothic", 12),
            };

            ComboBox comboBoxCountryName = new ComboBox()
            {
                Width = 200,
                Location = new Point(120, 60),
                DisplayMember = "Country",
                ValueMember = "CountryId",
            };

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

            Control[] controlsDetails = { buttonAddCity, comboBoxCountryName , labelCountryName , textBoxCityName , labelCityName };
            form.Controls.AddRange(controlsDetails);

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
                MaximumSize = new Size(360, 300),
                MinimumSize = new Size(360, 300),
            };

            Label labelUserName = new Label
            {
                Text = "UserName:",
                Width = 100,
                Location = new Point(20, 20),
                Font = new Font("Century Gothic", 12),
            };

            TextBox textBoxUserName = new TextBox
            {
                Width = 200,
                Location = new Point(140, 20),
            };

            Label labelUserPassword = new Label
            {
                Text = "Password:",
                Width = 100,
                Location = new Point(20, 60),
                Font = new Font("Century Gothic", 12),
            };

            TextBox textBoxUserPassword = new TextBox
            {
                Width = 200,
                Location = new Point(140, 60),
            };

            Label labelUserMail = new Label
            {
                Text = "User Mail:",
                Width = 100,
                Location = new Point(20, 100),
                Font = new Font("Century Gothic", 12)
            };

            TextBox textBoxUserMail = new TextBox
            {
                Width = 200,
                Location = new Point(140, 100)
            };

            Label labelRoleName = new Label
            {
                Text = "Role:",
                Width = 100,
                Location = new Point(20, 140),
                Font = new Font("Century Gothic", 12)
            };

            ComboBox comboBoxRoleName = new ComboBox
            {
                Width = 200,
                Location = new Point(140, 140),
                ValueMember = "RoleId",
                DisplayMember = "RoleName",
            };

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

            Control[] controlsDetails = { buttonAdd, comboBoxRoleName, labelRoleName, labelUserName, textBoxUserMail, textBoxUserName, labelUserMail, textBoxUserPassword, labelUserPassword };
            form.Controls.AddRange(controlsDetails);
            form.Show();
            buttonAdd.Click += (s, eventsargs) =>
            {
                try
                {
                    MailAddress m = new MailAddress(textBoxUserMail.Text);
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
                    command.Parameters.AddWithValue("@UserName", textBoxUserName.Text);
                    command.Parameters.AddWithValue("@UserPassword", textBoxUserPassword.Text);
                    command.Parameters.AddWithValue("@UserMail", textBoxUserMail.Text);
                    command.Parameters.AddWithValue("@RoleId", (int)comboBoxRoleName.SelectedValue);

                    if (command.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        form.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error while adding user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
        }
        private void button12_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Travel DataGrid",
                Width = 1108,
                Height = 450,
                MaximumSize = new Size(1108, 450),
                MinimumSize = new Size(1108, 450),
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
            dataGridView.BackgroundColor = Color.LightGray;

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

            Button sendButton = new Button()
            {
                Text = "Send photo",
                Location = new Point(form.Width - 150, dataGridView.Height + 60),
                Width = 125,
                Height = 40,
                Font = new Font("Century Gothic", 12),
                BackColor = SystemColors.ButtonHighlight,
            };
            Control[] controlsDetails = { sendButton, addPhotoButton, dataGridView};
            form.Controls.AddRange(controlsDetails);
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
                AddPhoto((int)dataGridView.SelectedRows[0].Cells["VacationId"].Value, photoPath);
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
        private void addNewTripButton_Click(object sender, EventArgs e)
        {
            Form form = new Form
            {
                Text = "Add new trip",
                Width = 500,
                Height = 670,
                MaximumSize = new Size(500, 670),
                MinimumSize = new Size(500, 670),
            };

            Label labelCountry = new Label
            {
                Text = "country: ",
                Width = 200,
                Location = new Point(10, 10),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            Label labelCity = new Label
            {
                Text = "city: ",
                Width = 200,
                Location = new Point(10, 50),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            ComboBox comboBoxCountries = new ComboBox
            {
                Width = 150,
                Location = new Point(210, 10),
                Font = new Font("Century Gothic", 10)
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT CountryId, Country FROM Country", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CountryClass item = new CountryClass { CountryIdGS = (int)reader["CountryId"], CountryNameGS = reader["Country"].ToString() };
                    comboBoxCountries.Items.Add(item.CountryNameGS);
                    comboBoxCountries.SelectedIndex = 0;
                }
            }

            ComboBox comboBoxCities = new ComboBox
            {
                Width = 150,
                Location = new Point(210, 50),
                Font = new Font("Century Gothic", 10)
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT CountryCity.CityId, CountryCity.City, Country.CountryId FROM CountryCity INNER JOIN Country ON Country.CountryId = CountryCity.CountryId WHERE Country.Country=@CountryName", connection);
                command.Parameters.AddWithValue("@CountryName", comboBoxCountries.Items[0].ToString());
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CityClass item = new CityClass { CityIdGS = (int)reader["CityId"], CityNameGS = reader["City"].ToString(), CountryIdGS = (int)reader["CountryId"] };
                    comboBoxCities.Items.Add(item.CityNameGS);
                    comboBoxCities.SelectedIndex = 0;
                }
            }

            comboBoxCountries.SelectedIndexChanged += (senderCity, eCity) =>
            {
                comboBoxCities.Items.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT City FROM CountryCity WHERE CountryId = (SELECT CountryId FROM Country WHERE Country = @SelectedCountry)", connection);
                    command.Parameters.AddWithValue("@SelectedCountry", comboBoxCountries.SelectedItem.ToString());
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

            Label labelType = new Label()
            {
                Text = "type: ",
                Width = 200,
                Location = new Point(10, 90),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            ComboBox comboBoxTypeName = new ComboBox
            {
                Width = 150,
                Location = new Point(210, 90),
                Font = new Font("Century Gothic", 10)
            };
            comboBoxTypeName.Items.AddRange(new[] { "National", "International" });
            comboBoxTypeName.SelectedIndex = 0;


            Label labelPeople = new Label()
            {
                Text = "people limit: ",
                Width = 200,
                Location = new Point(10, 130),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            NumericUpDown numericPeople = new NumericUpDown()
            {
                Value = 0,
                Maximum = 1000,
                Height = 25,
                Width = 120,
                Location = new Point(210, 130),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12)
            };

            Label labelPrice = new Label()
            {
                Text = "price: ",
                Width = 200,
                Location = new Point(10, 170),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            NumericUpDown numericPrice = new NumericUpDown()
            {
                Maximum = 1000000,
                Value = 0,
                Height = 25,
                Width = 120,
                Location = new Point(210, 170),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12)
            };

            Label labelHotelName = new Label()
            {
                Text = "hotel name: ",
                Height = 25,
                Width = 200,
                Location = new Point(10, 210),
                Font = new Font("Century Gothic", 14),
                TextAlign = ContentAlignment.MiddleRight
            };

            TextBox textBoxHotelName = new TextBox()
            {
                Text = "empty",
                Height = 25,
                Width = 200,
                Location = new Point(210, 210),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12)
            };

            Label labelHotelRating = new Label()
            {
                Text = "hotel rating: ",
                Height = 25,
                Width = 200,
                Location = new Point(10, 250),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            NumericUpDown numericHotelRating = new NumericUpDown()
            {
                Maximum = 10,
                Value = 1,
                Height = 25,
                Width = 120,
                Location = new Point(210, 250),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12)
            };

            Label labelVehicleType = new Label()
            {
                Text = "vehicle: ",
                Height = 25,
                Width = 200,
                Location = new Point(10, 290),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            ComboBox comboBoxVehicleType = new ComboBox
            {
                Width = 150,
                Location = new Point(210, 290),
                Font = new Font("Century Gothic", 10)
            };
            comboBoxVehicleType.Items.AddRange(new[] { "Plane", "Bus", "Train", "Cruise ship" });
            comboBoxVehicleType.SelectedIndex = 0;

            Label labelShortDescription = new Label()
            {
                Text = "Short Desctipton",
                Height = 25,
                Width = 400,
                Location = new Point(10, 410),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.TopCenter
            };

            TextBox textBoxShortDescription = new TextBox()
            {
                Text = "empty",
                Height = 80,
                Width = 360,
                Location = new Point(50, 440),
                Multiline = true,
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12),
                MaxLength = 100,
            };

            textBoxShortDescription.TextChanged += (senderSD, eSD) =>
            {
                if (textBoxShortDescription.Text.Length > 90 && textBoxShortDescription.Text.Length < 100)
                {
                    textBoxShortDescription.BackColor = Color.LightCoral;
                }
                else if (textBoxShortDescription.Text.Length == 100)
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
                Width = 200,
                Location = new Point(10, 330),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            DateTimePicker dateTimePicker = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy",
                Location = new Point(210, 330),
                Width = 120,
                Font = new Font("Century Gothic", 12),
                Height = 25
            };

            Label labelArrivalDate = new Label()
            {
                Text = "arrival: ",
                Width = 200,
                Location = new Point(10, 370),
                Font = new Font("Century Gothic", 12),
                TextAlign = ContentAlignment.MiddleRight
            };

            DateTimePicker dateTimePickerArrival = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd.MM.yyyy",
                Location = new Point(210, 370),
                Width = 120,
                Font = new Font("Century Gothic", 12),
                Height = 25
            };

            Button btnAdd = new Button
            {
                Text = "Add trip",
                Font = new Font("Century Gothic", 10, FontStyle.Regular),
                Size = new Size(130, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(335, 570),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };

            btnAdd.Click += new EventHandler((senderApply, eApply) =>
            {
                HolidaysClass holiday = new HolidaysClass();
                labelCountry.Text = comboBoxCountries.Text.ToString();
                holiday.addNewVacation(comboBoxTypeName.SelectedIndex + 1, comboBoxCountries.Text.ToString(), comboBoxCities.Text.ToString(), numericPrice.Value, dateTimePicker.Value.ToString("dd.MM.yyyy"), dateTimePickerArrival.Value.ToString("dd.MM.yyyy"), (int)numericPeople.Value, textBoxHotelName.Text.ToString(), (int)numericHotelRating.Value, comboBoxVehicleType.SelectedIndex + 1, textBoxShortDescription.Text.ToString());
                form.Close();
            });
            Control[] controlsDetails = { btnAdd, textBoxShortDescription, labelShortDescription, dateTimePicker, dateTimePickerArrival, labelDepartureDate, labelArrivalDate, labelCountry, comboBoxVehicleType, comboBoxCountries, labelCity, comboBoxCities, labelType, comboBoxTypeName, labelPeople , numericPeople, numericHotelRating, numericPrice, labelHotelName, labelHotelRating, labelPrice, labelVehicleType, textBoxHotelName};

            form.Controls.AddRange(controlsDetails);
            form.Show();
        }
    }
}