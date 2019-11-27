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
            int remainingMonths = -1;
            for (int index = 1; index <= 12; ++index)
            {
                totalSalary += Convert.ToDecimal(form["salary" + index.ToString()]);
                decimal taxPaid = Convert.ToDecimal(form["taxpaid" + index.ToString()]);
                if (remainingMonths == -1 && taxPaid == 0M)
                    remainingMonths = 13 - index;
                toalTaxPaid += taxPaid;
            }
            totalSalary += Convert.ToDecimal(form["salaryextra"]);

            decimal taxPerMonth = CalculationManager.GetMonthlyTax(
                totalSalary, toalTaxPaid, remainingMonths);
            ViewBag.TaxPerMonth = taxPerMonth;
            return View();
        }
    }
}