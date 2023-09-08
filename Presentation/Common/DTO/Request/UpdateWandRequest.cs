using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Common.DTO.Request
{
    public class UpdateWandRequest
    {
        [MinLength(3)]
        [MaxLength(25)]
        public string? Core { get; set; }

        [MinLength(3)]
        [MaxLength(15)]
        public string? Wood { get; set; }

        [Range(6, 17)]
        [Column(TypeName = "decimal(4,2)")]
        public decimal? LengthInInches { get; set; }

        [MinLength(5)]
        [MaxLength(80)]
        public string? Owner { get; set; }

        [MinLength(30)]
        [MaxLength(150)]
        public string? Description { get; set; }
    }
}
