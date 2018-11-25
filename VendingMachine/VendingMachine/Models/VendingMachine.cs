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

        public List<Can> canList;


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
            foreach (Can c in canList)
            {
                if (c.name.Equals(name))
                {
                    if (isCash)
                        _totalcash += c.value;
                    else
                        _totalcredit += c.value;

                    c.amount = c.amount - 1;
                    _totalcans--;
                    _totalsoldcans++;
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

            if (canList.Count == 10)
                throw new Exception("Cannot add more flavors");

            Can newcan = new Can();
            newcan.name = name;
            newcan.value = value;
            newcan.amount = amount;

            canList.Add(newcan);
            _totalcans += amount;
        }

        /// <summary>
        /// Re stock cans
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public bool Restock(string name, int amount)
        {
            foreach (Can c in canList)
            {
                if (c.name.Equals(name))
                {
                    c.amount = amount;
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
            //by design, all can's details are stored in a list with Class type Can
            // for deomo assume that all can's names are unique name
            canList = new List<Can>();

            //add 5 different cans for starting
            Can can1 = new Can();
            can1.name = "Coke";
            can1.value = 1.2d;
            can1.amount = 20;
            canList.Add(can1);


            Can can2 = new Can();
            can2.name = "Sprite";
            can2.value = 1.2d;
            can2.amount = 20;
            canList.Add(can2);

            Can can3 = new Can();
            can3.name = "Fanta";
            can3.value = 1.2d;
            can3.amount = 20;
            canList.Add(can3);

            Can can4 = new Can();
            can4.name = "Pepsi";
            can4.value = 1.1d;
            can4.amount = 20;
            canList.Add(can4);

            Can can5 = new Can();
            can5.name = "7up";
            can5.value = 1.1d;
            can5.amount = 20;
            canList.Add(can5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetTotalCans()
        {
            int total = 0;

            foreach (Can c in canList)
            {
                total += c.amount;
            }
            return total;
        }
    }
}