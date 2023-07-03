using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPS_task.Shared
{
    public class GenerateRequestPage
    {
        [Range(0, ushort.MaxValue, ErrorMessage = "Value must be 0 or a positive number.")]
        public int Count { get; set; }
        [Range(7, 8, ErrorMessage = "Value must be 7 or 8 number.")]
        public byte Length { get; set; }
    }
}
