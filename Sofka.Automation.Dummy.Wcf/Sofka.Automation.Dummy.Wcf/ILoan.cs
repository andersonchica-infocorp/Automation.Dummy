using Sofka.Automation.Dummy.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Sofka.Automation.Dummy.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILoan" in both code and config file together.
    [ServiceContract]
    public interface ILoan
    {
        [OperationContract]
        LoanRequestResponse LoanRequest(LoanRequestRequest request);

        [OperationContract]
        LoanRequestResponse Prueba(string CustomerId);
    }
}
