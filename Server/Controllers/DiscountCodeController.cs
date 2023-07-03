using EPS_task.Server.Data;
using EPS_task.Server.Sevices;
using EPS_task.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EPS_task.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IDiscountCodeService _discountCodeService;

        public DiscountCodeController(DataContext context, IDiscountCodeService discountCodeService)
        {
            _context = context;
            _discountCodeService = discountCodeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DiscountCode>>> GetDiscountCodes()
        {
            try
            {
                return _discountCodeService.GetDiscountCodes();
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
                var discountCode = _discountCodeService.GetSingleDiscountCode(id);
                if (discountCode == null)
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
        public async Task<ActionResult> CreateDiscountCode(GenerateCodeRequest codeRequest)
        {
            try
            {
                await _discountCodeService.GenerateDiscountCodes(codeRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while saving changes to the database: " + ex.Message);
            }
        }

        [HttpPut("{code}")]
        public async Task<ActionResult> UpdateDiscountCode(string code)
        {
            try
            {
                var result = _discountCodeService.UpdateDiscountCode(code); 
                if(result.Success == false)
                    return StatusCode(result.StatusCode, result.Message);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating changes to the database: " + ex.Message);
            }
        }
    }
}
