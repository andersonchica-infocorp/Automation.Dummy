using Sofka.Automation.Dummy.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sofka.Automation.Dummy.Entities.Loan
{
    [DataContract]
    public class LoanRequestResponse
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public bool ControlRiskStateReported { get; set; }

        [DataMember]
        public decimal AmmountRequested { get; set; }

        [DataMember]
        public decimal AmmountApproved { get; set; }

        [DataMember]
        public bool Approved { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
