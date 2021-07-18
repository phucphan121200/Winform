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
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void LoadingForm_Activated(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaProgressBar1.Value++;
            //for(int i=1;i<gunaProgressBar1.Maximum;i++)
            //{
            //    gunaProgressBar1.Value = i;
            //}
            //MenuForm menu = new MenuForm();
            //menu.Show(this);
            //Hide();
            //timer1.Enabled = false;
            //gunaLabel1.Text = "Loading.." + ((gunaProgressBar1.Value) / (gunaProgressBar1.Maximum) * 100) + "%..";
            if (gunaProgressBar1.Maximum == gunaProgressBar1.Value)
            {
                if (Global.check == 6)
                {
                    MenuForm menu = new MenuForm();
                    menu.Show(this);
                    Hide();
                    timer1.Enabled = false;
                }
                if (Global.check == 5)
                {
                    ManageOWELLForm manage = new ManageOWELLForm();
                    manage.Show(this);
                    Hide();
                    timer1.Enabled = false;
                }
            }
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            gunaProgressBar1.Maximum = 30;
            
        }
    }
}
