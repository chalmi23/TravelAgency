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
    internal class CountryClass
    {
        private int CountryId;
        private string CountryName;
        public int CountryIdGS { get => CountryId; set => CountryId = value; }
        public string CountryNameGS { get => CountryName; set => CountryName = value; }


        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public CountryClass GetCountry(int countryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT CountryId, Country FROM Country WHERE CountryId = @countryId", connection);
                command.Parameters.AddWithValue("@countryId", countryId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    CountryClass country = new CountryClass();
                    country.CountryIdGS = countryId;
                    country.CountryNameGS = reader.GetString(1);
                    return country;
                }
            }
            return null;
        }

        public CountryClass UpdateCountry(int countryId, string countryName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Country SET Country = @countryName WHERE countryId = @countryId";
                    command.Parameters.AddWithValue("@countryId", countryId);
                    command.Parameters.AddWithValue("@countryName", countryName);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Country updated!", "AdminTool", MessageBoxButtons.OK);
                }
            }
            return null;
        }

        public CountryClass DeleteCountry(int countryId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand deleteUserCommand = new SqlCommand("DELETE FROM Country WHERE CountryId = @countryId", connection);
                deleteUserCommand.Parameters.AddWithValue("@countryId", countryId);
                deleteUserCommand.ExecuteNonQuery();

                MessageBox.Show("Country succesfully deleted", "AdminTool", MessageBoxButtons.OK);
            }
            return null;
        }
    }
}
