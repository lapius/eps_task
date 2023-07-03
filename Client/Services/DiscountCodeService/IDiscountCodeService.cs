using EPS_task.Shared;

namespace EPS_task.Client.Services.DiscountCodeService
{
    public interface IDiscountCodeService
    {
        List<DiscountCode> DiscountCodes { get; set; }
        Task GetDiscountCodes();
        Task<string> CreateDiscountCode(GenerateCodeRequest code);
        Task<string> UpdateDiscountCode(string discountCode);
    }
}
