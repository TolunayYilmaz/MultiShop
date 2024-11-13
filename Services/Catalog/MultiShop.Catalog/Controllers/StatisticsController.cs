using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount() 
        {
            var value= _statisticService.GetBrandCount();
            return Ok(value);
        }
        [HttpGet("GetCategoryCount")]
        public IActionResult GetCategoryCount() 
        {
            var value= _statisticService.GetCategoryCount(); 
            return Ok(value);
        }
        [HttpGet("GetProductCount")]
        public IActionResult GetProductCount() 
        {
            var value= _statisticService.GetProductCount();
            return Ok(value);
        } 
        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice() 
        {
            var value= await _statisticService.GetProductAvgPrice();
            return Ok(value);
        }
        [HttpGet("GetMinProductPriceName")]
        public async Task<IActionResult> GetMinProductPriceName() 
        {
            var value= await _statisticService.GetMinProductPriceName();
            return Ok(value);
        }
        [HttpGet("GetMaxProductPriceName")]
        public async Task<IActionResult> GetMaxProductPriceName() 
        {
            var value= await _statisticService.GetMaxProductPriceName();
            return Ok(value);
        }
    }
}
