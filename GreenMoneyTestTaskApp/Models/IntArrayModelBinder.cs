using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenMoneyTestTaskApp.Models
{
    public class IntArrayModelBinder : IModelBinder
    {       
      
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (value == null || string.IsNullOrEmpty(value.FirstValue))
            {
                return null;
            }
            try
            {
                bindingContext.Result = ModelBindingResult.Success(value
                    .FirstValue
                    .Split(',')
                    .Select(int.Parse)
                    .ToArray());
            }
            catch(Exception)
            {

            }
            return Task.CompletedTask;            
        }
    }
}
