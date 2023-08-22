using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MVCProject.DataContext;
using MVCProject.Models;
using System.Security.Policy;

namespace MVCProject.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ProductReviewContext _context;
        public ReviewController(ProductReviewContext context) 
        {
            _context = context;
        }
       //Index
        public IActionResult Index()
        {
            var reviews = _context.Reviews.Include(p => p.Product).ToList();

            // Create a new list of ReviewModel with an additional property for star rating
            var reviewsWithStarRating = reviews.Select(review => new ReviewModel
            {
                Id = review.Id,
                Name = review.Name,
                Content = review.Content,
                Rating = review.Rating,
                StarRating = GetStarRating(review.Rating)
            }).ToList();

            return View(reviewsWithStarRating);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReviewModel review)
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
        //Edit
        public IActionResult Edit(int id)
        {
            var review = _context.Reviews.Include(r => r.Product).FirstOrDefault(r => r.Id == id);
            return View(review);
        }
        [HttpPost]
        public IActionResult Edit(int id, ReviewModel review)
        {
            if (ModelState.IsValid)
            {
                review.ProductId = GetProduct(review.NewProductReview);
                _context.Update(review);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
            
        }
        //detials
        public IActionResult Details(int id)
        {
            var review = _context.Reviews.Where(p => p.Id == id).Include(b => b.Product).FirstOrDefault();
            
            review.StarRating = GetStarRating(review.Rating);

            return View(review);
        }
        //Delete
        public IActionResult Delete(int id) 
        { 
            var review =_context.Reviews.FirstOrDefault(r => r.Id == id);
            if(review == null)
            {
                return NotFound();
            }
            return View(review);
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var reviews = _context.Reviews.Find(id);
            _context.Reviews.Remove(reviews);
            _context.SaveChanges(); 
            return RedirectToAction("Index");

        }
        //Product 
        private int GetProduct(string product)
        {
            ProductModel? pro = null;
            pro = _context.Products.Where(p => p.Name.ToLower()== product.ToLower()).FirstOrDefault();
            if (pro == null)
            {
                pro = new ProductModel { Name = product };
                _context.Add(pro);
                _context.SaveChanges();
            }
            return pro.Id;
        }

        private string GetStarRating(int rating)
        {
            string stars = string.Empty;

            for (int i = 0; i < rating; i++)
            {
                stars += "&#9733;"; 
            }

            for (int i = rating; i < 5; i++)
            {
                stars += "&#9734;"; 
            }

            return stars;
        }


    }
}
