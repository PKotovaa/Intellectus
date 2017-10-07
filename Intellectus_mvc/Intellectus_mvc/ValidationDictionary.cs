using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Intellectus_mvc
{
    public class ValidationDictionary : IValidationDictionary
    {
        private ModelStateDictionary modelState;

        public ValidationDictionary(ModelStateDictionary modelState)
        {
            this.modelState = modelState;
        }

        public void AddError(string key, string errorMessage)
        {
            modelState.AddModelError(key, errorMessage);
        }

        public bool IsValid
        {
            get { return modelState.IsValid; }
        }
    }
}