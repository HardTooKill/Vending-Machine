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
        [DisplayName("Flavor")]
        public string name { get; set; }
        [DisplayName("Price")]
        public double value { get; set; }
        [DisplayName("Amount")]
        public int amount { get; set; }
        public string SelectedPayment { get; set; }


        public CanViewModel()
        {
            
        }
    }
}