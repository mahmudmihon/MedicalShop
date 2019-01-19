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
using MedicalShopUI.Data_Access_Layer;
using MedicalShopUI.Business_Logic_Layer;


namespace MedicalShopUI
{
    public partial class StockModify : Form
    {
        string ap;
        BusinessAddMedicine bam = new BusinessAddMedicine();

        public StockModify(string ap)
        {
            InitializeComponent();
            this.ap = ap;
            dataGridView1.DataSource = bam.showWGrid();
        }
        void GridUpdate()
        {
            dataGridView1.DataSource = bam.showWGrid(); ;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminPanel ap2 = new AdminPanel(ap);
            ap2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
                MessageBox.Show("Fill up  medicine name");
            else
            {
                try
                {
                    dataGridView1.DataSource = bam.GetMedicine(textBox16.Text);

                    textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    textBox15.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                    textBox4.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                    comboBox2.Text = dataGridView1.Rows[0].Cells[6].Value.ToString();
                    comboBox1.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
                    textBox5.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
                    textBox10.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();

                    textBox7.Text = dataGridView1.Rows[0].Cells[10].Value.ToString();
                    textBox8.Text = dataGridView1.Rows[0].Cells[11].Value.ToString();
                    textBox9.Text = dataGridView1.Rows[0].Cells[9].Value.ToString();
                    textBox13.Text = dataGridView1.Rows[0].Cells[13].Value.ToString();
                    textBox14.Text = dataGridView1.Rows[0].Cells[12].Value.ToString();
                    textBox12.Text = dataGridView1.Rows[0].Cells[14].Value.ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Medicine name");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void StockModify_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (bam.UpdateMedicine(int.Parse(textBox15.Text), int.Parse(textBox5.Text), comboBox1.Text, comboBox2.Text, int.Parse(textBox2.Text), textBox10.Text, textBox9.Text, float.Parse(textBox7.Text), float.Parse(textBox8.Text), int.Parse(textBox13.Text), int.Parse(textBox12.Text), int.Parse(textBox14.Text), textBox16.Text))
            {
                GridUpdate();
                MessageBox.Show("Successfully Medicine updated");
            }
            else
            {
                MessageBox.Show("Error in updating");
            }

            textBox1.Text = textBox4.Text = textBox5.Text = textBox7.Text = comboBox1.Text = comboBox2.Text = textBox2.Text = textBox8.Text = textBox9.Text = textBox10.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = textBox16.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
                return;

            int id = int.Parse(textBox1.Text);

            if (bam.Delete(id))
            {
                MessageBox.Show("Medicine Succesfully Deleted");
                dataGridView1.DataSource = bam.showWGrid();
            }
            else
                MessageBox.Show("Failed to delete medicine");

            textBox1.Text = textBox4.Text = textBox5.Text = textBox7.Text = textBox8.Text = comboBox1.Text = comboBox2.Text = textBox2.Text = textBox9.Text = textBox10.Text = textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = textBox16.Text = string.Empty;
        }
        public string medicine_name { get; set; }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox16.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox15.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            textBox14.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
            textBox13.Text = dataGridView1.Rows[e.RowIndex].Cells[13].Value.ToString();
            textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            textBox12.Text = dataGridView1.Rows[e.RowIndex].Cells[14].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
