using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyJourneyToWork.Pages
{
    public class CalculatorModel : PageModel
    {
        [BindProperty]      // bound on POST request


        public Calculator.Calculator calculator { get; set; }

        // The OnGet method is intentionally left empty as this page does not perform any logic on HTTP GET requests.
        public void OnGet()
        {
        }
    }
}
