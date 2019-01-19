using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalShopUI.Business_Logic_Layer;

namespace MedicalShopUI.Presentation_Layer
{
    public partial class AdminPanel : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();
        Warnings warn = new Warnings();

        public AdminPanel()
        {
            InitializeComponent();
        }

        public AdminPanel(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            string name = lp.GetName(userId);
            lblName.Text = name.ToString();

            DataTable wdt = warn.GetData();

            if (wdt.Rows.Count == 0)
            {
                
                btnWarning.ForeColor = Color.White;
            }
            else
            {
                Color co = Color.FromArgb(242, 16, 16);
                btnWarning.ForeColor = co;
            }
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMedicine am = new AddMedicine(this);
            am.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StockModify sm = new StockModify(userId);
            sm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddStaff asf = new AddStaff(this);
            asf.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ModifyStaff ms = new ModifyStaff(this);
            ms.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddCompany ac = new AddCompany(this);
            ac.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MedicineSale ms = new MedicineSale(userId);
            ms.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaleInfo si = new SaleInfo(userId);
            si.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchMedicine sm = new SearchMedicine(userId);
            sm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ModifyCompany mc = new ModifyCompany(this);
            mc.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void AdminEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile ep = new EditProfile(userId);
            ep.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Warnings war = new Warnings(userId);
            war.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Summary sm = new Summary(userId);
            sm.Show();
            this.Hide();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            Profit p = new Profit(userId);
            p.Show();
            this.Hide();
        }
    }
}
