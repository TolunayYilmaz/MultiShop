namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollecitonName { get; set; }
        public string ProductCollecitonName { get; set; }
        public string ProductDetailCollecitonName { get; set; }
        public string ProductImageCollecitonName { get; set; }
        public string FeatureSliderCollecitonName { get; set; }
        public string SpecialOfferCollecitonName { get; set; }
        public string OfferDiscountCollecitonName { get; set; }
        public string FeatureCollecitonName { get; set; }
        public string BrandCollecitonName { get; set; }
        public string AboutCollecitonName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
