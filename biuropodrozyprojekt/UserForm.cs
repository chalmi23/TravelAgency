using System;
using System.Windows.Forms;

namespace biuropodrozyprojekt 
{
    public partial class UserForm : Form
    {
        public UserForm()
        {
            InitializeComponent();

            var discoverTrip = new discoverUserControl();
                discoverPanel.Controls.Add(discoverTrip);
            var searchTrip = new searchUserControl();
                panelSearch.Controls.Add(searchTrip);
            var myProfile = new profileUserControl();
                panelProfile.Controls.Add(myProfile);

        }
        #region Menu
        private void discoverTripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discoverPanel.Visible = true;
            panelSearch.Visible = false;
            panelProfile.Visible = false;
        }
        private void searchTripsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discoverPanel.Visible = false;
            panelSearch.Visible = true;
            panelProfile.Visible = false;
        }
        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discoverPanel.Visible = false;
            panelSearch.Visible = false;           
            panelProfile.Visible = true;   
            
        }
        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion Menu
    }
}
