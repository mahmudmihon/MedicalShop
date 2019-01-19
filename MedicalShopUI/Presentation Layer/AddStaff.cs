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
    public partial class AddStaff : Form
    {
        Form ap;

        BusinessStaff baf = new BusinessStaff();

        public AddStaff(AdminPanel ap)
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
            int check = baf.GetUserId(txtUserid.Text);

            if (check > 0)
            {
                MessageBox.Show("ID Already Exists");
            }
            else
            {
                try
                {
                    if (checkAdmin.Checked)
                    {
                        if (baf.CreateAsAdmin(txtName.Text, txtUserid.Text, txtPassword.Text, txtAddress.Text, txtMobile.Text, txtEmail.Text, int.Parse(txtSalary.Text)))
                        {
                            MessageBox.Show("Added As Admin.");
                            txtName.Text = "";
                            txtUserid.Text = "";
                            txtPassword.Text = "";
                            txtAddress.Text = "";
                            txtMobile.Text = "";
                            txtEmail.Text = "";
                            txtSalary.Text = "";
                            string id = baf.GetLastUserId();
                            lblId.Text = id.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                    }
                    else
                    {
                        if (baf.CreateAsSalesman(txtName.Text, txtUserid.Text, txtPassword.Text, txtAddress.Text, txtMobile.Text, txtEmail.Text, int.Parse(txtSalary.Text)))
                        {
                            MessageBox.Show("Salesman Added.");
                            txtName.Text = "";
                            txtUserid.Text = "";
                            txtPassword.Text = "";
                            txtAddress.Text = "";
                            txtMobile.Text = "";
                            txtEmail.Text = "";
                            txtSalary.Text = "";
                            string id = baf.GetLastUserId();
                            lblId.Text = id.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Error!");
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Fill all the field's");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtUserid.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtMobile.Text = "";
            txtEmail.Text = "";
            txtSalary.Text = "";
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            string id = baf.GetLastUserId();
            lblId.Text = id.ToString();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "xyz@mail.com")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "xyz@mail.com";
                txtEmail.ForeColor = Color.Silver;
            }
        }
    }
}
