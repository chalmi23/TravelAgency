using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace biuropodrozyprojekt
{
    internal class UserClass
    {
        private int UserId;
        private string UserName;
        private string Password;
        private string Email;
        private int Role;
        public int UserIdGS { get => UserId; set => UserId = value; }
        public string UserNameGS { get => UserName; set => UserName = value; }
        public string PasswordGS { get => Password; set => Password = value; }
        public string EmailGS { get => Email; set => Email = value; }
        public int RoleGS { get => Role; set => Role = value; }

        string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public UserClass GetUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT UserId, UserName, UserPassword, UserMail, RoleId FROM Users WHERE UserID = @userId", connection);
                command.Parameters.AddWithValue("@userId", userId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserClass user = new UserClass();
                    user.UserIdGS = userId;
                    user.UserName = reader.GetString(1);
                    user.PasswordGS = reader.GetString(2);
                    user.EmailGS = reader.GetString(3);
                    user.RoleGS = reader.GetInt32(4);
                    return user;
                }
            }
            return null;
        }

        public UserClass UpdateUser(int userId, string userName, string userPassword, string userMail, int roleId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE Users SET UserName = @userName, UserPassword = @userPassword, UserMail = @userMail, RoleId = @roleId WHERE UserId = @userId";
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@userName", userName);
                    command.Parameters.AddWithValue("@userPassword", userPassword);
                    command.Parameters.AddWithValue("@userMail", userMail);
                    command.Parameters.AddWithValue("@roleId", roleId);

                    command.ExecuteNonQuery();
                    MessageBox.Show("User updated!", "AdminTool", MessageBoxButtons.OK);
                }
            }
            return null;
        }
        
        public UserClass DeleteUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand deleteUserCommand = new SqlCommand("DELETE FROM Users WHERE UserId = @userId", connection);
                deleteUserCommand.Parameters.AddWithValue("@userId", userId);
                deleteUserCommand.ExecuteNonQuery();

                MessageBox.Show("User succesfully deleted", "AdminTool", MessageBoxButtons.OK);
            }
            return null;
        }
    }
}
