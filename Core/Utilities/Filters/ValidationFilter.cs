using System;
using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core.Utilities.Filters
{
    public static class ValidationFilter
    {

        public static IActionResult Validate(ActionContext actionContext)
        {
            var data = actionContext.ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();

            var message = $"One or more validtion errors occured.";

            var errorResult = new ErrorDataResult<List<string>>(data,message);

            return new BadRequestObjectResult(errorResult);
        }
    }
}
