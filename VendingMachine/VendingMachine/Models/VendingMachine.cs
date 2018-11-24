using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace VendingMachine.Models
{
    public class VendingMachine
    {
        public double _totalcash;
        public double _totalcredit;
        public double _totalsoldcans;
        public double _totalcans;

        public DataTable canCollectiontable;


        /// <summary>
        /// initialize all values
        /// </summary>
        public VendingMachine()
        {
            Initialization();
            Reset();
        }
        /// <summary>
        /// Reset vending machine
        /// </summary>
        public void Reset()
        {
            _totalcash = 0;
            _totalcans = GetTotalCans();
            _totalcredit = 0;
            _totalsoldcans = 0;
        }
        /// <summary>
        /// Vend
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isCash"></param>
        public void Vend(string name, bool isCash)
        {
            for (int i = 0; i < canCollectiontable.Rows.Count; i++)
            {
                if (canCollectiontable.Rows[i][0].Equals(name))
                {
                    if (isCash)
                        _totalcash += Convert.ToDouble(canCollectiontable.Rows[i][1].ToString());
                    else
                        _totalcredit += Convert.ToDouble(canCollectiontable.Rows[i][1].ToString());

                    canCollectiontable.Rows[i][0] = Convert.ToInt32(canCollectiontable.Rows[i][2].ToString()) - 1;
                    _totalcans--;
                    return;
                }
            }
        }
        /// <summary>
        /// Add new flavors of cans
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="amount"></param>
        public void AddNewCan(string name, double value, int amount)
        {

            if (canCollectiontable.Rows.Count == 10)
                throw new Exception("Cannot add more flavors");

            DataRow dr = canCollectiontable.NewRow();
            dr[0] = name;
            dr[1] = value;
            dr[2] = amount;

            canCollectiontable.Rows.Add(dr);
            _totalcans += amount;
        }

        /// <summary>
        /// Re stock cans
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public bool Restock(string name, int amount)
        {
            for (int i = 0; i < canCollectiontable.Rows.Count; i++)
            {
                if (canCollectiontable.Rows[i][0].ToString().Equals(name))
                {
                    canCollectiontable.Rows[i][2] = amount;
                    _totalcans = GetTotalCans();
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Add default stock of cans
        /// </summary>
        private void Initialization()
        {
            //by design, all can's details are stored in a data table with 3 columns
            // column 1: name
            // column 2: value
            // column 3: amount
            // for deomo assume that all can's names are unique name
            canCollectiontable = new DataTable();
            canCollectiontable.Columns.Add("name");
            canCollectiontable.Columns.Add("value");
            canCollectiontable.Columns.Add("amount");

            //add 5 different cans for starting
            DataRow dr1 = canCollectiontable.NewRow();
            dr1[0] = "Coke";
            dr1[1] = "1.2";
            dr1[2] = 20;
            canCollectiontable.Rows.Add(dr1);

            DataRow dr2 = canCollectiontable.NewRow();
            dr2[0] = "Sprite";
            dr2[1] = "1.2";
            dr2[2] = 20;
            canCollectiontable.Rows.Add(dr2);

            DataRow dr3 = canCollectiontable.NewRow();
            dr3[0] = "Fanta";
            dr3[1] = "1.2";
            dr3[2] = 20;
            canCollectiontable.Rows.Add(dr3);

            DataRow dr4 = canCollectiontable.NewRow();
            dr4[0] = "Pepsi";
            dr4[1] = "1.1";
            dr4[2] = 20;
            canCollectiontable.Rows.Add(dr4);

            DataRow dr5 = canCollectiontable.NewRow();
            dr5[0] = "7up";
            dr5[1] = "1.1";
            dr5[2] = 20;
            canCollectiontable.Rows.Add(dr5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetTotalCans()
        {
            int total = 0;

            for (int i = 0; i < canCollectiontable.Rows.Count; i++)
            {
                total += Convert.ToInt32(canCollectiontable.Rows[i][2].ToString());
            }
            return total;
        }
    }
}