using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachine.ViewModels
{
    public class VendingMachineViewModel
    {

        public double TotalCash { get; set; }
        public double Totalcredit { get; set; }
        public int TotalSoldcans { get; set; }
        public int Totalcans { get; set; }


        public List<CanViewModel> CanList { get; set; }
    }
}