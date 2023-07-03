using System.ComponentModel.DataAnnotations;

namespace EPS_task.Shared.Models
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
