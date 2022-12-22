using Lab4.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.Models
{
    public sealed class Position : ModelBase
    {
        public string Name { get; set; } = null!;
    }
}
