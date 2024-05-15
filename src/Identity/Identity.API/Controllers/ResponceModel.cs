using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Identity.API.Controllers
{
    internal class ResponceModel : ModelStateDictionary
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}