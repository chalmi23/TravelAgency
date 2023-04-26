﻿using System;
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

            List<HolidaysValuesClass> vacations = GetAllVacations();

            foreach (HolidaysValuesClass vacation in vacations)
            {
                Panel panel = new Panel
                {
                    Width = 1040,
                    Height = 400
                };

                PictureBox pictureBox = new PictureBox
                {
                    Size = new Size(500, 350),
                    Image = GetPhoto(vacation.PhotoBytesGS),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Location = new Point(10, 10)
                };

                Label lblCountry = new Label
                {
                    Text = vacation.CountryGS,
                    Font = new Font("Century Gothic", 20),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(530, 10)
                };

                Label lblCity = new Label
                {
                    Text = vacation.CityGS,
                    Font = new Font("Century Gothic", 16),
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(530, 50)
                };

                Label lblDescription = new Label
                {
                    Text = vacation.ShortDescriptionGS,
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
                    Text = vacation.VehicleTypeGS,
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
                    Text = vacation.HotelNameGS,
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
                    Text = vacation.HotelRatingGS.ToString(),
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
                    Text = vacation.DepartureDateGS,
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
                    Text = vacation.ArrivalDateGS,
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
                    Text = vacation.PriceGS.ToString(),
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
                        Text = vacation.CityGS,
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
                        Text = vacation.CountryGS,
                        Font = new Font("Century Gothic", 24, FontStyle.Bold),
                        Size = new Size(formDetails.Width, 50),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(0, 150),
                    };

                    Label lblCityDetails = new Label
                    {
                        Text = vacation.CityGS,
                        Font = new Font("Century Gothic", 20),
                        Size = new Size(formDetails.Width, 50),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Location = new Point(0, 190)
                    };

                    Label lblShortDesc = new Label
                    {
                        Text = vacation.ShortDescriptionGS,
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
                        Text = "way of travel: " + vacation.VehicleTypeGS,
                        Font = new Font("Century Gothic", 13),
                        Width = 220,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(100, 400)
                    };

                    Label lblHotelName = new Label
                    {
                        Text = "hotel: " + vacation.HotelNameGS,
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
                        Text = "rating: " + vacation.HotelRatingGS,
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
                        Text = "arrival: " + vacation.ArrivalDateGS,
                        Font = new Font("Century Gothic", 13),
                        Width = 220,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(picArr.Right + 5, picArr.Top)
                    };

                    Label lblDepart = new Label
                    {
                        Text = "departure: " + vacation.DepartureDateGS,
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
                        Text = "price ($): " + vacation.PriceGS.ToString(),
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

                    PictureBox pictureBoxes = new PictureBox
                    {
                        Width = 1000,
                        Height = 800,
                        Image = GetPhoto(vacation.PhotoBytesGS),
                        SizeMode = PictureBoxSizeMode.Zoom                
                    };

                    Control[] controlsDetails = { picTravelAgency, label, labelDiscover, picVehicle, picArr, numericUpDown, picprice, btnReserve, lblprice, picDepart, lblArr, lblDepart, lblHotelRating, picRating, picHotelName, lblHotelName, lblCountryDetails, lblVehicleType, lblCityDetails, lblShortDesc };

                    panelDetails.Controls.AddRange(controlsDetails);

                    flowLayoutPanelDetails.Controls.Add(panelDetails);
                    flowLayoutPanelDetails.Controls.Add(pictureBoxes);
                    formDetails.Controls.Add(flowLayoutPanelDetails);

                    formDetails.Show();

                    btnReserve.Click += new EventHandler((senderApply, eApply) =>
                    {
                        UserVacationClass userVacation = new UserVacationClass();
                        userVacation.addUserVacation(vacation.VacationIdGS, vacation.MaxPeopleGS, Form1.idUser,(int)numericUpDown.Value);
                        formDetails.Close();
                    });
                };

            }
        }

        List<HolidaysValuesClass> GetAllVacations()
        {
            List<HolidaysValuesClass> vacations = new List<HolidaysValuesClass>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, Country.Country, CountryCity.City, MAX(Photos.Photo) AS Photo, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price, Vacation.MaxPeople FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationID = Vacation.VacationId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN Country ON Country.CountryId = Vacation.CountryId LEFT JOIN Photos ON Photos.VacationId = Vacation.VacationId GROUP BY Vacation.VacationId, Country.Country, CountryCity.City, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price, Vacation.MaxPeople", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(3)&& !reader.IsDBNull(4))
                    {
                        HolidaysValuesClass vacation = new HolidaysValuesClass(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (byte[])reader["Photo"], reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10), reader.GetInt32(11));
                        vacations.Add(vacation);
                    }
                    else
                    {
                        HolidaysValuesClass vacation = new HolidaysValuesClass(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), null, reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10), reader.GetInt32(11));
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
