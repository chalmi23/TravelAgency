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
