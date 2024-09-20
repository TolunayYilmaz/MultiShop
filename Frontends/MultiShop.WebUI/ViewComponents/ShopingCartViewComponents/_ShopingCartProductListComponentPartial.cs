using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ShopingCartViewComponents
{
    public class _ShopingCartProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }  
}
