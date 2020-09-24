using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepo
{
    public class ClaimRepo
    {
        List<Claim> _claims = new List<Claim>();

        public List<Claim> ViewAllClaims()
        {
            return _claims;
        }

        public bool HandleClaim(int claimId)
        {
            Claim claimToHandle = GetClaimById(claimId);
            if (claimToHandle == null) { return false; }
            _claims.Remove(claimToHandle);
            return true;
        }

        public void NewClaim(Claim newClaim)
        {
            _claims.Add(newClaim);
        }

        // Helper
        private Claim GetClaimById(int claimId)
        {
            foreach (Claim c in _claims)
            {
                if (c.ClaimId == claimId)
                {
                    return c;
                }
            }
            return null;
        }

        public void PopulateClaims()
        {
            int c1ClaimId = 1;
            TypeOfClaim c1ClaimType = TypeOfClaim.Car;
            string c1Description = "Accident on 829";
            decimal c1ClaimAmount = 400M;
            DateTime c1DateOfIncident = new DateTime(2020, 09, 01);
            DateTime c1DateOfClaim = new DateTime(2020, 09, 10);
            Claim c1 = new Claim(c1ClaimId, c1ClaimType, c1Description, c1ClaimAmount, c1DateOfIncident, c1DateOfClaim);
            NewClaim(c1);

            int c2ClaimId = 1;
            TypeOfClaim c2ClaimType = TypeOfClaim.Car;
            string c2Description = "Accident on 829";
            decimal c2ClaimAmount = 400M;
            DateTime c2DateOfIncident = new DateTime(2020, 09, 01);
            DateTime c2DateOfClaim = new DateTime(2020, 10, 04);
            Claim c2 = new Claim(c2ClaimId, c2ClaimType, c2Description, c2ClaimAmount, c2DateOfIncident, c2DateOfClaim);
            NewClaim(c2);
        }
    }
}
