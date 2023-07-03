using System.ComponentModel.DataAnnotations;

namespace EPS_task.Shared.Entities
{
    public class GenerateCodeRequest
    {
        [Required]
        public ushort Count { get; set; }
        [Required]
        public byte Length { get; set; }
    }
}
