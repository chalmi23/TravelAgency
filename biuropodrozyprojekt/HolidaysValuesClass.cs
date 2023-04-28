using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
