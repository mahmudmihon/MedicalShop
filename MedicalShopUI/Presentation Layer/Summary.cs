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
using MedicalShopUI.Data_Access_Layer;
using System.Windows.Forms.DataVisualization.Charting;

namespace MedicalShopUI.Presentation_Layer
{
    public partial class Summary : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();

        public Summary()
        {
            InitializeComponent();
        }

        public Summary(string userId)
        {
            InitializeComponent();
            this.userId = userId;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Summary_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            LoadCategoryChart();
            LoadCompanyChart();
            LoadsaleChart();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate ()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void LoadCategoryChart()
        {
            DataTable dt = DataSummary.GetCategoryCount();

            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("category") ascending
                          select p.Field<string>("category")).ToArray();

            int[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("category") ascending
                       select p.Field<int>("cat_count")).ToArray();

            stockChart.Series[0].ChartType = SeriesChartType.Pie;
            stockChart.Series[0].Points.DataBindXY(x, y);
            stockChart.Legends[0].Enabled = true;
            stockChart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }

        private void LoadCompanyChart()
        {
            DataTable dt = DataSummary.GetCompanyCount();

            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("c_name") ascending
                          select p.Field<string>("c_name")).ToArray();

            int[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("c_name") ascending
                       select p.Field<int>("c_count")).ToArray();

            companyChart.Series[0].ChartType = SeriesChartType.Pie;
            companyChart.Series[0].Points.DataBindXY(x, y);
            companyChart.Legends[0].Enabled = true;
            companyChart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }





        private void LoadsaleChart()
        {
            DataTable dt = DataSummary.GetsaleCount();

            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("category") ascending
                          select p.Field<string>("category")).ToArray();

            int[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("category") ascending
                       select p.Field<int>("m_count")).ToArray();

            saleChart.Series[0].ChartType = SeriesChartType.Column;
            saleChart.Series[0].Points.DataBindXY(x, y);
            saleChart.Legends[0].Enabled = true;
            //stockChart.ChartAreas[0].Area3DStyle.Enable3D = true;
        }
    }
}
