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
            decimal taxPayable = 0M;
            // TODO: Write your code here
            if (yearlyIncome <= 600000M)
            {
                taxPayable = 0M;
            }

            else if (yearlyIncome > 600000M && yearlyIncome <= 1200000M)
            {
                taxPayable = 0.05M * (yearlyIncome - 600000M);
            }

            else if (yearlyIncome > 1200000M && yearlyIncome <= 1800000M)
            {
                taxPayable = 30000M + 0.1M * (yearlyIncome - 1200000M);
            }
            else if (yearlyIncome > 1800000M && yearlyIncome <= 2500000M)
            {
                taxPayable = 90000M + 0.15M * (yearlyIncome - 1800000M);
            }

            else if (yearlyIncome > 2500000M && yearlyIncome <= 3500000M)
            {
                taxPayable = 195000M + 0.175M * (yearlyIncome - 2500000M);
            }

            else if (yearlyIncome > 3500000M && yearlyIncome <= 5000000M)
            {
                taxPayable = 370000M + 0.2M * (yearlyIncome - 3500000M);
            }

            else if (yearlyIncome > 5000000M && yearlyIncome <= 8000000M)
            {
                taxPayable = 670000M + 0.225M * (yearlyIncome - 5000000M);
            }

            else if (yearlyIncome > 8000000M && yearlyIncome <= 12000000M)
            {
                taxPayable = 1345000M + 0.25M * (yearlyIncome - 8000000M);
            }

            else if (yearlyIncome > 12000000M && yearlyIncome <= 30000000M)
            {
                taxPayable = 2345000M + 0.275M * (yearlyIncome - 12000000M);
            }

            else if (yearlyIncome > 30000000M && yearlyIncome <= 50000000M)
            {
                taxPayable = 7295000M + 0.3M * (yearlyIncome - 30000000M);
            }

            else if (yearlyIncome > 50000000M && yearlyIncome <= 75000000M)
            {
                taxPayable = 13295000M + 0.32M * (yearlyIncome - 50000000M);
            }

            else if (yearlyIncome > 75000000M)
            {
                taxPayable = 21420000M + 0.35M * (yearlyIncome - 75000000M);
            }

            taxPayable = taxPayable - taxPaid;
            decimal taxPerMonth = taxPayable;
            if (remainingPeriods > 0)
                 taxPerMonth = taxPayable / (remainingPeriods);
            
            return new TaxComputation
            {
                TotalSalary = yearlyIncome,
                RemainingPeriods = remainingPeriods,
                TaxPaid = taxPaid,
                TotalTaxLiability = taxPayable,
                TaxPerMonth = taxPerMonth //assumed to be for remaining months only.
            };
        }
    }
}
