using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
