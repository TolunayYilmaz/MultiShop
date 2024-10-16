using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entitites
{
    public class Category
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }//Attriubute Id olduğunu belirtir.
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }


    } 
}
