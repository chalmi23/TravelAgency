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

        public int CityIdGS { get => CityId; set => CityId = value; }
        public string CityNameGS { get => CityName; set => CityName = value; }
        public int CountryIdGS { get => CountryId; set => CountryId = value; }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];


        public CityClass DeleteCity(int cityId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand deleteUserCommand = new SqlCommand("DELETE FROM CountryCity WHERE CityId = @cityId", connection);
                deleteUserCommand.Parameters.AddWithValue("@cityId", cityId);
                deleteUserCommand.ExecuteNonQuery();

                MessageBox.Show("City succesfully deleted", "AdminTool", MessageBoxButtons.OK);
            }
            return null;
        }

    }

}
