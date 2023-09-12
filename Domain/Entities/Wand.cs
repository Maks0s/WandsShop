using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Wand
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Core { get; set; } = "";
        [Required]
        [MaxLength(15)]
        public string Wood { get; set; } = "";
        [Required]
        [Range(6, 17)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal LengthInInches { get; set; }
        [MaxLength(80)]
        public string? Owner { get; set; }
        [Required]
        [MaxLength(150)]
        [MinLength(30)]
        public string Description { get; set; } = "";

    }
}
