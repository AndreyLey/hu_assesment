using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Model
{
    public class SubmitedField
    {
        [BsonElement("field")]
        public Field Field { get; set; }

        [BsonElement("value")]
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
