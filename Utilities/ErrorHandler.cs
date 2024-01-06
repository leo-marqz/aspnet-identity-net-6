using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPNetIdentity.Utilities
{
    public static class ErrorHandler
    {
        public static void ErrorMapper(this IdentityResult identityResult, ModelStateDictionary modelState)
        {
            foreach(var error in identityResult.Errors){
                modelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}