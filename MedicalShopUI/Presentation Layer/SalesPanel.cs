using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalShopUI.Presentation_Layer;
using MedicalShopUI.Business_Logic_Layer;

namespace MedicalShopUI
{
    public partial class SalesPanel : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();
        Warnings warn = new Warnings();

        public SalesPanel()
        {
            InitializeComponent();
        }

        public SalesPanel(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SaselmanSearch_Click(object sender, EventArgs e)
        {
            SearchMedicine sm = new SearchMedicine(userId);
            sm.Show();
            this.Hide();
        }

        private void SalesmanSale_Click(object sender, EventArgs e)
        {
            MedicineSale ms = new MedicineSale(userId);
            ms.Show();
            this.Hide();
        }

        private void SalesmanSaleInfo_Click(object sender, EventArgs e)
        {
            SaleInfo si = new SaleInfo(userId);
            si.Show();
            this.Hide();
        }

        private void SalesEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile ep = new EditProfile(userId);
            ep.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Warnings war = new Warnings(userId);
            war.Show();
            this.Hide();
        }

        private void SalesPanel_Load(object sender, EventArgs e)
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
    }
}
