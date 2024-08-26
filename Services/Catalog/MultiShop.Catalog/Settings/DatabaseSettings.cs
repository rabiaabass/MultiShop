namespace MultiShop.Catalog.Settings
{
    public class DatabaseSettings:IDatabaseSettings
    {
        public string CategoryCollectionName { get; set; } = default!;
        public string ProductCollectionName { get; set; } = default!;   
        public string ProductDetailCollectionName { get; set; } = default!;
        public string ProductImageCollectionName { get; set; } = default!;
        public string ConnectionString { get; set; } = default!;
        public string DatabaseName { get; set; } = default!;
    }
}
