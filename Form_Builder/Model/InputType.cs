using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Form_Builder.Model
{
    public class InputType
    {
        [JsonIgnore]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonProperty(PropertyName ="type_name")]
        public string Name { get; set; }

        public InputType() { }
        public InputType(string name)
        {
            Name = name;
        }
    }
}
