using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RankCreditCard.Data;
using RankCreditCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankCreditCard.Controllers
{
    public class CreditCardController : Controller
    {
       
        private RankCreditCardContext _context;

        public CreditCardController(RankCreditCardContext context)
        {           
            _context = context;
        }
        public async Task<IActionResult> List()
        {
            var creditcards = await _context.CreditCards.ToListAsync();
            return View(creditcards);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreditCard creditcard)
        {
            //CreditCardValidator.Luhn.CheckLuhn(creditcard.CardNumber);

            //var cc = new CreditCardDetector(creditcard.CardNumber);
            //var isValid = cc.IsValid();
            //var brand = cc.Brand;

            //CreditCardValidator.

            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // update the ef core context in memory 
                    _context.Add(creditcard);

                    // sync the changes of ef code in memory with the database
                    await _context.SaveChangesAsync();

                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            // We return the object back to view
            return View(creditcard);
        }
    }
}
