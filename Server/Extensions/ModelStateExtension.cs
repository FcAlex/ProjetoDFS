using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Extensions
{
    public static class ModelStateExtension
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return (from model in dictionary 
                    from msg in model.Value.Errors 
                    select msg.ErrorMessage)
                    .ToList();
        }
    }
}
