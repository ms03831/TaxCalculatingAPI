using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Assignment4APITemplate.Models;

namespace Assignment4APITemplate.Controllers
{
    public class TaxCalculatorController : ApiController
    {
        [HttpGet]
        public TaxComputation CalculateTax(decimal yearlyIncome = 880000M,
                    int remainingPeriods = 4, decimal taxPaid = 4000M)
        {
            // TODO: Write your code here
            return new TaxComputation
            {
                TotalSalary = yearlyIncome,
                RemainingPeriods = remainingPeriods,
                TaxPaid = taxPaid,
                TotalTaxLiability = 14000,
                TaxPerMonth = 2500.00M
            };
        }
    }
}
