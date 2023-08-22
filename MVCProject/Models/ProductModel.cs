using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVCProject.Models;
public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Image { get; set; }
       
        public string Description { get; set; }



        

         public virtual IEnumerable <ReviewModel>? Reviews { get; set; }

        





}

