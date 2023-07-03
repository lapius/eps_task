using EPS_task.Shared;

namespace EPS_task.Server.Sevices
{
    public interface IGenerateCodeService
    {
        Task GenerateDiscountCodes(GenerateCodeRequest codeRequest);
    }
}
