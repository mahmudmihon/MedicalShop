using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShopUI.Data_Access_Layer;

namespace MedicalShopUI.Business_Logic_Layer
{
    public class BusinessAddCompany
    {
        DataAddCompany dac = new DataAddCompany();
        public bool CreateCompany(string name, string contactperson, string email, int id, string address, string mobile)
        {
            return dac.InsertCompany(name, contactperson, email, id, address, mobile);
        }
        public DataTable showWholeGrid()
        {
            return dac.GridUpdate();
        }
        public DataTable showSearchGrid(string searchText, bool withId)
        {
            return dac.SearchGrid(searchText, withId);
        }
        public bool UpdateCompany(string contact_person, string email, string address, string mobile, string name)
        {
            return dac.Update(contact_person, email, address, mobile, name);
        }
        public bool DeleteCompany(string id)
        {
            return dac.Delete(id);
        }

        public int GetCompanyId(string id)
        {
            return dac.GetCompanyIdData(id);
        }

        public string GetLastCompanyId()
        {
            return dac.GetLastCompanyIdData();
        }
    }
}
