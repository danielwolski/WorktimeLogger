using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FunnyWebRazor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Nazwa kategorii")]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "Kolejność wyświetlania powinna być w granicach 1-100")]
        [DisplayName("Kolejność wyświetlania")]
        public int DisplayOrder { get; set; }
    }
}
