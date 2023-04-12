using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biuropodrozyprojekt
{
    internal class HolidayDateClass
    {
        private int DateId;
        private int VacationId;
        private string DepartureDate;
        private string ArrivalDate;

        public int DateIdGS { get => DateId; set => DateId = value; }
        public int VacationIdGS { get => VacationId; set => VacationId = value; }
        public string DepartureDateGS { get => DepartureDate; set => DepartureDate = value; }
        public string ArrivalDateGS { get => ArrivalDate; set => ArrivalDate = value; }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
        public HolidayDateClass GetVacationDate(int tripId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT DateId, VacationId, DepartureDate, ArrivalDate FROM DateVacation WHERE VacationId = @tripId", connection);
                command.Parameters.AddWithValue("@tripId", tripId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    HolidayDateClass date = new HolidayDateClass();
                    date.DateIdGS = tripId;
                    date.VacationIdGS = reader.GetInt32(1);
                    date.DepartureDate = reader.GetString(2);
                    date.ArrivalDate = reader.GetString(3);
                    return date;
                }
            }
            return null;
        }
    }
}
