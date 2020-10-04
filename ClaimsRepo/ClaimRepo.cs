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
            newClaim.ClaimId = _claims.Count + 1;
            _claims.Add(newClaim);
        }

        // Helper Functions
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
            TypeOfClaim c1ClaimType = TypeOfClaim.Car;
            string c1Description = "Accident on 829";
            decimal c1ClaimAmount = 400.00M;
            DateTime c1DateOfIncident = new DateTime(2020, 09, 01);
            DateTime c1DateOfClaim = new DateTime(2020, 09, 10);
            Claim c1 = new Claim(c1ClaimType, c1Description, c1ClaimAmount, c1DateOfIncident, c1DateOfClaim);
            NewClaim(c1);

            TypeOfClaim c2ClaimType = TypeOfClaim.Theft;
            string c2Description = "House theft";
            decimal c2ClaimAmount = 1127.59M;
            DateTime c2DateOfIncident = new DateTime(2020, 09, 01);
            DateTime c2DateOfClaim = new DateTime(2020, 10, 04);
            Claim c2 = new Claim(c2ClaimType, c2Description, c2ClaimAmount, c2DateOfIncident, c2DateOfClaim);
            NewClaim(c2);
        }
    }
}
