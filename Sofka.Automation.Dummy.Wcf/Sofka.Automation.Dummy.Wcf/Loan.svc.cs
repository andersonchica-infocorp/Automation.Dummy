using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Sofka.Automation.Dummy.Entities.Loan;

namespace Sofka.Automation.Dummy.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Loan" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Loan.svc or Loan.svc.cs at the Solution Explorer and start debugging.
    public class Loan : ILoan
    {
        public LoanRequestResponse LoanRequest(LoanRequestRequest request)
        {
            BusinessComponent.Loan loanBusiness = new BusinessComponent.Loan();
            return loanBusiness.ValidateLoanRequest(request);
        }

        public LoanRequestResponse Prueba(string CustomerId)
        {
            return new LoanRequestResponse
            {
                AmmountApproved = 1000,
                AmmountRequested = 1000,
                Approved = true,
                ErrorMessage = "hola",
                Id = 1
            };
        }
    }
}
