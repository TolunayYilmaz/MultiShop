using MongoDB.Driver;
using MultiShop.Catalog.Entitites;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;


        public StatisticService(IMongoCollection<Product> productCollection, IMongoCollection<Category> categoryCollection, IMongoCollection<Brand> brandCollection, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionStrings);//Bağlantı
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//database
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollecitonName);//tablo
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollecitonName);//tablo
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollecitonName);//tablo
        }

        public long GetBrandCount()
        {
            return _brandCollection.CountDocuments(FilterDefinition<Brand>.Empty);
        }

        public long GetCategoryCount()
        {
            throw new NotImplementedException();
        }

        public decimal GetProductAvgPrice()
        {
            throw new NotImplementedException();
        }

        public long GetProductCount()
        {
            throw new NotImplementedException();
        }
    }
}
