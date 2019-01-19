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
    class BusinessSale
    {
        DataSale ds = new DataSale();

        public int GetBillNumber()
        {
            return ds.GetBillNumberData();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string BuyingPrice { get; set; }
        public string ExpireDate { get; set; }
        public string SellingPrice { get; set; }
        public string Lot { get; set; }
        public string Row { get; set; }
        public string Column { get; set; }

        BusinessSale sale;

        public List<BusinessSale> GetMedicine(string name)
        {
            var medicine = ds.GetMedicineData(name);
            List<BusinessSale> list = new List<BusinessSale>();

            for (int i = 0; i < medicine.Rows.Count; i++)
            {
                sale = new BusinessSale();

                sale.Id = medicine.Rows[i][0].ToString();
                sale.Name = medicine.Rows[i][1].ToString();
                sale.Quantity = medicine.Rows[i][2].ToString();
                sale.BuyingPrice = medicine.Rows[i][3].ToString();
                sale.ExpireDate = medicine.Rows[i][4].ToString();
                sale.SellingPrice = medicine.Rows[i][5].ToString();
                sale.Lot = medicine.Rows[i][6].ToString();
                sale.Row = medicine.Rows[i][7].ToString();
                sale.Column = medicine.Rows[i][8].ToString();

                list.Add(sale);
            }

            return list;
        }

        public void InsertSale(DataTable dt2)
        {
            ds.InsertSaleData(dt2);
        }

        public int GetAvailable(string name, int lot)
        {
            return ds.GetAvailableData(name, lot);
        }

        public void Update(string name, int lot, int quan)
        {
            ds.UpdateData(name, lot, quan);
        }

        public void UpdateM(string name, int lot, int quan)
        {
            ds.UpdateMData(name, lot, quan);
        }

        public void UpdateU(string name, int lot, int quan)
        {
            ds.UpdateUData(name, lot, quan);
        }

        public void InsertBill(int bill, float total, string date, float profit)
        {
            ds.InsertBillData(bill, total, date, profit);
        }
    }
}
