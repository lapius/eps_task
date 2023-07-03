using EPS_task.Shared.Entities;

namespace EPS_task.Server.Repositories
{
    public interface IDiscountCodeRepository
    {
        public void AddRange(List<DiscountCode> codes);
        public List<DiscountCode> GetAll();
        public DiscountCode Get(int id);
        public DiscountCode GetByCode(string code);
        public UpdateDiscountResult Update(string code);
    }
}
