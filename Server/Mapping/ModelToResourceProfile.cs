using AutoMapper;
using Server.Domains.Models;
using Server.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Purchase, PurchaseResource>();
            CreateMap<Company, CompanyResource>();
            CreateMap<Product, ProductResource>();
            CreateMap<User, UserResource>();
            CreateMap<AuthUserResource, User>(); // REMOVE
        }
    }
}
