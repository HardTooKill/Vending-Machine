using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        private Models.VendingService service;

        public HomeController(Models.VendingService service)
        {
            this.service = service;
        }

        public HomeController()
        {
            //  this.service = new Models.VendingMachine();
           
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<ViewModels.CanViewModel> list = new List<ViewModels.CanViewModel>();
            foreach (Models.Can can in service.GetCansList())
            {
                ViewModels.CanViewModel cvm = new ViewModels.CanViewModel();
                cvm.amount = can.amount;
                cvm.name = can.name;
                cvm.value = can.value;
                cvm.SelectedPayment = "Cash";
                list.Add(cvm);
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult Vend(string name, string selectedpayment)
        {
            service.Vend(name, selectedpayment.Equals("Cash"));

            List<ViewModels.CanViewModel> list = new List<ViewModels.CanViewModel>();
            foreach (Models.Can can in Models.VendingMachine.canList)
            {
                ViewModels.CanViewModel cvm = new ViewModels.CanViewModel();
                cvm.amount = can.amount;
                cvm.name = can.name;
                cvm.value = can.value;
                cvm.SelectedPayment = "Cash";
                list.Add(cvm);
            }
            return View("Index", list);
        }
        public ActionResult Manage()
        {
            ViewModels.VendingMachineViewModel vm = new ViewModels.VendingMachineViewModel();
            vm.Totalcans = service.GetTotalCans();
            vm.TotalCash = service.GetTotalcash();
            vm.Totalcredit = service.GetTotalCredit();
            vm.TotalSoldcans = service.GetTotalSoldCans();

            List<ViewModels.CanViewModel> list = new List<ViewModels.CanViewModel>();
            foreach (Models.Can can in Models.VendingMachine.canList)
            {
                ViewModels.CanViewModel cvm = new ViewModels.CanViewModel();
                cvm.amount = can.amount;
                cvm.name = can.name;
                cvm.value = can.value;
                cvm.SelectedPayment = "Cash";
                list.Add(cvm);
            }
            vm.CanList = list;

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}