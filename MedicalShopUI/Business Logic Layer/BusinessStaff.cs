using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using MedicalShopUI.Data_Access_Layer;

namespace MedicalShopUI.Business_Logic_Layer
{
    public class BusinessStaff
    {
        DataStaff daf = new DataStaff();

        public string UserId { get; set; }
        public string Name { get; set; }       
        public string Mobile { get; set; }       
        public string Email { get; set; }       
        public string Address { get; set; }        
        public int Salary { get; set; }       
        public string JoiningDate { get; set; }
        public int Status { get; set; }
        public int AdminAccess { get; set; }
       
        BusinessStaff baf, baf2;

        public List<BusinessStaff> GetStaff(string id, string name)
        {
            var staff = daf.GetStaffData(id, name);
            List<BusinessStaff> list = new List<BusinessStaff>();

            baf = new BusinessStaff();

            baf.UserId = staff.Rows[0][0].ToString();
            baf.Name = staff.Rows[0][1].ToString();
            baf.Mobile = staff.Rows[0][2].ToString();
            baf.Email = staff.Rows[0][3].ToString();
            baf.Address = staff.Rows[0][4].ToString();
            baf.Salary = int.Parse(staff.Rows[0][5].ToString());
            baf.JoiningDate = staff.Rows[0][6].ToString();
            baf.Status = int.Parse(staff.Rows[0][7].ToString());
            baf.AdminAccess = int.Parse(staff.Rows[0][8].ToString());

            list.Add(baf);

            return list;
        }

        public List<BusinessStaff> GetAllStaff()
        {
            var staffs = daf.GetAllStaffData();
            List<BusinessStaff> fullList = new List<BusinessStaff>();

            for (int i = 0; i < staffs.Rows.Count; i++)
            {
                baf2 = new BusinessStaff();

                baf2.UserId = staffs.Rows[i][0].ToString();
                baf2.Name = staffs.Rows[i][1].ToString();
                baf2.Mobile = staffs.Rows[i][2].ToString();
                baf2.Email = staffs.Rows[i][3].ToString();
                baf2.Address = staffs.Rows[i][4].ToString();
                baf2.Salary = int.Parse(staffs.Rows[i][5].ToString());
                baf2.JoiningDate = staffs.Rows[i][6].ToString();
                baf2.Status = int.Parse(staffs.Rows[i][7].ToString());
                baf2.AdminAccess = int.Parse(staffs.Rows[i][8].ToString());

                fullList.Add(baf2);
            }

            return fullList;
        }

        public bool CreateAsAdmin(string name, string id, string pass, string address, string mobile, string email, int salary)
        {
            return daf.InsertAsAdmin(name, id, pass, address, mobile, email, salary);
        }

        public bool CreateAsSalesman(string name, string id, string pass, string address, string mobile, string email, int salary)
        {
            return daf.InsertAsStaff(name, id, pass, address, mobile, email, salary);
        }

        public string GetLastUserId()
        {
            return daf.GetLastUserIdData();
        }

        public void DeleteStaff(string id)
        {
            daf.DeleteStaffData(id);
        }

        public void UpdateStaff(string id, int sal, int status, int admin)
        {
            daf.UpdateStaffData(id, sal, status, admin);
        }

        public void UpdateInfo(string name, string mobile, string email, string address, string id)
        {
            daf.UpdateInfoData(name, mobile, email, address, id);
        }

        public DataTable GetPerson(string id)
        {
            return daf.GetPersonData(id);
        }

        public void UpdatePass(string pass, string id)
        {
            daf.UpdatePassData(pass, id);
        }

        public int GetUserId(string id)
        {
            return daf.GetUserIdData(id);
        }
    }
}
