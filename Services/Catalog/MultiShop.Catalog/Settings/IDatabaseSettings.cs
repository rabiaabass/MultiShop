namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        // Interface si olan şeyin mutlaka class ı da olmalı
        // CRUD Create (Oluştur), Read (Oku), Update (Güncelle) ve Delete (Sil) , işlemleri için gerekli

        // Dto klasöründe her bir CRUD işlemi için ayrı ayrı sınıflar tanımlayacağız.
        string CategoryCollectionName { get; set; }
        string ProductCollectionName { get; set; }
        string ProductDetailCollectionName { get; set; }
        string ProductImageCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
