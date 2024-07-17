using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolomonsAdviceWebApp.Models.Entities
{

    [Table("Advices")]
    public class Advice
    {

        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        public int Chapter { get; set; }

        [Required]
        public int Verse { get; set; }


        [Required]
        public string Book { get; set; }
    }
}
