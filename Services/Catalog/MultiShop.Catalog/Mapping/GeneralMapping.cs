using AutoMapper;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Entitites;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMApping:Profile
    {
        public GeneralMApping()
        {
            //Mapleme yapılarak ara katman oluşturuldu.
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto>().ReverseMap();
       
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();
            CreateMap<Product, ResultProductsWithCategory>().ReverseMap();


            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();     
            
            
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();
           
            
           CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();
           CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
           CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
           CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap(); 
            
           CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
           CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
           CreateMap<Feature, CreateFeatureDto>().ReverseMap();
           CreateMap<Feature, ResultFeatureDto>().ReverseMap(); 
            
           CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();
           CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
           CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
           CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            
            
           CreateMap<Brand, GetByIdBrandDto>().ReverseMap();
           CreateMap<Brand, UpdateBrandDto>().ReverseMap();
           CreateMap<Brand, CreateBrandDto>().ReverseMap();
           CreateMap<Brand, ResultBrandDto>().ReverseMap();

           CreateMap<About, GetByIdAboutDto>().ReverseMap();
           CreateMap<About, ResultAboutDto>().ReverseMap();
           CreateMap<About, CreateAboutDto>().ReverseMap();
           CreateMap<About, UpdateAboutDto>().ReverseMap(); 
            
           CreateMap<Contact, GetByIdContactDto>().ReverseMap();
           CreateMap<Contact, ResultContactDto>().ReverseMap();
           CreateMap<Contact, CreateContactDto>().ReverseMap();
           CreateMap<Contact, UpdateContactDto>().ReverseMap();






        }
    }
}
