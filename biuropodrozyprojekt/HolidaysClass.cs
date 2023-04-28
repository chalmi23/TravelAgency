using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace biuropodrozyprojekt
{
    internal class HolidaysClass
    {
        private int VacationId;
        private int TypeId;
        private int CountryId;
        private int CityId;
        private int MaxPeople;
        private int Price;
        private string HotelName;
        private int HotelRating;
        private int VehicleId;
        private string ShortDescription;

        public int VacationIdGS { get => VacationId; set => VacationId = value; }
        public int TypeIdGS { get => TypeId; set => TypeId = value; }
        public int CountryIdGS { get => CountryId; set => CountryId = value; }
        public int CityIdGS { get => CityId; set => CityId = value; }
        public int MaxPeopleGS { get => MaxPeople; set => MaxPeople = value; }
        public int PriceGS { get => Price; set => Price = value; }
        public string HotelNameGS { get => HotelName; set => HotelName = value; }
        public int HotelRatingGS { get => HotelRating; set => HotelRating = value; }
        public int VehicleIdGS { get => VehicleId; set => VehicleId = value; }
        public string ShortDescriptionGS { get => ShortDescription; set => ShortDescription = value; }


        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public HolidaysClass GetHolidays(int holidaysId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT VacationId, TypeId, CountryId, CityId, MaxPeople, Price, HotelName, HotelRating, VehicleId, ShortDescription FROM Vacation WHERE VacationId = @holidaysId", connection);
                command.Parameters.AddWithValue("@holidaysId", holidaysId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    HolidaysClass holiday = new HolidaysClass();
                    holiday.VacationIdGS = holidaysId;
                    holiday.TypeIdGS = reader.GetInt32(1);
                    holiday.CountryIdGS = reader.GetInt32(2);
                    holiday.CityIdGS = reader.GetInt32(3);
                    holiday.MaxPeopleGS = reader.GetInt32(4);
                    holiday.PriceGS = reader.GetInt32(5);
                    holiday.HotelNameGS = reader.GetString(6);
                    holiday.HotelRatingGS = reader.GetInt32(7);
                    holiday.VehicleIdGS = reader.GetInt32(8);
                    holiday.ShortDescriptionGS = reader.GetString(9);

                    return holiday;
                }
            }
            return null;
        }

        public UserClass DeleteTrip(int tripId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand deleteUserCommand = new SqlCommand("DELETE FROM Vacation WHERE VacationId = @tripId", connection);
                deleteUserCommand.Parameters.AddWithValue("@tripId", tripId);
                deleteUserCommand.ExecuteNonQuery();

                MessageBox.Show("Trip succesfully deleted", "AdminTool", MessageBoxButtons.OK);
            }
            return null;
        }

        public void updateVacation(int vacationId, int typeId, string country, string city, decimal price, string departureDate, string arrivalDate, int maxPeople, string hotelName, int hotelRating, int vehicleId, string shortDescription)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Vacation SET TypeId = @typeId, CountryId = (SELECT CountryId FROM Country WHERE Country = @country), CityId = (SELECT CityId FROM CountryCity WHERE City = @city), Price = @price, MaxPeople = @maxPeople, HotelName = @hotelName, HotelRating = @hotelRating, VehicleId = @vehicleId, ShortDescription = @shortDescription WHERE VacationId = @vacationId";
                    command.Parameters.AddWithValue("@vacationId", vacationId);
                    command.Parameters.AddWithValue("@typeId", typeId);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@maxPeople", maxPeople);
                    command.Parameters.AddWithValue("@hotelName", hotelName);
                    command.Parameters.AddWithValue("@hotelRating", hotelRating);
                    command.Parameters.AddWithValue("@vehicleId", vehicleId);
                    command.Parameters.AddWithValue("@shortDescription", shortDescription);
                    command.ExecuteNonQuery();
                }

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE DateVacation SET DepartureDate = @departureDate, ArrivalDate = @arrivalDate WHERE VacationId = @vacationId";
                    command.Parameters.AddWithValue("@vacationId", vacationId);
                    command.Parameters.AddWithValue("@departureDate", departureDate);
                    command.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Trip edited succesfully!", "AdminTool", MessageBoxButtons.OK);
            }
        }

        public void addNewVacation(int typeId, string country, string city, decimal price, string departureDate, string arrivalDate, int maxPeople, string hotelName, int hotelRating, int vehicleId, string shortDescription)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO Vacation (TypeId, CountryId, CityId, Price, MaxPeople, HotelName, HotelRating, VehicleId, ShortDescription) VALUES (@typeId, (SELECT CountryId FROM Country WHERE Country = @country), (SELECT CityId FROM CountryCity WHERE City = @city), @price, @maxPeople, @hotelName, @hotelRating, @vehicleId, @shortDescription); SELECT SCOPE_IDENTITY()";
                    command.Parameters.AddWithValue("@typeId", typeId);
                    command.Parameters.AddWithValue("@country", country);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@maxPeople", maxPeople);
                    command.Parameters.AddWithValue("@hotelName", hotelName);
                    command.Parameters.AddWithValue("@hotelRating", hotelRating);
                    command.Parameters.AddWithValue("@vehicleId", vehicleId);
                    command.Parameters.AddWithValue("@shortDescription", shortDescription);
                    int vacationId = Convert.ToInt32(command.ExecuteScalar());

                    using (SqlCommand command2 = connection.CreateCommand())
                    {
                        command2.CommandText = "INSERT INTO DateVacation (DepartureDate, ArrivalDate, VacationId) VALUES (@departureDate, @arrivalDate, @vacationId)";
                        command2.Parameters.AddWithValue("@departureDate", departureDate);
                        command2.Parameters.AddWithValue("@arrivalDate", arrivalDate);
                        command2.Parameters.AddWithValue("@vacationId", vacationId);
                        command2.ExecuteNonQuery();
                    }
                    MessageBox.Show("Trip added succesfully!", "AdminTool", MessageBoxButtons.OK);
                }
            }
        }
    }
}
