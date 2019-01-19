using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalShopUI.Data_Access_Layer;

namespace MedicalShopUI.Business_Logic_Layer
{
    class BusinessProfit
    {
        DataProfit dp = new DataProfit();

        public DataTable GetProfit()
        {
            return dp.GetProfitData();
        }
    }
}
