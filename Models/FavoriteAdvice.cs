using SolomonsAdviceWebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolomonsAdviceWebApp.Models
{
    public class FavoriteAdvice
    {
        [Key]
        [Required]
        [MaxLength(450)]
        public string UserId { get; set; }


        [Required]
        public int AdviceId { get; set; }


    }
}
