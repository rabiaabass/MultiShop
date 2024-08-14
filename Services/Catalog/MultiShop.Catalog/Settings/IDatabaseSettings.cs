namespace MultiShop.Catalog.Settings
{
    public class IDatabaseSettings
    {
        // Interface si olan şeyin mutlaka class ı da olmalı
        // CRUD Create (Oluştur), Read (Oku), Update (Güncelle) ve Delete (Sil) , işlemleri için gerekli
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ProductDetailCollectionName { get; set; }
        public string ProductImageCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
