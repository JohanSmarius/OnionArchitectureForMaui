using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class ClothingRequest
    {
        private string desiredSize;

        public int Id { get; set; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("desiredSize")]
        public string DesiredSize {
            get => desiredSize;
            set 
            {
                int size;
                if (int.TryParse(value, out size))
                {
                    if (size >= 50 && size <= 168)
                    {
                        desiredSize = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(DesiredSize));
                    }
                }
                else
                {
                    desiredSize = value;
                }
                
            } 
        }

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
