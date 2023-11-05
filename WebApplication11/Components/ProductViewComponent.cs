using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Components
{
    public class ProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Product> products)

        {
            return View("../Views/ProductTable.cshtml", products);

        }

    }

}   
