using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace MedicalShopUI.Data_Access_Layer
{
    class DataSale
    {
        public int GetBillNumberData()
        {
            int id;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT TOP 1 bill_no FROM sales ORDER BY bill_no DESC");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                return 0;
            }
            else
            {
                id = int.Parse(dt.Rows[0][0].ToString());

                return id;
            }           
        }

        public DataTable GetMedicineData(string name)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT medicines.medicine_id,medicines.medicine_name,medicines.quantity,medicines.buying_price,medicines.expire_date,medicines.selling_price,medicines.lot,medicines.row,medicines.mcolumn FROM medicines WHERE medicines.medicine_name like '{0}%'", name);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void InsertSaleData(DataTable dt2)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                SqlCommand cmd = new SqlCommand(@"INSERT INTO sales(medicine_name,quantity,price,total,bill_no) VALUES('" + dt2.Rows[i][0].ToString() + "','" + int.Parse(dt2.Rows[i][1].ToString()) + "','" + float.Parse(dt2.Rows[i][2].ToString()) + "','" + float.Parse(dt2.Rows[i][3].ToString()) + "','" + int.Parse(dt2.Rows[i][4].ToString()) + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public int GetAvailableData(string name, int lot)
        {
            int quan;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT quantity FROM medicines WHERE medicine_name='{0}' and lot={1}", name, lot);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            quan = int.Parse(dt.Rows[0][0].ToString());

            return quan;
        }

        public void UpdateData(string name, int lot, int quan)
        {
            int quantity = GetAvailableData(name, lot);
            int newQuantity = quantity - quan;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("UPDATE medicines SET quantity={0} WHERE medicine_name='{1}' and lot={2}", newQuantity, name, lot);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public void UpdateMData(string name, int lot, int quan)
        {
            int quantity = GetAvailableData(name, lot);
            int newQuantity = quantity + quan;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("UPDATE medicines SET quantity={0} WHERE medicine_name='{1}' and lot={2}", newQuantity, name, lot);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public void UpdateUData(string name, int lot, int quan)
        {
            int quantity = GetAvailableData(name, lot);
            int newQuantity = quantity + quan;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("UPDATE medicines SET quantity={0} WHERE medicine_name='{1}' and lot={2}", newQuantity, name, lot);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetAllSaleInfoData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT sales.medicine_name,sales.quantity,sales.price,sales.total,sales.bill_no,bills.net_total,bills.date FROM sales,bills WHERE sales.bill_no=bills.bill_no");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetSaleInfoData(int no)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT sales.medicine_name,sales.quantity,sales.price,sales.total,sales.bill_no,bills.net_total,bills.date FROM sales,bills WHERE sales.bill_no={0} and bills.bill_no={1}", no, no);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void InsertBillData(int bill, float total, string date, float profit)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("INSERT INTO bills(bill_no,net_total,profit,date) VALUES({0},{1},{2},'{3}')", bill, total, profit, date);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }
    }
}
