using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalShopUI.Data_Access_Layer;

namespace MedicalShopUI.Business_Logic_Layer
{
    public class BusinessSaleInfo
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public string Bill { get; set; }
        public string Net_Total { get; set; }
        public string Date { get; set; }

        DataSale ds = new DataSale();
        BusinessSaleInfo si;

        public List<BusinessSaleInfo> GetAllSaleInfo()
        {
            var bills = ds.GetAllSaleInfoData();
            List<BusinessSaleInfo> fullList = new List<BusinessSaleInfo>();

            for (int i = 0; i < bills.Rows.Count; i++)
            {
                si = new BusinessSaleInfo();

                si.Name = bills.Rows[i][0].ToString();
                si.Quantity = bills.Rows[i][1].ToString();
                si.Price = bills.Rows[i][2].ToString();
                si.Total = bills.Rows[i][3].ToString();
                si.Bill = bills.Rows[i][4].ToString();
                si.Net_Total = bills.Rows[i][5].ToString();
                si.Date = bills.Rows[i][6].ToString();

                fullList.Add(si);
            }

            return fullList;
        }

        public List<BusinessSaleInfo> GetSaleInfo(int no)
        {
            var bills = ds.GetSaleInfoData(no);
            List<BusinessSaleInfo> fullList = new List<BusinessSaleInfo>();

            for (int i = 0; i < bills.Rows.Count; i++)
            {
                si = new BusinessSaleInfo();

                si.Name = bills.Rows[i][0].ToString();
                si.Quantity = bills.Rows[i][1].ToString();
                si.Price = bills.Rows[i][2].ToString();
                si.Total = bills.Rows[i][3].ToString();
                si.Bill = bills.Rows[i][4].ToString();
                si.Net_Total = bills.Rows[i][5].ToString();
                si.Date = bills.Rows[i][6].ToString();

                fullList.Add(si);
            }

            return fullList;
        }
    }
}
