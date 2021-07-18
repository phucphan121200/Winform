using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Đồ_án_ltwin
{
    public partial class NotificationSignup : Form
    {
        public NotificationSignup(string strTextBox)
        {
            InitializeComponent();
            LabelName.Text = strTextBox;
        }

        private void NotificationSignup_Load(object sender, EventArgs e)
        {
            RegisterForm logup = new RegisterForm();
            LabelYourein.Text=("You're in ORWELL, " + logup.TextBoxFname.Text);
        }

        private void BacktoForm1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
