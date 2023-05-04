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
using System.Configuration;

namespace biuropodrozyprojekt
{
    public partial class searchUserControl : UserControl
    {
        public searchUserControl()
        {
            InitializeComponent();
        }

    string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
    private void search(object sender, EventArgs e)
        {
            dataGridView1.DataBindings.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.GridColor = Color.Gray;
            dataGridView1.BackgroundColor = Color.LightGray;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            string search = searchTx.Text;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("SELECT DISTINCT TypeOfVacation.TypeName AS 'Trip type', Country.Country, CountryCity.City, Vacation.HotelName AS 'Hotel Name', Vacation.HotelRating AS 'Hotel Rating', Vacation.MaxPeople AS 'Free places', VehicleType.VehicleName AS 'Type of Vehicle', Vacation.Price AS 'Price($)', DateVacation.DepartureDate AS Departure, DateVacation.ArrivalDate as Arrival  FROM Vacation INNER JOIN DateVacation ON DateVacation.VacationId = Vacation.VacationId INNER JOIN Country ON Country.CountryId = Vacation.CountryId INNER JOIN TypeOfVacation ON TypeOfVacation.TypeId = Vacation.TypeId INNER JOIN VehicleType ON VehicleType.VehicleId = Vacation.VehicleId INNER JOIN CountryCity ON CountryCity.CityId = Vacation.CityId WHERE Country.Country LIKE '%' + @search + '%' OR CountryCity.City LIKE '%' + @search + '%' OR Vacation.HotelName LIKE '%' + @search + '%' OR Vacation.HotelRating LIKE '%' + @search + '%' OR DateVacation.ArrivalDate LIKE '%' + @search + '%' OR DateVacation.DepartureDate LIKE '%' + @search + '%'  OR VehicleType.VehicleName LIKE '%' + @search + '%' OR Vacation.Price LIKE '%' + @search + '%' OR TypeOfVacation.TypeName LIKE '%' + @search + '%'", connection);
                
                command.Parameters.AddWithValue("@search", search);
                adapter.SelectCommand = command;

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[1].Width = 112;
                dataGridView1.Columns[2].Width = 105;
                dataGridView1.Columns[4].Width = 70;
                dataGridView1.Columns[5].Width = 70;
                dataGridView1.Columns[7].Width = 70;
            }
        }
    }
}
