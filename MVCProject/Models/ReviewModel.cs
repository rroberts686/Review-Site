using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCProject.Models
{
    public class ReviewModel
    {
        [Key]
       public int Id { get; set; }
       public string Name { get; set; }
       public string Content { get; set;} 
       public int Rating { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        
        public virtual ProductModel? Product { get; set; }

        [NotMapped]
        public string? NewProductReview { get; set; }

        
        public string? StarRating { get; set; }

    }
}
