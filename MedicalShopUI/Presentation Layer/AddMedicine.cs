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
    public partial class AddMedicine : Form
    {
        Form ap;
        BusinessAddMedicine bam = new BusinessAddMedicine();

        public AddMedicine(AdminPanel ap)
        {
            InitializeComponent();
            this.ap = ap;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPanel ad = new AdminPanel();
            ad.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ap.Show();
            this.Hide();
        }

        private void AddMedicine_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            string id = bam.GetLastMedicId();
            lblMedicNum.Text = id.ToString();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int check = bam.CheckId(textBox11.Text);

            if (check > 0)
            {
                MessageBox.Show("Medicine_id " + textBox11.Text + " Already Exists");
            }
            else
            {
                try
                {
                    if (bam.AddMedicine(int.Parse(textBox11.Text), textBox4.Text, int.Parse(textBox5.Text), comboBox1.Text, comboBox2.Text, int.Parse(textBox6.Text), int.Parse(textBox12.Text), int.Parse(textBox13.Text), int.Parse(textBox14.Text), textBox10.Text, textBox9.Text, float.Parse(textBox7.Text), float.Parse(textBox8.Text)))
                    {
                        MessageBox.Show(" Medicine Added.");
                    }
                    else
                    {
                        MessageBox.Show("Error!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox6.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";

            string id = bam.GetLastMedicId();
            lblMedicNum.Text = id.ToString();
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            if (textBox9.Text == "yyyy/mm/dd")
            {
                textBox9.Text = "";
                textBox9.ForeColor = Color.Black;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                textBox9.Text = "yyyy/mm/dd";
                textBox9.ForeColor = Color.Silver;
            }
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            if (textBox10.Text == "yyyy/mm/dd")
            {
                textBox10.Text = "";
                textBox10.ForeColor = Color.Black;
            }
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            if (textBox10.Text == "")
            {
                textBox10.Text = "yyyy/mm/dd";
                textBox10.ForeColor = Color.Silver;

            }
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            if (textBox7.Text == "00.00")
            {
                textBox7.Text = "";
                textBox7.ForeColor = Color.Black;
            }
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "00.00";
                textBox7.ForeColor = Color.Silver;

            }
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            if (textBox8.Text == "00.00")
            {
                textBox8.Text = "";
                textBox8.ForeColor = Color.Black;
            }
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                textBox8.Text = "00.00";
                textBox8.ForeColor = Color.Silver;

            }
        }
    }
}
