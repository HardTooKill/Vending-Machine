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
            Models.VendingMachine.Reset();
            Models.VendingMachine.Initialization();
            Assert.IsTrue(Models.VendingMachine.canList.Count == 5);
            Assert.AreEqual(100, Models.VendingMachine.GetTotalCans());
        }

        [TestMethod]
        public void TestAddnewCans()
        {
            Models.VendingMachine.Reset();
            Models.VendingMachine.Initialization();

            Assert.IsTrue(Models.VendingMachine.canList.Count == 5);
            Assert.AreEqual(100, Models.VendingMachine.GetTotalCans());

            Models.VendingMachine.AddNewCan("Lift", 1.3, 50);
            Assert.IsTrue(Models.VendingMachine.canList.Count == 6);
            Assert.AreEqual(150, Models.VendingMachine.GetTotalCans());
        }
        [TestMethod]
        public void TestRestock()
        {
            Models.VendingMachine.Reset();
            Models.VendingMachine.Initialization();
            Assert.IsTrue(Models.VendingMachine.canList.Count == 5);
            Assert.AreEqual(100, Models.VendingMachine.GetTotalCans());

            //no flavor in the machine should return false
            Assert.IsFalse(Models.VendingMachine.Restock("Lift", 50));

            //restock the Coke and check total cans after
            Assert.IsTrue(Models.VendingMachine.Restock("Coke", 30));
            Assert.AreEqual(110, Models.VendingMachine.GetTotalCans());
        }
        [TestMethod]
        public void TestVend()
        {
            Models.VendingMachine.Reset();
            Models.VendingMachine.Initialization();
            Assert.IsTrue(Models.VendingMachine.canList.Count == 5);
            Assert.AreEqual(100, Models.VendingMachine.GetTotalCans());

            Models.VendingMachine.Vend("Coke", true);
            Models.VendingMachine.Vend("Sprite", false);

            Assert.IsTrue(Models.VendingMachine._totalcans== 98,"Total Can Number is wrong");
            Assert.IsTrue(Models.VendingMachine._totalsoldcans == 2, "Total Can sold is wrong");
            Assert.IsTrue(Models.VendingMachine.GetTotalCans() == 98, "Total Can sold is wrong");
            Assert.IsTrue(Models.VendingMachine._totalcash == 1.2D,"Total cash is wrong");
            Assert.IsTrue(Models.VendingMachine._totalcredit == 1.2D, "Total credit is wrong");
        }
        [TestMethod]
        public void TestReset()
        {
            Models.VendingMachine.Reset();
            Models.VendingMachine.Initialization();
            Assert.IsTrue(Models.VendingMachine.canList.Count == 5);
            Assert.AreEqual(100, Models.VendingMachine.GetTotalCans());

            Models.VendingMachine.Vend("Coke", true);
            Models.VendingMachine.Vend("Sprite", false);

            Assert.IsTrue(Models.VendingMachine._totalcans == 98, "Total Can Number is wrong");
            Assert.IsTrue(Models.VendingMachine._totalcash == 1.2D, "Total cash is wrong");
            Assert.IsTrue(Models.VendingMachine._totalcredit == 1.2D, "Total credit is wrong");

            Models.VendingMachine.Reset();
            Assert.IsTrue(Models.VendingMachine._totalcans == 0, "Total Can Number is wrong");
            Assert.IsTrue(Models.VendingMachine._totalcash == 0D, "Total cash is wrong");
            Assert.IsTrue(Models.VendingMachine._totalcredit == 0D, "Total credit is wrong");
            Assert.IsTrue(Models.VendingMachine._totalsoldcans == 0, "Total can sold is wrong");
        }
    }
}
