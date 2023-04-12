using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using System.Configuration;

namespace biuropodrozyprojekt
{
    public partial class addTripAdminControl : UserControl
    {
        public addTripAdminControl()
        {
            InitializeComponent();
        }


    string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

    private void addTripButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(hotelNameTx.Text) == false)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string insertVacationQuery = "INSERT INTO Vacation VALUES (@typeId, @countryId, @cityId, @maxPeople, @price, @hotelName, @hotelRating, @vehicleId)";

                        using (SqlCommand command = new SqlCommand(insertVacationQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@typeId", int.Parse(vacationTypeTx.Text));
                            command.Parameters.AddWithValue("@countryId", int.Parse(countryTx.Text));
                            command.Parameters.AddWithValue("@cityId", int.Parse(cityTx.Text));
                            command.Parameters.AddWithValue("@price", int.Parse(priceTx.Text));
                            command.Parameters.AddWithValue("@hotelName", hotelNameTx.Text);
                            command.Parameters.AddWithValue("@hotelRating", int.Parse(hotelRatingTx.Text));
                            command.Parameters.AddWithValue("@vehicleId", int.Parse(vehicleTx.Text));
                            command.Parameters.AddWithValue("@maxPeople", int.Parse(peopleTx.Text));

                            command.ExecuteNonQuery();
                        }

                        int insertedVacationId = 0;

                        string selectVacationIdQuery = "SELECT TOP 1 VacationId from Vacation order by VacationId DESC";
                        using (SqlCommand command = new SqlCommand(selectVacationIdQuery, connection, transaction))
                        {
                            insertedVacationId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        string insertDateVacationQuery = "INSERT INTO DateVacation (DepartureDate, ArrivalDate, VacationId) VALUES (@departureDate, @arrivalDate, @vacationId)";
                        using (SqlCommand command = new SqlCommand(insertDateVacationQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@departureDate", dateTimePicker1.Text);
                            command.Parameters.AddWithValue("@arrivalDate", dateTimePicker2.Text);
                            command.Parameters.AddWithValue("@vacationId", insertedVacationId);

                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Holidays succesfully added!", "UserTool", MessageBoxButtons.OK);
                    }
                    catch (SqlException)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Please enter a valid values!", "Error 303", MessageBoxButtons.OK);
                    }
                    catch (FormatException)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Please enter a valid values!", "Error 505", MessageBoxButtons.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hotel name cannot be empty!", "Error 505", MessageBoxButtons.OK);
            }
        }
    }
}
