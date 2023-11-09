﻿using System;
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

        public Gender Gender { get; set; }

        public string DesiredSize { get; set; }

        public int Age { get; set; }

        public string RequestedClothes { get; set; }
    }

    [JsonSerializable(typeof(List<ClothingRequest>))]
    internal sealed partial class ClothingContext : JsonSerializerContext
    {

    }
}
