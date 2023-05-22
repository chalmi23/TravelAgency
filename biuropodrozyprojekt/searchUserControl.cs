using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace biuropodrozyprojekt
{
    public partial class searchUserControl : UserControl
    {
        public searchUserControl()
        {
            InitializeComponent();
        }

    string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        private void search(object sender, EventArgs e)
        {
            dataGridView1.DataBindings.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT DISTINCT Vacation.VacationId, TypeOfVacation.TypeName AS 'Trip type', Country.Country, CountryCity.City, Vacation.HotelName AS 'Hotel Name', Vacation.HotelRating AS 'Hotel Rating', Vacation.MaxPeople AS 'Free places', VehicleType.VehicleName AS 'Type of Vehicle', Vacation.Price AS 'Price($)', DateVacation.DepartureDate AS Departure, DateVacation.ArrivalDate as Arrival  FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationId = Vacation.VacationId INNER JOIN Country ON Country.CountryId = Vacation.CountryId INNER JOIN TypeOfVacation ON TypeOfVacation.TypeId = Vacation.TypeId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId WHERE Country.Country LIKE '%' + @search + '%' OR CountryCity.City LIKE '%' + @search + '%' OR Vacation.HotelName LIKE '%' + @search + '%' OR Vacation.HotelRating LIKE '%' + @search + '%' OR DateVacation.ArrivalDate LIKE '%' + @search + '%' OR DateVacation.DepartureDate LIKE '%' + @search + '%'  OR VehicleType.VehicleName LIKE '%' + @search + '%' OR Vacation.Price LIKE '%' + @search + '%' OR TypeOfVacation.TypeName LIKE '%' + @search + '%'", connection);

                command.Parameters.AddWithValue("@search", searchTx.Text);
                adapter.SelectCommand = command;

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Width = 112;
                dataGridView1.Columns[3].Width = 105;
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[6].Width = 70;
                dataGridView1.Columns[8].Width = 70;
            }

            dataGridView1.CellDoubleClick += (sender2, e2) =>
            {
                DataGridViewRow row = dataGridView1.Rows[e2.RowIndex];
                HolidaysValuesClass holiday = new HolidaysValuesClass(0,null,null,null,null,null,null,0,null,null,0,0);
                holiday = HolidaysValuesClass.GetOneTrip((int)row.Cells["VacationId"].Value);

                Form formDetails = new Form()
                {
                    Width = 1040,
                    BackColor = SystemColors.ButtonHighlight,
                    MaximumSize = new Size(1040, 900),
                    MinimumSize = new Size(1040, 900),
                    Text = holiday.CityGS,
                    Height = 900,
                };

                Panel panelDetails = new Panel
                {
                    Width = formDetails.Width - 50,
                    Height = formDetails.Height
                };

                FlowLayoutPanel flowLayoutPanelDetails = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };

                PictureBox picTravelAgency = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\agency.png")),
                    Size = new Size(300, 100),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point((formDetails.Width - 300) / 2, 10)
                };

                Label lblCountryDetails = new Label
                {
                    Text = holiday.CountryGS,
                    Font = new Font("Century Gothic", 24, FontStyle.Bold),
                    Size = new Size(formDetails.Width, 50),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 150),
                };

                Label lblCityDetails = new Label
                {
                    Text = holiday.CityGS,
                    Font = new Font("Century Gothic", 20),
                    Size = new Size(formDetails.Width, 50),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 190)
                };

                Label lblShortDesc = new Label
                {
                    Text = holiday.ShortDescriptionGS,
                    Font = new Font("Century Gothic", 15),
                    Size = new Size(formDetails.Width / 2, 100),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(230, 230)
                };

                PictureBox picVehicle = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\types.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(60, 390),
                };

                Label lblVehicleType = new Label
                {
                    Text = "way of travel: " + holiday.VehicleTypeGS,
                    Font = new Font("Century Gothic", 13),
                    Width = 220,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(100, 400)
                };

                Label lblHotelName = new Label
                {
                    Text = "hotel: " + holiday.HotelNameGS,
                    Font = new Font("Century Gothic", 13),
                    Width = 220,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(100, 450)
                };

                PictureBox picHotelName = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\hotelname.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(60, 440)
                };

                Label lblHotelRating = new Label
                {
                    Text = "rating: " + holiday.HotelRatingGS,
                    Font = new Font("Century Gothic", 13),
                    Width = 220,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(100, 500)
                };

                PictureBox picRating = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\star.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(60, 490)
                };

                PictureBox picDepart = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\departurelogo.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(720, 390)
                };

                PictureBox picArr = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\arrivallogo.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(720, 440)
                };

                Label lblArr = new Label
                {
                    Text = "arrival: " + holiday.ArrivalDateGS,
                    Font = new Font("Century Gothic", 13),
                    Width = 220,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picArr.Right + 5, picArr.Top)
                };

                Label lblDepart = new Label
                {
                    Text = "departure: " + holiday.DepartureDateGS,
                    Font = new Font("Century Gothic", 13),
                    Width = 250,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(760, 400)
                };

                PictureBox picprice = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\dollar.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(720, 490)
                };

                Label lblprice = new Label
                {
                    Text = "price ($): " + holiday.PriceGS.ToString(),
                    Font = new Font("Century Gothic", 13),
                    Width = 250,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picprice.Right + 5, picprice.Top)
                };

                Button btnReserve = new Button
                {
                    Text = "Reserve",
                    Font = new Font("Century Gothic", 13, FontStyle.Regular),
                    Size = new Size(200, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(720, 700),
                    BackColor = Color.LightGreen,
                    FlatStyle = FlatStyle.Flat
                };

                NumericUpDown numericUpDown = new NumericUpDown()
                {
                    BackColor = SystemColors.Window,
                    ForeColor = SystemColors.WindowText,
                    Font = new Font("Century Gothic", 14, FontStyle.Bold),
                    Location = new Point(720, 650),
                    Width = 80,
                    Height = 20,
                    DecimalPlaces = 0,
                    Maximum = 5,
                    Minimum = 1,
                };

                Label label = new Label()
                {
                    Text = "Number of Travelers",
                    Width = 200,
                    Location = new Point(715, 625),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12),
                    TextAlign = ContentAlignment.MiddleLeft
                };

                Label labelDiscover = new Label()
                {
                    Text = "Scroll down to explore the beauty of this place",
                    Width = 1040,
                    Location = new Point(0, 780),
                    BackColor = SystemColors.ButtonHighlight,
                    Font = new Font("Century Gothic", 12),
                    TextAlign = ContentAlignment.TopCenter
                };
                List<byte[]> photos = holiday.GetPhotosForTrip(holiday.VacationIdGS);

                Control[] controlsDetails = { picTravelAgency, label, labelDiscover, picVehicle, picArr, numericUpDown, picprice, btnReserve, lblprice, picDepart, lblArr, lblDepart, lblHotelRating, picRating, picHotelName, lblHotelName, lblCountryDetails, lblVehicleType, lblCityDetails, lblShortDesc };
                panelDetails.Controls.AddRange(controlsDetails);
                flowLayoutPanelDetails.Controls.Add(panelDetails);

                foreach (byte[] photoBytes in photos)
                {
                    discoverUserControl discoverControl = new discoverUserControl();
                    PictureBox pictureBoxPhotos = new PictureBox
                    {
                        Width = 1000,
                        Height = 800,
                        Image = discoverControl.GetPhoto(photoBytes),
                        SizeMode = PictureBoxSizeMode.Zoom
                    };
                    flowLayoutPanelDetails.Controls.Add(pictureBoxPhotos);
                }
                formDetails.Controls.Add(flowLayoutPanelDetails);
                formDetails.Show();

                btnReserve.Click += new EventHandler((senderApply, eApply) =>
                {
                    HolidaysValuesClass vacationCheck = HolidaysValuesClass.GetOneTrip(holiday.VacationIdGS);
                    if ((int)numericUpDown.Value <= vacationCheck.MaxPeopleGS)
                    {
                        UserVacationClass.addUserVacation(holiday.VacationIdGS, holiday.MaxPeopleGS, Form1.idUser, (int)numericUpDown.Value);
                        holiday.MaxPeopleGS = holiday.MaxPeopleGS - (int)numericUpDown.Value;
                        formDetails.Close();
                    }
                    else
                    {
                        MessageBox.Show("There aren't as many free spots available as needed. Only " + vacationCheck.MaxPeopleGS + " are left.", "Info", MessageBoxButtons.OK);
                    }
                });
            };
        }
    }
}
