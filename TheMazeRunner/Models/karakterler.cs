using System.ComponentModel.DataAnnotations;

namespace TheMazeRunner.Models
{
    public class karakterler
    {
        [Key]
        public int Id { get; set; }
        public int isim { get; set; }
        public int taraf { get; set; }
    }
}
