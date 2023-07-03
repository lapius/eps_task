using EPS_task.Server.Data;
using EPS_task.Server.Sevices;
using EPS_task.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EPS_task.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IGenerateCodeService _generateCodeService;

        public DiscountCodeController(DataContext context, IGenerateCodeService generateCodeService)
        {
            _context = context;
            _generateCodeService = generateCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiscountCode>>> GetDiscountCodes()
        {
            try
            {
                var discountCodes = await _context.DiscountCodes.ToListAsync();
                return discountCodes;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting data from database: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscountCode>> GetSingleDiscountCode(int id)
        {
            try
            {
                var discountCode = await _context.DiscountCodes.FindAsync(id);
                if(discountCode == null)
                {
                    return NotFound("Nothing found");
                }

                return discountCode;
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while getting data from database: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<DiscountCode>> CreateDiscountCode(GenerateCodeRequest codeRequest)
        {
            try
            {
                await _generateCodeService.GenerateDiscountCodes(codeRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving changes to the database: " + ex.Message);
            }
        }

        [HttpPut("{code}")]
        public async Task<ActionResult<DiscountCode>> UpdateDiscountCode(string code)
        {
            try
            {
                var discountCode = await _context.DiscountCodes.FirstOrDefaultAsync(c => c.Code == code);
                if (discountCode == null)
                {
                    return NotFound("Nothing found");
                }
                if (discountCode.IsUsed)
                {
                    return Conflict("The discount code is already used.");
                }
                discountCode.IsUsed = true;
                discountCode.UsedOn = DateTime.Now;

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating changes to the database: " + ex.Message);
            }
        }
    }
}
