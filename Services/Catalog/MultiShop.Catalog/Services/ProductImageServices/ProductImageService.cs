using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageService:IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection; // field türettik .

        // (Fields) Nedir? Alanlar, bir sınıfın içinde veri depolamak için kullanılır. Bu veriler, sınıfın özelliklerini ve davranışlarını tanımlayan değişkenlerdir

        private readonly IMapper _mapper;
        private readonly IOptions<DatabaseSettings> _databaseSettings;


        // ProductImageService sınıfının Constructor ını oluşturduk aşağıda.
        public ProductImageService(IMapper mapper, IOptionsSnapshot<DatabaseSettings> databaseSettings)
        {
            // Bağlantı   client ile bağlantı kurdum veritabanına gittim
            // Database   database ile veritabanına eriştim
            // Tablo    colection ile istediğim tablo vs ulaştım

            _databaseSettings = databaseSettings;
            var client = new MongoClient(_databaseSettings.Value.ConnectionString); // connectionStringe bağlantı kuracağız burada
            var database = client.GetDatabase(_databaseSettings.Value.DatabaseName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.Value.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await   _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await  _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await  _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await  _productImageCollection.Find<ProductImage>(x => x.ProductImageId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImage>(updateProductImageDto);
            await  _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, values);
        }
    }
}
