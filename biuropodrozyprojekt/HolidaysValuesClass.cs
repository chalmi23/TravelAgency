using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace biuropodrozyprojekt
{
    internal class HolidaysValuesClass
    {
        private int VacationId;
        private string Country;
        private string City;
        private byte[] PhotoBytes;
        private string ShortDescription;
        private string VehicleType;
        private string HotelName;
        private int HotelRating;
        private string DepartureDate;
        private string ArrivalDate;
        private int Price;
        private int MaxPeople;

        public HolidaysValuesClass(int id, string country, string city, byte[] photoBytes, string shortDescription, string vehicleType, string hotelName, int hotelRating, string departureDate, string arrivalDate, int price, int maxPeople)
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
            MaxPeople = maxPeople;
        }

        public int VacationIdGS { get => VacationId; set => VacationId = value; }
        public string CountryGS { get => Country; set => Country = value; }
        public string CityGS { get => City; set => City = value; }
        public byte[] PhotoBytesGS { get => PhotoBytes; set => PhotoBytes = value; }
        public string ShortDescriptionGS { get => ShortDescription; set => ShortDescription = value; }
        public string VehicleTypeGS { get => VehicleType; set => VehicleType = value; }
        public string HotelNameGS { get => HotelName; set => HotelName = value; }
        public int HotelRatingGS { get => HotelRating; set => HotelRating = value; }
        public string DepartureDateGS { get => DepartureDate; set => DepartureDate = value; }
        public string ArrivalDateGS { get => ArrivalDate; set => ArrivalDate = value; }
        public int PriceGS { get => Price; set => Price = value; }
        public int MaxPeopleGS { get => MaxPeople; set => MaxPeople = value; }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public List<byte[]> GetPhotosForTrip(int tripId)
        {
            List<byte[]> photos = new List<byte[]>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Photo FROM Photos WHERE VacationId = @tripId", connection);
                command.Parameters.AddWithValue("@tripId", tripId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    byte[] photoBytes = reader.IsDBNull(0) ? null : (byte[])reader.GetValue(0);
                    if (photoBytes != null)
                    {
                        photos.Add(photoBytes);
                    }
                }
            }

            return photos;
        }

        public static List<HolidaysValuesClass> GetAllVacations()
        {
            List<HolidaysValuesClass> vacations = new List<HolidaysValuesClass>();
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, Country.Country, CountryCity.City, MAX(Photos.Photo) AS Photo, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price, Vacation.MaxPeople FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationID = Vacation.VacationId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN Country ON Country.CountryId = Vacation.CountryId LEFT JOIN Photos ON Photos.VacationId = Vacation.VacationId GROUP BY Vacation.VacationId, Country.Country, CountryCity.City, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price, Vacation.MaxPeople", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
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

        public static HolidaysValuesClass GetOneTrip(int tripId)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Vacation.VacationId, Country.Country, CountryCity.City, MAX(Photos.Photo) AS Photo, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price, Vacation.MaxPeople FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationID = Vacation.VacationId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId INNER JOIN Country ON Country.CountryId = Vacation.CountryId LEFT JOIN Photos ON Photos.VacationId = Vacation.VacationId  WHERE Vacation.VacationId=@VacationId GROUP BY Vacation.VacationId, Country.Country, CountryCity.City, Vacation.ShortDescription, VehicleType.VehicleName, Vacation.HotelName, Vacation.HotelRating, DateVacation.DepartureDate, DateVacation.ArrivalDate, Vacation.Price, Vacation.MaxPeople", connection);
                command.Parameters.AddWithValue("@VacationId", tripId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.IsDBNull(3) && !reader.IsDBNull(4))
                    {
                        HolidaysValuesClass vacation = new HolidaysValuesClass(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), (byte[])reader["Photo"], reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10), reader.GetInt32(11));
                        return vacation;
                    }
                    else
                    {
                        HolidaysValuesClass vacation = new HolidaysValuesClass(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), null, reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10), reader.GetInt32(11));
                        return vacation;
                    }
                }
            }
            return null;
        }
    }
}
