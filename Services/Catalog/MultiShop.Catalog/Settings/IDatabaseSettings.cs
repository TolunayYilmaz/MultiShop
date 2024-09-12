namespace MultiShop.Catalog.Settings
{
    public interface IDatabaseSettings
    {
        public string CategoryCollecitonName { get; set; }
        public string ProductCollecitonName { get; set; }
        public string ProductDetailCollecitonName { get; set; }
        public string ProductImageCollecitonName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
