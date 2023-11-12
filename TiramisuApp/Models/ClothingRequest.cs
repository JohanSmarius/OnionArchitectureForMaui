using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TiramisuApp.Models
{
    public class ClothingRequest
    {
        public int Id { get; set; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("desiredSize")]
        public string DesiredSize { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("requestedClothes")]
        public string RequestedClothes { get; set; }
    }

    [JsonSerializable(typeof(List<ClothingRequest>))]
    internal sealed partial class ClothingContext : JsonSerializerContext
    {

    }
}
