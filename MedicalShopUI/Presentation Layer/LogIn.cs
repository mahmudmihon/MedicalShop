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
    public partial class LogIn : Form
    {
        TextBox tb = new TextBox();
        LogInProcess lip = new LogInProcess();

        public LogIn()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int check;

            if ((txtuserId.Text == "") && (txtPassword.Text == ""))
            {
                MessageBox.Show("Please Enter USERID & PASSWORD!");
            }

            else
            {
                check = lip.GetStatus(txtuserId.Text, txtPassword.Text);

                if (check == 1)
                {
                    AdminPanel ap = new AdminPanel(txtuserId.Text);
                    ap.Show();
                    this.Hide();
                }
                else if (check == 2)
                {
                    SalesPanel sp = new SalesPanel(txtuserId.Text);
                    sp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password");

                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            txtuserId.Focus();
        }

        internal int GetStatusData(int id, string pass)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Label email = new Label();
            email.Text = "Enter Email Adrress";
            email.Location = new Point(485, 453);
            email.ForeColor = Color.White;
            email.Width = 110;
            email.Height = 30;
            this.Controls.Add(email);

            
            tb.Width = 204;
            tb.Height = 70;
            tb.Location = new Point(600, 450);
            this.Controls.Add(tb);

            Button confirm = new Button();
            confirm.Text = "Send Email";
            confirm.Location = new Point(830, 447);
            confirm.Width = 100;
            confirm.Height = 25;
            confirm.ForeColor = Color.White;
            confirm.BackColor = Color.FromArgb(0,122,204);
            confirm.FlatStyle = FlatStyle.Flat;
            confirm.FlatAppearance.BorderSize = 0;
            this.Controls.Add(confirm);
            confirm.Click += new EventHandler(confirm_Click);
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if ((txtuserId.Text == "") || (tb.Text == ""))
            {
                MessageBox.Show("Fill UserId and Email!");
            }
            else
            {
                int con = lip.GetConfirm(txtuserId.Text, tb.Text);

                if (con == 1)
                {
                    MessageBox.Show("Please Check Email!");
                    txtuserId.Text = tb.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Invalid Email!");
                    tb.Text = string.Empty;
                }
            }
        }
    }
}
