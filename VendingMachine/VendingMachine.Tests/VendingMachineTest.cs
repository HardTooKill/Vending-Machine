using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace VendingMachine.Tests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void TestCansInitialization()
        {
            Models.VendingMachine vm = new Models.VendingMachine();
            Assert.IsTrue(vm.canCollectiontable.Rows.Count == 5);
            Assert.AreEqual(100, vm._totalcans);
        }

        [TestMethod]
        public void TestAddnewCans()
        {
            Models.VendingMachine vm = new Models.VendingMachine();
            Assert.IsTrue(vm.canCollectiontable.Rows.Count == 5);
            Assert.AreEqual(100, vm._totalcans);

            vm.AddNewCan("Lift", 1.3, 50);
            Assert.IsTrue(vm.canCollectiontable.Rows.Count == 6);
            Assert.AreEqual(150, vm._totalcans);
        }
        [TestMethod]
        public void TestRestock()
        {
            Models.VendingMachine vm = new Models.VendingMachine();
            Assert.IsTrue(vm.canCollectiontable.Rows.Count == 5);
            Assert.AreEqual(100, vm._totalcans);

            //no flavor in the machine should return false
            Assert.IsFalse(vm.Restock("Lift", 50));

            //restock the Coke and check total cans after
            Assert.IsTrue(vm.Restock("Coke", 30));
            Assert.AreEqual(110, vm._totalcans);
        }
        [TestMethod]
        public void TestVend()
        {
            Models.VendingMachine vm = new Models.VendingMachine();
            Assert.IsTrue(vm.canCollectiontable.Rows.Count == 5);
            Assert.AreEqual(100, vm._totalcans);

            vm.Vend("Coke", true);
            vm.Vend("Sprite", false);

            Assert.IsTrue(vm._totalcans== 98,"Total Can Number is wrong");
            Assert.IsTrue(vm._totalsoldcans == 2, "Total Can sold is wrong");
            Assert.IsTrue(vm.GetTotalCans() == 98, "Total Can sold is wrong");
            Assert.IsTrue(vm._totalcash == 1.2D,"Total cash is wrong");
            Assert.IsTrue(vm._totalcredit == 1.2D, "Total credit is wrong");
        }
        [TestMethod]
        public void TestReset()
        {
            Models.VendingMachine vm = new Models.VendingMachine();
            Assert.IsTrue(vm.canCollectiontable.Rows.Count == 5);
            Assert.AreEqual(100, vm._totalcans);

            vm.Vend("Coke", true);
            vm.Vend("Sprite", false);

            Assert.IsTrue(vm._totalcans == 98, "Total Can Number is wrong");
            Assert.IsTrue(vm._totalcash == 1.2D, "Total cash is wrong");
            Assert.IsTrue(vm._totalcredit == 1.2D, "Total credit is wrong");

            vm.Reset();
            Assert.IsTrue(vm._totalcans == 98, "Total Can Number is wrong");
            Assert.IsTrue(vm._totalcash == 0D, "Total cash is wrong");
            Assert.IsTrue(vm._totalcredit == 0D, "Total credit is wrong");
            Assert.IsTrue(vm._totalsoldcans == 0, "Total can sold is wrong");
        }
    }
}
