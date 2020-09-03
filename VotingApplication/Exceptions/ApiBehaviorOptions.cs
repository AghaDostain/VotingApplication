using System;
using Microsoft.AspNetCore.Mvc;

namespace VotingApplication.WebAPI.Exceptions
{
    public class ApiBehaviorOptions
    {
        public Func<ActionContext, IActionResult> InvalidModelStateResponseFactory { get; set; }
        public bool SuppressModelStateInvalidFilter { get; set; }
        public bool SuppressInferBindingSourcesForParameters { get; set; }
        public bool SuppressConsumesConstraintForFormFileParameters { get; set; }
    }
}
