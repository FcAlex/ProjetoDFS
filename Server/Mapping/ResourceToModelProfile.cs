using AutoMapper;
using Server.Domains.Models;
using Server.Resources.Saving;
using Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Mapping
{
  public class ResourceToModelProfile : Profile
  {
    public ResourceToModelProfile()
    {
      CreateMap<SaveUserResource, User>();
      CreateMap<SavePurchaseResource, Purchase>();
      CreateMap<SaveCompanyResource, Company>();
      CreateMap<SaveProductResource, Product>();
      CreateMap<PurchaseProductResource, PurchaseProduct>();

    }
  }
}
