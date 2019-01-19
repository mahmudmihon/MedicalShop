using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShopUI.Data_Access_Layer;

namespace MedicalShopUI.Business_Logic_Layer
{
    public class LogInProcess
    {
        DataLogIn li = new DataLogIn();

        public int GetStatus(string id, string pass)
        {
            return li.GetStatusData(id, pass);
        }

        public string GetName(string userId)
        {
            return li.GetNameData(userId);
        }

        public int GetIdStatus(string id)
        {
            return li.GetIdStatusData(id);
        }

        public int GetConfirm(string id, string email)
        {
            return li.GetConfirmData(id, email);
        }
    }
}
