using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShopUI.Data_Access_Layer;

namespace MedicalShopUI.Business_Logic_Layer
{
    public class BusinessAddMedicine
    {
        DataAddMedicine dam = new DataAddMedicine();

        public bool AddMedicine(int medicine_id, string medicine_name, int quantity, string category, string type, int company_id, int lot, int row, int mcolumn, string production_date, string expire_date, float buying_price, float selling_price)
        {
            return dam.Insert(medicine_id, medicine_name, quantity, category, type, company_id, lot, row, mcolumn, production_date, expire_date, buying_price, selling_price);

        }

        public string dt { get; set; }
    
    
        public  DataTable showWGrid()
        {
            return dam.GridUpdate();
        }

        public DataTable GetExpiredWarningMedicines()
        {
            return dam.GetWarningMedicines();
        }

        public DataTable Search(string searchMedicine, bool withId)
        {
            return dam.Search( searchMedicine, withId);
        }


        public DataTable GetMedicine(string id)
        {
            return dam.GetMedicineData(id);
        }

        public bool UpdateMedicine(int medicine_id, int quantity, string category, string type, int company_id, string production_date, string expire_date, float buying_price, float selling_price, int row, int mcolumn, int lot, string medicine_name)
        {
            return dam.Update( medicine_id,quantity,category,type,company_id, production_date, expire_date, buying_price, selling_price, row, mcolumn, lot, medicine_name);
        }
       public bool Delete(int id)
        {
            return dam.Delete(id);
        }

        public string GetLastMedicId()
        {
            return dam.GetLastMedicIdData();
        }

        public int CheckId(string id)
        {
            return dam.CheckIdData(id);
        }
    }
}

