using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Model
{
    public class Form
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("form_name")]
        [JsonProperty(PropertyName = "form_name")]
        public string Form_name { get; set; }

        [BsonElement("fields")]
        [JsonProperty(PropertyName = "fields")]
        public List<Field> Fields { get; set; }

        [BsonElement("submissions_ids")]
        [JsonProperty(PropertyName = "submissions_ids")]
        public List<string> Submissions_Ids { get; set; } = new List<string>();
    }
}
