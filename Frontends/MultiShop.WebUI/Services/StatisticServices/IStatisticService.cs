namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        long GetCategoryCount();
        long GetProductCount();
        long GetBrandCount();
        decimal GetProductAvgPrice();

    }
}
