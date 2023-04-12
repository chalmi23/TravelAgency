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
using System.Net.Mail;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;

namespace biuropodrozyprojekt
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;
        public static Form1 Instance
        {
            get
            {
                if (_instance == null) _instance = new Form1();
                return _instance;
            }
        }
        public static int idUser;

        logowanieUC logowanie = new logowanieUC();
        rejestracjaUC rejestracja = new rejestracjaUC();
        AdminForm adminForm = new AdminForm();
        UserForm userForm = new UserForm();

    string connectionString = ConfigurationManager.AppSettings["ConnectionString"];

    public Form1()
        {
            InitializeComponent();
            logowanie.loginClick += loginButton_Click;
            rejestracja.registerClick += rejestracjaButton_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rejestracja.Visible = false;
            _instance = this;
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            logowanie.Dock = DockStyle.Fill;
            panel1.Controls.Add(logowanie);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            logowanie.Visible = !logowanie.Visible;
            panel1.Visible = !panel1.Visible;
            rejestracja.Visible = !rejestracja.Visible;
            button1.Visible = !button1.Visible;
            label1.Visible = !label1.Visible;
            loginBt.Visible = !loginBt.Visible;
            label2.Visible = !label2.Visible;
            pictureBox1.Visible = !pictureBox1.Visible;
            contactLabel.Visible = !contactLabel.Visible;
            phoneIcon.Visible = !phoneIcon.Visible;
            mailIcon.Visible = !mailIcon.Visible;
            labelBaner.Visible = !labelBaner.Visible;
            logoIcon.Visible = !logoIcon.Visible;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.Controls.Add(rejestracja);
        }

        #region Login
        private void loginButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string loginQuery = "SELECT * FROM Users WHERE UserName = @username AND UserPassword = @password";

                using (SqlCommand command = new SqlCommand(loginQuery, connection))
                {
                    command.Parameters.AddWithValue("@username", logowanie.LoginTx.Text.ToString());
                    command.Parameters.AddWithValue("@password", logowanie.PasswordTx.Text.ToString());

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            this.Hide();

                            int roleId = reader.GetInt32(reader.GetOrdinal("RoleId"));
                            int userId = reader.GetInt32(reader.GetOrdinal("UserId"));
                            idUser = userId;

                            if (roleId == 1)
                            {
                                adminForm.ShowDialog();
                            }
                            else if (roleId == 2)
                            {
                                userForm.ShowDialog();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password!", "Error 404", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }
        #endregion Login
        #region Register
        private void rejestracjaButton_Click(object sender, EventArgs e)
        {


            if (rejestracja.RegisterUsernameTx.Text.Contains(" ") == true || rejestracja.RegisterPasswdTx.Text.Contains(" ") == true || rejestracja.RegisterEmailTx.Text.Contains(" ") == true)
            {
                MessageBox.Show("Enter all informations correctly!", "UserTool", MessageBoxButtons.OK);
                return;
            }

            if (rejestracja.RegisterUsernameTx.Text.Length < 6 || rejestracja.RegisterUsernameTx.Text.Length > 24 || rejestracja.RegisterPasswdTx.Text.Length < 6 || rejestracja.RegisterPasswdTx.Text.Length > 24)
            {
                MessageBox.Show("Data must be between 6 and 24 characters long!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(rejestracja.RegisterEmailTx.Text, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$"))
            {
                MessageBox.Show("Enter valid email!", "Error 666", MessageBoxButtons.OK);
                return;
            }

            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Users (Username, UserPassword, UserMail, RoleId) VALUES (@Username, @UserPassword, @UserMail, @RoleId)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", rejestracja.RegisterUsernameTx.Text);
                        command.Parameters.AddWithValue("@UserPassword", rejestracja.RegisterPasswdTx.Text);
                        command.Parameters.AddWithValue("@UserMail", rejestracja.RegisterEmailTx.Text);
                        command.Parameters.AddWithValue("@RoleId", '2');

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Account has been created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (System.Data.SqlClient.SqlException)
                        {
                            MessageBox.Show("Username or email already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        #endregion Register
        public static bool ContainsSpace(string input)
        {
            return input.IndexOf(" ") != -1;
        }
    }
}
