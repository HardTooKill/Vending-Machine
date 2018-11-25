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
        public ActionResult Vend(string name)
        {
            var canlist = service.GetCansList();
            ViewModels.CanViewModel cvm = new ViewModels.CanViewModel();
            foreach (var can in canlist)
            {
                if(can.name.Equals(name))
                {
                    cvm.name = can.name;
                    cvm.value = can.value;
                    cvm.SelectedPayment = "Cash";
                }
            }

            return View(cvm);
        }

        [HttpPost]
        public ActionResult Vend(ViewModels.CanViewModel vm)
        {

            service.Vend(vm.name, vm.SelectedPayment.Equals("Cash"));

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
            return View("Index",list);
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

        [HttpGet]
        public ActionResult Restock()
        {
            List<ViewModels.CanViewModel> list = new List<ViewModels.CanViewModel>();
            foreach (Models.Can can in service.GetCansList())
            {
                ViewModels.CanViewModel cvm = new ViewModels.CanViewModel();
                cvm.amount = can.amount;
                cvm.name = can.name;
                list.Add(cvm);
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Restock(IEnumerable<ViewModels.CanViewModel> canlist)
        {
            
            foreach (var can in canlist)
            {
                
                service.Restock(can.name, can.amount);
            }
            List<ViewModels.CanViewModel> list = new List<ViewModels.CanViewModel>();
            foreach (Models.Can can in service.GetCansList())
            {
                ViewModels.CanViewModel cvm = new ViewModels.CanViewModel();
                cvm.amount = can.amount;
                cvm.name = can.name;
                list.Add(cvm);
            }

            return View("Restock", list);
        }
    }
}