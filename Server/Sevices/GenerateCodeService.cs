using EPS_task.Server.Data;
using EPS_task.Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace EPS_task.Server.Sevices
{
    public class GenerateCodeService : IGenerateCodeService
    {
        private readonly DataContext _context;

        public GenerateCodeService(DataContext context)
        {
            _context = context;
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

                _context.DiscountCodes.AddRange(codes);
                await _context.SaveChangesAsync();
            }

        }
    }
}
