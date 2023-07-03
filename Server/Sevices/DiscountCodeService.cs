using EPS_task.Server.Data;
using EPS_task.Server.Repositories;
using EPS_task.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EPS_task.Server.Sevices
{
    public class DiscountCodeService : IDiscountCodeService
    {
        private readonly DataContext _context;
        private readonly IDiscountCodeRepository _discountCodeRepository;

        public DiscountCodeService(DataContext context, IDiscountCodeRepository discountCodeRepository)
        {
            _context = context;
            _discountCodeRepository = discountCodeRepository;
        }


        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        public async Task GenerateDiscountCodes(GenerateCodeRequest codeRequest)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var codes = new List<DiscountCode>(codeRequest.Count);

            using (_context)
            {
                while (codes.Count < codeRequest.Count)
                {
                    var buffer = new byte[codeRequest.Length];

                    Rng.GetBytes(buffer);

                    var result = new string(buffer.Select(b => chars[b % chars.Length]).ToArray());

                    var existingCode = await _context.DiscountCodes.FirstOrDefaultAsync(c => c.Code == result);
                    if (existingCode == null)
                    {
                        var discountCode = new DiscountCode { Code = result, CreatedOn = DateTime.Now };
                        codes.Add(discountCode);
                    }
                }

                _discountCodeRepository.AddRange(codes);
                await _context.SaveChangesAsync();
            }
        }

        public List<DiscountCode> GetDiscountCodes()
        {
            return _discountCodeRepository.GetAll();
        }

        
        public DiscountCode GetSingleDiscountCode(int id)
        {
            return _discountCodeRepository.Get(id);
        }


        public UpdateDiscountResult UpdateDiscountCode(string code)
        {
            _discountCodeRepository.Update(code);
            _context.SaveChangesAsync();
            return new UpdateDiscountResult { Success = true };
        }
    }
}
