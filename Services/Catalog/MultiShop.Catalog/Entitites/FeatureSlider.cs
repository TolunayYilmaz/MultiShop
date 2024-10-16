using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MultiShop.Catalog.Entitites
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureSliderId { get; set; }//Attriubute Id olduğunu belirtir.
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
    }
}
