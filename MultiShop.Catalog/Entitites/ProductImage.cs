using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entitites
{
    public class ProductImage
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductImageId { get; set; }//Attriubute Id olduğunu belirtir.
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public int ProductId { get; set; }
        
        [BsonIgnore]
        public Product Product { get; set; }




    }
}
