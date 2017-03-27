using Sofka.Automation.Dummy.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofka.Automation.Dummy.BusinessComponent
{
    public class Loan
    {
        public LoanRequestResponse ValidateLoanRequest(LoanRequestRequest request)
        {
            LoanRequestResponse response = new LoanRequestResponse();

            response.ErrorMessage = this.ValidateClientInformation(request);
            if (string.IsNullOrEmpty(response.ErrorMessage))
            {
                response.ErrorMessage = this.ValidateRiskCenter(request);
                if (string.IsNullOrEmpty(response.ErrorMessage))
                {
                    response.ErrorMessage = this.ValidateBorrowingCapacity(request);
                    if (string.IsNullOrEmpty(response.ErrorMessage))
                    {
                        response.AmmountApproved = this.CalculateAmmountApproved(request);
                    }
                }
                else
                {
                    response.ControlRiskStateReported = true;
                }
            }

            response.Approved = response.AmmountApproved > 0;

            return response;
        }

        public string ValidateClientInformation(LoanRequestRequest request)
        {
            string response = string.Empty;

            if (request.Id > 17)
            {
                response = "the current Id client does not exist";
            }
            else if (request.Id % 2 == 0)
            {
                response = "Client is not valid";
            }

            return response;
        }

        public string ValidateRiskCenter(LoanRequestRequest request)
        {
            string response = string.Empty;

            if (request.Id == 1 || request.Id == 5 || request.Id == 15)
            {
                response = "The client is reported in the risk center";
            }

            return response;
        }

        public string ValidateBorrowingCapacity(LoanRequestRequest request)
        {
            string response = string.Empty;

            if (request.Id == 3)
            {
                if (request.AmmountRequested > 5000)
                {
                    response = "The ammount requested is higher than the borrowing capacity";
                }
            }
            else if (request.Id == 7)
            {
                if (request.AmmountRequested > 9000)
                {
                    response = "The ammount requested is higher than the borrowing capacity";
                }
            }
            else if (request.Id == 11)
            {
                if (request.AmmountRequested > 9000)
                {
                    response = "The ammount requested is higher than the borrowing capacity";
                }
            }

            return response;
        }

        public decimal CalculateAmmountApproved(LoanRequestRequest request)
        {
            decimal response = 0;

            if (request.Id == 9)
            {
                response = 5000;
            }
            else if (request.Id == 13)
            {
                response = 15000;
            }
            else if (request.Id == 17)
            {
                response = 50000;
            }

            return response;
        }
    }
}
