using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace VendingMachine.Models
{
    public static class VendingMachine
    {
        public static double _totalcash;
        public static double _totalcredit;
        public static double _totalsoldcans;
        public static double _totalcans;

        public static List<Can> canList;
       
        /// <summary>
        /// Reset vending machine
        /// </summary>
        public static void Reset()
        {
            canList = new List<Can>();
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
        public static void Vend(string name, bool isCash)
        {
            foreach (Can c in canList)
            {
                if (c.name.Equals(name))
                {
                    if (c.amount == 0) return;
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
        public static void AddNewCan(string name, double value, int amount)
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
        public static bool Restock(string name, int amount)
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
        public static void Initialization()
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
            _totalcans = GetTotalCans();
        }

        /// <summary>
        /// Get total number of cans
        /// </summary>
        /// <returns></returns>
        public static int GetTotalCans()
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