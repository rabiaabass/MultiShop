using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection; // field türettik .

        // (Fields) Nedir? Alanlar, bir sınıfın içinde veri depolamak için kullanılır. Bu veriler, sınıfın özelliklerini ve davranışlarını tanımlayan değişkenlerdir

        private readonly IMapper _mapper;


        // CategoryService sınıfının Constructor ını oluşturduk aşağıda.
        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {   
            // Bağlantı   client ile bağlantı kurdum veritabanına gittim
            // Database   database ile veritabanına eriştim
            // Tablo    colection ile istediğim tablo vs ulaştım

            var client = new MongoClient(_databaseSettings.ConnectionString); // connectionStringe bağlantı kuracağız burada
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x=> x.CategoryID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryID, values);
        }
    }
}
