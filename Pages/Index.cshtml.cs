using lrnaz204.Models;
using lrnaz204.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace lrnaz204.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products;
        
        public void OnGet()
        {
            ProductService productService= new ProductService();
            Products=productService.GetProducts();

        }
    }
}