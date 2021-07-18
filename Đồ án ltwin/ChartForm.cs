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
    public partial class ChartForm : Form
    {
        public ChartForm()
        {
            InitializeComponent();
        }
        LOGIN login = new LOGIN();
        MEMBER member = new MEMBER();
        private void ChartForm_Load(object sender, EventArgs e)
        {
            if(Global.check==1)
            {
                double total = Convert.ToDouble(member.totalStore());
                double FPT = Convert.ToDouble(member.totalFPTStore());
                double TGDD = Convert.ToDouble(member.totalTGDD());
                double PhongVu = Convert.ToDouble(member.totalPhongvu());
                double DMX = Convert.ToDouble(member.totalDMX());
                double FPTPercentage = (FPT * (100 / total));
                double TGDDPercentage = (TGDD * (100 / total));
                double PhongVuPercentage = (PhongVu * (100 / total));
                double DMXPercentage = (DMX * (100 / total));

                chart1.Series["BDT"].Points.AddXY("FPT: " + FPTPercentage.ToString("0.00") + "%", FPTPercentage);
                chart1.Series["BDT"].Points.AddXY("TGDD: " + TGDDPercentage.ToString("0.00") + "%", TGDDPercentage);
                chart1.Series["BDT"].Points.AddXY("Phong Vu: " + PhongVuPercentage.ToString("0.00") + "%", PhongVuPercentage);
                chart1.Series["BDT"].Points.AddXY("DMX: " + DMXPercentage.ToString("0.00") + "%", DMXPercentage);
            }
            if(Global.check==2)
            {
                double total = Convert.ToDouble(login.totalMember());
                double Male = Convert.ToDouble(login.totalMaleMember());
                double Female = Convert.ToDouble(login.totalFemaleMember());
                double maleStudentsPercentage = (Male * (100 / total));
                double FemaleStudentsPercentage = (Female * (100 / total));

                chart1.Series["BDT"].Points.AddXY("Male: " + maleStudentsPercentage.ToString("0.00") + "%", maleStudentsPercentage);
                chart1.Series["BDT"].Points.AddXY("Female: " + FemaleStudentsPercentage.ToString("0.00") + "%", FemaleStudentsPercentage);
            }
        }
    }
}
