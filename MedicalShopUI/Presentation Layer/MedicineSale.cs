using MedicalShopUI.Presentation_Layer;
using MedicalShopUI.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;


namespace MedicalShopUI
{
    public partial class MedicineSale : Form
    {
        string userId;
        LogInProcess lp = new LogInProcess();
        BusinessSale bs = new BusinessSale();
        int nQuantity;
        double buying;
        double dtotal;

        DataTable ddt = new DataTable();
        DataRow dr;
        int indexRow;

        public MedicineSale()
        {
            InitializeComponent();
        }

        public MedicineSale(string userId)
        {
            InitializeComponent();
            this.userId = userId;
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

        private void button5_Click(object sender, EventArgs e)
        {
            SearchMedicine sm = new SearchMedicine();
            sm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                float profit = (float.Parse(txtNetTotal.Text)) - (float.Parse(txtOP.Text));

                bs.InsertBill(int.Parse(txtBill.Text), float.Parse(txtNetTotal.Text), txtDate.Text, profit);

                PdfDocument doc = new PdfDocument();
                PdfPage page = doc.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Century Gothic", 30, XFontStyle.Bold);

                gfx.DrawString("ATZ Pharmacy", font, XBrushes.Black, new XRect(290, 30, 10, 5), XStringFormats.Center);
                gfx.DrawString("Bill No: ", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(210, 60, 10, 5), XStringFormats.Center);
                gfx.DrawString(txtBill.Text, new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(240, 60, 10, 5), XStringFormats.Center);
                gfx.DrawString("Date: ", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(300, 60, 10, 5), XStringFormats.Center);
                gfx.DrawString(txtDate.Text, new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(360, 60, 10, 5), XStringFormats.Center);
                gfx.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(0, 80, 300, 5), XStringFormats.Center);
                gfx.DrawString("Customer Name:", new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(170, 120, 10, 5), XStringFormats.Center);
                gfx.DrawString("Discount(%):", new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(182, 140, 10, 5), XStringFormats.Center);
                gfx.DrawString(txtDiscount.Text, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.DarkRed, new XRect(450, 140, 10, 5), XStringFormats.Center);
                gfx.DrawString("Total:", new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(203, 160, 10, 5), XStringFormats.Center);
                gfx.DrawString(txtNetTotal.Text, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.DarkRed, new XRect(450, 160, 10, 5), XStringFormats.Center);
                gfx.DrawString("Paid:", new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(203, 180, 10, 5), XStringFormats.Center);
                gfx.DrawString(txtPaid.Text, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.DarkRed, new XRect(450, 180, 10, 5), XStringFormats.Center);
                gfx.DrawString("---------------------------------------------------------------", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(300, 195, 10, 5), XStringFormats.Center);
                gfx.DrawString("Return:", new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(198, 210, 10, 5), XStringFormats.Center);
                gfx.DrawString(txtReturn.Text, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.DarkRed, new XRect(450, 210, 10, 5), XStringFormats.Center);
                gfx.DrawString("Medicine List", new XFont("Century Gothic", 20, XFontStyle.Bold), XBrushes.Black, new XRect(305, 260, 10, 5), XStringFormats.Center);
                gfx.DrawString("Medicine Name", new XFont("Century Gothic", 16, XFontStyle.Bold), XBrushes.Red, new XRect(130, 300, 10, 5), XStringFormats.Center);
                gfx.DrawString("Quantity", new XFont("Century Gothic", 16, XFontStyle.Bold), XBrushes.Red, new XRect(280, 300, 10, 5), XStringFormats.Center);
                gfx.DrawString("Price", new XFont("Century Gothic", 16, XFontStyle.Bold), XBrushes.Red, new XRect(390, 300, 10, 5), XStringFormats.Center);
                gfx.DrawString("Total", new XFont("Century Gothic", 16, XFontStyle.Bold), XBrushes.Red, new XRect(490, 300, 10, 5), XStringFormats.Center);
                gfx.DrawString("-----------------------", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(127, 310, 10, 5), XStringFormats.Center);
                gfx.DrawString("------------", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(280, 310, 10, 5), XStringFormats.Center);
                gfx.DrawString("-----------", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(390, 310, 10, 5), XStringFormats.Center);
                gfx.DrawString("---------", new XFont("Century Gothic", 15, XFontStyle.Bold), XBrushes.Black, new XRect(490, 310, 10, 5), XStringFormats.Center);

                DataTable dt3 = new DataTable();
                dt3 = (DataTable)saleGridView.DataSource;

                int npoint = 0;
                string name = null;
                string quantity = null;
                string price = null;
                string total = null;

                npoint = npoint + 330;

                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    name = dt3.Rows[i][0].ToString();
                    quantity = dt3.Rows[i][1].ToString();
                    price = dt3.Rows[i][2].ToString();
                    total = dt3.Rows[i][3].ToString();

                    gfx.DrawString(name, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(115, npoint, 10, 5), XStringFormats.Center);

                    gfx.DrawString(quantity, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(280, npoint, 10, 5), XStringFormats.Center);

                    gfx.DrawString(price, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(390, npoint, 10, 5), XStringFormats.Center);

                    gfx.DrawString(total, new XFont("Century Gothic", 12, XFontStyle.Bold), XBrushes.Black, new XRect(490, npoint, 10, 5), XStringFormats.Center);

                    npoint = npoint + 20;
                }

                txtBill.Text = txtDiscount.Text = txtNetTotal.Text = txtPaid.Text = txtReturn.Text = string.Empty;
                saleGridView.DataSource = null;
                saleGridView.Rows.Clear();


                string filename = "G:/Bill.pdf";
                doc.Save(filename);

                Process.Start(filename);
            }
            catch (Exception)
            {
                MessageBox.Show("Operation Failed! Please Check Every Field Properly!");
            }
        }

        private void MedicineSale_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            DateTime dt = DateTime.Now;
            DateTime dateOnly = dt.Date;

            lblDate.Text = dateOnly.ToString();

            txtDate.Text = DateTime.Now.ToShortDateString();

            int bill = bs.GetBillNumber() + 1;
            txtBill.Text = bill.ToString();

            ddt.Columns.Add("Name");
            ddt.Columns.Add("Quantity");
            ddt.Columns.Add("Price");
            ddt.Columns.Add("Total");
            ddt.Columns.Add("Bill No.");
            ddt.Columns.Add("O");

        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new MethodInvoker(delegate()
            {
                lblClock.Text = DateTime.Now.ToString("T");
            }));
        }

        private void searchMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMedicineName.Text = searchMedicine.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = searchMedicine.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtLot.Text = searchMedicine.Rows[e.RowIndex].Cells[6].Value.ToString();
            buying = double.Parse(searchMedicine.Rows[e.RowIndex].Cells[3].Value.ToString());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMedicineName.Text == "")
                {
                    MessageBox.Show("Enter Medicine Name");
                }
                else
                {
                    searchMedicine.DataSource = bs.GetMedicine(txtMedicineName.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Not Available!");
            }
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            double price, quantity, total;
            int available;

            try
            {
                available = bs.GetAvailable(txtMedicineName.Text, int.Parse(txtLot.Text));

                if (int.Parse(txtQuantity.Text) > available)
                {
                    MessageBox.Show("Quantity Not Available");
                }
                else if ((txtQuantity.Text == "") || (int.Parse(txtQuantity.Text) == 0) || (int.Parse(txtQuantity.Text) < 0))
                {
                    MessageBox.Show("Enter Valid Amount");
                }
                else
                {
                    if (txtQuantity.Text != "")
                    {
                        quantity = Convert.ToDouble(txtQuantity.Text);
                    }
                    else
                    {
                        quantity = 0.0;
                    }

                    if (txtPrice.Text != "")
                    {
                        price = Convert.ToDouble(txtPrice.Text);
                    }
                    else
                    {
                        price = 0.0;
                    }

                    total = quantity * price;
                    txtTotal.Text = total.ToString();
                    double btotal = quantity * buying;
                    txtOrginal.Text = btotal.ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Medicine Name or Lot Number is Invalid");
            }
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            double price, quantity, total;

            if (txtPrice.Text != "")
            {
                price = Convert.ToDouble(txtPrice.Text);
            }
            else
            {
                price = 0.0;
            }

            if (txtQuantity.Text != "")
            {
                quantity = Convert.ToDouble(txtQuantity.Text);
            }
            else
            {
                quantity = 0.0;
            }

            total = quantity * price;
            txtTotal.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((txtMedicineName.Text == "") || (txtQuantity.Text == "") || (txtPrice.Text == "") || (txtLot.Text == ""))
            {
                MessageBox.Show("Fill all the field's!");
            }

            else
            {
                dr = ddt.NewRow();
                dr["Name"] = txtMedicineName.Text;
                dr["Quantity"] = txtQuantity.Text;
                dr["Price"] = txtPrice.Text;
                dr["Total"] = txtTotal.Text;
                dr["Bill No."] = txtBill.Text;
                dr["O"] = txtOrginal.Text;
                ddt.Rows.Add(dr);
                saleGridView.DataSource = ddt;
                bs.Update(txtMedicineName.Text, int.Parse(txtLot.Text), int.Parse(txtQuantity.Text));
                txtOrginal.Text = "";
                Clear();
            }
        }
        public void Clear()
        {
            txtMedicineName.Text = txtQuantity.Text = txtPrice.Text = txtTotal.Text = txtLot.Text = string.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if ((txtLot.Text == "") || (txtMedicineName.Text == "") || (txtQuantity.Text == "") || (txtPrice.Text == ""))
            {
                MessageBox.Show("Fill all the field's!");
            }
            else
            {
                try
                {
                    int rowIndex = saleGridView.CurrentCell.RowIndex;
                    bs.UpdateM(txtMedicineName.Text, int.Parse(txtLot.Text), int.Parse(txtQuantity.Text));
                    saleGridView.Rows.RemoveAt(rowIndex);
                    txtOrginal.Text = "";
                    Clear();                   
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Lot");
                }
            }
        }

        private void saleGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            nQuantity = int.Parse(saleGridView.Rows[e.RowIndex].Cells[1].Value.ToString());

            txtMedicineName.Text = saleGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtQuantity.Text = saleGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtPrice.Text = saleGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtTotal.Text = saleGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if ((txtLot.Text == "") || (txtMedicineName.Text == "") || (txtQuantity.Text == "") || (txtPrice.Text == ""))
            {
                MessageBox.Show("Fill all the field's!");
            }
            else
            {
                try
                {
                    int newQuan, txtQuan;

                    txtQuan = int.Parse(txtQuantity.Text);

                    newQuan = nQuantity - txtQuan;

                    DataGridViewRow newDataRow = saleGridView.Rows[indexRow];

                    newDataRow.Cells[0].Value = txtMedicineName.Text;
                    newDataRow.Cells[1].Value = txtQuantity.Text;
                    newDataRow.Cells[2].Value = txtPrice.Text;
                    newDataRow.Cells[3].Value = txtTotal.Text;
                    newDataRow.Cells[5].Value = txtOrginal.Text;

                    bs.UpdateU(txtMedicineName.Text, int.Parse(txtLot.Text), newQuan);
                    txtOrginal.Text = "";
                    Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Lot");
                }
            }          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = (DataTable)saleGridView.DataSource;

            bs.InsertSale(dt2);

            double sum = 0.0, osum = 0.0;
            for (int i = 0; i < saleGridView.Rows.Count; i++)
            {
                sum = sum + double.Parse(saleGridView.Rows[i].Cells[3].Value.ToString());
                osum = osum + double.Parse(saleGridView.Rows[i].Cells[5].Value.ToString());
            }

            dtotal = sum;
            txtNetTotal.Text = sum.ToString();
            txtOP.Text = osum.ToString();

            searchMedicine.DataSource = null;
            searchMedicine.Rows.Clear();
        }

        

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int bill = bs.GetBillNumber() + 1;
            txtBill.Text = bill.ToString();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            try
            {
                double paid = double.Parse(txtPaid.Text);
                double total = double.Parse(txtNetTotal.Text);

                if (paid == total)
                {
                    txtReturn.Text = "0.00";
                }
                else if (paid > total)
                {
                    txtReturn.Text = (paid - total).ToString();
                }
                else if (total > paid)
                {
                    MessageBox.Show("Insufficient Amount");
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int.Parse(txtDiscount.Text) == 0) || (txtDiscount.Text == null))
                {
                    txtNetTotal.Text = dtotal.ToString();
                }
                else
                {
                    double dis = (double.Parse(txtDiscount.Text) / 100);
                    double total = double.Parse(txtNetTotal.Text);
                    double discount = total - (total * dis);

                    txtNetTotal.Text = discount.ToString();
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
