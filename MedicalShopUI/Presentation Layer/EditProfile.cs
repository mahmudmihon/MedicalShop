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
    public partial class EditProfile : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();
        BusinessStaff bs = new BusinessStaff();

        public EditProfile()
        {
            InitializeComponent();
        }

        public EditProfile(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((txtName.Text == "") || (txtMobile.Text == "") || (txtEmail.Text == ""))
            {
                MessageBox.Show("Fill all the field's");
            }
            else
            {
                bs.UpdateInfo(txtName.Text, txtMobile.Text, txtEmail.Text, txtAddress.Text, userId);
                MessageBox.Show("Information Updated");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Text = txtMobile.Text = txtEmail.Text = txtAddress.Text = string.Empty;
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            DataTable person = bs.GetPerson(userId);

            txtName.Text = person.Rows[0][0].ToString();
            txtMobile.Text = person.Rows[0][1].ToString();
            txtEmail.Text = person.Rows[0][2].ToString();
            txtAddress.Text = person.Rows[0][3].ToString();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNew.Text == txtConfirm.Text)
            {
                bs.UpdatePass(txtConfirm.Text, userId);
                MessageBox.Show("Password Changed");
                txtConfirm.Text = txtNew.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Password don't match");
            }
        }
    }
}
