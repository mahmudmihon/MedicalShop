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
    public partial class Warnings : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();
        BusinessAddMedicine bam = new BusinessAddMedicine();

        public Warnings()
        {
            InitializeComponent();
        }

        public Warnings(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int status = lp.GetIdStatus(userId);

            if (status == 1)
            {
                AdminPanel ap = new AdminPanel(userId);
                ap.Show();
                this.Hide();
            }

            else if (status == 2)
            {
                SalesPanel sp = new SalesPanel(userId);
                sp.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MedicineSale ms = new MedicineSale();
            ms.Show();
            this.Hide();
        }

        private void Warnings_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            warningGridView.DataSource = bam.GetExpiredWarningMedicines();
        }

        public DataTable GetData()
        {
            return bam.GetExpiredWarningMedicines();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        
    }
}
