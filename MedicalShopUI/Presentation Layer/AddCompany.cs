using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MedicalShopUI.Presentation_Layer;
using MedicalShopUI.Business_Logic_Layer;

namespace MedicalShopUI
{
    public partial class AddCompany : Form
    {

        BusinessAddCompany bac = new BusinessAddCompany();
        Form ap;

        public AddCompany(AdminPanel ap)
        {
            InitializeComponent();
            this.ap = ap;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ap.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int check = bac.GetCompanyId(textBox8.Text);

            if (check > 0)
            {
                MessageBox.Show("Company_id Already Exists");
            }
            else
            {

                try
                {
                    if (bac.CreateCompany(textBox4.Text, textBox6.Text, textBox7.Text, int.Parse(textBox8.Text), textBox9.Text, textBox11.Text))
                    {
                        MessageBox.Show(" Company Added.");
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                    textBox4.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox11.Text = string.Empty;
                    string id = bac.GetLastCompanyId();
                    lblCompany.Text = id.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Fill up all Information");
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox11.Text = string.Empty;
        }

        private void AddCompany_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            string id = bac.GetLastCompanyId();
            lblCompany.Text = id.ToString();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
                {
                    lblClock.Text = DateTime.Now.ToString("T");
                }));
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "xyz@mail.com")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "xyz@mail.com";
                textBox7.ForeColor = Color.Silver;
            }
        }
    }
}
