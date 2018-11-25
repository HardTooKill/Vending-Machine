using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    public class CanViewModel
    {
        public string name { get; set; }
        public double value { get; set; }
        public int amount { get; set; }
        public string SelectedPayment { get; set; }


        public CanViewModel()
        {
            
        }
    }
}