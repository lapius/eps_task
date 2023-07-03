using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS_task.Shared
{
    public class GenerateCodeRequest
    {
        [Required]
        public ushort Count { get; set; }
        [Required]
        public byte Length { get; set; }
    }
}
