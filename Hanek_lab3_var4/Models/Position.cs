using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Lab3.Models
{
    public partial class Position
    {
        public string Name { get; set; } = null!;
    }
}
