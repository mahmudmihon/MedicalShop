using System;
using System.Data.SqlClient;
using System.Data;

namespace MedicalShopUI.Data_Access_Layer
{
    public class DataLogIn
    {
        public int GetStatusData(string ids, string pass)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM login WHERE user_id='{0}' and password='{1}'", ids, pass);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr=cmd.ExecuteReader();
            

            
            if (dr.HasRows)
            {
                con.Close();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                int status = int.Parse(dt.Rows[0][3].ToString());

                if (status == 1)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            
            }
            else
            {
                return -1;
            }
        }

        public string GetNameData(string userId)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT name FROM staffs WHERE user_id='{0}'", userId);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string id = dt.Rows[0][0].ToString();

            return id;
        }

        public int GetIdStatusData(string ids)
        {
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
                con.Open();
                string query = string.Format("SELECT * FROM login WHERE user_id='{0}'", ids);
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();



                if (dr.HasRows)
                {
                    con.Close();
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int status = int.Parse(dt.Rows[0][3].ToString());

                    if (status == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }

                }
                else
                {
                    return -1;
                }
            }
        }

        public int GetConfirmData(string id, string email)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT email FROM staffs WHERE user_id='{0}'", id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string uEmail = dt.Rows[0][0].ToString();

            if (uEmail == email)
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
