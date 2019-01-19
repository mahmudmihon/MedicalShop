using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MedicalShopUI.Data_Access_Layer
{
    public class DataAddCompany
    {
        SqlConnection con;
        public DataAddCompany()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public bool InsertCompany(string name, string contactperson, string email, int id, string address, string mobile)
        {
            DateTime dt = DateTime.Now;
            DateTime date = dt.Date;

            string query = string.Format("INSERT INTO companys(company_id,company_name,contact_person,mobile,email,address, entry_date) VALUES({0},'{1}','{2}','{3}','{4}','{5}','{6}')", id, name, contactperson, mobile, email, address, date);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }

            return false;
        }

        public DataTable GridUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM companys");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable SearchGrid(string searchText, bool withId)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query;
            if (!withId)
                query = string.Format("SELECT * FROM companys where lower(company_name) like '%{0}%'", searchText.ToLower());
            else
                query = string.Format("SELECT * FROM companys where company_id='{0}'", searchText);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable SearchIDGrid(string searchText)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM companys where company_name ilike '%{0}%'", searchText);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public bool Update(string contact_person, string email, string address, string mobile, string name)
        {
            string query = string.Format("UPDATE companys SET contact_person='{0}',email='{1}',address='{2}',mobile='{3}' WHERE company_name='{4}' ", contact_person, email, address, mobile, name);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public bool Delete(string id)
        {
            string query = string.Format("DELETE FROM companys WHERE company_id='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public int GetCompanyIdData(string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM companys where company_id = '{0}'", id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public string GetLastCompanyIdData()
        {
            string id;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT TOP 1 company_id FROM companys ORDER BY company_id DESC");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            id = dt.Rows[0][0].ToString();

            return id;
        }
    }
}
