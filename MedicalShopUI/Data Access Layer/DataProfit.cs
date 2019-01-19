using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MedicalShopUI.Data_Access_Layer
{
    class DataProfit
    {
        public DataTable GetProfitData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT bills.bill_no,bills.profit,bills.date FROM bills");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
