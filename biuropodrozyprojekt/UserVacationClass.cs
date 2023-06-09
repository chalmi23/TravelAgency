﻿using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    internal class UserVacationClass
    {
        private int UserId;
        private int VacationId;
        private int NumberOfPeople;

        public int UserIdGS { get => UserId; set => UserId = value; }
        public int VacationIdGS { get => VacationId; set => VacationId = value; }
        public int NumberOfPeopleGS { get => NumberOfPeople; set => NumberOfPeople = value; }


        public static UserVacationClass addUserVacation(int vacationId, int maxPeople, int userId, int numberOfPeople)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Vacation SET MaxPeople = @maxPeople WHERE VacationId = @vacationId";
                    command.Parameters.AddWithValue("@vacationId", vacationId);
                    command.Parameters.AddWithValue("@maxPeople", maxPeople-numberOfPeople);
                    command.ExecuteNonQuery();
                }
            }
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
                }
            }
            return null;
        }
    }
}
