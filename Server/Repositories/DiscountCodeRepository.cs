using EPS_task.Server.Data;
using EPS_task.Shared.Entities;

namespace EPS_task.Server.Repositories
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly DataContext _context;

        public DiscountCodeRepository(DataContext context)
        {
            _context = context;
        }

        public void AddRange(List<DiscountCode> codes)
        {
            List<Shared.Models.DiscountCode> modelDiscountCodes = new List<Shared.Models.DiscountCode>();
            foreach (var code in codes)
            {
                modelDiscountCodes.Add(MapEntityToModel(code));
            }

            _context.DiscountCodes.AddRange(modelDiscountCodes);
        }

        public DiscountCode Get(int id)
        {
            var result = _context.DiscountCodes.FirstOrDefault(x => x.Id == id);
            return MapModelToEntity(result);
        }

        public List<DiscountCode> GetAll()
        {
            List<Shared.Models.DiscountCode> modelDiscountCodes = _context.DiscountCodes.ToList();
            List<DiscountCode> discountCodes = new List<DiscountCode>();
            foreach (var code in modelDiscountCodes)
            {
                discountCodes.Add(MapModelToEntity(code));
            }

            return discountCodes;
        }

        public DiscountCode GetByCode(string code)
        {
            var result = _context.DiscountCodes.FirstOrDefault(c => c.Code == code);
            return MapModelToEntity(result);
        }

        public UpdateDiscountResult Update(string code)
        {
            var result = _context.DiscountCodes.FirstOrDefault(c => c.Code == code);
            if (result == null)
            {
                return new UpdateDiscountResult { Success = false, StatusCode = 404, Message = "Nothing found" };
            }
            if (result.IsUsed)
            {
                return new UpdateDiscountResult { Success = false, StatusCode = 409, Message = "The discount code is already used." };
            }

            result.IsUsed = true;
            result.UsedOn = DateTime.Now;

            _context.DiscountCodes.Update(result);
            return new UpdateDiscountResult { Success = true };
        }

        private Shared.Models.DiscountCode MapEntityToModel(DiscountCode code)
        {
            return new Shared.Models.DiscountCode
            {
                Code = code.Code,
                CreatedOn = code.CreatedOn,
                Id = code.Id,
                IsUsed = code.IsUsed,
                UsedOn = code.UsedOn
            };
        }

        private DiscountCode MapModelToEntity(Shared.Models.DiscountCode code)
        {
            return new DiscountCode
            {
                Code = code.Code,
                CreatedOn = code.CreatedOn,
                Id = code.Id,
                IsUsed = code.IsUsed,
                UsedOn = code.UsedOn
            };
        }
    }
}
