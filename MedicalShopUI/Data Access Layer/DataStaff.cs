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
    public class DataStaff
    {
        public bool InsertAsAdmin(string name, string id, string pass, string address, string mobile, string email, int salary)
        {
            int status = 1;
            int access = 1;


            string date = DateTime.Now.ToShortDateString();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query1 = string.Format("INSERT INTO staffs (user_id, name, address, phone, email, joining_date, salary) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6})", id, name, address, mobile, email, date, salary);
            string query2 = string.Format("INSERT INTO login (user_id, password, status, admin_access) VALUES('{0}','{1}',{2},{3})", id, pass, status, access);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            int row1 = -1;
            int row2 = -1;
            row1 = cmd1.ExecuteNonQuery();
            row2 = cmd2.ExecuteNonQuery();
            if ((row1 >= 0) && (row2 >= 0))
            {
                return true;
            }

            return false;
        }

        public bool InsertAsStaff(string name, string id, string pass, string address, string mobile, string email, int salary)
        {
            int status = 2;
            int access = 0;

            string date = DateTime.Now.ToShortDateString();

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query1 = string.Format("INSERT INTO staffs (user_id, name, address, phone, email, joining_date, salary) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6})", id, name, address, mobile, email, date, salary);
            string query2 = string.Format("INSERT INTO login (user_id, password, status, admin_access) VALUES('{0}','{1}',{2},{3})", id, pass, status,access);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);

            int row1 = -1;
            int row2 = -1;
            row1 = cmd1.ExecuteNonQuery();
            row2 = cmd2.ExecuteNonQuery();
            if ((row1 >= 0) && (row2 >=0))
            {
                return true;
            }

            return false;
        }

        public DataTable GetStaffData(string id, string name)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT staffs.user_id,staffs.name,staffs.phone,staffs.email,staffs.address,staffs.salary,staffs.joining_date,login.status,login.admin_access FROM staffs,login WHERE staffs.user_id = '{0}' and login.user_id = '{1}'", id, id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;  
        }

        public DataTable GetAllStaffData()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT staffs.user_id,staffs.name,staffs.phone,staffs.email,staffs.address,staffs.salary,staffs.joining_date,login.status,login.admin_access FROM staffs,login WHERE staffs.user_id=login.user_id");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public string GetLastUserIdData()
        {
            string id;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT TOP 1 user_id FROM staffs ORDER BY user_id DESC");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            id = dt.Rows[0][0].ToString();

            return id;
        }

        public void DeleteStaffData(string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string q1 = string.Format("DELETE FROM staffs where user_id='{0}'", id);
            string q2 = string.Format("DELETE FROM login where user_id='{0}'", id);
            SqlCommand cmd1 = new SqlCommand(q1, con);
            SqlCommand cmd2 = new SqlCommand(q2, con);
            cmd2.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            
        }

        public void UpdateStaffData(string id, int sal, int status, int admin)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query1 = string.Format("UPDATE staffs SET salary={0} WHERE user_id='{1}'", sal, id);
            string query2 = string.Format("UPDATE login SET status={0},admin_access={1} WHERE user_id='{2}'", status, admin, id);
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlCommand cmd2 = new SqlCommand(query2, con);
            cmd1.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
        }

        public void UpdateInfoData(string name, string mobile, string email, string address, string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("UPDATE staffs SET name='{0}',email='{1}',phone='{2}',address='{3}' WHERE user_id='{4}'", name, email, mobile, address, id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public DataTable GetPersonData(string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT staffs.name,staffs.phone,staffs.email,staffs.address FROM staffs WHERE staffs.user_id = '{0}'", id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public void UpdatePassData(string pass, string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("UPDATE login SET password='{0}' WHERE user_id='{1}'", pass, id);
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
        }

        public int GetUserIdData(string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM staffs where user_id = '{0}'", id);
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
    }
}
