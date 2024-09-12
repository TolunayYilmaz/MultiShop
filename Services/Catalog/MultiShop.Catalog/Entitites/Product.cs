using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entitites
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }//Attriubute Id olduğunu belirtir.
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl{ get; set; }
        public string ProductDescription{ get; set; }
        public string CategoryId{ get; set; }

        [BsonIgnore]
        public Category Category{ get; set; }


    }
}
