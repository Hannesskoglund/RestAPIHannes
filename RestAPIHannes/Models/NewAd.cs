using System.ComponentModel.DataAnnotations;

namespace RestAPIHannes.Models
{
    public class NewAd
    {

        [Required, StringLength(100)]
        public string? Title { get; set; }

        [Required, StringLength(2000)]
        public string? Description { get; set; }

        [Range(0, 10000000)]
        public decimal Price { get; set; }

        [Required, StringLength(100)]
        public string? Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        [Required, StringLength(50)]
        public string? SellerName { get; set; }

        [Required, EmailAddress]
        public string? SellerEmail { get; set; }
    }
}
