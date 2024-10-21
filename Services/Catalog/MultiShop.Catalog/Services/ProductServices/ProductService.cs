using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entitites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;//mongo db bağlantı
        //Product sınıfı Crud İşlemleri ve Mapleme
        public ProductService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client=new MongoClient(_databaseSettings.ConnectionStrings);//Bağlantı
            var database=client.GetDatabase(_databaseSettings.DatabaseName);//database
            _productCollection=database.GetCollection<Product>(_databaseSettings.ProductCollecitonName);//tablo
            _categoryCollection=database.GetCollection<Category>(_databaseSettings.CategoryCollecitonName);//tablo
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value=_mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
          await _productCollection.DeleteOneAsync(x=>x.CategoryId==id);  
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values= await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
           var value =await _productCollection.Find<Product>(x=>x.ProductId==id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultProductsWithCategory>> GetProductsWithCategoryAsync()
        {
           var values = await _productCollection.Find(x=>true).ToListAsync();
            foreach (var product in values)
            {
                product.Category= await _categoryCollection.Find<Category>(x => x.CategoryId==product.CategoryId).FirstAsync();

            }
            return _mapper.Map<List<ResultProductsWithCategory>>(values);   
        }

        public async Task<List<ResultProductsWithCategory>> GetProductsWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await _productCollection.Find(x => x.CategoryId==CategoryId).ToListAsync();
            foreach (var product in values)
            {
                product.Category = await _categoryCollection.Find<Category>(x => x.CategoryId == product.CategoryId).FirstAsync();

            }
            return _mapper.Map<List<ResultProductsWithCategory>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value=_mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId==updateProductDto.ProductId,value);
        }
    }
}
