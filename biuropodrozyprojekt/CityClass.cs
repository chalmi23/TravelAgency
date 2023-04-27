using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    internal class CityClass
    {
        private int CityId;
        private string CityName;
        private int CountryId;
        //#test2
        public int CityIdGS { get => CityId; set => CityId = value; }
        public string CityNameGS { get => CityName; set => CityName = value; }
        public int CountryIdGS { get => CountryId; set => CountryId = value; }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public CityClass GetCity(int cityId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT CityId, City, CountryId FROM CountryCity WHERE CityId = @cityId", connection);
                command.Parameters.AddWithValue("@cityId", cityId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CityClass city = new CityClass();
                    city.CityIdGS = cityId;
                    city.CityNameGS = reader.GetString(1);
                    city.CountryIdGS = reader.GetInt32(2);
                    return city;
                }
            }
            return null;
        }

        public UserClass UpdateCity(int cityId, string cityName, int countryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE CountryCity SET City = @cityName, CountryId = @countryId WHERE CityId = @cityId";
                    command.Parameters.AddWithValue("@cityId", cityId);
                    command.Parameters.AddWithValue("@cityName", cityName);
                    command.Parameters.AddWithValue("@countryId", countryId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("City updated!", "AdminTool", MessageBoxButtons.OK);
                }
            }
            return null;
        }
        public CityClass DeleteCity(int cityId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand updateUserCommand = new SqlCommand("UPDATE Vacation SET CityId = 47 WHERE CityId = @cityId", connection);
                updateUserCommand.Parameters.AddWithValue("@cityId", cityId);
                updateUserCommand.ExecuteNonQuery();

                SqlCommand deleteCityCommand = new SqlCommand("DELETE FROM CountryCity WHERE CityId = @cityId", connection);
                deleteCityCommand.Parameters.AddWithValue("@cityId", cityId);
                deleteCityCommand.ExecuteNonQuery();

                MessageBox.Show("City succesfully deleted", "AdminTool", MessageBoxButtons.OK);
            }
            return null;
        }

    }

}
