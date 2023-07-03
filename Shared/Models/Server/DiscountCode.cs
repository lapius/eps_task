using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EPS_task.Shared
{
    public class DiscountCode
    {
        public int Id { get; set; }

        [MaxLength(8)]
        public string Code { get; set; } = String.Empty;

        public bool IsUsed { get; set; } = false;

        public DateTime CreatedOn { get; set; }

        public DateTime UsedOn { get; set; }
    }
}
