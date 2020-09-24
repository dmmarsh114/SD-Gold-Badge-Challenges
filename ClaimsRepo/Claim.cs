using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepo
{
    public enum TypeOfClaim
    {
        Car = 1,
        Home,
        Theft
    }

    public class Claim
    {
        public int ClaimId { get; set; }
        public TypeOfClaim ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; }


        public Claim(int id, TypeOfClaim claimType, string desc, decimal amt, DateTime dateIncident, DateTime dateClaim)
        {
            ClaimId = id;
            ClaimType = claimType;
            Description = desc;
            ClaimAmount = amt;
            DateOfIncident = dateIncident;
            DateOfClaim = dateClaim;

            TimeSpan length = dateClaim - dateIncident;
            if (length.TotalDays > 30) { IsValid = false; }
            else { IsValid = true; }
        }
    }
}
