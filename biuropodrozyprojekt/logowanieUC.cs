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
    }
}
