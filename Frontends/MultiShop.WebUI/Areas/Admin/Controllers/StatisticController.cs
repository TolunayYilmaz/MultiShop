using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStaticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStaticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStaticService, ICommentService commentService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStaticService = userStaticService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            var getBrandCount = await _catalogStatisticService.GetBrandCount();
            var getProductCount = await _catalogStatisticService.GetProductCount();
            var getCategoryCount = await _catalogStatisticService.GetCategoryCount();
            var getMaxProductPriceName = await _catalogStatisticService.GetMaxProductPriceName();
            var getMinProductPriceName = await _catalogStatisticService.GetMinProductPriceName();
           

            var getUserCount = await _userStaticService.GetUserCount();

            var getDiscountCouponCount = await _discountStatisticService.GetDiscountCouponCount();

            var getActiveCommandCount = await _commentService.GetActiveCommandCount();
            var getPassiveCommandCount = await _commentService.GetPassiveCommandCount();
            var getTotalCommandCount = await _commentService.GetTotalCommandCount();

            var getTotalMessageCount = await _messageStatisticService.GetTotalMessageCount();


            ViewBag.getBrandCount=getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxProductPriceName = getMaxProductPriceName;
            ViewBag.getMinProductPriceName = getMinProductPriceName;
            ViewBag.getProductAvgPrice = 55;

            ViewBag.getUserCount = getUserCount;

            ViewBag.getActiveCommandCount = getActiveCommandCount;
            ViewBag.getPassiveCommandCount = getPassiveCommandCount;    
            ViewBag.getTotalCommandCount = getTotalCommandCount;
            ViewBag.getDiscountCouponCount = getDiscountCouponCount;

            ViewBag.getTotalMessageCount = getTotalMessageCount;

            return View();
        }
    }
}
