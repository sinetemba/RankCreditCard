using AutoMapper;
using Core.Entities;
using RankCreditCard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankCreditCard.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {           
            CreateMap<CreditCard, CreditCardViewModel>();          
        }

    }
}
