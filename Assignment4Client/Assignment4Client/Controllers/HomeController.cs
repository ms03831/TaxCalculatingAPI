using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment4Client.Models;

namespace Assignment4Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(FormCollection form)
        {
            decimal totalSalary = 0M;
            decimal toalTaxPaid = 0M;
            int remainingMonths = 0;
            for (int index = 1; index <= 12; ++index)
            {
                decimal salary = Convert.ToDecimal(form["salary" + index.ToString()]);
                totalSalary += salary;
                decimal taxPaid = Convert.ToDecimal(form["taxpaid" + index.ToString()]);
                //assuming that remaining periods means the non tax paid months.
                if (taxPaid == 0M)
                    remainingMonths++;
                toalTaxPaid += taxPaid;
            }
            totalSalary += Convert.ToDecimal(form["salaryextra"]);

            TaxComputation report = CalculationManager.GetMonthlyTax(
                totalSalary, toalTaxPaid, remainingMonths);

            ViewBag.TaxPerMonth = report.TaxPerMonth;
            ViewBag.TotalTaxLiability = report.TotalTaxLiability;
            ViewBag.TaxPaid = report.TaxPaid;
            ViewBag.TotalIncome = report.TotalSalary;
            ViewBag.RemainingPeriods = report.RemainingPeriods;

            return View();
        }
    }
}