using System;
using System.Collections.Generic;

namespace VendingMachine.Models
{
    public class VendingService
    {
        public double GetTotalcash()
        {
            return VendingMachine._totalcash;
        }

        public double GetTotalCredit()
        {
            return VendingMachine._totalcredit;
        }
        public int GetTotalSoldCans()
        {
            return VendingMachine._totalsoldcans;
        }
        public int GetTotalCans()
        {
            return VendingMachine._totalcans;
        }
        public List<Can> GetCansList()
        {
            return VendingMachine.canList;
        }

        /// <summary>
        /// Reset vending machine
        /// </summary>
        public  void Reset()
        {
            VendingMachine.Reset();
        }
        /// <summary>
        /// Vend
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isCash"></param>
        public  void Vend(string name, bool isCash)
        {
            VendingMachine.Vend(name, isCash);
        }
        /// <summary>
        /// Add new flavors of cans
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="amount"></param>
        public void AddNewCan(string name, double value, int amount)
        {
            VendingMachine.AddNewCan(name, value, amount);
        }

        /// <summary>
        /// Re stock cans
        /// </summary>
        /// <param name="name"></param>
        /// <param name="amount"></param>
        public bool Restock(string name, int amount)
        {
            if (VendingMachine.Restock(name, amount))
            {
                VendingMachine.Reset();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get total number of cans
        /// </summary>
        /// <returns></returns>
        public int GetTotalCansAmount()
        {
            return VendingMachine.GetTotalCans();
        }
    }
}