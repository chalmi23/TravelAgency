using System;
using System.Windows.Forms;

namespace biuropodrozyprojekt
{
    public partial class logowanieUC : UserControl
    {
        public EventHandler loginClick;
        public logowanieUC()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler click = loginClick;
            click?.Invoke(this, e);
        }

        private void logowanieUC_Load(object sender, EventArgs e)
        {

        }
    }
}
