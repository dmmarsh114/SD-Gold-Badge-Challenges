using System;
using System.Collections.Generic;
using ClaimsRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        ClaimRepo cRepo = new ClaimRepo();

        [TestMethod]
        public void ViewAllClaimsTest()
        {
            cRepo.PopulateClaims();
            List<Claim> allClaims = cRepo.ViewAllClaims();
            Assert.AreEqual(2, allClaims.Count);
        }

        [TestMethod]
        public void HandleClaimTest()
        {
            cRepo.PopulateClaims();
            cRepo.HandleClaim(1);
            Assert.AreEqual(1, cRepo.ViewAllClaims().Count);
        }

        [TestMethod]
        public void NewClaimTest()
        {
            TypeOfClaim type = TypeOfClaim.Car;
            string desc = "New Claim Test";
            decimal amt = 400.00M;
            DateTime dateInc = new DateTime(2020, 9, 1);
            DateTime dateClaim = new DateTime(2020, 9, 20);
            Claim testClaim = new Claim(type, desc, amt, dateInc, dateClaim);
            cRepo.NewClaim(testClaim);
            Assert.AreEqual(1, cRepo.ViewAllClaims().Count);
        }
    }
}
