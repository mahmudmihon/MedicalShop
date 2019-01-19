using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MedicalShopUI.Presentation_Layer;
using MedicalShopUI.Business_Logic_Layer;

namespace MedicalShopUI
{
    public partial class SearchMedicine : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();
        BusinessAddMedicine bam = new BusinessAddMedicine();
        SqlConnection con;

        public SearchMedicine()
        {
            InitializeComponent();
            dataGridView1.DataSource = bam.showWGrid();
            con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
        }

        public SearchMedicine(string userId)
        {
            InitializeComponent();
            dataGridView1.DataSource = bam.showWGrid();
            con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            this.userId = userId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AdminPanel ad = new AdminPanel();
            //ad.Show();
            //this.Hide();

            string searchMedicine;
            if (textBox7.Text == "" && textBox1.Text == "")
                MessageBox.Show("Fill up either ID or medicine name");
            else if (textBox7.Text == "")
            {
                searchMedicine = textBox1.Text;
                dataGridView1.DataSource = bam.Search(searchMedicine, true);
            }

            else
            {
                searchMedicine = textBox7.Text;
                dataGridView1.DataSource = bam.Search(searchMedicine, false);
            }
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

        private void SearchMedicine_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }
    }
}
