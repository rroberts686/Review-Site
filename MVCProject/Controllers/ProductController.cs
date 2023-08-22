using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProject.DataContext;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductReviewContext _context; 
        public ProductController (ProductReviewContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var productsWithReviews = _context.Products.Include(p => p.Reviews).ToList();
            return View(productsWithReviews);
        }

        public IActionResult Details (int id)
        {
            var list =_context.Products.Where(p => p.Id == id).Include(r => r.Reviews).FirstOrDefault();
            return View(list);

        }
        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReviewModel review,ProductModel product)
        {
            if (ModelState.IsValid)
            {
                review.ProductId = GetProduct(review.NewProductReview);
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        private int GetProduct(string product)
        {
            ProductModel? pro = null;
            pro = _context.Products.Where(p => p.Name.ToLower() == product.ToLower()).FirstOrDefault();
            if (pro == null)
            {
                pro = new ProductModel { Name = product };
                _context.Add(pro);
                _context.SaveChanges();
            }
            return pro.Id;
        }


    }
}

