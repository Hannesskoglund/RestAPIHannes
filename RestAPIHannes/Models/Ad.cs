namespace RestAPIHannes.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string? Category { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

        public string? SellerName { get; set; }

        public string? SellerEmail { get; set; }
    }
}
