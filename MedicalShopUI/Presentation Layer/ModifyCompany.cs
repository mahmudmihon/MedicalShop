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
    public partial class ModifyCompany : Form
    {
        Form ap;
        BusinessAddCompany bac = new BusinessAddCompany();

        public ModifyCompany(AdminPanel ap)
        {
            InitializeComponent();
            dataGridView1.DataSource = bac.showWholeGrid();
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
            if (textBox1.Text == "")
                return;

            string id = textBox1.Text;
            if (bac.DeleteCompany(id))
            {
                MessageBox.Show("Company Succesfully deleted");
                dataGridView1.DataSource = bac.showWholeGrid();
            }
            else
                MessageBox.Show("Failed to delete compnay");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ModifyCompany_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            string searchText;
            if (textBox4.Text == "" && textBox1.Text == "")
                MessageBox.Show("Fill up either ID or company name");
            else if (textBox4.Text == "")
            {
                searchText = textBox1.Text;
                dataGridView1.DataSource = bac.showSearchGrid(searchText, true);
            }
            else
            {
                searchText = textBox4.Text;
                dataGridView1.DataSource = bac.showSearchGrid(searchText, false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (bac.UpdateCompany(textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox4.Text))
            {
                dataGridView1.DataSource = bac.showWholeGrid();
                MessageBox.Show("Successfully Company updated");
            }
            else
            {
                MessageBox.Show("Error in updating");
            }

            textBox6.Text = textBox7.Text = textBox8.Text = textBox9.Text = textBox4.Text = string.Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }
    }
}
