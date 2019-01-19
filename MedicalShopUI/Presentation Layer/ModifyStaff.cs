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
    public partial class ModifyStaff : Form
    {
        Form ap;
        BusinessStaff bms = new BusinessStaff();

        public ModifyStaff(AdminPanel ap)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmsUserId.Text == "")
                {
                    MessageBox.Show("Please Enter userId");
                }
                else
                {
                    msGridView.DataSource = bms.GetStaff(txtmsUserId.Text, txtmsName.Text);
                    txtmsName.Text = msGridView.Rows[0].Cells[1].Value.ToString();
                    txtmsMobile.Text = msGridView.Rows[0].Cells[2].Value.ToString();
                    txtmsEmail.Text = msGridView.Rows[0].Cells[3].Value.ToString();
                    txtmsAddress.Text = msGridView.Rows[0].Cells[4].Value.ToString();
                    txtJoining.Text = msGridView.Rows[0].Cells[6].Value.ToString();
                    txtmsSalary.Text = msGridView.Rows[0].Cells[5].Value.ToString();

                    int status = int.Parse(msGridView.Rows[0].Cells[8].Value.ToString());

                    if (status == 1)
                    {
                        msCheckAdmin.Checked = true;
                    }
                    else
                    {
                        msCheckAdmin.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid UserId");
            }
        }

        private void ModifyStaff_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();
            msGridView.DataSource = bms.GetAllStaff();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtmsUserId.Text == "")
            {
                MessageBox.Show("Enter UserId First!");
            }
            else
            {
                bms.DeleteStaff(txtmsUserId.Text);
                MessageBox.Show("Staff Removed!");
                msGridView.DataSource = bms.GetAllStaff();
                txtmsUserId.Text = txtmsName.Text = txtmsMobile.Text = txtmsEmail.Text = txtmsAddress.Text = txtmsSalary.Text = txtJoining.Text = string.Empty;
                msCheckAdmin.Checked = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((txtmsUserId.Text == "") || (txtmsSalary.Text == ""))
            {
                MessageBox.Show("Nothing to Update!");
            }
            else
            {
                if (msCheckAdmin.Checked)
                {
                    int status = 1;
                    int admin = 1;
                    bms.UpdateStaff(txtmsUserId.Text, int.Parse(txtmsSalary.Text), status, admin);
                }
                else
                {
                    int status = 0;
                    int admin = 0;
                    bms.UpdateStaff(txtmsUserId.Text, int.Parse(txtmsSalary.Text), status, admin);
                }
            }
        }

        private void msGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmsUserId.Text = msGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtmsName.Text = msGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmsMobile.Text = msGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtmsEmail.Text = msGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtmsAddress.Text = msGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtmsSalary.Text = msGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtJoining.Text = msGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            int check = int.Parse(msGridView.Rows[e.RowIndex].Cells[8].Value.ToString());

            if (check == 1)
            {
                msCheckAdmin.Checked = true;
            }
            else
            {
                msCheckAdmin.Checked = false;
            }
        }
    }
}
