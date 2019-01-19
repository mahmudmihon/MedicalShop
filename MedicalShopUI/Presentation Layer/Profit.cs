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

namespace MedicalShopUI.Presentation_Layer
{
    public partial class Profit : Form
    {
        BusinessProfit bp = new BusinessProfit();
        BusinessSaleInfo si = new BusinessSaleInfo();
        string userId;

        public Profit()
        {
            InitializeComponent();
        }

        public Profit(string userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Profit_Load(object sender, EventArgs e)
        {
            profitGridView.DataSource = bp.GetProfit();
        }

        public void CalculateProfit()
        {
            DataGridView dg = new DataGridView();
            dg.DataSource = si.GetAllSaleInfo();
            DataTable data = (DataTable)dg.DataSource;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            LogIn li = new LogIn();
            li.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AdminPanel ap = new AdminPanel(userId);
            ap.Show();
            this.Hide();
        }
    }
}
