using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();

            var panelAdminCheck = new AdminControlCheckInformations();
                panelAdminCheckInf.Controls.Add(panelAdminCheck);
        }
        private void addNewTripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdminCheckInf.Visible = false;
        }

        private void checkInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelAdminCheckInf.Visible = true;
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void userFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
        }

        private void panelAdminCheckInf_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

