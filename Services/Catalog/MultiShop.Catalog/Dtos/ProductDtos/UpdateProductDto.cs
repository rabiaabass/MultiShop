namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; } // nullable geçilebilir isteseydik string? yapacaktık
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }

        // silme işlemleri için Dto ya gerek yok. Çünkü silme işlemi geriye bir şey getirmeyecek. Parametre olarak sadece id alacak.
    }
}
