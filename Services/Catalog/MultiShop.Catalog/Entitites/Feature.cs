using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entitites
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }//Attriubute Id olduğunu belirtir.
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
