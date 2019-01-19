using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MedicalShopUI.Data_Access_Layer
{
    class DataAddMedicine
    {
        public bool Insert(int medicine_id, string medicine_name, int quantity, string category, string type, int company_id, int lot, int row, int mcolumn, string production_date, string expire_date, float buying_price, float selling_price)
        {

            DateTime dt = DateTime.Now;
            DateTime date = dt.Date;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query1 = string.Format("INSERT INTO medicines (medicine_id,medicine_name, quantity, category, type,entry_date, company_id, lot, row, mcolumn, production_date, expire_date,buying_price,selling_price) VALUES({0},'{1}',{2},'{3}','{4}','{5}',{6},{7},{8},{9},'{10}','{11}',{12},{13})", medicine_id, medicine_name, quantity, category, type,date, company_id, lot, row, mcolumn, production_date, expire_date, buying_price, selling_price);

            SqlCommand cmd1 = new SqlCommand(query1, con);



            int row1 = -1;

            row1 = cmd1.ExecuteNonQuery();

            if ((row1 >= 0))
            {
                return true;
            }

            return false;
        }

        public DataTable GetWarningMedicines()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT medicine_id, medicine_name, expire_date, row, mcolumn, lot FROM medicines WHERE DATEDIFF(day, (CAST(GETDATE() AS DATE)), expire_date) <= 10");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GridUpdate()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM medicines");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetMedicineData(string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM medicines WHERE medicine_name like '{0}%'", id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable Search(string searchMedicine, bool withId)
        {

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query;
            if (!withId)
                query = string.Format("SELECT * FROM medicines where lower(medicine_name) like '%{0}%'", searchMedicine.ToLower());
            else
                query = string.Format("SELECT * FROM medicines where medicine_id='{0}'", searchMedicine);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
       

        public bool Update(int medicine_id, int quantity,string category,string type,int company_id, string production_date, string expire_date, float buying_price, float selling_price, int row, int mcolumn, int lot, string medicine_name)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();

            string expire = GetExpireDate(medicine_id);
            DateTime dt = DateTime.Now;
            DateTime date = dt.Date;

            if (expire == expire_date)
            {
                string query = string.Format("UPDATE medicines SET  medicine_id={0}, quantity={1},category='{2}',type='{3}',company_id={4},entry_date='{5}',production_date='{6}',expire_date='{7}',buying_price={8},selling_price={9},row={10},mcolumn={11},lot={12} WHERE medicine_name='{13}' ", medicine_id, quantity, category, type, company_id, date, production_date, expire_date, buying_price, selling_price, row, mcolumn, lot, medicine_name);
                SqlCommand cmd = new SqlCommand(query, con);
                int rows = -1;
                rows = cmd.ExecuteNonQuery();
                if (rows >= 0)
                {
                    return true;
                }
                return false;
            }
            else
            {
                int nlot = lot + 1;
                string query1 = string.Format("INSERT INTO medicines (medicine_id,medicine_name, quantity, category, type,entry_date, company_id, lot, row, mcolumn, production_date, expire_date,buying_price,selling_price) VALUES({0},'{1}',{2},'{3}','{4}','{5}',{6},{7},{8},{9},'{10}','{11}',{12},{13})", medicine_id, medicine_name, quantity, category, type, date, company_id, nlot, row, mcolumn, production_date, expire_date, buying_price, selling_price);

                SqlCommand cmd1 = new SqlCommand(query1, con);



                int row1 = -1;

                row1 = cmd1.ExecuteNonQuery();

                if ((row1 >= 0))
                {
                    return true;
                }

                return false;
            }
            
        }

        public string GetExpireDate(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT expire_date FROM medicines WHERE medicine_id={0}", id);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            string date = dt.Rows[0][0].ToString();

            return date;
        }

        public bool Delete(int id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("DELETE FROM medicines WHERE  id={0} ", id);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public string GetLastMedicIdData()
        {
            string id;

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT TOP 1 medicine_id FROM medicines ORDER BY medicine_id DESC");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            id = dt.Rows[0][0].ToString();

            return id;
        }

        public int CheckIdData(string id)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-TD8UJR4\SQLEXPRESS;Initial Catalog=MedicalShop;Integrated Security=True");
            con.Open();
            string query = string.Format("SELECT * FROM medicines where medicine_id = '{0}'", id);
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
