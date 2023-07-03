using EPS_task.Shared.Entities;

namespace EPS_task.Server.Sevices
{
    public interface IDiscountCodeService
    {
        Task GenerateDiscountCodes(GenerateCodeRequest codeRequest);
        List<DiscountCode> GetDiscountCodes();
        DiscountCode GetSingleDiscountCode(int id);
        UpdateDiscountResult UpdateDiscountCode(string code);
    }
}
