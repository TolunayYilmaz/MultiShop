using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entitites
{
    public class ProductDetail
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductDetailId { get; set; }//Attriubute Id olduğunu belirtir.
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }


        [BsonIgnore]
        public Product Product { get; set; }





    }
}
