using Form_Builder.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Form_Builder.DB
{
    public class Submission
    {

        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public List<SubmitedField> SubmitedFields { get; set; }
    }
}