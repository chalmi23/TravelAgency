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
using System.IO;
using System.Configuration;

namespace biuropodrozyprojekt
{   
    public partial class discoverUserControl : UserControl
    {

        public discoverUserControl()
        {
            InitializeComponent();
        }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public partial class VacationInfoForm : Form
        {
            private readonly int _vacationId;

            public VacationInfoForm(int vacationId)
            {
                _vacationId = vacationId;
            }
        }
        public class Vacation
        {
            public int VacationId { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public byte[] PhotoBytes { get; set; }
            public string ShortDescription { get; set; }
            public string VehicleType { get; set; }
            public string HotelName { get; set; }
            public int HotelRating { get; set; }
            public string DepartureDate { get; set; }
            public string ArrivalDate { get; set; }
            public int Price { get; set; }
            public Vacation(int id, string country, string city, byte[] photoBytes, string shortDescription, string vehicleType, string hotelName, int hotelRating, string departureDate, string arrivalDate, int price)
            {
                VacationId = id;
                Country = country;
                City = city;
                PhotoBytes = photoBytes;
                ShortDescription = shortDescription;
                VehicleType = vehicleType;
                HotelName = hotelName;
                HotelRating = hotelRating;
                DepartureDate = departureDate;
                ArrivalDate = arrivalDate;
                Price = price;
            }
        }

        private void showInformation(object sender, EventArgs e)
        {

            DataSet dataSet = new DataSet();
            DataTable travelTable = new DataTable("Vacation");

            DataGridView dataGridView = new DataGridView
            {
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Height = 500,
                Width = 1095,
                GridColor = Color.Gray,
                Location = new Point(10, 10),
                AllowUserToAddRows = false,
                RowHeadersVisible = false,
                ReadOnly = true,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                DataSource = dataSet,
                DataMember = "Vacation"
            };
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView.BackgroundColor = Color.LightGray;


            Form form = new Form()
            {
                Text = "Reserve trip",
                Width = 1125,
                Height = 700,
                BackColor = SystemColors.ButtonHighlight,
                MaximumSize = new Size(1136, 700),
                MinimumSize = new Size(1136, 700),              
            };

            NumericUpDown numericUpDown = new NumericUpDown()
            {
                BackColor = SystemColors.Window,
                ForeColor = SystemColors.WindowText,
                Font = new Font("Century Gothic", 10, FontStyle.Bold),
                Location = new Point(form.Width - 110, 550),
                Width = 80,
                Height = 20,
            };

            Label label1 = new Label()
            {
                Text = "Number of Travelers",
                Height = 25,
                Width = 200,
                Location = new Point(form.Width - 190, 520),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12)
            };

            Label labelInf = new Label()
            {
                Text = "*select trip and then triple-click to see photos",
                Height = 25,
                Width = 500,
                Location = new Point(10, 520),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12)
            };

            Button button1 = new Button()
            {
                Height = 50,
                Width = 100,
                Text = "RESERVE",
                Location = new Point(form.Width - 120, 600),
                BackColor = SystemColors.ButtonHighlight,
                Font = new Font("Century Gothic", 12),
            };

            form.Controls.Add(label1);
            form.Controls.Add(numericUpDown);
            form.Controls.Add(labelInf);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, TypeOfVacation.TypeName AS Type, Country.Country, CountryCity.City, Vacation.MaxPeople AS 'Places left', Vacation.HotelName AS Hotel, Vacation.HotelRating, Vacation.Price AS 'Price($)', VehicleType.VehicleName as Vehicle, DateVacation.DepartureDate as Departure, DateVacation.ArrivalDate as Arrival  FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationId = Vacation.VacationId INNER JOIN Country ON Country.CountryId = Vacation.CountryId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN TypeOfVacation ON Vacation.TypeId = TypeOfVacation.TypeId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId", connection);
                
                adapter.SelectCommand = command;
                adapter.Fill(travelTable);
            }

            dataSet.Tables.Add(travelTable);        
            form.Controls.Add(dataGridView);
                 
            button1.Click += new EventHandler(button1_Click);
            form.Controls.Add(button1);    
            form.Show();
            dataGridView.Columns[7].Width = 92;

            void button1_Click(object sender2, EventArgs e2)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridView.SelectedRows[0];

                    int vacationId = (int)selectedRow.Cells[0].Value;
                    int maxPeople = (int)selectedRow.Cells[4].Value;
                    int numberOfPeople = (int)numericUpDown.Value;

                    if (numberOfPeople > maxPeople || numberOfPeople < 1)
                    {
                        MessageBox.Show("Check the number of people!", "Error", MessageBoxButtons.OK);
                        return;
                    }

                    updateVacation(vacationId, maxPeople - numberOfPeople);
                    addUserVacation(Form1.idUser, vacationId, numberOfPeople);
                }
                catch(System.NullReferenceException)
                {
                    MessageBox.Show("Select correct trip!", "Error", MessageBoxButtons.OK);
                    return;
                }
                catch(System.InvalidCastException)
                {
                    MessageBox.Show("Select correct trip!", "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            void updateVacation(int vacationId, int maxPeople)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE Vacation SET MaxPeople = @maxPeople WHERE VacationId = @vacationId";
                        command.Parameters.AddWithValue("@vacationId", vacationId);
                        command.Parameters.AddWithValue("@maxPeople", maxPeople);
                        command.ExecuteNonQuery();
                    }
                }
            }

            void addUserVacation(int userId, int vacationId, int numberOfPeople)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO UserVacation (UserId, VacationId, NumberOfPeople) VALUES (@userId, @vacationId, @numberOfPeople)";
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@vacationId", vacationId);
                        command.Parameters.AddWithValue("@numberOfPeople", numberOfPeople);
                        command.ExecuteNonQuery();
                        
                        MessageBox.Show("Reservation confirmed!", "Enjoy your trip!", MessageBoxButtons.OK);
                        form.Close();
                    }
                }
            }

            dataGridView.CellDoubleClick += (sender2, e2) =>
            {
                int rowIndex = e2.RowIndex;
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                int vacationId = (int)row.Cells["VacationId"].Value;

                VacationInfoForm form2 = new VacationInfoForm(vacationId)
                {
                    Width = 1040,
                    BackColor = SystemColors.ButtonHighlight,
                    MaximumSize = new Size(1040, 900),
                    MinimumSize = new Size(1040, 900),
                    Text = "Photo Gallery",
                    Height = 900,                 
                };

                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.LeftToRight,
                    AutoScroll = true,
                    Dock = DockStyle.Fill
                };
                form2.Controls.Add(flowLayoutPanel);

                Vacation vacation = GetVacationById(vacationId);

                Label lblVacationId = new Label()
                {
                    Text = $"Vacation ID: {vacation.VacationId}",
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Width = flowLayoutPanel.Width,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lblCountry = new Label()
                {
                    Text = $"Country: {vacation.Country}",
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Width = flowLayoutPanel.Width,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                Label lblCity = new Label()
                {
                    Text = $"City: {vacation.City}" + Environment.NewLine,
                    Font = new Font("Century Gothic", 12, FontStyle.Bold),
                    Width = flowLayoutPanel.Width,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                string text = "Scroll down to witness the beauty of this place. Let the breathtaking views take your breath away as you immerse yourself in the stunning surroundings. From the towering mountains to the sparkling sea, there's so much to see and appreciate. So go ahead, take a scroll and discover the magic that this place has to offer.";
                string newText = text.Replace(".", Environment.NewLine);
                
                Label lblInf = new Label()
                {
                    Text = newText,
                    Font = new Font("Century Gothic", 12, FontStyle.Italic),
                    Width = flowLayoutPanel.Width,
                    Height = 85,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                flowLayoutPanel.Controls.Add(lblVacationId);
                flowLayoutPanel.Controls.Add(lblCountry);
                flowLayoutPanel.Controls.Add(lblCity);
                flowLayoutPanel.Controls.Add(lblInf);


                PictureBox pictureBox = new PictureBox
                {
                    Width = 1000,
                    Height = 800,
                    Image = GetPhoto(vacation.PhotoBytes),
                    SizeMode = PictureBoxSizeMode.Zoom
                 };

                 flowLayoutPanel.Controls.Add(pictureBox);

            form2.Controls.Add(flowLayoutPanel);
            form2.Show();
            };

            Vacation GetVacationById(int vacationId)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, Country.Country, CountryCity.City FROM Vacation INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN Country ON Country.CountryId = Vacation.CountryId WHERE VacationId = @vacationId", connection);
                    command.Parameters.AddWithValue("@vacationId", vacationId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        //Vacation vacation = new Vacation(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                        //return vacation;
                    }
                }
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form()
            {
                Width = 1040,
                BackColor = SystemColors.ButtonHighlight,
                MaximumSize = new Size(1040, 900),
                MinimumSize = new Size(1040, 900),
                Text = "Discover Holidays with us!",
                Height = 900,
            };

            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoScroll = true,
                Dock = DockStyle.Fill
            };

            List<Vacation> vacations = GetAllVacations();

            foreach (Vacation vacation in vacations)
            {
                Panel panel = new Panel
                {
                    Width = 1040,
                    Height = 400
                };

                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(500, 350),
                    Image = GetPhoto(vacation.PhotoBytes),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10)
                };

                Label lblCountry = new Label
                {
                    Text = vacation.Country,
                    Font = new Font("Century Gothic", 20),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(530, 10)
                };

                Label lblCity = new Label
                {
                    Text = vacation.City,
                    Font = new Font("Century Gothic", 16),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(530, 50)
                };

                Label lblDescription = new Label
                {
                    Text = vacation.ShortDescription,
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(350, 105),
                    Location = new Point(530, 80),
                    TextAlign = ContentAlignment.TopLeft
                };

                PictureBox picVacation = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\types.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(530, 190)
                };

                Label lblTransport = new Label
                {
                    Text = vacation.VehicleType,
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(100, 35),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picVacation.Right + 5, picVacation.Top)
                };

                PictureBox picHotel = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\hotelname.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(530, 235)
                };

                Label lblHotel = new Label
                {
                    Text = vacation.HotelName,
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(200, 35),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picHotel.Right + 5, picHotel.Top)
                };

                PictureBox picStar = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\star.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(530, 280)
                };

                Label lblStar = new Label
                {
                    Text = vacation.HotelRating.ToString(),
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(100, 35),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picStar.Right + 5, picStar.Top)
                };

                PictureBox picDeparture = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\departurelogo.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(800, 190)
                };

                Label lblDeparture = new Label
                {
                    Text = vacation.DepartureDate,
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(100, 35),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picDeparture.Right + 5, picDeparture.Top)
                };

                PictureBox picArrival = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\arrivallogo.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(800, 235)
                };

                Label lblArrival = new Label
                {
                    Text = vacation.ArrivalDate,
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(100, 35),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picArrival.Right + 5, picArrival.Top)
                };

                PictureBox picPrice = new PictureBox
                {
                    Image = Image.FromFile(Path.Combine(Application.StartupPath, @"icons\dollar.png")),
                    Size = new Size(35, 35),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(800, 280)
                };

                Label lblPrice = new Label
                {
                    Text = vacation.Price.ToString(),
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(100, 35),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(picPrice.Right + 5, picPrice.Top)
                };

                Label line = new Label
                {
                    BorderStyle = BorderStyle.Fixed3D,
                    Height = 1,
                    Width = form2.Width,
                    Dock = DockStyle.Top,
                    Location = new Point(0, 300)
                };

                Button btnDetails = new Button
                {
                    Text = "Details",
                    Font = new Font("Century Gothic", 10, FontStyle.Regular),
                    Size = new Size(125, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(800, 350),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat
                };

                Control[] controls = { btnDetails, pictureBox, lblCountry, lblCity, lblDescription, picVacation, lblTransport, picHotel, lblHotel, picStar, lblStar, picDeparture, lblDeparture, lblArrival, picArrival, picPrice, lblPrice, line };
                panel.Controls.AddRange(controls);

                flowLayoutPanel1.Controls.Add(panel);
                form2.Controls.Add(flowLayoutPanel1);

                form2.Show();

                btnDetails.Click += (s, ev) =>
                {
                    Form formDetails = new Form()
                    {
                        Width = 1040,
                        BackColor = SystemColors.ButtonHighlight,
                        MaximumSize = new Size(1040, 900),
                        MinimumSize = new Size(1040, 900),
                        Text = vacation.City,
                        Height = 900,
                    };

                    Panel panelDetails = new Panel
                    {
                        Width = formDetails.Width-50,
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
                        Text = vacation.Country,
                        Font = new Font("Century Gothic", 24, FontStyle.Bold),
                        Size = new Size(formDetails.Width, 50),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(0, 150)
                    };

                    Label lblCityDetails = new Label
                    {
                        Text = vacation.City,
                        Font = new Font("Century Gothic", 20),
                        Size = new Size(formDetails.Width, 50),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(0, 190)
                    };

                    Label lblShortDesc = new Label
                    {
                        Text = vacation.ShortDescription,
                        Font = new Font("Century Gothic", 15),
                        Size = new Size(formDetails.Width/2, 100),
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
                        Text = "way of travel: " + vacation.VehicleType,
                        Font = new Font("Century Gothic", 13),
                        Width = 220,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(100, 400)
                    };

                    Label lblHotelName = new Label
                    {
                        Text = "hotel: " + vacation.HotelName,
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
                        Text = "rating: " + vacation.HotelRating,
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
                        Text = "arrival: " + vacation.ArrivalDate,
                        Font = new Font("Century Gothic", 13),
                        Width = 220,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(picArr.Right + 5, picArr.Top)
                    };

                    Label lblDepart = new Label
                    {
                        Text = "departure: " + vacation.DepartureDate,
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
                        Text = "price ($): " + vacation.Price.ToString(),
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

                    Control[] controlsDetails = { picTravelAgency, label, picVehicle, picArr, numericUpDown, picprice, btnReserve,  lblprice, picDepart, lblArr, lblDepart, lblHotelRating, picRating, picHotelName, lblHotelName, lblCountryDetails, lblVehicleType, lblCityDetails, lblShortDesc };

                    panelDetails.Controls.AddRange(controlsDetails);
                    flowLayoutPanelDetails.Controls.Add(panelDetails);
                    formDetails.Controls.Add(flowLayoutPanelDetails);

                    formDetails.Show();
                };

            }
        }

        List<Vacation> GetAllVacations()
        {
            List<Vacation> vacations = new List<Vacation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, Country.Country, CountryCity.City, MAX(Photos.Photo) AS Photo, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationID = Vacation.VacationId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN Country ON Country.CountryId = Vacation.CountryId LEFT JOIN Photos ON Photos.VacationId = Vacation.VacationId GROUP BY Vacation.VacationId, Country.Country, CountryCity.City, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(3)&& !reader.IsDBNull(4))
                    {
                        Vacation vacation = new Vacation(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (byte[])reader["Photo"], reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10));
                        vacations.Add(vacation);
                    }
                    else
                    {
                        Vacation vacation = new Vacation(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), null, reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10));
                        vacations.Add(vacation);
                    }
                }
            }

            return vacations;
        }

        private Image GetPhoto(byte[] imageBytes)
        {
            try
            {
                using (var ms = new MemoryStream(imageBytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (System.ArgumentException)
            {
                return null;
            }
        }
    }
}
