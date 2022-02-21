using CreditCardValidator;
using Microsoft.AspNetCore.Mvc;
using RankCreditCard.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RankCreditCard.Helpers;
using Core.Entities;
using Core.Interfaces;
using AutoMapper;
using Infrastructure.Helpers;

namespace RankCreditCard.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;       

        public CreditCardController(ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> List()
        {
            var creditcards = await _creditCardRepository.GetCreditCardsAsync();

            var model = _mapper.Map<List<CreditCard>, List<CreditCardViewModel>>(creditcards);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CreditCardViewModel creditcardViewModel)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {          
                    var entity = new CreditCard()
                    {
                        CardHolderName = creditcardViewModel.CardHolderName,
                        CardNumber = creditcardViewModel.CardNumber.Encrypt(),
                        CCVNumber = creditcardViewModel.CCVNumber,
                        ExpiryMonth = creditcardViewModel.ExpiryMonth,
                        ExpiryYear = creditcardViewModel.ExpiryYear,
                        Provider = creditcardViewModel.CardNumber.GetCreditCardBrandName(),

                    };

                    _creditCardRepository.AddNewCreditCard(entity);


                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid information provided.");


            return View(creditcardViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var creditCard = await _creditCardRepository.GetCreditCardByIdAsync(id);

            return View(_mapper.Map<CreditCard, CreditCardViewModel>(creditCard));
        }
       
        [HttpPost]
        public async Task<IActionResult> RemoveCreditCard(int creditcardId)
        {
            var creditCard = await _creditCardRepository.GetCreditCardByIdAsync(creditcardId);

            if (creditCard != null)
            {
                _creditCardRepository.RemoveCreditCard(creditCard);
            }

            return RedirectToAction("List");
        }
    }
}
