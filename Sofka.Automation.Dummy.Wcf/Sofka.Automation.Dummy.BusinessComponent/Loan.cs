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
            response.AmmountRequested = request.AmmountRequested;

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

        private string ValidateClientInformation(LoanRequestRequest request)
        {
            string response = string.Empty;

            if (request.Id > 13)
            {
                response = "the current Id client does not exist";
            }
            else if (request.Id % 2 == 0)
            {
                response = "Client is not valid";
            }

            return response;
        }

        private string ValidateRiskCenter(LoanRequestRequest request)
        {
            string response = string.Empty;

            if (request.Id == 1 || request.Id == 5)
            {
                response = "The client is reported in the risk center";
            }

            return response;
        }

        private string ValidateBorrowingCapacity(LoanRequestRequest request)
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
                if (request.AmmountRequested > 50000)
                {
                    response = "The ammount requested is higher than the borrowing capacity";
                }
            }

            return response;
        }

        private decimal CalculateAmmountApproved(LoanRequestRequest request)
        {
            decimal response = 0;

            if (request.Id == 3)
            {
                response = 4000;
            }
            else if (request.Id == 7)
            {
                response = 7000;
            }
            else if (request.Id == 9)
            {
                response = 5000;
            }
            else if(request.Id == 11)
            {
                response = 50000;
            }
            else if (request.Id == 13)
            {
                response = 15000;
            }

            return response;
        }
    }
}
