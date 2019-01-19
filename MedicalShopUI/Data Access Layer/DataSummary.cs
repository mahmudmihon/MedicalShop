using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalShopUI.Data_Access_Layer
{
    public class DataSummary
    {
        public static DataTable GetCategoryCount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT category, COUNT(*) AS cat_count FROM medicines GROUP BY category ORDER BY category ASC");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable GetCompanyCount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("select c.company_name as c_name, count(*) as c_count from companys c, medicines m where c.company_id=m.company_id group by c.company_name order by c.company_name");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }



        public static DataTable GetsaleCount()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("select m.category as category, count(*) as m_count from medicines m, sales s where s.medicine_name=m.medicine_name group by m.category order by m.category");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
