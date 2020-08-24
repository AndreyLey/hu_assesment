using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Form_Builder.Model
{

    public class Field
    {
        [BsonElement ("label")]
        [JsonProperty ("label")]
        public string Label { get; set; }

        [BsonElement("input_name")]
        [JsonProperty ("input_name")]
        public string Input_Name { get; set; }

        [BsonElement("input_type")]
        [JsonProperty("input_type")]
        public string Input_Type { get; set; }

    }
}
